using Microsoft.AspNetCore.Identity;
using StationInterface.IEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StationMonitor.Entidades
{
    public class ApplicationUser : IdentityUser, IUsuario<Station>
    {
        public virtual IEnumerable<Station> Estacoes { get; set; }
        public Guid Token { get; set; }
        [StringLength(50)]
        public string TokenSenha { get; set; }
    }
}
