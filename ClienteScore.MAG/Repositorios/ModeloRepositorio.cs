using ClienteScoreMAG.Dominio.Interfaces;
using ClienteScoreMAG.Dominio.Model;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ClienteScoreMAG.Repositorios
{
    public class ModeloRepositorio : IModeloRepositorio
    {
        private readonly string _url;
        public ModeloRepositorio(IConfiguration configuration)
        {
            _url = configuration.GetConnectionString("ClienteScore");
        }

        public async Task<bool> SalvarModelo(Proponente proponente)
        {
            try
            {
                var numeroProcesso = proponente.Documento;
                var media = proponente.MediaGeral.ToString();
                var data = proponente.CriadoEm.ToString();

                var sql = @"INSERT INTO revisoes (documento, media_geral, datetime, criado_em)
                        VALUES(@numeroProcesso, @media, null, @data)";

                using (var connection = new SqlConnection(_url))
                {
                    var results = await connection.ExecuteAsync(sql, param: numeroProcesso, media, data);
                }
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }

            return true;
        }
    }
}
