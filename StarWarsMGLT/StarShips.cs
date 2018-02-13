using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsMGLT
{
    public class StarShips
    {
        private static string _baseUri = "";
        internal const string Uri = "baseURI";
        public const string StarshipUri = "api/starships/?page=";

        public StarShips()
        {
            _baseUri = System.Configuration.ConfigurationManager.AppSettings[Uri];
        }
        /// <summary>
        /// Initiate the calculation to get the number of resupply of all the availabe StarShips.
        /// </summary>
        /// <param name="distanceInMglt"></param>
        /// <returns></returns>
        public bool ProcessReSupply(double distanceInMglt)
        {
            bool isSuccess = false;
            int pageNo = 1;
            try
            {
                __calculateResupply(distanceInMglt, ref isSuccess, ref pageNo);
                Console.WriteLine("\n StarWars finding of Resupply is completed.... Press any key to exit!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting SW starships. Error:" + ex.Message);
            }
            return isSuccess;
        }

        private static void __calculateResupply(double distanceInMglt, ref bool isSuccess, ref int pageNo)
        {
            for (var i = 1; i <= pageNo; i++)
            {
                //Get the dynamic response from the API
                dynamic response = __getHttpResponse(_baseUri, StarshipUri + i) ??
                                   throw new ArgumentNullException();

                //Allow the next = null only once to read the models
                if (!response.next.ToString().Equals(string.Empty))
                    pageNo += 1;
                else
                    pageNo = 0;

                foreach (var item in response.results)
                {
                    //To check for only numbers in the string
                    var starshipMglt = item != null && NumberHelper.CheckIsNumber(item.MGLT.ToString()) ? int.Parse(item.MGLT.ToString()) : 0;
                    if (starshipMglt == 0) continue;
                    var calc = distanceInMglt / starshipMglt;
                    Console.WriteLine("Starship Name: " + item?.name + ", Stops for resupply:" + Math.Ceiling(calc));
                }

                isSuccess = true;
            }
        }

        private static dynamic __getHttpResponse(string baseUri, string relativeUri)
        {
            var httpClient = new HttpClient { BaseAddress = new Uri(baseUri) };
            var httpResponse = httpClient.GetAsync(relativeUri).Result;
            dynamic response = httpResponse.Content.ReadAsAsync<object>().Result;
            return response;
        }
    }
}
