using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers
{
    public interface ICreateHotDogSubmit
    {
        public Guid CorrelationId { get; set; }
        public int BunSize { get; set; }
        public int SausageSize { get; set; }
    }
}
