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
            _endpoint = configuration.GetValue<string>("TEXT_ANALYTICS_ENDPOINT");
            _subscriptionKey = _endpoint = configuration.GetValue<string>("TEXT_ANALYTICS_SUBSCRIPTION_KEY");
        }

        public  async Task<AnalizadorSentimento> SentimentV3PreviewPredictAsync(TextAnalyticsBatchInput inputDocuments)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _subscriptionKey);

                var httpContent = new StringContent(JsonConvert.SerializeObject(inputDocuments), Encoding.UTF8, "application/json");

                var httpResponse = await httpClient.PostAsync(new Uri(_endpoint), httpContent);
                var responseContent = await httpResponse.Content.ReadAsStringAsync();

                if (!httpResponse.StatusCode.Equals(HttpStatusCode.OK) || httpResponse.Content == null)
                {
                    throw new Exception(responseContent);
                }

                return JsonConvert.DeserializeObject<AnalizadorSentimento>(responseContent, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            }
        }
    }
}
