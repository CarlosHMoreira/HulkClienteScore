using Azure;
using System;
using Azure.AI.TextAnalytics;
using System.Collections.Generic;

namespace Example
{
    class modeloFuncionaAnaliseSentimento
    {
        //credentials, sua crendencial de um servico cognitivo da Azure Microsoft
        private static readonly AzureKeyCredential credentials = new AzureKeyCredential("db31f8a7db3a43bc870b5a75ad45fd2a");
        //endpoint, seu endpoint do mesmo servico cognitivo da Azure Microsoft
        private static readonly Uri endpoint = new Uri("https://analisedetextomag.cognitiveservices.azure.com/");

        //Modelo exemplo de deteccao de sentimento a partir de um texto 
        static void SentimentAnalysisExample(TextAnalyticsClient client)
        {
            string inputText = "Gostaria que todos ficassem sabendo que a Mag seguros age com tremenda falta de respeito com o cliente.";
            DocumentSentiment documentSentiment = client.AnalyzeSentiment(inputText);
            Console.WriteLine($"Document sentiment: {documentSentiment.Sentiment}\n");

            foreach (var sentence in documentSentiment.Sentences)
            {
                Console.WriteLine($"\tText: \"{sentence.Text}\"");
                Console.WriteLine($"\tSentence sentiment: {sentence.Sentiment}");
                Console.WriteLine($"\tPositive score: {sentence.ConfidenceScores.Positive:0.00}");
                Console.WriteLine($"\tNegative score: {sentence.ConfidenceScores.Negative:0.00}");
                Console.WriteLine($"\tNeutral score: {sentence.ConfidenceScores.Neutral:0.00}\n");
            }
        }

        //Modelo exemplo de deteccao de sentimento a partir de um texto 2
        static void SentimentAnalysisWithOpinionMiningExample(TextAnalyticsClient client)
        {
            var documents = new List<string>
            {
                "Gostaria que todos ficassem sabendo que a Mag seguros age com tremenda falta de respeito com o cliente. Pensem muito antes de fechar esse seguro. O problema começa quando vc fica incapacitado para trabalhar, eles começam a tentar enrolar de uma tal forma, achar brechas para não pagar o segurado, mesmo diante de todos os exames de ressonância magnética e laudo médico. Minha advogada pediu para tentar resolver administrativamente até hoje, mas cada vez que ligo para ouvidoria a equipe médica da uma desculpa diferente, uma vez é o sistema, outra vez é o horário, enfim, muitas mentiras. Hoje esgotou as tratativas com eles e estamos tomando as medidas cabíveis. Não façam esse seguro é muito aborrecimento"
            };

            AnalyzeSentimentResultCollection reviews = client.AnalyzeSentimentBatch(documents, options: new AnalyzeSentimentOptions()
            {
                IncludeOpinionMining = true
            });

            //Modelo exemplo de deteccao de sentimento, conjunto de opnioes
            foreach (AnalyzeSentimentResult review in reviews)
            {
                Console.WriteLine($"Document sentiment: {review.DocumentSentiment.Sentiment}\n");
                Console.WriteLine($"\tPositive score: {review.DocumentSentiment.ConfidenceScores.Positive:0.00}");
                Console.WriteLine($"\tNegative score: {review.DocumentSentiment.ConfidenceScores.Negative:0.00}");
                Console.WriteLine($"\tNeutral score: {review.DocumentSentiment.ConfidenceScores.Neutral:0.00}\n");
                foreach (SentenceSentiment sentence in review.DocumentSentiment.Sentences)
                {
                    Console.WriteLine($"\tText: \"{sentence.Text}\"");
                    Console.WriteLine($"\tSentence sentiment: {sentence.Sentiment}");
                    Console.WriteLine($"\tSentence positive score: {sentence.ConfidenceScores.Positive:0.00}");
                    Console.WriteLine($"\tSentence negative score: {sentence.ConfidenceScores.Negative:0.00}");
                    Console.WriteLine($"\tSentence neutral score: {sentence.ConfidenceScores.Neutral:0.00}\n");

                    foreach (SentenceOpinion sentenceOpinion in sentence.Opinions)
                    {
                        Console.WriteLine($"\tTarget: {sentenceOpinion.Target.Text}, Value: {sentenceOpinion.Target.Sentiment}");
                        Console.WriteLine($"\tTarget positive score: {sentenceOpinion.Target.ConfidenceScores.Positive:0.00}");
                        Console.WriteLine($"\tTarget negative score: {sentenceOpinion.Target.ConfidenceScores.Negative:0.00}");
                        foreach (AssessmentSentiment assessment in sentenceOpinion.Assessments)
                        {
                            Console.WriteLine($"\t\tRelated Assessment: {assessment.Text}, Value: {assessment.Sentiment}");
                            Console.WriteLine($"\t\tRelated Assessment positive score: {assessment.ConfidenceScores.Positive:0.00}");
                            Console.WriteLine($"\t\tRelated Assessment negative score: {assessment.ConfidenceScores.Negative:0.00}");
                        }
                    }
                }
                Console.WriteLine($"\n");
            }
        }

        static void Main(string[] args)
        {
            var client = new TextAnalyticsClient(endpoint, credentials);
            SentimentAnalysisExample(client);
            SentimentAnalysisWithOpinionMiningExample(client);

            Console.Write("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
