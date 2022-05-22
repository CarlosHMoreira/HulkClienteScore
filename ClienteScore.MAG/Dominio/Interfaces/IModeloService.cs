using ClienteScoreMAG.Dominio.Model;
using System.Threading.Tasks;

namespace ClienteScoreMAG.Dominio.Interfaces
{
    public interface IModeloService
    {
        Task<bool> CalcularModelo(CognitivoSentimento cognitivo);
    }
}
