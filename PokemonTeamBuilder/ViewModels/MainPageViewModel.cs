using PokemonTeamBuilder.Model;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using static PokemonTeamBuilder.Model.PokemonItemModel;

namespace PokemonTeamBuilder.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        public DelegateCommand GetPokemonForNameCommand { get; set; }
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private string _nameEnteredByUser;
        public string NameEnteredByUser
        {
            get { return _nameEnteredByUser; }
            set { SetProperty(ref _nameEnteredByUser, value); }
        }
        private string _pokemonNameByUser;
        public string PokemonNameByUser
        {
            get { return _pokemonNameByUser; }
            set { SetProperty(ref _pokemonNameByUser, value); }
        }
        private ObservableCollection<PokemonItem> _pokemonCollection = new ObservableCollection<PokemonItem>();
        public ObservableCollection<PokemonItem> PokemonCollection
        {
            get { return _pokemonCollection; }
            set { SetProperty(ref _pokemonCollection, value); }
        }
        INavigationService _navigationServie;
        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationServie = navigationService;
            GetPokemonForNameCommand = new DelegateCommand(GetPokemonInfo);
        }

        internal async void GetPokemonInfo()
        {
            HttpClient client = new HttpClient();
            var uri = new Uri($"https://pokeapi.co/api/v2/pokemon/{NameEnteredByUser}");
           var response = await client.GetAsync(uri);
            PokemonItem pokemonData = null;
            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                pokemonData = PokemonItem.FromJson(content);
            }
            PokemonCollection.Add(pokemonData);
        }
        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }
    }
}

