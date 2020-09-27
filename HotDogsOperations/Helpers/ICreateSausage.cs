using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers
{
    public interface ICreateSausage
    {
        Guid CorrelationId { get; set; }
        string Name { get; set; }
    }
}
