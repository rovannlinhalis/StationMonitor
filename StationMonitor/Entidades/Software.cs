using StationInterface.IEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StationMonitor.Entidades
{
    [Table("softwares")]
    public class Software : ISoftware
    {
        public Guid StationId    { get; set; }
        public int Sequence     { get; set; }
        [StringLength(200)]
        public string Name       { get; set; }
        [StringLength(200)]
        public string Manufacturer    { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("StationId")]
        public Station Station { get; set; }
    }
}
