using System;
using System.Collections.Generic;
using System.Text;

namespace StationInterface.IEntidades
{
    public interface IConexao
    {
        Guid StationId { get; set; }
        int Sequence { get; set; }
        string Name { get; set; }
        double Speed { get; set; }
        string Status { get; set; }
        string Type { get; set; }
    }

  
}
