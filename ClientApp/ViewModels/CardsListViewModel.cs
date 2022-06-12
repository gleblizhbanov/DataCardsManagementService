using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using ClientApp.Models;
using Newtonsoft.Json;

namespace ClientApp.ViewModels
{
    public class CardsListViewModel : ViewModelBase
    {
        private readonly HttpClient client;
        private ObservableCollection<Card> cards;
        private IList<Card> selectedCards;

        public CardsListViewModel()
        {
            this.client = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:5000/"),
            };
        }

        public ObservableCollection<Card> Cards
        {
            get => this.cards is null ? null : new ObservableCollection<Card>(this.cards.Skip((Page - 1) * PageSize).Take(PageSize));
            set
            {
                this.cards = value;
                this.OnPropertyChanged();
            }
        }

        public IList<Card> SelectedCards
        {
            get => selectedCards;
            set
            {
                this.selectedCards = value;
                this.OnSelectionChanged();
            }
        }

        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = int.MaxValue;

        public event PropertyChangedEventHandler SelectionChanged;

        public static CardsListViewModel GetCardsListViewModel()
        {
            var viewModel = new CardsListViewModel();
            viewModel.LoadCards();
            return viewModel;
        }

        protected virtual void OnSelectionChanged([CallerMemberName] string propertyName = null)
        {
            SelectionChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void LoadCards()
        {
            this.client.GetStringAsync("api/Cards").ContinueWith(task =>
            {
                if (task.Exception is null)
                {
                    this.Cards = JsonConvert.DeserializeObject<ObservableCollection<Card>>(task.Result);
                }
            });
        }
    }
}
