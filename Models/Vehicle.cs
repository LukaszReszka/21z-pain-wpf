using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAIN21Z_WPF2.Models
{
    public class Vehicle : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string brand = "";
        public string Brand
        {
            get { return brand; }
            set { brand = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Brand))); }
        }

        private ulong maxV;
        public ulong MaxVelocity
        {
            get { return maxV; }
            set { maxV = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MaxVelocity))); }
        }

        private DateTime prodDate;
        public DateTime ProductionDate
        {
            get { return prodDate; }
            set { prodDate = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ProductionDate))); }
        }

        private string type = "";
        public string Type
        {
            get { return type; }
            set { type = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Type))); }
        }

        public Vehicle(string brand, ulong max_velocity, DateTime prod_date, string type)
        {
            Brand = brand;
            MaxVelocity = max_velocity;
            ProductionDate = prod_date;
            Type = type;
        }
    }
}
