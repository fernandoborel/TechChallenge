using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TechChallenge.Domain.Interfaces.Repositories;
using TechChallenge.Domain.Interfaces.Services;
using TechChallenge.Domain.Services;
using TechChallenge.Infra.Data.Context;
using TechChallenge.Infra.Data.Repositories;

namespace TechChallenge.UnitTests;

public class Setup : Xunit.Di.Setup
{
    protected override void Configure()
    {
        ConfigureAppConfiguration((hostingContext, config) =>
        {
            #region Ativar a Injeção de dependência no XUnit

            bool reloadOnChange = hostingContext.Configuration.GetValue("hostBuilder:reloadConfigOnChange", true);
            if (hostingContext.HostingEnvironment.IsDevelopment())
                config.AddUserSecrets<Setup>(true, reloadOnChange);

            #endregion
        });

        ConfigureServices((context, services) =>
        {
            #region Localizar o arquivo appsettings.json

            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            #endregion

            #region Capturar a connectionstring do arquivo appsettings.json

            var root = configurationBuilder.Build();
            var connectionString = root.GetSection("ConnectionStrings").GetSection("TechChallengeDB").Value;

            #endregion

            #region Fazendo as injeção de dependência do projeto de teste

            //Injetando a connection string na classe SqlServerContext
            services.AddDbContext<TechChallengeDbContext>(options => options.UseSqlServer(connectionString));

            //Injetando a classe UsuarioRepository na interface IUsuarioRepository
            services.AddTransient<IContatoRepository, ContatoRepository>();

            //Injetando a classe UsuarioDomainService na interface IUsuarioDomainService
            services.AddTransient<IContatoDomainService, ContatoDomainService>();

            #endregion
        });
    }
}