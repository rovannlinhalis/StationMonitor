using StationCore.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace StationCore.IEntidades
{
    public interface IEvento<TEstacao>
    {
        TEstacao Estacao { get; set; }
        int? Sequencia { get; set; }
        DateTime Data { get; set; }
        bool Processado { get; set; }
        TiposEventos Tipo { get; set; }
        string Titulo { get; set; }
        string Processo { get; set; }
        string OSUserName { get; set; }
    }


}
