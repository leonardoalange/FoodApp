using FoodApp.Infra.Context;
using FoodApp.Web;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace FoodApp.IntegrationTest
{
   public abstract class IntegrationTestBase
    {
        protected readonly HttpClient _client;

        public IntegrationTestBase()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                   {
                       services.AddDbContext<MainContext>(options =>
                       {
                           options.UseInMemoryDatabase(databaseName: "FoodAppTest");
                       });
                   });
                });
            _client = appFactory.CreateClient();
            _client.BaseAddress = new System.Uri("https://localhost:44370/");
        }
    }
}
