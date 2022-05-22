using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteScoreMAG.Repositorios.Models
{
    public class AnaliseTextoInput
    {
        /// <summary>
        /// A unique, non-empty document identifier.
        /// </summary>
        public string Id { get; set; }

        public string Text { get; set; }

        public string LanguageCode { get; set; } = "pt-br";
    }
}
