using System.Collections.Generic;
using ClientApp.Models;

namespace ClientApp.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public HomeViewModel(CardsListViewModel cardsListViewModel)
        {
            this.CardsListViewModel = cardsListViewModel;
        }

        public CardsListViewModel CardsListViewModel { get; set; }
    }
}
