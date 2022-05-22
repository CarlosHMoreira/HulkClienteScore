using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ClienteScore.MAG.Dominio;
using ClienteScoreMAG.Servicos;
using System;

namespace ClienteScoreMAG.Functions
{
    public class BuscarProponente
    {
        private readonly IClienteScoreRepositorio _clienteScoreRepositorio;
        private readonly AnalizadorSentimento _sentimento;

        public BuscarProponente(IClienteScoreRepositorio clienteScoreRepositorio, AnalizadorSentimento sentimento)
        {
            _clienteScoreRepositorio = clienteScoreRepositorio;
            _sentimento = sentimento;
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

            var sentimentV3Prediction =  _sentimento.SentimentV3PreviewPredictAsync(documentos).Result;

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return new OkObjectResult("");
        }
    }
}
