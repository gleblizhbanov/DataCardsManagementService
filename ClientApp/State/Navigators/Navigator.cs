using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ClientApp.Commands;
using ClientApp.ViewModels;

namespace ClientApp.State.Navigators
{
    public class Navigator : INavigator, INotifyPropertyChanged
    {
        private ViewModelBase currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get => currentViewModel;
            set
            {
                this.currentViewModel = value;
                if (value is HomeViewModel model)
                {
                    model.CardsListViewModel.SelectionChanged += (sender, args) => OnPropertyChanged();
                }

                OnPropertyChanged();
            }
        }

        public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommand(this);

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
