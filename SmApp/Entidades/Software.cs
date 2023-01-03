using StationInterface.IEntidades;
using System;

namespace StationMonitor.Entidades
{
    
    public class Software : ISoftware
    {
        public Guid StationId    { get; set; }
        public int Sequence     { get; set; }
        public string Name       { get; set; }
        public string Manufacturer    { get; set; }
        public DateTime Date { get; set; }

    }
}
