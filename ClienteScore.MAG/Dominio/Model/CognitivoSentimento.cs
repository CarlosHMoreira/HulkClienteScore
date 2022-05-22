using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteScoreMAG.Dominio.Model
{
    public class CognitivoSentimento
    {
        public IEnumerable<Documento> Documentos { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public DateTime VersaoModelo { get; set; }
    }
}
