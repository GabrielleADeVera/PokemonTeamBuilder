using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Net.Http;
using static Week9PrismExampleApp.Models.WeatherItemModel;
using System.Runtime.CompilerServices;
using Microsoft.AppCenter.Analytics;
using static Week9PrismExampleApp.Models.PokemonItemModel;

[assembly: InternalsVisibleTo("Week9PrismExampleUnitTests")]
namespace Week9PrismExampleApp.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        public DelegateCommand NavToNewPageCommand { get; set; }
        public DelegateCommand GetWeatherForLocationCommand { get; set; }
        public DelegateCommand GetPokemonFromNameCommand { get; set; }
        public DelegateCommand<PokemonItem> NavToMoreInfoPageCommand { get; set; }

        private string _buttonText;
        public string ButtonText
        {
            get { return _buttonText; }
            set { SetProperty(ref _buttonText, value); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _locationEnteredByUser;
        public string LocationEnteredByUser
        {
            get { return _locationEnteredByUser; }
            set { SetProperty(ref _locationEnteredByUser, value); }
        }

      /*  private ObservableCollection<WeatherItem> _weatherCollection = new ObservableCollection<WeatherItem>();
        public ObservableCollection<WeatherItem> WeatherCollection
        {
            get { return _weatherCollection; }
            set { SetProperty(ref _weatherCollection, value); }
        }
        */

        private ObservableCollection<PokemonItem> _pokemonCollection = new ObservableCollection<PokemonItem>();
        public ObservableCollection<PokemonItem> PokemonCollection
        {
            get { return _pokemonCollection; }
            set { SetProperty(ref _pokemonCollection, value); }
        }

        INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            NavToNewPageCommand = new DelegateCommand(NavToNewPage);
            GetPokemonFromNameCommand = new DelegateCommand(GetPokemonFromName);
          //  GetWeatherForLocationCommand = new DelegateCommand(GetWeatherForLocation);
            NavToMoreInfoPageCommand = new DelegateCommand<PokemonItem>(NavToMoreInfoPage);

            Title = "Xamarin Forms Application + Prism";
            ButtonText = "Add Name";
        }

        private async void NavToMoreInfoPage(PokemonItem pokemonItem)
        {
            var navParams = new NavigationParameters();
            navParams.Add("WeatherItemInfo", pokemonItem);
            await _navigationService.NavigateAsync("MoreInfoPage", navParams);
        }

        internal async void GetPokemonFromName(){
            Analytics.TrackEvent("GetWeatherButtonTapped", new Dictionary<string, string> {
                { "WeatherLocation", LocationEnteredByUser},
            });

            HttpClient client = new HttpClient();
            var uri = new Uri(string.Format( $"{ApiKeys.PokemonKey}" + LocationEnteredByUser));
            var response = await client.GetAsync(uri);
            PokemonItem pokemonData = null;
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                pokemonData = PokemonItem.FromJson(content);
            }
            PokemonCollection.Add(pokemonData);
        }
        /*
        internal async void GetWeatherForLocation()
        {
            Analytics.TrackEvent("GetWeatherButtonTapped", new Dictionary<string, string> {
                { "WeatherLocation", LocationEnteredByUser},
            });

            HttpClient client = new HttpClient();
            var uri = new Uri(
                string.Format(
                    $"http://api.openweathermap.org/data/2.5/weather?q={LocationEnteredByUser}&units=imperial&APPID=" +
                    $"{ApiKeys.WeatherKey}"));
            var response = await client.GetAsync(uri);
            WeatherItem weatherData = null;
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                weatherData = WeatherItem.FromJson(content);
            }
            WeatherCollection.Add(weatherData);
        }
        */
        private async void NavToNewPage()
        {
            var navParams = new NavigationParameters();
            navParams.Add("NavFromPage", "MainPageViewModel");
            await _navigationService.NavigateAsync("SamplePageForNavigation", navParams);
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
        }
    }
}

