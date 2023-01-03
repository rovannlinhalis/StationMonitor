using System;
using System.Collections.Generic;
using System.Text;

namespace StationCore.IEntidades
{
   

    public interface IEstacao<EventT>
    {
        Guid Id { get; set; }
        string Nome { get; set; }
        //UserT User { get; set; }
        string Processador { get; set; }
        string PlacaMae { get; set; }
        double Memoria { get; set; }
        IEnumerable<EventT> Eventos { get;}
    }
}
