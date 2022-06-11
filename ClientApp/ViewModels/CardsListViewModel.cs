using System;
using System.Collections.Generic;
using System.Net.Http;
using ClientApp.Models;
using Newtonsoft.Json;

namespace ClientApp.ViewModels
{
    public class CardsListViewModel
    {
        private readonly HttpClient client;

        public CardsListViewModel()
        {
            this.client = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:5000/"),
            };
        }

        public IList<Card> Cards { get; set; }

        public static CardsListViewModel GetCardsListViewModel()
        {
            var viewModel = new CardsListViewModel();
            viewModel.LoadCards();
            return viewModel;
        }

        private void LoadCards()
        {
            this.client.GetStringAsync("api/Cards").ContinueWith(task =>
            {
                if (task.Exception is null)
                {
                    this.Cards = JsonConvert.DeserializeObject<List<Card>>(task.Result);
                }
            });
        }
    }
}
