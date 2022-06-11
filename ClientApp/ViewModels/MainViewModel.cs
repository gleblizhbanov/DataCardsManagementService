using ClientApp.State.Navigators;

namespace ClientApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public INavigator Navigator { get; set; } = new Navigator();
    }
}
