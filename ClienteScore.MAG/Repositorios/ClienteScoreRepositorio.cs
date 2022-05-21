using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ClienteScore.MAG.Dominio;
using ClienteScore.MAG.Repositorios.Models;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace ClienteScore.MAG.Repositorios
{
    public class ClienteScoreRepositorio : IClienteScoreRepositorio
    {
        private readonly IConfiguration _configuration;

        public ClienteScoreRepositorio(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Caso> ObterCaso()
        {
            var sql = @"SELECT TOP(1) * FROM casos c1
                        WHERE c1.criado_em >= dateadd(day,-30, GETDATE())
                        AND documento NOT IN (
                            SELECT r.documento FROM revisoes r WHERE r.criado_em >= dateadd(day,-30, GETDATE())
                        )";

            await using var conexao = new SqlConnection(_configuration.GetConnectionString("ClienteScore"));
            return await conexao.QueryFirstOrDefaultAsync<Caso>(sql: sql);
        }

        public async Task<IEnumerable<Caso>> ObterCasosDeCliente(string documento)
        {
            var sql = @"SELECT documento, mensagem, motivo, criado_em
                        FROM casos
                        WHERE criado_em >= dateadd(day,-30, GETDATE())
                        AND documento = @documento";

            using var conexao = new SqlConnection(_configuration.GetConnectionString("ClienteScore"));
            return await conexao.QueryAsync<Caso>(sql: sql, new { documento = new DbString { Value = documento } });
        }
    }
}