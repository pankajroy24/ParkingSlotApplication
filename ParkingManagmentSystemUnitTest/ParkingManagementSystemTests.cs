using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingManagement;
using ParkingManagement.ParkingStrategy;
using System;
using System.Linq;
using System.Transactions;


namespace ParkingManagmentSystemUnitTest
{
    [TestClass]
    public class ParkingManagementSystemTests
    {
        [TestMethod]
        public void TestParkVehicle()
        {
            // Arrange
            ParkingManagementSystem parkingSystem = new ParkingManagementSystem();

            // Act
            Vehicle vehicle = new Vehicle(VehicleType.HATCHBACK, "xyz12345");
            parkingSystem.ParkVehicle(vehicle, DateTime.Now);

            // Assert
            Assert.AreEqual(1, parkingSystem.ParkingLot.GetNumberOfParkedVehicles());
        }

        [TestMethod]
        public void TestExitParking()
        {
            // Arrange
            ParkingManagementSystem parkingSystem = new ParkingManagementSystem();

            // Act
            Vehicle vehicle = new Vehicle(VehicleType.SEDAN, "xyz12345");

          
            int slotNumber=parkingSystem.ParkVehicle(vehicle, DateTime.Now);
            parkingSystem.ExitParking(slotNumber);

            // Assert
            Assert.AreEqual(0, parkingSystem.ParkingLot.GetNumberOfParkedVehicles());
        }

        [TestMethod]
        public void TestFindAvailableSlot()
        {
            // Arrange
            ParkingLot parkingLot = new ParkingLot(new RandomParkingSlotStrategy());

            // Act
            Vehicle vehicle1 = new Vehicle(VehicleType.HATCHBACK, "xyz12345");
            Vehicle vehicle2 = new Vehicle(VehicleType.SEDAN, "xyz23456");
            int availableSlot1 = parkingLot.FindAvailableSlot(vehicle1);
            int availableSlot2 = parkingLot.FindAvailableSlot(vehicle2);

            // Assert
            Assert.IsTrue(availableSlot1 > 0);
            Assert.IsTrue(availableSlot2 > 0);
            Assert.AreNotEqual(availableSlot1, availableSlot2);
        }

        [TestMethod]
        public void TestReleaseSlot()
        {
            // Arrange
            ParkingLot parkingLot = new ParkingLot(new RandomParkingSlotStrategy());

            // Act
            Vehicle vehicle = new Vehicle(VehicleType.SUV, "xyz12345");
            int slotNumber = parkingLot.FindAvailableSlot(vehicle);
            parkingLot.ReleaseSlot(slotNumber);

            // Assert
            ParkingSlot releasedSlot = parkingLot.GetSlotByNumber(slotNumber);
            Assert.IsNull(releasedSlot);
        }

        [TestMethod]
        public void TestParkingFeeCalculation()
        {
            // Arrange
            ParkingManagementSystem parkingSystem = new ParkingManagementSystem();

            DateTime entryTime = DateTime.Now.AddMinutes(-60);
            Vehicle vehicle = new Vehicle(VehicleType.SEDAN, "xyz12345");// Parked for 1 hour
            int slotNumber = parkingSystem.ParkVehicle(vehicle, entryTime);

            // Act
            parkingSystem.ExitParking(slotNumber);

            // Assert
            Billing transaction = parkingSystem.GetTransaction(slotNumber);
            Assert.IsNotNull(transaction);
            Assert.IsTrue(transaction.ParkingFee > 0);
        }

        // Example method for cleaning up test data
        [TestCleanup]
        public void Cleanup()
        {
            // You can implement cleanup logic here, such as resetting the parking lot or transaction data
        }
    }
}
