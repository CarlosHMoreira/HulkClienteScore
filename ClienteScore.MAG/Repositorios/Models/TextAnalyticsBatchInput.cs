using System;
using System.Collections.Generic;
using System.Text;
using static ClienteScoreMAG.Servicos.JsonMapper;

namespace ClienteScoreMAG.Repositorios.Models
{
    public class TextAnalyticsBatchInput
    {
        public IList<TextAnalyticsInput> Documents { get; set; }
    }
}
