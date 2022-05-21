namespace ClienteScoreMAG.Dominio.Model
{
    public class EmailModel
    {
        public EmailModel(string nomeDestinatario, string assunto, string emailDeDestino)
        {
            NomeDestinatario = nomeDestinatario;
            Assunto = assunto;
            EmailDeDestino = emailDeDestino;
        }

        public string NomeDestinatario { get; set; }
        public string Assunto { get; set; }
        public string EmailDeDestino { get; set; }
        public string Mensagem { get; set; }
    }
}
