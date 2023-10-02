using ParkingManagement.ParkingStrategy;

namespace ParkingManagement
{
    public class ParkingLot
    {
        private List<ParkingSlot> _slots;
        private IParkingSlotStrategy _parkingSlotStrategy;

        public ParkingLot(IParkingSlotStrategy parkingSlotStrategy)
        {
            _slots = new List<ParkingSlot>();
            _parkingSlotStrategy = parkingSlotStrategy;
            InitializeSlots();
        }

       
        public int GetNumberOfParkedVehicles()
        {
            return _slots.Count(x => x.IsOccupied);
        }


        protected virtual void InitializeSlots()
        {
           
            for (int index = 1; index <= 100; index++)
            {
                List<VehicleType> compatibleTypes = new List<VehicleType>();

                if (index <= 50)
                    compatibleTypes.AddRange((IEnumerable<VehicleType>)Enum.GetValues(typeof(VehicleType)));
                else if (index <= 80)
                    compatibleTypes.AddRange(new[] { VehicleType.SEDAN, VehicleType.SUV });
                else
                    compatibleTypes.Add(VehicleType.SUV);

                _slots.Add(new ParkingSlot(index, (ParkingSlotType)(index % 3), compatibleTypes));
            }
        }

        public virtual int FindAvailableSlot(Vehicle vehicle)
        {
            return _parkingSlotStrategy.FindAvailableSlot(_slots, vehicle);
        }


        public virtual void ReleaseSlot(int slotNumber)
        {
           _parkingSlotStrategy.ReleaseSlot(_slots, slotNumber);
        }

        public void PrintAvailableSlots()
        {
            Console.WriteLine("Available Slots:");
            foreach (var slot in _slots.Where(s => !s.IsOccupied))
            {
                Console.WriteLine($"Slot {slot.SlotNumber} - {slot.SlotType}");
            }
        }

        public ParkingSlot GetSlotByNumber(int slotNumber)
        {
            var slot = _slots?.FirstOrDefault(slot => slot.IsOccupied && slot.SlotNumber == slotNumber);
            return slot;
        }
    }
}
