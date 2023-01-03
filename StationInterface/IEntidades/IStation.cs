using System;
using System.Collections.Generic;
using System.Text;

namespace StationInterface.IEntidades
{
   

    public interface IStation<TEvent, TDriver, TSoftware, TConnection>
    {
        Guid Id { get; set; }
        string Name { get; set; }
        //UserT User { get; set; }
        string Cpu { get; set; }
        string MotherBoard { get; set; }
        UInt64 Memory { get; set; }
        string OS { get; set; }
        string OSDirectory { get; set; }
        string OSArchitecture { get; set; }
        string InstallDate { get; set; }
        string LastBootUpTime { get; set; }
        string LocalDateTime { get; set; }

        IEnumerable<TEvent> Events { get; }
        IEnumerable<TDriver> Drivers { get; set; }
        IEnumerable<TSoftware> Softwares { get; set; }
        IEnumerable<TConnection> Connections { get; set; }
       
    }
}
