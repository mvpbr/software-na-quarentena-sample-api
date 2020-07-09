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
                        "Se eu at� sou burro consigo, imagina voc�s que s�o inteligentes!",
                        "Pra quem t� se afogando, jacar� � tronco!",
                        "Meu portugu�s � intermedi�rio!",
                        "Cada enxadada, uma minhoca!",
                        "Palmeiras n�o tem mundial!"
                    }
                },
                {
                    "william",
                    new List<string>()
                    {
                        "Na minha maquina funciona!",
                        "aaaaoooo viiiiivvoooo"
                    }
                }
            };
    }
}
