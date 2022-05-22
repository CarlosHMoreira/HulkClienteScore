using ClienteScoreMAG.Dominio.Interfaces;
using ClienteScoreMAG.Dominio.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteScoreMAG.Repositorios
{
    public class ModeloRepositorio : IModeloRepositorio
    {
        private readonly string _url;
        public ModeloRepositorio(IConfiguration configuration)
        {
            _url = configuration.GetConnectionString("clientcaseshulkdev");
        }

        public bool SalvarModelo(Proponente proponente)
        {
            throw new NotImplementedException();
        }
    }
}
