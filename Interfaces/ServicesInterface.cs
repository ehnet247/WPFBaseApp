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

        ValueTask<NavigationResult> OpenNewWindowAsync(string uri);

        NavigationResult ToggleFlyout(bool isPresented);

        NavigationResult SelectTab(string tabName);

        ValueTask<NavigationResult> GoBackAsync(bool modal = false, bool animated = true);

        ValueTask<NavigationResult> GoBackToRootAsync(bool animated = true);

        ValueTask<NavigationResult> NavigateAsync(string uri, bool modal = false, bool animated = true);

        ValueTask<NavigationResult> NavigateThrougFlyoutPageAsync(string stringUri);
        void OpenNewWindow<T>();
        void OpenAsMainWindow<T>();
    }
    public record NavigationResult(bool Success, Exception? Exception);
}
