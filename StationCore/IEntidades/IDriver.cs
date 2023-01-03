using System;
using System.Collections.Generic;
using System.Text;

namespace StationCore.IEntidades
{
    public interface IDriver<TEstacao>
    {
        TEstacao Estacao { get; set; }
        double Tamanho { get; set; }
        double Livre { get; set; }
        string Nome { get; set; }
    }
}
