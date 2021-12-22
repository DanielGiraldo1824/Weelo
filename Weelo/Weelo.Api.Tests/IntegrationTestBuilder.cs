using System;
using System.Collections.Generic;
using Weelo.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.EntityFrameworkCore;
using Weelo.Infrastructure.Context;
using Microsoft.Extensions.DependencyInjection;
using Weelo.Domain.Ports;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Weelo.Api.Tests;

class IntegrationTestBuilder : WebApplicationFactory<Program>
{

    readonly Guid _id;

    public Guid Id => this._id;

    public IntegrationTestBuilder()
    {
        _id = Guid.NewGuid();
    }

    protected override IHost CreateHost(IHostBuilder builder)
    {
        var rootDb = new InMemoryDatabaseRoot();

        builder.ConfigureServices(services =>
        {
            services.RemoveAll(typeof(DbContextOptions<PersistenceContext>));
            services.AddDbContext<PersistenceContext>(options =>
                    options.UseInMemoryDatabase("Testing", rootDb));

        });

        SeedDatabase(builder.Build().Services);

        return base.CreateHost(builder);


    }

    void SeedDatabase(IServiceProvider services)
    {
        var Properties = new List<Property>
            {
                new Property
                {
                    Id = _id, Name = "Karla", Address = "Av 43 # 34-345", IdOwner = Guid.Parse("190BE6BC-66DA-4B20-E20D-08D9C4168C98"),
                    Price = 23345435, CodeInternal = 545,Year = 2018
                }
            };

        using (var scope = services.CreateScope())
        {
            var personRepo = scope.ServiceProvider.GetRequiredService<IGenericRepository<Property>>();
            foreach (var property in Properties)
            {
                personRepo.AddAsync(property).Wait();
            }
        }
    }
}