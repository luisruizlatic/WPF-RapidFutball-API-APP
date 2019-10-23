using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerScoresApp.Model
{
    public class Country
    {
        public string country { get; set; }
        public string code { get; set; }
        public string flag { get; set; }
    }

    public class APICountryResults
    {
        public int results { get; set; }
        public List<Country> countries { get; set; }
    }

    public class APICountry
    {
        public APICountryResults api { get; set; }
    }

}
