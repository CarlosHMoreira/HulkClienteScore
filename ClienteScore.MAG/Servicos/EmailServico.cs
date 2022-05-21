using ClienteScoreMAG.Dominio.Interfaces;
using System;
using System.Net;
using System.Net.Mail;

namespace ClienteScore.MAG.Servicos
{
    public class EmailServico : IEmailServico
    {

        public void EnviarEmail(string emailDestino, string nomeDestinatario, string assunto)
        {
            try
            {
                var nome = Environment.GetEnvironmentVariable("COMPANHIA");
                var enderecoEmail = Environment.GetEnvironmentVariable("ENDERECO_DE_EMAIL");
                var senha = Environment.GetEnvironmentVariable("SENHA_EMAIL");

                MailMessage email = new MailMessage();
                email.From = new MailAddress(enderecoEmail);
                email.CC.Add(enderecoEmail);
                email.Subject = assunto;
                email.IsBodyHtml = true;
                email.Body = $"Email do usuário {nomeDestinatario} chegou";              

                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(enderecoEmail, senha);
                    smtpClient.Send(email);
                };

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
