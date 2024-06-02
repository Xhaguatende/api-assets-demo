// -------------------------------------------------------------------------------------
//  <copyright file="ServiceCollectionExtensions.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace AssetsDemo.Backend.Application.Extensions;

using AssetsDemo.Backend.Application;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterApplication(this IServiceCollection services)
    {
        services.AddMediatR(
            cfg => { cfg.RegisterServicesFromAssembly(typeof(IAssemblyReference).Assembly); });

        return services;
    }
}