﻿using Helpers;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BunService.Masstransit
{
    public class SubmitBunConsumer : IConsumer<ICreateBun>
    {
        public Task Consume(ConsumeContext<ICreateBun> context)
        {
            throw new NotImplementedException();
        }
    }
}