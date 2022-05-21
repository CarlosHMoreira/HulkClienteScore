using System.Collections.Generic;
using System.Threading.Tasks;
using ClienteScore.MAG.Repositorios.Models;

namespace ClienteScore.MAG.Dominio
{
    public interface IClienteScoreRepositorio
    {
        Task<Caso> ObterCaso();
        Task<IEnumerable<Caso>> ObterCasosDeCliente(string documento);
    }
}