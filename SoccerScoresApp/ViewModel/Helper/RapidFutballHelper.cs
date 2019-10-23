using Newtonsoft.Json;
using SoccerScoresApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SoccerScoresApp.ViewModel.Helper
{
    class RapidFutballHelper
    {
        private const string BASE_URL = "https://api-football-v1.p.rapidapi.com";
        private const string BASE_HOST = "api-football-v1.p.rapidapi.com";
        private const string GET_COUNTRIES_ENDPOINT = "/v2/countries";
        private const string GET_LEAGUES_ENDPOINT = "v2/leagues/country/{0}/{1}";
        private const string GET_TEAMS_ENDPOINT = "v2/teams/league/{0}";
        private const string API_KEY = "f08c685137msh73607b9c030edcfp176fc7jsn2d553ffca885";
        private static string[][] CUSTOM_HEADERS = {
           new string[] {"x-rapidapi-host",BASE_HOST},
           new string[]  {"x-rapidapi-key", API_KEY }
        };        

        public static async Task<List<Country>> GetCountries()
        {
            List<Country> Contries = new List<Country>();

            string URL = BASE_URL + GET_COUNTRIES_ENDPOINT;

            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, URL);

                foreach (string[] customHeader in CUSTOM_HEADERS)
                {
                    requestMessage.Headers.Add(customHeader[0].ToString(), customHeader[1].ToString());
                }

                var response = await client.SendAsync(requestMessage);

                string jsonString = await response.Content.ReadAsStringAsync();

                APICountry json = JsonConvert.DeserializeObject<APICountry>(jsonString);

                Contries = json.api.countries;

            }
            return Contries;
        }

        public static async Task<List<League>> GetLeagues(string CountryName)
        {
            List<League> Leagues = new List<League>();

            string URL = BASE_URL + String.Format(GET_LEAGUES_ENDPOINT, CountryName, DateTime.Now.Year.ToString());

            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, URL);

                foreach (string[] customHeader in CUSTOM_HEADERS)
                {
                    requestMessage.Headers.Add(customHeader[0].ToString(), customHeader[1].ToString());
                }

                var response = await client.SendAsync(requestMessage);

                string jsonString = await response.Content.ReadAsStringAsync();

                APILeague json = JsonConvert.DeserializeObject<APILeague>(jsonString);

                Leagues = json.api.leagues;

            }
            return Leagues;
        }

        public static async Task<List<Team>> GetTeams(string LeagueId)
        {
            List<Team> Teams = new List<Team>();

            string URL = BASE_URL + String.Format(GET_TEAMS_ENDPOINT, LeagueId);

            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, URL);

                foreach (string[] customHeader in CUSTOM_HEADERS)
                {
                    requestMessage.Headers.Add(customHeader[0].ToString(), customHeader[1].ToString());
                }

                var response = await client.SendAsync(requestMessage);

                string jsonString = await response.Content.ReadAsStringAsync();

                APITeam json = JsonConvert.DeserializeObject<APITeam>(jsonString);

                Teams = json.api.teams;

            }
            return Teams;
        }


    }
}
