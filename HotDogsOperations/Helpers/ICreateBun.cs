using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers
{
    public interface ICreateBun
    {
        Guid CorrelationId { get; set; }
        int Size { get; set; }
    }
}
