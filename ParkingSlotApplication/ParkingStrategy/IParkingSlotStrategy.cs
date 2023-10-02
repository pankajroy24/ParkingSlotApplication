

namespace ParkingManagement.ParkingStrategy
{
    public interface IParkingSlotStrategy
    {
        int FindAvailableSlot(List<ParkingSlot> slots, Vehicle vehicle);
        void ReleaseSlot(List<ParkingSlot> slots, int slotNumber);
    }

    public class RandomParkingSlotStrategy : IParkingSlotStrategy
    {
        
        public int FindAvailableSlot(List<ParkingSlot> slots, Vehicle vehicle)
        {
            var slot = slots.FirstOrDefault(s => !s.IsOccupied && s.CompatibleVehicleTypes.Contains(vehicle.Type));
            if (slot != null)
            {
                slot.ParkedVehicle = vehicle;
                return slot.SlotNumber;
            }
            else
            {
                return -1;
            }
        }

        public void ReleaseSlot(List<ParkingSlot> slots, int slotNumber)
        {
            var slot = slots.FirstOrDefault(s => s.SlotNumber == slotNumber);
            if (slot != null)
            {
                slot.ParkedVehicle = null;
            }
        }
    }
}
