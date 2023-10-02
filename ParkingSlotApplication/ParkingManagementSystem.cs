using ParkingManagement.ParkingStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagement
{
    public class ParkingManagementSystem
    {
        private ParkingLot parkingLot;
        private List<Billing> billings;
       
        public ParkingManagementSystem()
        {
            parkingLot = new ParkingLot(new RandomParkingSlotStrategy());
            billings = new List<Billing>();
            HourlyFee = 50.0;
        }

        public ParkingLot ParkingLot => parkingLot;

        public double HourlyFee { get; set; }

        public int ParkVehicle(Vehicle vehicle,DateTime? entryTime)
        {
            
            int slotNumber = parkingLot.FindAvailableSlot(vehicle);
            if (slotNumber != -1)
            {
                Console.WriteLine($"Drive to Slot {slotNumber} and park your {vehicle.Type}.");
                billings.Add(new Billing
                {
                    SlotNumber = slotNumber,
                    Vehicle = vehicle,
                    EntryTime = entryTime ?? DateTime.Now
                });
            }
            else
            {
                Console.WriteLine("No available slots for the selected vehicle type.");
            }

            return slotNumber;
        }

        public void ExitParking(int slotNumber)
        {
            var transaction = billings?.FirstOrDefault(t => t.SlotNumber == slotNumber);
            if (transaction != null)
            {
                transaction.ExitTime = DateTime.Now;
                var duration = Math.Ceiling( transaction.ExitTime.Subtract(transaction.EntryTime).TotalHours);
                transaction.ParkingFee= duration* HourlyFee;
                parkingLot.ReleaseSlot(slotNumber);
                Console.WriteLine($"Vehicle exited from Slot {slotNumber}. Parking fee: {transaction.ParkingFee}.");
            }
            else
            {
                Console.WriteLine($"No transaction found for Slot {slotNumber}.");
            }
        }

        public Billing GetTransaction(int entrySlotNumber)
        {
            var transaction = billings?.FirstOrDefault(t => t.SlotNumber == entrySlotNumber);
            return transaction;
        }
    }


}
