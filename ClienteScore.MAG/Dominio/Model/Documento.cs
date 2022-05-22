using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteScoreMAG.Dominio.Model
{
    public class Documento
    {
        public string Id { get; set; }
        public string Sentimento { get; set; }
        public ConfidenceScore confidenceScores { get; set; }
        public IEnumerable<Sentenca> Sentecas { get; set; }
        public IEnumerable<string> Warnnings { get; set; }
    }
        
}
