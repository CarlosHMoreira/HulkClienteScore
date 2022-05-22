
using ClienteScoreMAG.Dominio.Interfaces;
using ClienteScoreMAG.Dominio.Model;
using System.Threading.Tasks;

namespace ClienteScoreMAG.Servicos
{
    public class ModeloServico : IModeloService
    {
        private readonly IModeloRepositorio _repositorio;

        public ModeloServico(IModeloRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public Task<bool> CalcularModelo(CognitivoSentimento cognitivo)
        {
            
        }              
    }
}
