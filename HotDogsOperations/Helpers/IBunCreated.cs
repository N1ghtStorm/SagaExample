using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers
{
    public interface IBunCreated
    {
        Guid CorrelationId { get; set; }
    }
}
