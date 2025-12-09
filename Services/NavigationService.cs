using Microsoft.Extensions.DependencyInjection;
using System;
using System.CodeDom;
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

        public ValueTask<NavigationResult> GoBackAsync(bool modal = false, bool animated = true)
        {
            throw new NotImplementedException();
        }

        public ValueTask<NavigationResult> GoBackToRootAsync(bool animated = true)
        {
            throw new NotImplementedException();
        }

        public ValueTask<NavigationResult> NavigateAsync(string uri, bool modal = false, bool animated = true)
        {
            throw new NotImplementedException();
        }

        public ValueTask<NavigationResult> NavigateThrougFlyoutPageAsync(string stringUri)
        {
            throw new NotImplementedException();
        }

        public ValueTask<NavigationResult> OpenNewWindowAsync(string uri)
        {
            throw new NotImplementedException();
        }

        public void OpenNewWindow<T>() where T : notnull
        {
            var serviceCollection = new ServiceCollection();
            var service = _serviceProvider.GetRequiredService<T>();
            if (service is Window window)
            {
                window.Show();
            }
        }

        public void OpenAsMainWindow<T>() where T : notnull
        {
            var type = typeof(T);
            var serviceCollection = new ServiceCollection();
            var service = _serviceProvider.GetRequiredService<T>();
            if (service is Window window)
            {
                Application.Current.MainWindow = window;
                Application.Current.MainWindow.Show();
            }
        }

        public NavigationResult SelectTab(string tabName)
        {
            throw new NotImplementedException();
        }

        public NavigationResult ToggleFlyout(bool isPresented)
        {
            throw new NotImplementedException();
        }
    }
}
