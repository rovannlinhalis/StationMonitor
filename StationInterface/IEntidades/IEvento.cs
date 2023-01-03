using StationInterface.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace StationInterface.IEntidades
{
    public interface IEvento
    {
        Guid StationId { get; set; }
        int? Sequence { get; set; }
        DateTime Date { get; set; }
        TiposEventos Type { get; set; }
        string Title { get; set; }
        string Process { get; set; }
        string OSUserName { get; set; }
        int? X { get; set; }
        int? Y { get; set; }
        double? CurrentTemperature { get; set; }
        double? WarningTemperature { get; set; }
        UInt64? FreeMemory { get; set; }
        double? CPULoad { get; set; }
            

    }


}
