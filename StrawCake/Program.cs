using Hangfire;
using Hangfire.Raven.Storage;
using StrawCake.Dominio.Servicos;
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ServicoBolo>();

var conexaoDoHangfire = Environment.GetEnvironmentVariable("URL_CLIENT_PESSOAL")
        ?? throw new Exception($"Variável de Ambiente [URL_CLIENT_PESSOAL] não configurada, por favor informar a conexão com o banco!");

var certificado = new X509Certificate2(Environment.GetEnvironmentVariable("CERTIFICADO_PESSOAL"));

builder.Services.AddHangfire(op =>
{
    conexaoDoHangfire
    .Split(',')
    .ToList()
    .ForEach(url =>
    {
        if (certificado != null)
        {
            op.UseRavenStorage(url, "HangfireDB", certificado);
        }
        else
        {
            op.UseRavenStorage(url, "HangfireDB");
        }
    });
});
builder.Services.AddHangfireServer();



var app = builder.Build();
app.UseHangfireDashboard();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
var client = new BackgroundJobServer();
