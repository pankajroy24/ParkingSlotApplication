
using ParkingManagement;


public class Program
{
    static void Main(string[] args)
    {
        ParkingManagementSystem parkingSystem = new ParkingManagementSystem();

        while (true)
        {
            Console.WriteLine("1. Park Vehicle");
            Console.WriteLine("2. Exit Parking");
            Console.WriteLine("3. Check Available Slots");
            Console.WriteLine("4. Show Slots");
            Console.WriteLine("5. Show Slot Information");
            Console.WriteLine("6. Quit");
            Console.Write("Select an option: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Vehicle Type (1:SUV, 2:Sedan, 3:Hatchback): ");
                    VehicleType vehicleType = (VehicleType)(int.Parse(Console.ReadLine()));
                    var vehicle = new Vehicle(vehicleType, GenerateLicensePlate());
                    parkingSystem.ParkVehicle(vehicle, DateTime.Now);
                    break;

                case 2:
                    Console.Write("Enter Slot Number to Exit: ");
                    int exitSlotNumber = int.Parse(Console.ReadLine());
                    parkingSystem.ExitParking(exitSlotNumber);
                    break;

                case 3:

                    var emptySlots=parkingSystem.ParkingLot.GetNumberOfParkedVehicles();
                    Console.WriteLine($"Available Slots:{emptySlots}");
                    break;

                case 4:
                    parkingSystem.ParkingLot.PrintAvailableSlots();
                    break;
                case 5:
                    Console.Write("Enter Slot Number to get info: ");
                    int slotNumber = int.Parse(Console.ReadLine());
                    Console.WriteLine(parkingSystem.ParkingLot.GetSlotByNumber(slotNumber));
                    break;

                case 6:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private static string GenerateLicensePlate()
    {
        // Generate a random license plate (simplified for demonstration)
        Random random = new Random();
        string licensePlate = "XYZ" + random.Next(1000, 9999).ToString();
        return licensePlate;
    }
}

