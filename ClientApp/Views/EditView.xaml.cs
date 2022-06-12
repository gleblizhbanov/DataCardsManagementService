using System;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using ClientApp.Models;
using ClientApp.ViewModels;
using Newtonsoft.Json;

namespace ClientApp.Views
{
    /// <summary>
    /// Interaction logic for EditView.xaml
    /// </summary>
    public partial class EditView : UserControl
    {
        public EditView()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (EditViewModel)DataContext;
            var card = viewModel.Card;
            var client = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:5000/"),
            };

            var json = JsonConvert.SerializeObject(card);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            client.PutAsync($"api/Cards/{card.Id}", content).ContinueWith(task => viewModel.Card = new Card()).Wait();
        }
    }
}
