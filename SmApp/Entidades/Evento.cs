using StationInterface.Enum;
using StationInterface.IEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace StationMonitor.Entidades
{
    
    public class Evento : IEvento
    {
        public Guid StationId { get; set; }
        public int? Sequence { get; set; }
        public string OSUserName { get; set; }
        public DateTime Date { get; set; }
        public bool Processado { get; set; }
        public TiposEventos Type { get; set; }
        public string Title { get; set; }
        public string Process { get; set; }
        public int? X { get; set; }
        public int? Y { get; set; }
        public double? CurrentTemperature { get; set; }
        public double? WarningTemperature { get; set; }
        public ulong? FreeMemory {get;set;}
        public double? CPULoad { get; set; }
    }
}
