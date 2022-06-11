using System;
using System.Windows.Input;
using ClientApp.State.Navigators;
using ClientApp.ViewModels;

namespace ClientApp.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        private readonly INavigator navigator;

        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            this.navigator = navigator;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            if (parameter is ViewType type)
            {
                switch (type)
                {
                    case ViewType.Home:
                        this.navigator.CurrentViewModel = new HomeViewModel(CardsListViewModel.GetCardsListViewModel());
                        break;
                    case ViewType.Create:
                        this.navigator.CurrentViewModel = new CreateViewModel();
                        break;
                    default:
                        break;
                }
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
