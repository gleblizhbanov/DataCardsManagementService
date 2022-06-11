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
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public ICommand CurrentViewModelCommand => new UpdateCurrentViewModelCommand(this);
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
