using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Xamarin.Forms.Xaml;
using static Week9PrismExampleApp.Models.WeatherItemModel;
using static Week9PrismExampleApp.Models.PokemonItemModel;

namespace Week9PrismExampleApp.ViewModels
{
    public class MoreInfoPageViewModel : BindableBase, INavigatedAware
    {
		INavigationService _navigationService;

		public DelegateCommand GoBackCommand { get; set; }

        private PokemonItem _pokemonItem;
        public PokemonItem PokemonItem
        {
            get { return _pokemonItem; }
            set { SetProperty(ref _pokemonItem, value); }
        }

        public MoreInfoPageViewModel(INavigationService navigationService)
        {
			_navigationService = navigationService;

			GoBackCommand = new DelegateCommand(GoBack);
		}

		private void GoBack()
		{
			_navigationService.GoBackAsync();
		}

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("WeatherItemInfo"))
            {
                PokemonItem = (PokemonItem)parameters["WeatherItemInfo"];
            }
        }
    }
}
