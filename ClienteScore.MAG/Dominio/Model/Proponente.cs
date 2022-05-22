using System;
using System.Collections.Generic;

namespace ClienteScoreMAG.Dominio.Model
{
    public class Proponente
    {
        public string Documento { get; set; }
        public IEnumerable<Motivo> Motivos { get; set; }
        public float MediaGeral { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
