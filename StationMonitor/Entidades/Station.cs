using StationInterface.IEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StationMonitor.Entidades
{
    [Table("stations")]
    public class Station : IStation<Event, Driver, Software, Connection>
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public ApplicationUser User { get; set; }


        [StringLength(100)]
        public string Cpu { get; set; }

        [StringLength(100)]
        public string MotherBoard { get; set; }

        public UInt64 Memory { get; set; }

        public string MemoryString
        {
            get
            {

                if (this.Memory < 1048576)
                {
                    return (Memory / 1024 / 1024).ToString("0.00") + " MB";
                }
                else
                {
                    return (Memory / 1024 / 1024 / 1024).ToString("0.00") + " GB";
                }

            }
        }

        public Guid GroupId { get; set; }

        [ForeignKey("GroupId")]
        public Group Group { get; set; }

        public DateTime? LastUpdate { get; set; }

        [StringLength(200)]
        public string OS { get; set; }
        [StringLength(200)]
        public string OSDirectory { get; set; }
        [StringLength(200)]
        public string OSArchitecture { get; set; }
        [StringLength(200)]
        public string InstallDate { get; set; }
        [StringLength(200)]
        public string LastBootUpTime { get; set; }
        [StringLength(200)]
        public string LocalDateTime { get; set; }


        public virtual IEnumerable<Event> Events { get; set; }
        public virtual IEnumerable<Driver> Drivers { get; set; }
        public virtual IEnumerable<Software> Softwares { get; set; }
        public virtual IEnumerable<Connection> Connections { get; set; }

        public virtual Event LastEvent { get { return (Events != null && Events.Count() > 0) ? Events.OrderBy(x => x.Date).Last() : null; } }

        

    }
}

