using ClienteScoreMAG.Dominio.Interfaces;
using ClienteScoreMAG.Dominio.Model;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
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
            await using var conexao = new SqlConnection(_url);
            var sql = @"INSERT INTO revisoes VALUES(@documento, @media_geral, null, @criado_em)";
            SqlCommand command = new SqlCommand();
            command.Connection = conexao;
            command.CommandText = sql;
            command.CommandType = CommandType.Text;

            SqlParameter parameter = new SqlParameter();

            parameter.ParameterName = "@documento";
            parameter.SqlDbType = SqlDbType.Int;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = proponente.Documento;

            command.Parameters.Add(parameter);

            parameter.ParameterName = "@media_geral";
            parameter.SqlDbType = SqlDbType.Float;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = proponente.MediaGeral;

            command.Parameters.Add(parameter);

            parameter.ParameterName = "@criado_em";
            parameter.SqlDbType = SqlDbType.DateTime;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = DateTime.Now;

            command.Parameters.Add(parameter);

            var valor = conexao.QueryFirstOrDefault(sql);

            foreach (Motivo motivo in proponente.Motivos)
            {
                var id = conexao.ExecuteAsync("SELECT MAX(casos_revisados.id) FROM casos_revisados");
                sql = @"INSERT INTO casos.revisados values (@media, @nome, @negativo, @positivo, @id)";

                command.Connection = conexao;
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                parameter.ParameterName = "@media";
                parameter.SqlDbType = SqlDbType.Float;
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = motivo.Media;

                command.Parameters.Add(parameter);
                
                parameter.ParameterName = "@nome";
                parameter.SqlDbType = SqlDbType.VarChar;
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = motivo.Nome;

                command.Parameters.Add(parameter);

                parameter = new SqlParameter();
                parameter.ParameterName = "@negativo";
                parameter.SqlDbType = SqlDbType.Float;
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = motivo.Negativo;

                command.Parameters.Add(parameter);

                parameter.ParameterName = "@positivo";
                parameter.SqlDbType = SqlDbType.Float;
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = motivo.Positivo;

                command.Parameters.Add(parameter);

                parameter.ParameterName = "@id";
                parameter.SqlDbType = SqlDbType.Int;
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = id;

                command.Parameters.Add(parameter);
            }
            return true;
        }
    }
}
