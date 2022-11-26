using AutoMapper;
using BusinessLogic.Logic;
using Core.Entities;
using Core.Interfaces;
using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PawCluesAPI.Dtos;
using System.Web.Helpers;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System.Collections;
using System.Text.Json.Nodes;
using Newtonsoft.Json;

namespace PawCluesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotaController : ControllerBase
    {
        private readonly IMascotaRepository _mascotaRepository;

        private readonly IMapper _mapper;
        public MascotaController(IMascotaRepository mascotaRepository, IMapper mapper)
        {
            _mascotaRepository = mascotaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Mascota>>> getMascotas() {

            var mascotas = await _mascotaRepository.GetMascotasAsync();

            return Ok(mascotas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Mascota>> getMascota(int id) { 
        
               return await _mascotaRepository.getMascotaByIdAsync(id);
        }
        [HttpPost]
        public async Task<ActionResult> postMascota(IFormFile file, string colorPelo, int Años, int Meses, int RazaId, bool encontrada, int usuarioId) {

            Mascota mascota = new Mascota();

            Stream image = file.OpenReadStream();
            string urlimagen = await SubirStorage(image, file.FileName);

            mascota.Imagen = urlimagen;
            mascota.ColorPelo = colorPelo;
            mascota.Años = Años;
            mascota.Meses = Meses;
            mascota.RazaId = RazaId;
            mascota.Encontrada = encontrada;
            mascota.UsuarioId = usuarioId;
                
            await _mascotaRepository.PostMascotaAsync(mascota);




            return Ok(mascota);
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<string> SubirStorage(Stream archivo, string nombre) {

            string email = "carlord5272009@gmail.com";
            string clave = "x5x2x7";
            string ruta = "pawclues.appspot.com";
            string api_key = "AIzaSyASaVr8WgvFakuWSct9f0abZvKTeo70qgY";

            var auth = new FirebaseAuthProvider(new FirebaseConfig(api_key));

            var a = await auth.SignInWithEmailAndPasswordAsync(email, clave);

            var cancellation = new CancellationTokenSource();
            var task = new FirebaseStorage(
            ruta,
            new FirebaseStorageOptions
            {

                AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                ThrowOnCancel = true
            })
                .Child("Fotos_Mascotas")
                .Child(nombre)
                .PutAsync(archivo, cancellation.Token);


            var downloadUrl = await task;

            return downloadUrl;
        }
        [HttpPost("postImageAzure")]
        public async Task<string> SubirImagenAzure(string urlImagen) {

            //Computer Vision subscription key and endpoint
             string subscriptionKey = "0fa7d4e4255241d2875b22dfa5e17e07";
             string endpoint = "https://tcmmascotas.cognitiveservices.azure.com/";
             string URL_IMAGEN = urlImagen;

            ComputerVisionClient client = Authenticate(endpoint, subscriptionKey);

           var resultados =  AnalyzeImageUrl(client, URL_IMAGEN);

            return await resultados;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public static ComputerVisionClient Authenticate(string endpoint, string key)
        {
            ComputerVisionClient client =
              new ComputerVisionClient(new ApiKeyServiceClientCredentials(key))
              { Endpoint = endpoint };
            return client;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<string> AnalyzeImageUrl(ComputerVisionClient client, string imageUrl) {

            Dictionary<string, Double> resultadosdic = new Dictionary<string, Double>();


            List<VisualFeatureTypes?> features = new List<VisualFeatureTypes?>()
            {
                VisualFeatureTypes.Tags
            };

            ImageAnalysis results = await client.AnalyzeImageAsync(imageUrl, visualFeatures: features);

            foreach (var tag in results.Tags) {

                resultadosdic.Add(tag.Name, tag.Confidence);
            }

            return JsonConvert.SerializeObject(resultadosdic);
        }

        //[HttpDelete]
        //public async Task<ActionResult> deleteMascota(int id) {

        //     await _mascotaRepository.DeleteMascotaAsync(id);
        //    return Ok();
        //        }
    }
}
