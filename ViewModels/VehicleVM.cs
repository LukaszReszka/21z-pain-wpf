using PAIN21Z_WPF2.MVVM;
using PAIN21Z_WPF2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PAIN21Z_WPF2.ViewModels
{
    public class VehicleVM : IViewModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Action Close { get; set; }
        public string Brand { get; set; } = "";
        public ulong MaxVelocity { get; set; } = 0;
        public DateTime ProductionDate { get; set; } = DateTime.Now;

        public string Type
        {
            get { return type; }
            set
            {
                type = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Type)));
            }
        }

        private string type;
        private VehiclesModel VehiclesModel { get; }
        private Vehicle Vehicle { get; }

        public VehicleVM(VehiclesModel vehiclesModel, Vehicle vehicle = null)
        {
            VehiclesModel = vehiclesModel;
            Vehicle = vehicle;
            Type = "osobowy";
            if(Vehicle != null)
            {
                Brand = Vehicle.Brand;
                MaxVelocity = Vehicle.MaxVelocity;
                ProductionDate = Vehicle.ProductionDate;
                Type = Vehicle.Type;
            }
        }

        public RelayCommand<VehicleVM> OkCom { get; } = new RelayCommand<VehicleVM>(
            (vehicleViewModel) => { vehicleViewModel.Ok(); }
            );

        public RelayCommand<VehicleVM> CancelCom { get; } = new RelayCommand<VehicleVM>(
            (vehicleViewModel) => { vehicleViewModel.Cancel(); }
            );

        public RelayCommand<VehicleVM> NextVehTypeCom { get; } = new RelayCommand<VehicleVM>(
            (vehicleViewModel) => { vehicleViewModel.OnClickVehicleTypePicker(); }
            );

        private void Ok()
        {
            if(Vehicle == null)
            {
                Vehicle vehicle = new Vehicle(Brand, MaxVelocity, ProductionDate, Type);
                VehiclesModel.Vehicles.Add(vehicle);

            }
            else
            {
                Vehicle.Brand = Brand;
                Vehicle.MaxVelocity = MaxVelocity;
                Vehicle.ProductionDate = ProductionDate;
                Vehicle.Type = Type;
            }
            Close?.Invoke();
        }

        private void Cancel()
        {
            Close?.Invoke();
        }

        private void OnClickVehicleTypePicker()
        {
            if(Type == "osobowy")
            {
                Type = "ciężarowy";
            } 
            else if(Type == "ciężarowy")
            {
                Type = "jednoślad";
            }
            else 
            {
                Type = "osobowy";
            }
        }
    }
}
