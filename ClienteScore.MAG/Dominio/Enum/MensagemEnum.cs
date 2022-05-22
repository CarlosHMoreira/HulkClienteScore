using System.ComponentModel;

namespace ClienteScoreMAG.Dominio.Enum
{
    enum MensagemEnum
    {
        [Description("Posição de Pagamento")]
        PosicaoPagamento,
        [Description("Posição Consolidada de Planos")]
        PosicaoConsolidada,
        [Description("Segunda Via de Boleto")]
        Boleto
    }
}
