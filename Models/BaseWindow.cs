using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using WpfBaseApp.Interfaces;

namespace WpfBaseApp.Models
{
    public class BaseWindow : Window
    {
        private IBaseViewModel _viewModel;
        public BaseWindow()
        {
            this.Loaded += Window_Loaded;
        }

        public void SetViewModel(IBaseViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void Show()
        {
            base.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (_viewModel != null)
            {
                this.DataContext = _viewModel;
            }
        }

        //Unsubscribe events in finalizer
        ~BaseWindow()
        {
            this.Loaded -= Window_Loaded;
        }
    }
}
