namespace ClienteScoreMAG.Dominio.Interfaces
{
    public interface IEmailServico
    {
        void EnviarEmail(string emailDestino, string nomeDestinatario, string assunto);
    }
}
