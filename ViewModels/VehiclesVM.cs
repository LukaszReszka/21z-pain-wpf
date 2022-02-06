using PAIN21Z_WPF2.MVVM;
using PAIN21Z_WPF2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace PAIN21Z_WPF2.ViewModels 
{

    enum FilterIndex
    {
        AllRecords = 0,
        LessThan100,
        MoreEqual100

    }

    public class VehiclesVM : IViewModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICollectionView Vehicles { get; }
        public Vehicle SelectedVehicle
        {
            get => selectedVehicle;
            set
            {
                selectedVehicle = value;
                ModifyCom?.NotifyCanExecuteChanged();
                DeleteCom?.NotifyCanExecuteChanged();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedVehicle)));
            }
        }

        public Action Close { get; set; }
        public RelayCommand<object> AddCom { get; }
        public RelayCommand<object> ModifyCom { get; }
        public RelayCommand<object> DeleteCom { get; }
        public RelayCommand<object> NewWinCom { get; }
        public int SelectedFilter
        {
            get => (int)selectedFilter;
            set
            {
                selectedFilter = (FilterIndex)value;
                collectionViewSource.View.Refresh();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedFilter)));
            }
        }

        private VehiclesModel VehiclesModel { get; }
        private readonly CollectionViewSource collectionViewSource;
        private Vehicle selectedVehicle;
        private FilterIndex selectedFilter;

        public VehiclesVM(VehiclesModel vehiclesModel)
        {
            VehiclesModel = vehiclesModel;
            collectionViewSource = new CollectionViewSource
            {
                Source = VehiclesModel.Vehicles
            };
            collectionViewSource.LiveFilteringProperties.Add(nameof(Vehicle.MaxVelocity));
            collectionViewSource.IsLiveFilteringRequested = true;
            collectionViewSource.View.Filter = (o) => FilterVehicles((Vehicle)o);
            Vehicles = collectionViewSource.View;
            SelectedFilter = (int)FilterIndex.AllRecords;

            AddCom = new RelayCommand<object>(o => AddVehicle());
            ModifyCom = new RelayCommand<object>(o => ModifyVehicle(SelectedVehicle), o => SelectedVehicle != null);
            DeleteCom = new RelayCommand<object>(o => DeleteVehicle(SelectedVehicle), o => SelectedVehicle != null);
            NewWinCom = new RelayCommand<object>(o => CreateNewWindow());
        }

        private void CreateNewWindow()
        {
            VehiclesVM vehiclesViewModel = new VehiclesVM(VehiclesModel);
            ((App) Application.Current).WindowService.Show(vehiclesViewModel);
        }

        private void AddVehicle()
        {
            VehicleVM vehicleViewModel = new VehicleVM(VehiclesModel);
            ((App)Application.Current).WindowService.ShowDialog(vehicleViewModel);
        }

        private void ModifyVehicle(Vehicle vehicle)
        {
            if (vehicle != null)
            {
                VehicleVM vehicleViewModel = new VehicleVM(VehiclesModel, vehicle);
                ((App)Application.Current).WindowService.ShowDialog(vehicleViewModel);
            }
        }

        private void DeleteVehicle(Vehicle vehicle)
        {
            if (vehicle != null)
            {
                VehiclesModel.Vehicles.Remove(vehicle);
            }
        }

        private bool FilterVehicles(Vehicle vehicle)
        {
            return selectedFilter == FilterIndex.AllRecords || (selectedFilter == FilterIndex.LessThan100 && vehicle.MaxVelocity < 100)
                || (selectedFilter == FilterIndex.MoreEqual100 && vehicle.MaxVelocity >= 100);
        }
    }
}