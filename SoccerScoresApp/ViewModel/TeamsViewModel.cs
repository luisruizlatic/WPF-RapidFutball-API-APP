using SoccerScoresApp.Model;
using SoccerScoresApp.ViewModel.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerScoresApp.ViewModel 
{
    class TeamsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Country> Countries { get; set; }
        public ObservableCollection<League> Leagues { get; set; }
        public ObservableCollection<Team> Teams { get; set; }

        public TeamsViewModel()
        {

            Countries = new ObservableCollection<Country>();
            UpdateCountries();
            Leagues = new ObservableCollection<League>();
            Teams = new ObservableCollection<Team>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Country selectedCountry;

        public Country SelectedCountry
        {
            get { return selectedCountry; }
            set {
                if (value != null)
                {
                    selectedCountry = value;
                    OnPropertyChanged("SelectedCountry");
                    UpdateLeagues();
                }
                
            }
        }

        private Country selectedLeague;

        public Country SelectedLeague
        {
            get { return selectedLeague; }
            set
            {
                if (value != null)
                {
                    selectedLeague = value;
                    OnPropertyChanged("SelectedLeague");
                }
            }
        }

        private async void UpdateLeagues()
        {
            var LeaguesAPIList = await RapidFutballHelper.GetLeagues(SelectedCountry.country);
            Leagues.Clear();            
            foreach (var League in LeaguesAPIList)
            {
                Leagues.Add(League);
            }
        }       

        private async void UpdateCountries()
        {
            var CountriesAPIList = await RapidFutballHelper.GetCountries();
            Countries.Clear();
            Teams.Clear();
            foreach (var Country in CountriesAPIList)
            {
                Countries.Add(Country);
            }
        }

        private async void UpdateTeams()
        {
            var TeamsAPIList = await RapidFutballHelper.GetTeams(SelectedLeague.code);
            Teams.Clear();
            foreach (var Team in TeamsAPIList)
            {
                Teams.Add(Team);
            }
        }

    }
}
