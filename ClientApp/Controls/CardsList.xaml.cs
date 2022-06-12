using System.Linq;
using System.Windows.Controls;
using ClientApp.ViewModels;

namespace ClientApp.Controls
{
    /// <summary>
    /// Interaction logic for CardsListRow.xaml
    /// </summary>
    public partial class CardsList : UserControl
    {
        public CardsList()
        {
            InitializeComponent();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var viewModel = (CardsListViewModel)DataContext;
            if (viewModel != null)
            {
                viewModel.SelectedCards = ((ListView)sender).SelectedItems.Cast<Models.Card>().ToList();
            }
        }
    }
}
