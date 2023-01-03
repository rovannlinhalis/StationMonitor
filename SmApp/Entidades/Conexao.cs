using StationInterface.IEntidades;
using System;


namespace StationMonitor.Entidades
{
    
    public class Conexao : IConexao
    {
        public Guid StationId    { get; set; }
        public int Sequence     { get; set; }
        public string Name       { get; set; }
        public double Speed { get; set; }
        public string Status     { get; set; }
        public string Type { get; set; }
    }
}
