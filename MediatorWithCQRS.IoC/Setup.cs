using MediatorWithCQRS.Application;
using MediatorWithCQRS.Data.Repositories;
using MediatorWithCQRS.Domain.interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MediatorWithCQRS.IoC
{
    public static class Setup
    {
        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddMediatR(AppDomain.CurrentDomain.Load("MediatorWithCQRS.Application"));

            services.AddAutoMapper(typeof(MappingSetup));

            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
