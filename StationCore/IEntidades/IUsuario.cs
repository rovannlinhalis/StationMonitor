using System;
using System.Collections.Generic;
using System.Text;

namespace StationCore.IEntidades
{
    public interface IUsuario<TEstacao>
    {
        string Id { get; set; }
        string UserName { get; set; }
        Guid Token { get; set; }
        string TokenSenha { get; set; }
        IEnumerable<TEstacao> Estacoes { get; set; }
    }
}
