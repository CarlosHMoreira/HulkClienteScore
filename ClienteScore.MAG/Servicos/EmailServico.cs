using ClienteScoreMAG.Dominio.Interfaces;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ClienteScore.MAG.Servicos
{
    public class EmailServico : IEmailServico
    {
        public void EnviarEmail(string emailDestino, string nomeDestinatario, string assunto, string mensagem)
        {
            try
            {
                var nome = Environment.GetEnvironmentVariable("COMPANHIA");
                var enderecoEmail = Environment.GetEnvironmentVariable("ENDERECO_DE_EMAIL");
                var senha = Environment.GetEnvironmentVariable("SENHA_EMAIL");

                MailMessage email = new MailMessage();
                email.From = new MailAddress(enderecoEmail);
                email.CC.Add(enderecoEmail);
                email.To.Add(emailDestino);
                email.Subject = assunto;
                email.IsBodyHtml = true;
                email.Body = @$"<table style='font-family: Arial, sans-serif; margin: auto; margin-top: 25px; width: 80%;'>
                                  <tbody>
                                      <tr>
                                        <td style='text-align:left'>
                                          <h2 style='margin: 25px 25px;'>Olá, {nomeDestinatario}</h2>
                                        </td>
                                      </tr>
                                      <tr>
                                        <td style='margin: 25px; font-family: Arial, sans-serif;'>
                                          <p style='margin: 25px;'>{mensagem}</p>
                                        </td>
                                      </tr>
                                      <tr>
                                        <td style='text-align:center;'>
                                          <img style='margin-top: 50px; margin-bottom: 25px; width: 70%;' src='https://magportalmagprdstg.blob.core.windows.net/public/assets/app/css/img/header_external.png' alt='Banner Mongeral Aegon - Banner Azul e branco com o logotipo da MAG'>
                                        </td>
                                      </tr>
                                  </tbody>
                                </table>
                                ";             

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
