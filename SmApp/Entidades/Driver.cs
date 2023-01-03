using StationInterface.Enum;
using StationInterface.IEntidades;
using System;

namespace StationMonitor.Entidades
{
    public class Driver : IDriver
    {
        public Guid StationId { get; set; }
        public string Letter { get; set; }
        public double TotalSize { get; set; }
        public double FreeSize { get; set; }
        public string Label { get; set; }
        public string Format { get; set; }
        public DriveType Type { get; set; }
    }
}
