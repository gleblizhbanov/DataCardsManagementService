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
                        var createViewModel = new CreateViewModel();
                        createViewModel.PropertyChanged += (sender, args) => this.Execute(ViewType.Home);
                        this.navigator.CurrentViewModel = createViewModel;
                        break;
                    case ViewType.Edit:
                        this.navigator.CurrentViewModel =  new EditViewModel();
                        break;
                    default:
                        break;
                }
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
