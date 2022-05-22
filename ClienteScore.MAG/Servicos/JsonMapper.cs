using ClienteScore.MAG.Repositorios.Models;
using ClienteScoreMAG.Repositorios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClienteScoreMAG.Servicos
{
    public class JsonMapper
    {
        public TextAnalyticsBatchInput CriarJson(IEnumerable<Caso> casos)
        {
            var inputDocuments = new TextAnalyticsBatchInput();
            var lista = casos.Select((x, i) => new TextAnalyticsInput() { Id = i.ToString(), Text= x.Mensagem, LanguageCode= "pt" });

            inputDocuments.Documents = lista.ToList();
            return inputDocuments;
        }
       

        public class TextAnalyticsInput
        {
            public string Id { get; set; }

            public string Text { get; set; }

            public string LanguageCode { get; set; } = "en";
        }

    }
}
