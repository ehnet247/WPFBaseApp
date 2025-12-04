using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Navigation;
using WpfbaseApp.Views;
using WpfBaseApp.Interfaces;
using WpfBaseApp.ViewModels;
using WpfBaseApp.Services;

namespace WpfbaseApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;
        public App()
        {
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            _serviceProvider = serviceCollection.BuildServiceProvider();
            //ConfigureServices(serviceCollection);
            var mainViewModel = _serviceProvider.GetRequiredService<IMainView>();
            var mainWindow = _serviceProvider.GetRequiredService<IMainView>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Configure Logging
            services.AddLogging();

            // Register Services
            services.AddSingleton<INavigationService, WpfBaseApp.Services.NavigationService>();

            // Register ViewModels
            services.AddSingleton<IMainViewModel, MainViewModel>();

            // Register Views
            services.AddSingleton<IMainView, MainWindow>();
        }

        protected void OnExit(object sender, ExitEventArgs e)
        {
            // Dispose of services if needed
            if (_serviceProvider is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }

}
