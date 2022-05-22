using ClienteScoreMAG.Dominio.Interfaces;
using ClienteScoreMAG.Dominio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ClienteScoreMAG.Functions
{
    public class CalcularModelo
    {
        private readonly IModeloService _modeloService;

        public CalcularModelo(IModeloService modeloService)
        {
            _modeloService = modeloService;
        }

        [FunctionName("CalcularModelo")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "calcularmodelo")] CognitivoSentimento cognitivo,
            ILogger log)
        {

            if (cognitivo == default) return new BadRequestResult();

            var result = await _modeloService.CalcularModelo(cognitivo);

            if (result) return new OkResult();

            return new BadRequestResult();
        }
    }
}
