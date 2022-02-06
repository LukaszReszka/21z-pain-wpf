using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAIN21Z_WPF2.Models
{
    public class VehiclesModel
    {
        public ObservableCollection<Vehicle> Vehicles { get; private set; } = new ObservableCollection<Vehicle>();

    }
}
