using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PAIN21Z_WPF2.MVVM
{
    class WindowService : IWindowService
    {
        public void Show(IViewModel viewModel)
        {
            Window win = new Window
            {
                Title = "Pojazdy",
                SizeToContent = SizeToContent.WidthAndHeight,
                Content = viewModel
            };
            viewModel.Close = win.Close;
            win.Show();
        }

        public void ShowDialog(IViewModel viewModel)
        {
            Window win = new Window
            {
                Title = "Pojazd",
                SizeToContent = SizeToContent.WidthAndHeight,
                Content = viewModel
            };
            viewModel.Close = win.Close;
            win.ShowDialog();
        }
    }
}
