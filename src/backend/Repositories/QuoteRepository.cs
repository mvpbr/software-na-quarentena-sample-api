using System;
using System.Collections.Generic;
using System.Linq;

namespace SwNaQuarentena.Api.Repositories
{
    public class QuoteRepository : IQuoteRepository
    {
        public string GetAQuoteByPersonName(string name)
        {
            var quotesCollection = QuotesCollection();

            if (!quotesCollection.ContainsKey(name))
            {
                return string.Empty;
            }

            var quotes = quotesCollection.FirstOrDefault(quote =>
                quote.Key.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                .Value;

            return GetRandomQuoteFromAListOfQuotes(quotes);
        }

        private string GetRandomQuoteFromAListOfQuotes(List<string> quotes)
        {
            var random = new Random();
            var index = random.Next(0, quotes.Count);
            return quotes[index];
        }

        private Dictionary<string, List<string>> QuotesCollection() =>
            new Dictionary<string, List<string>>
            {
                {
                    "angelo",
                    new List<string>
                    {
                        "Se eu até sou burro consigo, imagina vocês que são inteligentes!",
                        "Pra quem tá se afogando, jacaré é tronco!",
                        "Meu português é intermediário!",
                        "Cada enxadada, uma minhoca!",
                        "Palmeiras não tem mundial!"
                    }
                },
                {
                    "william",
                    new List<string>()
                    {
                        "Na minha maquina funciona!",
                        "aaaaoooo viiiiivvoooo"
                    }
                },
                {
                    "surra",
                    new List<string>()
                    {
                        "Deu trabalho mais funfou!",
                        "ufaaaaa"
                    }
                },
                {
                    "miltoncamara",
                    new List<string>()
                    {
                        "Ajudou nois!",
                        "Habilitem o ADMIN ACCESS NO CONTAINER REGISTRY pelo AMORRRRRRR"
                    }
                }
            };
    }
}
