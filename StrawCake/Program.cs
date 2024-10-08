using Hangfire;
using Hangfire.Console;
using Hangfire.Dashboard;
using Hangfire.Raven.Storage;
using StrawCake.Dominio.RavenDB;
using StrawCake.Dominio.Servicos;
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ServicoBolo>();

// URL_RAVEN_DOCKER
//URL_RAVEN_CLIENT
var conexaoDoHangfire = Environment.GetEnvironmentVariable(ConstantesDoRaven.URL_RAVEN_DOCKER)
        ?? throw new Exception($"Variável de Ambiente [URL_CLIENT_PESSOAL] não configurada, por favor informar a conexão com o banco!");

var certificado = new X509Certificate2(Environment.GetEnvironmentVariable(ConstantesDoRaven.CERTIFICADO));

builder.Services.AddHangfire(op =>
{
    conexaoDoHangfire
    .Split(',')
    .ToList()
    .ForEach(url =>
    {
            op.UseRavenStorage(url, ConstantesDoRaven.NOME_BASE_HANGFIRE);
        //if (certificado != null)
        //{
        //    op.UseRavenStorage(url, ConstantesDoRaven.NOME_BASE_HANGFIRE, certificado);
        //}
        //else
        //{
        //}

        op.UseConsole();
        op.UseFilter(new AutomaticRetryAttribute { Attempts = 3 });
    });
});

builder.Services.AddHangfireServer();

var app = builder.Build();
app.UseHangfireDashboard(options: new DashboardOptions
{
    Authorization = new[] { new HangfireAuthorizationFilter() }
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
var client = new BackgroundJobServer();

public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
{
    public bool Authorize(DashboardContext context)
    {
        // var userIdentity = context.GetHttpContext().User.Identity;
        return true;
    }
}
