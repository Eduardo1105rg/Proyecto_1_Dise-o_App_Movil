using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AppMovilProyecto1.Models;
using Newtonsoft.Json;

namespace AppMovilProyecto1.Services
{
    class ExchangeService
    {

        private static string BaseURL = "https://v6.exchangerate-api.com/v6/8c5f4efc1fc0fe962af7a9f6";
        public static API_Obj Import(string divisaBase = "USD")
        {
            try
            {
                string URLString = $"{BaseURL}/latest/{divisaBase}";
                using (var webClient = new WebClient())
                {
                    var json = webClient.DownloadString(URLString);
                    API_Obj rates = JsonConvert.DeserializeObject<API_Obj>(json);
                    return rates;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static Dictionary<string, List<double>> GetWeeklyHistory(string baseCurrency)
        {
            try
            {
                var weeklyHistory = new Dictionary<string, List<double>>();
                var today = DateTime.UtcNow;

                // Hacemos 7 consultas para los ultimos 7 días
                for (int i = 0; i < 7; i++)
                {
                    var date = today.AddDays(-i);
                    string URLString = $"https://v6.exchangerate-api.com/v6/8c5f4efc1fc0fe962af7a9f6/history/{baseCurrency}/{date.Year}/{date.Month}/{date.Day}";

                    using (var webClient = new WebClient())
                    {
                        var json = webClient.DownloadString(URLString);
                        var historicalData = JsonConvert.DeserializeObject<API_Obj>(json);

                        if (historicalData?.conversion_rates != null)
                        {
                            foreach (var rate in historicalData.conversion_rates.GetType().GetProperties())
                            {
                                var currency = rate.Name;
                                var value = (double)rate.GetValue(historicalData.conversion_rates);

                                if (!weeklyHistory.ContainsKey(currency))
                                    weeklyHistory[currency] = new List<double>();

                                weeklyHistory[currency].Add(value);
                            }
                        }
                    }
                }

                return weeklyHistory;
            }
            catch (Exception ex)
            {
                return null;
            }
        }




        // ============================== Apartadado para el proceso de conversion entre divisas. ===================================================



        public static double? optencion_tipo_de_cambio_conversion(string divisa_origen, string divisa_destino)
        {
            try
            {
                var fecha = DateTime.UtcNow;

                string URLString = $"https://v6.exchangerate-api.com/v6/8c5f4efc1fc0fe962af7a9f6/history/{divisa_origen}/{fecha.Year}/{fecha.Month}/{fecha.Day}";
                using (var webClient = new WebClient())
                {
                    var json = webClient.DownloadString(URLString);
                    var historicalData = JsonConvert.DeserializeObject<API_Obj>(json);

                    if (historicalData?.conversion_rates != null)
                    {
                        var rateProperty = historicalData.conversion_rates.GetType().GetProperty(divisa_destino);
                        if (rateProperty != null)
                        {
                            var value = (double)rateProperty.GetValue(historicalData.conversion_rates);
                            return value;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                return null;
            }
            return null;

        }

    }
}
