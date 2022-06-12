using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using ClientApp.State.Navigators;
using ClientApp.ViewModels;

namespace ClientApp.Controls
{
    /// <summary>
    /// Interaction logic for NavigationBar.xaml
    /// </summary>
    public partial class NavigationBar : UserControl
    {
        public NavigationBar()
        {
            InitializeComponent();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Do you really want to delete selected cards?", "Delete Confirmation", MessageBoxButton.YesNo);
            if (result is MessageBoxResult.Yes)
            {
                var navigator = (INavigator)DataContext;
                var homeViewModel = (HomeViewModel)navigator.CurrentViewModel;
                var selectedCards = homeViewModel.CardsListViewModel.SelectedCards;
                if (selectedCards is null)
                {
                    return;
                }
                DeleteCards(selectedCards, navigator);
            }
        }

        private static void DeleteCards(IEnumerable<Models.Card> cards, INavigator navigator)
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:5000/"),
            };
            
            foreach (var card in cards)
            {
                client.DeleteAsync($"api/Cards/{card.Id}").Wait();
            }

            navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Home);
        }
    }
}
