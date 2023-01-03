using System;
using System.Collections.Generic;
using System.Text;

namespace StationInterface.IEntidades
{
    public interface ISoftware
    {
        Guid StationId { get; set; }
        int Sequence { get; set; }
        string Name { get; set; }
        string Manufacturer { get; set; }
        DateTime Date { get; set; }

    }
}
