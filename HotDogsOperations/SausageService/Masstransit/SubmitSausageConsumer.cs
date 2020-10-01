using Helpers;
using MassTransit;
using SausageService.Models;
using SausageService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SausageService.Masstransit
{
    public class SubmitSausageConsumer : IConsumer<ICreateSausage>
    {
        private readonly ISausageRepository _repo;

        public SubmitSausageConsumer(ISausageRepository repo)
        {
            this._repo = repo;
        }
        public async Task Consume(ConsumeContext<ICreateSausage> context)
        {
            //throw new NotImplementedException();
            await _repo.CreateSausage(new Sausage { Size = context.Message.Size });
            await context.Publish<ISausageCreated>(new { CorrelationId  = context.Message.CorrelationId});
        }
    }
}
