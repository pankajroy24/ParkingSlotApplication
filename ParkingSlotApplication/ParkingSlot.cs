using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagement
{
    public enum ParkingSlotType { Small, Medium, Large }
    public class ParkingSlot
    {
        public int SlotNumber { get; set; }
        public ParkingSlotType SlotType { get; set; }
        public List<VehicleType> CompatibleVehicleTypes { get; set; }
        public Vehicle ParkedVehicle { get; set; } = null;
        public bool IsOccupied { get { return ParkedVehicle != null; } }


        public ParkingSlot(int slotNumber, ParkingSlotType slotType, List<VehicleType> compatibleVehicleTypes)
        {
            SlotNumber = slotNumber;
            SlotType = slotType;
            CompatibleVehicleTypes = compatibleVehicleTypes;
           
        }


        public override string ToString()
        {
            return $"Slot Number:{SlotNumber} | Vehicle Number:{ParkedVehicle}";
        }

    }
}
