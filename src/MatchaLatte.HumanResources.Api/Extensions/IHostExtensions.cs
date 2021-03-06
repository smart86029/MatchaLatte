﻿using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MatchaLatte.HumanResources.Api.Extensions
{
    internal static class IHostExtensions
    {
        internal static IHost MigrateDbContext<TContext>(this IHost host, Action<TContext> seeder) where TContext : DbContext
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<TContext>();
                var env = services.GetService<IWebHostEnvironment>();

                try
                {
                    context.Database.Migrate();
                    if (env.IsDevelopment())
                        seeder(context);
                }
                catch (Exception)
                {
                }
            }

            return host;
        }
    }
}