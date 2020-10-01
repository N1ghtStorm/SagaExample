using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers
{
    public interface ISausageCreated
    {
        Guid CorrelationId { get; set; }
    }
}
