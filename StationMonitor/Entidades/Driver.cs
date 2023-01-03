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
    [Table("drivers")]
    public class Driver : IDriver
    {
        
        public Guid StationId { get; set; }
        [StringLength(5)]
        public string Letter   { get; set; }
        public double TotalSize { get; set; }
        public double FreeSize   { get; set; }
        [StringLength(50)]
        public string Label    { get; set; }
        [StringLength(10)]
        public string Format { get; set; }
        public DriveType Type { get; set; }

        [ForeignKey("StationId")]
        public Station Station { get; set; }

        public double TotalSizeMB { get { return Math.Round(TotalSize / 1024 / 1024,2); } }
        public double FreeSizeMB { get { return Math.Round(FreeSize / 1024 / 1024,2); } }
    }
}
