using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System.CodeDom;
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
            if (_serviceProvider == null)
                throw new Exception("Unable to retrieve services");
            var mainViewModel = _serviceProvider.GetRequiredService<IMainView>();
            var navigationService = _serviceProvider.GetRequiredService<INavigationService>();
            var mainWindow = _serviceProvider.GetRequiredService<IMainView>();
            navigationService.OpenMainWindow<IMainView>();
            mainWindow.Show();
        }

        protected void OnExit(object sender, ExitEventArgs e)
        {
            // Dispose of services if needed
            if (_serviceProvider is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Configure logging
            services.AddLogging()

            // Register Services
            .AddSingleton<INavigationService, WpfBaseApp.Services.NavigationService>()

            // Register ViewModels
            .AddSingleton<IMainViewModel, MainViewModel>()

            // Register Views
            .AddSingleton<IMainView, MainWindow>();

        }

        private void InitializeLogger()
        {
            var eventLevel = Serilog.Events.LogEventLevel.Debug;
            Log.Logger = new LoggerConfiguration()
                    .WriteTo.File("Logs\\log_.txt",eventLevel)
                    .CreateLogger();
            //Log.Logger = new LoggerConfiguration()
            //    .ReadFrom.AppSettings()
            //    .CreateLogger();
        }
    }

}
