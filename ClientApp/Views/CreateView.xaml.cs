using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClientApp.Models;
using ClientApp.ViewModels;
using Newtonsoft.Json;

namespace ClientApp.Views
{
    /// <summary>
    /// Interaction logic for CreateView.xaml
    /// </summary>
    public partial class CreateView : UserControl
    {
        public CreateView()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (CreateViewModel)DataContext;
            var card = viewModel.Card;
            var client = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:5000/"),
            };

            var json = JsonConvert.SerializeObject(card);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            client.PostAsync("api/Cards", content).ContinueWith(task => viewModel.Card = new Card()).Wait();
        }
    }
}
