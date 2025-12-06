using CommunityToolkit.Mvvm.ComponentModel;
using Serilog;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Text;
using WpfBaseApp.Interfaces;

namespace WpfBaseApp.ViewModels
{
    public partial class MainViewModel : ObservableRecipient, IMainViewModel
    {
        [ObservableProperty]
        private string _title = string.Empty;
        public MainViewModel()
        {
            // Log entering the MainViewModel constructor
            var logger = Log.Logger;
            logger.Debug("MainViewModel()");
            Title = "Main Window";
        }
    }
}
