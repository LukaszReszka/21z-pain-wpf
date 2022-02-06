using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PAIN21Z_WPF2
{
    public partial class App : Application
    {
        public MVVM.IWindowService WindowService { get; } = new MVVM.WindowService();

        private Models.VehiclesModel VehiclesModel { get; } = new Models.VehiclesModel();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ViewModels.VehiclesVM vehiclesViewModel = new ViewModels.VehiclesVM(VehiclesModel);
            WindowService.Show(vehiclesViewModel);
        }
    }
}
