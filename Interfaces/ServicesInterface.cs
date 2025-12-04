using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using WpfBaseApp.Services;

namespace WpfBaseApp.Interfaces
{
    public interface INavigationService
    {
        Guid CurrentWindowId { get; }

        Window? Window { get; }

        NavigationResult CloseWindow(Guid? windowId = null);

        ValueTask<NavigationResult> OpenNewWindowAsync(string uri, INavigationParameters? parameters = null);

        NavigationResult ToggleFlyout(bool isPresented);

        NavigationResult SelectTab(string tabName, INavigationParameters? parameters);

        ValueTask<NavigationResult> GoBackAsync(INavigationParameters? parameters = null, bool modal = false, bool animated = true);

        ValueTask<NavigationResult> GoBackToRootAsync(INavigationParameters? parameters = null, bool animated = true);

        ValueTask<NavigationResult> NavigateAsync(string uri, INavigationParameters? navigationParameters = null, bool modal = false, bool animated = true);

        ValueTask<NavigationResult> NavigateThrougFlyoutPageAsync(string stringUri, INavigationParameters? parameters = null);
        void OpenNewWindow<T>();
        void OpenMainWindow<T>();
    }
    public record NavigationResult(bool Success, Exception? Exception);
}
