
using StationInterface.Enum;
using StationInterface.IEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StationMonitor.Entidades
{
    [Table("events")]
    public class Event : IEvento
    {
        public Guid StationId { get; set; }

        public int? Sequence { get; set; }

        [StringLength(200)]
        public string OSUserName { get; set; }

        [ForeignKey("StationId")]
        public Station Station { get; set; }

        public DateTime Date { get; set; }

        public TiposEventos Type { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(100)]
        public string Process { get; set; }

        public int? X { get; set; }

        public int? Y { get; set; }

        public double? CurrentTemperature { get; set; }

        public double? WarningTemperature { get; set; }
        public UInt64? FreeMemory {get;set;}
        public double? CPULoad { get; set; }
    }
}
