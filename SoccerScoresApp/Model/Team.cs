using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerScoresApp.Model
{
    public class Team
    {
        public int team_id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string logo { get; set; }
        public string country { get; set; }
        public int founded { get; set; }
        public string venue_name { get; set; }
        public string venue_surface { get; set; }
        public string venue_address { get; set; }
        public string venue_city { get; set; }
        public int venue_capacity { get; set; }
    }

    public class APITeamResults
    {
        public int results { get; set; }
        public List<Team> teams { get; set; }
    }

    public class APITeam
    {
        public APITeamResults api { get; set; }
    }

}
