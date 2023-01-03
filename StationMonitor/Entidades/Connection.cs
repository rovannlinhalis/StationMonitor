using StationInterface.IEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StationMonitor.Entidades
{
    [Table("connections")]
    public class Connection : IConexao
    {
        public Guid StationId    { get; set; }
        public int Sequence     { get; set; }
        [StringLength(200)]
        public string Name       { get; set; }
        public double Speed { get; set; }
        [StringLength(50)]
        public string Status     { get; set; }
        [StringLength(50)]
        public string Type { get; set; }

        [ForeignKey("StationId")]
        public Station Station { get; set; }
    }
}
