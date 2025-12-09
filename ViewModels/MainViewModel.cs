using CommunityToolkit.Mvvm.ComponentModel;
using Serilog;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Text;
using System.Windows;
using WpfBaseApp.Interfaces;

namespace WpfBaseApp.ViewModels
{
    public partial class MainViewModel : ObservableRecipient, IMainViewModel
    {
        [ObservableProperty]
        private string _title = string.Empty;
        [ObservableProperty]
        private bool _darkMode = false;
        partial void OnDarkModeChanged(bool value)
        {
            if (value)
            {
#pragma warning disable WPF0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
                Application.Current.ThemeMode = ThemeMode.Dark;
#pragma warning restore WPF0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
            }
            else
            {
#pragma warning disable WPF0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
                Application.Current.ThemeMode = ThemeMode.Light;
#pragma warning restore WPF0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
            }
        }
        public MainViewModel()
        {
            // Log entering the MainViewModel constructor
            var logger = Log.Logger;
            logger.Debug("MainViewModel()");
            Title = "Main Window";
        }
    }
}
