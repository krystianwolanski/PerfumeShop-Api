using FluentValidation;
using FragranceShopApi.Authorization.PerfumeReviewAuthorization;
using Data.Entities;
using FragranceShopApi.Services.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FragranceShopApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private static Type[] _exportedTypesFromCurrentAssembly = Assembly.GetExecutingAssembly().GetExportedTypes();

        public static IServiceCollection AddConventionalServices(
            this IServiceCollection services )
        {
            var transientServiceInterfaceType = typeof(ITransientService);
            var singletonServiceInterfaceType = typeof(ISingletonService);
            var scopedServiceInterfaceType = typeof(IScopedService);

            var types = _exportedTypesFromCurrentAssembly
                .Where(t => t.IsClass && !t.IsAbstract)
                .Select(t => new
                {
                    Service = t.GetInterface($"I{t.Name}"),
                    Implemenation = t
                })
                .Where(t => t.Service != null);

            foreach (var type in types)
            {
                if (scopedServiceInterfaceType.IsAssignableFrom(type.Service))
                {
                    services.AddScoped(type.Service, type.Implemenation);
                }
                else if (transientServiceInterfaceType.IsAssignableFrom(type.Service))
                {
                    services.AddTransient(type.Service, type.Implemenation);
                }
                else if (singletonServiceInterfaceType.IsAssignableFrom(type.Service))
                {
                    services.AddSingleton(type.Service, type.Implemenation);
                }
            }

            return services;
        }

        public static IServiceCollection AddAuthorizationServices(this IServiceCollection services)
        {

            var authorizationHandlers = _exportedTypesFromCurrentAssembly
                .Where(t => t.IsAssignableTo(typeof(IAuthorizationHandler)) && !t.IsAbstract && !t.IsInterface);

            foreach(var authorizationHandler in authorizationHandlers)
            {
                services.AddScoped(typeof(IAuthorizationHandler), authorizationHandler);
            }
;
            return services;
        }

        public static IServiceCollection AddValidatorServices(this IServiceCollection services)
        {
            var validators = _exportedTypesFromCurrentAssembly
                .Where(t => t.IsAssignableTo(typeof(IValidator)) 
                    && !t.IsAbstract 
                    && !t.IsInterface 
                    && !t.IsGenericType)
                .Select(t => new
                {
                    ValidateType = t.GetInterfaces()
                        .First(i => i.GetGenericTypeDefinition() == typeof(IValidator<>)),
                    Validator = t
                });

            foreach (var validator in validators)
            {
                services.AddScoped(validator.ValidateType, validator.Validator);
            }

            return services;
        }
    }    
}
