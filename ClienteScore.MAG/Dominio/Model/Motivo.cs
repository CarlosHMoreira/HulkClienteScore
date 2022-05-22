using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteScoreMAG.Dominio.Model
{
    public class Motivo
    {
        public string Nome { get; set; }
        public float Media { get; set; }
        public float Negativo { get; set; }
        public float Positivo { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
