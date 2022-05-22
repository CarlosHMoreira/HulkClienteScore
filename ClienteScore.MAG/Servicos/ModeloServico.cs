
using ClienteScoreMAG.Dominio.Interfaces;
using ClienteScoreMAG.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteScoreMAG.Servicos
{
    public class ModeloServico : IModeloService
    {
        private readonly IModeloRepositorio _repositorio;
        private readonly IEmailServico _emailServico;

        public ModeloServico(IModeloRepositorio repositorio, IEmailServico emailServico)
        {
            _repositorio = repositorio;
            _emailServico = emailServico;
        }

        public async Task<bool> CalcularModelo(CognitivoSentimento cognitivo)
        {
            var medias = cognitivo.Documentos.Select(x =>
                (x.confidenceScores.Positiva +
                    x.confidenceScores.Neutra +
                    x.confidenceScores.Negativa) / 3);

            float soma = 0;

            foreach (var media in medias)
            {
                soma += (float)media;
            }

            var proponente = new Proponente
            {
                MediaGeral = soma,
                CriadoEm = DateTime.Now,
                Documento = "11111111111",
                Motivos = new List<Motivo>()
                { 
                    new Motivo()
                    {
                        Negativo = 0.9F,
                        CriadoEm = DateTime.Now,
                        Media = 0.76F,
                        Nome = "2ª VIA DE BOLETO",
                        Positivo = 0.1F,
                    }
                }
            };

            await _repositorio.SalvarModelo(proponente);
            if (proponente.Motivos.Select(x => x.Nome.Equals("2ª VIA DE BOLETO")).FirstOrDefault())
            {
                _emailServico.EnviarEmail("mateuscalabria@gmail.com", "Mateus Calabria Machado", "boleto", "Olá,\nComo requisitado, aqui está o número da sua segunda via do boleto, 34191.79001 01043.510047 91020.150008 8 89930026000\nPara mais pedidos semelhantes à esse temos o portal do cliente!\nNele você tem acesso imediato à muitas informações.\nAcesse já clicando nesse link: https://areadocliente.mongeralaegon.com.br");
            };
            return true;
        }
    }
}
