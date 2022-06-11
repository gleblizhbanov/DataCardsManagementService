using System.Windows.Input;
using ClientApp.ViewModels;

namespace ClientApp.State.Navigators
{
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }

        ICommand CurrentViewModelCommand { get; }
    }
}
