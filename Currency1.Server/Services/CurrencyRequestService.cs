using Currency1.Server.Models;
using CurrencyStore;
using Newtonsoft.Json;
using System.Net.Http;

namespace Currency1.Server.Services
{
    public interface ICurrencyService
    {
        public Task<Root?> GetRates(string requestUrl);
        public Task<List<Currency>?> GetExchangeRates();

        public Task<decimal?> GetRate(decimal? amount, string from, string to, string date);
    }
    public class CurrencyRequestService : ICurrencyService
    {
        private HttpClient httpClient { get; set; }//TO DO: check if initialized, return current else return new

        public CurrencyRequestService()
        {
            httpClient = new HttpClient();
        }
        public async Task<Root?> GetRates(string requestUrl)
        {
            if (requestUrl == null)
                return null;

            using (httpClient = new HttpClient())
            {
                string json = await httpClient.GetStringAsync(requestUrl);
                return JsonConvert.DeserializeObject<Root>(json);
            }
        }

        public async Task<List<Currency>?> GetExchangeRates()
        {
            using (httpClient = new HttpClient())
            {
                var result = await httpClient.GetStringAsync("http://localhost:5016/currencies");
                var curencies = JsonConvert.DeserializeObject<List<StoredCurrency>>(result);
                return curencies.Select(s => new Currency { Name = s.Name, FullName = s.FullName }).ToList();
            }
        }

        public async Task<decimal?> GetRate(decimal? amount, string from, string to, string date = "2024-02-28")//TO FIX: make something smarter
        {
            string apiUrl = $"https://data-api.ecb.europa.eu/service/data/EXR/M.{to}.{from}.SP00.A?updatedAfter={date}&detail=dataonly&format=jsondata"; // ECB API URL

            var response = await GetRates(apiUrl);
            var currencySeries = response.dataSets[0].series.Values.Select(s => s.observations["0"].FirstOrDefault()).ToList();// TO DO: add parsing checks

            return currencySeries[0] * amount;
        }


    }
}
