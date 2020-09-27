using Helpers;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SausageService.Masstransit
{
    public class SubmitSausageConsumer : IConsumer<ICreateSausage>
    {
        public Task Consume(ConsumeContext<ICreateSausage> context)
        {
            throw new NotImplementedException();
        }
    }
}
