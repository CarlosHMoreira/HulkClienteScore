using ClienteScore.MAG.Repositorios.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteScore.MAG.Dominio.Models
{
    class ProponenteCasosPreProcessamentoDTO
    {
        public ProponenteCasosPreProcessamentoDTO() { }
        public ProponenteCasosPreProcessamentoDTO(string documento, IEnumerable<Caso> casos) 
        {
            this.documento = documento;
            this.casos = casos;
        }

        public string documento { get; set; }
        public IEnumerable<Caso> casos { get; set; }
    }
}
