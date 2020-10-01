using BunService.Models;
using BunService.Repositories;
using Helpers;
using MassTransit;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace BunService.Masstransit
{
    public class SubmitBunConsumer : IConsumer<ICreateBun>
    {
        private readonly IBunRepository _repo;

        public SubmitBunConsumer(IBunRepository repo)
        {
            _repo = repo;
        }

        public async Task Consume(ConsumeContext<ICreateBun> context)
        {
            //throw new NotImplementedException();
            await _repo.CreateBun(new Bun { Size = context.Message.Size});
            await context.Publish<IBunCreated>(new { CorrelationId = context.Message.CorrelationId });
        }
    }
}
