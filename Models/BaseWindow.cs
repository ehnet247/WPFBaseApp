using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using WpfBaseApp.Interfaces;

namespace WpfBaseApp.Models
{
    public class BaseWindow : Window
    {
        private IBaseViewModel? _viewModel;
        private bool _windowLoaded = false;
        public BaseWindow()
        {
            this.Loaded += Window_Loaded;
            this.Unloaded += Window_Unloaded;
        }

        public void SetViewModel(IBaseViewModel viewModel)
        {
            _viewModel = viewModel;
            if (_windowLoaded && _viewModel != null)
            {
                this.DataContext = _viewModel;
            }
        }

        public void Show()
        {
            base.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _windowLoaded = true;
            if (_viewModel != null)
            {
                this.DataContext = _viewModel;
            }
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            _windowLoaded = false;
        }

        //Unsubscribe events in finalizer
        ~BaseWindow()
        {
            this.Loaded -= Window_Loaded;
            this.Unloaded -= Window_Unloaded;
        }
    }
}
