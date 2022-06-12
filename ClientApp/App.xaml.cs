using System;
using System.Windows;
using ClientApp.State.Navigators;
using ClientApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace ClientApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceProvider = this.CreateServiceProvider();
            var window = new MainWindow
            {
                DataContext = serviceProvider.GetRequiredService<MainViewModel>()
            };

            window.Show();

            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            var services = new ServiceCollection();

            services.AddScoped<INavigator, Navigator>();
            services.AddScoped<MainViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
