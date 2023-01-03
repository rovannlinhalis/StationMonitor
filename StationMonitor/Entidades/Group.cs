using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StationMonitor.Entidades
{
    public class Group
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        public ApplicationUser User { get; set; }
    }
}
