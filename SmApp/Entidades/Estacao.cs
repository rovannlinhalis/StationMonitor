
using StationInterface.IEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StationMonitor.Entidades
{
    
    public class Estacao : IStation<Evento, Driver, Software,Conexao>
    {
    
        public Guid Id { get; set; }

        public string Name { get; set; }
                  
        public string Cpu { get; set; }

        public string MotherBoard { get; set; }

        public UInt64 Memory { get; set; }

        public string OS { get; set; }
        public string OSDirectory { get; set; }
        public string OSArchitecture { get; set; }
        public string InstallDate { get; set; }
        public string LastBootUpTime { get; set; }
        public string LocalDateTime { get; set; }

        public virtual IEnumerable<Evento> Events { get; }
        public virtual IEnumerable<Driver> Drivers { get; set; }
        public virtual IEnumerable<Software> Softwares { get; set; }
        public virtual IEnumerable<Conexao> Connections { get; set; }
        
    }
}
