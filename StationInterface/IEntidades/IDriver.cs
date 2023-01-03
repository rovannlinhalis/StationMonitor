using StationInterface.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace StationInterface.IEntidades
{
    public interface IDriver
    {
        Guid StationId { get; set; }
        string Letter { get; set; }
        double TotalSize { get; set; }
        double FreeSize { get; set; }
        string Label { get; set; }
        string Format { get; set; }
        DriveType Type { get; set; }
    }
}
