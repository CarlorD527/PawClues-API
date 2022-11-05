using Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BusinessLogic.Data
{
    public class PawCluesDbContextData
    {
        public static async Task cargarDataAsync(PawClawsDbContext context, ILoggerFactory loggerFactory) {

			try
			{
				if (!context.Raza.Any()) {

					var razaData = File.ReadAllText("../BusinessLogic/CargarData/razas.json");
             
					 var razas = JsonSerializer.Deserialize<List<Raza>>(razaData);

                        foreach (var raza in razas)
                        {
                            context.Raza.Add(raza);
                        }
					await context.SaveChangesAsync();
						
				}
			}	
			catch (Exception e)
			{

				throw;
			}
        }
    }
}
