using ClienteScore.MAG.Dominio.Models;
using System.Threading.Tasks;

namespace ClienteScore.MAG.Dominio
{
    class RecuperarCasosDeCliente
    {
        private readonly IClienteScoreRepositorio _clienteScoreRepositorio;

        public RecuperarCasosDeCliente(IClienteScoreRepositorio clienteScoreRepositorio)
        {
            _clienteScoreRepositorio = clienteScoreRepositorio;
        }

        public async Task<ProponenteCasosPreProcessamentoDTO> ObterMotivos()
        {
            var caso = await _clienteScoreRepositorio.ObterCaso();
            var casos = await _clienteScoreRepositorio.ObterCasosDeCliente(caso.Documento);
            return new ProponenteCasosPreProcessamentoDTO()
            {
                documento = caso.Documento,
                casos = casos,
            };
        }
    }
}
