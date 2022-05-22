using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ClienteScore.MAG.Dominio;
using ClienteScoreMAG.Servicos;
using System;
using ClienteScoreMAG.Dominio.Interfaces;

namespace ClienteScoreMAG.Functions
{
    public class BuscarProponente
    {
        private readonly IClienteScoreRepositorio _clienteScoreRepositorio;
        private readonly AnalizadorSentimento _sentimento;
        private readonly IModeloService _modeloService;
        private readonly IEmailServico _emailServico;

        public BuscarProponente(IClienteScoreRepositorio clienteScoreRepositorio, AnalizadorSentimento sentimento, IModeloService modeloService, IEmailServico emailServico)
        {
            _clienteScoreRepositorio = clienteScoreRepositorio;
            _sentimento = sentimento;
            _modeloService = modeloService;
            _emailServico = emailServico;
        }

        [FunctionName("BuscarProponente")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "buscarproponente")] HttpRequest req,
            ILogger log)
        {
            try
            {
                var action = new RecuperarCasosDeCliente(_clienteScoreRepositorio);
                var proponente = await action.ObterMotivos();
                var documentos = new JsonMapper().CriarJson(proponente.casos);
                var sentimentV3Prediction = await _sentimento.SentimentV3PreviewPredictAsync(documentos);
                var result = await _modeloService.CalcularModelo(sentimentV3Prediction);


            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return new OkResult();
        }
    }
}
