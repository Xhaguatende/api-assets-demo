// -------------------------------------------------------------------------------------
//  <copyright file="ServiceCollectionExtensions.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace AssetsDemo.Backend.Infrastructure.Extensions;

using Application.Repositories;
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Repositories;
using Settings;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterInfrastructure(this IServiceCollection services)
    {
        services.AddRepositories();

        return services;
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddDbContext<AssetsContext>(
            (provider, options) =>
            {
                var settings = provider.GetRequiredService<IOptions<SqlServerSettings>>().Value;

                if (settings.UseInMemory)
                {
                    options.UseInMemoryDatabase("InMemoryDb");
                }
                else
                {
                    options.UseSqlServer(settings.ConnectionString);
                }
            });

        services.AddScoped<IAssetRepository, AssetRepository>();
        services.AddScoped<IAssetTypeRepository, AssetTypeRepository>();
    }
}