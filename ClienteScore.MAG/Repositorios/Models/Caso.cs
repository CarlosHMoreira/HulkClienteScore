using System;

namespace ClienteScore.MAG.Repositorios.Models
{
    public class Caso
    {
        public int Id { get; set; }
        public string Documento { get; set; }
        public string Mensagem { get; set; }
        public string Motivo { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}