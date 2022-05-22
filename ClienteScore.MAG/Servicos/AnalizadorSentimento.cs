using ClienteScoreMAG.Dominio.Model;
using ClienteScoreMAG.Repositorios.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClienteScoreMAG.Servicos
{
    public class AnalizadorSentimento
    {
        private readonly string _endpoint;
        private readonly string _subscriptionKey;
        public AnalizadorSentimento(IConfiguration configuration)
        {
            _endpoint = configuration.GetValue<string>("TEXT_ANALYTICS_ENDPOINT") + "/text/analytics/v3.1/sentiment";
            _subscriptionKey = configuration.GetValue<string>("TEXT_ANALYTICS_SUBSCRIPTION_KEY");
        }

        public async Task<CognitivoSentimento> SentimentV3PreviewPredictAsync(TextAnalyticsBatchInput inputDocuments)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _subscriptionKey);

                var httpContent = new StringContent(JsonConvert.SerializeObject(inputDocuments), Encoding.UTF8, "application/json");

                //var httpResponse = await httpClient.PostAsync(new Uri(_endpoint), httpContent);

                var mock = GerarMock(inputDocuments);

                //var responseContent = await httpResponse.Content.ReadAsStringAsync();

                //if (!httpResponse.StatusCode.Equals(HttpStatusCode.OK) || httpResponse.Content == null)
                //{
                //    throw new Exception(responseContent);
                //}

                //return JsonConvert.DeserializeObject<CognitivoSentimento>(responseContent, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });

                return mock;
            }
        }

        private CognitivoSentimento GerarMock(TextAnalyticsBatchInput inputDocuments)
        {
            return new CognitivoSentimento
            {
                Documentos = new List<Documento>()
                {
                    new Documento
                    {
                        Id = new Guid().ToString(),
                        confidenceScores = new ConfidenceScore
                        {
                            Negativa = double.Parse($"0.{new Random().Next(7, 10)}"),
                            Neutra = double.Parse($"0.{new Random().Next(7, 10)}"),
                            Positiva = double.Parse($"0.{new Random().Next(7, 10)}")
                        },
                        Sentecas = new List<Sentenca>()
                        {
                            new Sentenca{
                                    Offset = 0,
                                    Lenght = 132,
                                    Texto = inputDocuments.Documents[0].Text,
                                    Alvos = new List<string>(),
                                    Assessments = new List<string>(),
                                    ConfidenceScores = new ConfidenceScore
                                    {
                                        Negativa = double.Parse($"0.{new Random().Next(7, 10)}"),
                                        Neutra = double.Parse($"0.{new Random().Next(7, 10)}"),
                                        Positiva = double.Parse($"0.{new Random().Next(7, 10)}")
                                    }
                            }
                        },
                    }
                },
                Errors = new List<string>(),
                VersaoModelo = DateTime.Now
            };
        }
    }
}
