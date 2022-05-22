using ClienteScoreMAG.Dominio.Model;
using System.Threading.Tasks;

namespace ClienteScoreMAG.Dominio.Interfaces
{
    public interface IModeloRepositorio
    {
        Task<bool> SalvarModelo(Proponente proponente);
    }
}
