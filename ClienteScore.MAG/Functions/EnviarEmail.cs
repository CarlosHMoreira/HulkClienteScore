using ClienteScoreMAG.Dominio.Interfaces;
using ClienteScoreMAG.Dominio.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ClienteScoreMAG.Functions
{
    public class EnviarEmail
    {
        private readonly IEmailServico _emailServico;

        public EnviarEmail(IEmailServico emailServico)
        {
            _emailServico = emailServico;
        }

        [FunctionName("EnviarEmail")]
        public ActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "clientescore/email/enviar")] EmailModel dadosEmail,
            ILogger log)
        {
            if (dadosEmail.Assunto == null || dadosEmail.EmailDeDestino == null || dadosEmail.NomeDestinatario == null)
                return new BadRequestResult();

            _emailServico.EnviarEmail(dadosEmail.EmailDeDestino, dadosEmail.NomeDestinatario, dadosEmail.Assunto, dadosEmail.Mensagem);

            return new OkResult();
        }
    }
}
