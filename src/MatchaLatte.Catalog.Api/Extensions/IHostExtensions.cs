﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MatchaLatte.Catalog.Api.Extensions
{
    internal static class IHostExtensions
    {
        internal static IHost MigrateDbContext<TContext>(this IHost host, Action<TContext, IServiceProvider> seeder) where TContext : DbContext
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<TContext>();

                try
                {
                    context.Database.Migrate();
                    seeder(context, services);
                }
                catch (Exception)
                {
                }
            }

            return host;
        }
    }
}