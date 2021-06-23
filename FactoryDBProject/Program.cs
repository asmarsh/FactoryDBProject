using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryDBProject.Data;

namespace FactoryDBProject
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("(1) Add a vehicle");
            Console.WriteLine("(2) Update a vehicle");
            Console.WriteLine("(3) Retrieve a vehicle");
            Console.WriteLine("(4) Delete a vehicle");

            var selection = Console.ReadLine();
            bool success;
            if (int.TryParse(selection.ToString(), out var parsed) && parsed >= 1 && parsed <= 4)
            {
                switch (parsed)
                {
                    case 1:
                        success = AddVehicle();
                        break;

                    case 2:
                        success = UpdateVehicle();
                        break;

                    case 3:
                        success = RetrieveVehicle();
                        break;

                    case 4:
                        success = DeleteVehicle();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
            if (success)
            {
                Console.WriteLine("Operation succeeded.");
            }
            else
            {
                Console.WriteLine("Operation failed.");
            }
        }

        private static bool AddVehicle()
        {
            var vehicle = new VHT001_VEHICLE();
            Console.WriteLine("Enter Vehicle Id:");
            vehicle.VehicleId = Console.ReadLine();
            Console.WriteLine("Enter Vehicle Color:");
            vehicle.VehicleColor = Console.ReadLine();
            Console.WriteLine("Enter Vehicle Type:");
            var vehicleType = Console.ReadLine().ToUpper();
            switch (vehicleType)
            {
                case "CAR":
                    vehicle.VehicleTypeCode = (int?)Constants.VehicleType.Car;
                    break;

                case "TRUCK":
                    vehicle.VehicleTypeCode = (int?)Constants.VehicleType.Truck;
                    break;

                case "BOAT:":
                    vehicle.VehicleTypeCode = (int?)Constants.VehicleType.Boat;
                    break;

                default:
                    vehicle.VehicleTypeCode = (int?)Constants.VehicleType.Other;
                    break;
            }

            using (var ctx = new VehiclesContext())

            {
                ctx.VHT001_VEHICLE.Add(vehicle);
                ctx.SaveChanges();
            }

            return true;
        }

        private static bool UpdateVehicle()
        {
            throw new NotImplementedException();
        }

        private static bool RetrieveVehicle()
        {
            Console.WriteLine("Enter vehicle number:");
            var vehicleNumber = Console.ReadLine();
            if (int.TryParse(vehicleNumber, out var parsedVehicleNumber))
            {
                VHT001_VEHICLE vehicle;
                using (var ctx = new VehiclesContext())
                {
                    vehicle = ctx.VHT001_VEHICLE.FirstOrDefault(x => x.VehicleNo == parsedVehicleNumber);
                }
                if (vehicle != null)
                {
                    Console.WriteLine(vehicle.ToString());
                    return true;
                }
            }
            return false;
        }

        private static bool DeleteVehicle()
        {
            Console.WriteLine("Enter vehicle number:");
            var vehicleNumber = Console.ReadLine();
            if (int.TryParse(vehicleNumber, out var parsedVehicleNumber))
            {
                using (var ctx = new VehiclesContext())
                {
                    var vehicleToDelete = ctx.VHT001_VEHICLE.FirstOrDefault(x => x.VehicleNo == parsedVehicleNumber);
                    if (vehicleToDelete == null) return false;
                    ctx.VHT001_VEHICLE.Remove(vehicleToDelete);
                    ctx.SaveChanges();
                }

                return true;
            }
            return false;
        }
    }
}