using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Helpers;
using HotDogsOperations.Domain;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotDogsOperations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotDogController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateHotDogAsync([FromBody]HotDog hotDog)
        {
            var busControl = Bus.Factory.CreateUsingRabbitMq();

            var source = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            await busControl.StartAsync(source.Token);
            try
            {
                do
                {
                    string value = await Task.Run(() =>
                    {
                        Console.WriteLine("Enter message (or quit to exit)");
                        Console.Write("> ");
                        return Console.ReadLine();
                    });

                    if ("quit".Equals(value, StringComparison.OrdinalIgnoreCase))
                        break;

                    await busControl.Publish<ICreateHotDogSubmit>(new
                    {
                        CorrelationId = Guid.NewGuid(),
                        BunSize = hotDog.BunSize,
                        SausageSize = hotDog.SausageSize
                    }); 
                }
                while (true);
            }
            finally
            {
                await busControl.StopAsync();
            }

            return Ok();
        }
    }
}