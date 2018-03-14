﻿using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using IdentityServerHost.Interface;
using IdentityServerHost.Model;
using IdentityServerHost.Repository;
using IdentityServerHost.Store;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MongoDB.Bson.Serialization;
using System.Collections.Generic;
namespace IdentityServerHost.Extension
{
    public static class IdentityServerBuilderExtensions
    {
        public static IIdentityServerBuilder AddMongoRepository(this IIdentityServerBuilder builder)
        {
            builder.Services.AddTransient<IRepository, MongoRepository>();

            return builder;
        }


        /// <summary>
        /// Configure ClientId / Secrets
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="configurationOption"></param>
        /// <returns></returns>
        public static IIdentityServerBuilder AddClients(this IIdentityServerBuilder builder)
        {
            builder.Services.AddTransient<IClientStore, CustomClientStore>();
            builder.Services.AddTransient<ICorsPolicyService, InMemoryCorsPolicyService>();

            return builder;
        }


        /// <summary>
        /// Configure API  &  Resources
        /// Note: Api's have also to be configured for clients as part of allowed scope for a given clientID 
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IIdentityServerBuilder AddIdentityApiResources(this IIdentityServerBuilder builder)
        {
            builder.Services.AddTransient<IResourceStore, CustomResourceStore>();

            return builder;
        }

        /// <summary>
        /// Configure Grants
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public static IIdentityServerBuilder AddPersistedGrants(this IIdentityServerBuilder builder)
        {
            builder.Services.TryAddSingleton<IPersistedGrantStore, CustomPersistedGrantStore>();

            return builder;
        }

    }
}
