using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers
{
    public interface ICreateSausage
    {
        Guid CorrelationId { get; set; }
        int Size { get; set; }
    }
}
