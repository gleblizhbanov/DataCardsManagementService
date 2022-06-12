using ClientApp.Models;

namespace ClientApp.ViewModels
{
    public class CreateViewModel : ViewModelBase
    {
        private Card card = new Card();

        public Card Card 
        {
            get => this.card;
            set
            {
                this.card = value;
                this.OnPropertyChanged();
            }
        }
    }
}
