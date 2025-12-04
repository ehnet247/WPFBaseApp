using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using WpfBaseApp.Interfaces;

namespace WpfBaseApp.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IServiceProvider _serviceProvider;

        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public Guid CurrentWindowId => throw new NotImplementedException();

        public Window? Window => throw new NotImplementedException();

        public NavigationResult CloseWindow(Guid? windowId = null)
        {
            throw new NotImplementedException();
        }

        public ValueTask<NavigationResult> GoBackAsync(INavigationParameters? parameters = null, bool modal = false, bool animated = true)
        {
            throw new NotImplementedException();
        }

        public ValueTask<NavigationResult> GoBackToRootAsync(INavigationParameters? parameters = null, bool animated = true)
        {
            throw new NotImplementedException();
        }

        public ValueTask<NavigationResult> NavigateAsync(string uri, INavigationParameters? navigationParameters = null, bool modal = false, bool animated = true)
        {
            throw new NotImplementedException();
        }

        public ValueTask<NavigationResult> NavigateThrougFlyoutPageAsync(string stringUri, INavigationParameters? parameters = null)
        {
            throw new NotImplementedException();
        }

        public ValueTask<NavigationResult> OpenNewWindowAsync(string uri, INavigationParameters? parameters = null)
        {
            throw new NotImplementedException();
        }

        public void OpenNewWindow<T>()
        {
            var serviceCollection = new ServiceCollection();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var window = serviceProvider.GetRequiredService<T>() as Window;
            if (window != null)
            {
                window.Show();
            }
        }

        public void OpenMainWindow<T>()
        {
            var serviceCollection = new ServiceCollection();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var window = _serviceProvider.GetRequiredService<T>() as Window;
            if (window != null)
            {
                Application.Current.MainWindow = window;
                Application.Current.MainWindow.Show();
            }
        }

        public NavigationResult SelectTab(string tabName, INavigationParameters? parameters)
        {
            throw new NotImplementedException();
        }

        public NavigationResult ToggleFlyout(bool isPresented)
        {
            throw new NotImplementedException();
        }
    }
}
