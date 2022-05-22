using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteScoreMAG.Dominio.Model
{
    public class Sentenca
    {
        public string Sentimento { get; set; }
        public ConfidenceScore ConfidenceScores { get; set; }
        public int Offset { get; set; }
        public int Lenght { get; set; }
        public string Texto { get; set; }
        public IEnumerable<string> Alvos { get; set; }
        public IEnumerable<string> Assessments { get; set; }
    }
}
