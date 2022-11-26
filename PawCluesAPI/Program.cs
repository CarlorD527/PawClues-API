using BusinessLogic.Data;
using BusinessLogic.Logic;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using PawCluesAPI.Dtos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PawClawsDbContext>(opt => {
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddTransient<IMascotaRepository, MascotaRepository>();
builder.Services.AddTransient<IRazaRepository, RazaRepository>();
builder.Services.AddTransient<IUsuarioRepository,UsuarioRepository>();
builder.Services.AddTransient<IDistritoRepository, DistritoRepository>();
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

//Ejecucion de migraciones
using (var scope = app.Services.CreateScope())
{

    var loggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();
    try
    {
        var dataContext = scope.ServiceProvider.GetRequiredService<PawClawsDbContext>();
        await dataContext.Database.MigrateAsync();
        await PawCluesDbContextData.cargarDataAsync(dataContext, loggerFactory);
    }
    catch (Exception e)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(e, "Errores en el proceso de migración");

        throw;
    }
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("corsapp");
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
