using Microsoft.EntityFrameworkCore;
using TechChallenge.Application.Interfaces;
using TechChallenge.Application.Mappings;
using TechChallenge.Application.Services;
using TechChallenge.Domain.Interfaces.Repositories;
using TechChallenge.Domain.Interfaces.Services;
using TechChallenge.Domain.Services;
using TechChallenge.Infra.Data.Context;
using TechChallenge.Infra.Data.Repositories;

namespace TechChallenge.Api;

public static class Setup
{
    public static void AddRegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IContatoAppService, ContatoAppService>();
        builder.Services.AddScoped<IContatoDomainService, ContatoDomainService>();
        builder.Services.AddScoped<IContatoRepository, ContatoRepository>();
    }

    public static void AddEntityFrameworkServices(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("TechChallengeDB");
        builder.Services.AddDbContext<TechChallengeDbContext>(options =>
            options.UseSqlServer(connectionString));
    }

    public static void AddAutomapperServices(this WebApplicationBuilder builder)
     =>   builder.Services.AddAutoMapper(typeof(DtoToEntity));
}