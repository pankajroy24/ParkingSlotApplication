using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagement
{
    public enum VehicleType { NONE,SUV, SEDAN, HATCHBACK }
    public class Vehicle
    {
        public VehicleType Type { get; set; }
        public string LicensePlate { get; set; }

        public Vehicle(VehicleType type, string licensePlate)
        {
            Type = type;
            LicensePlate = licensePlate;
        }

        public override string ToString()
        {
            return LicensePlate;
        }
    }
}
