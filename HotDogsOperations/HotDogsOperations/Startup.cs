using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotDogsOperations.Sagas;
using MassTransit;
using MassTransit.Saga;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HotDogsOperations
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddMassTransit(cfg => 
            {
                cfg.SetKebabCaseEndpointNameFormatter();
                cfg.UsingRabbitMq((context, _cfg) => 
                {
                    //_cfg.ConfigureEndpoints(context);
                    _cfg.ReceiveEndpoint("hot-dog-saga", e => e.StateMachineSaga(
                        new HotDogStateMachine(),
                        new InMemorySagaRepository<HotDogStateInstance>()
                        ));
                });

                //cfg.AddSagaStateMachine<HotDogStateMachine, HotDogState>().InMemoryRepository();
            });

            services.AddMassTransitHostedService();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
