using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryDBProject.Data;

namespace FactoryDBProject.DataConnection
{
    internal class SqlConnection : IDataConnection
    {
        public bool Create()
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

                case "BOAT":
                    vehicle.VehicleTypeCode = (int?)Constants.VehicleType.Boat;
                    break;

                default:
                    vehicle.VehicleTypeCode = (int?)Constants.VehicleType.Other;
                    break;
            }
            vehicle.VehicleAddDateTime = DateTime.Now;

            using (var ctx = new VehiclesContext())

            {
                ctx.VHT001_VEHICLE.Add(vehicle);
                ctx.SaveChanges();
                Console.WriteLine($"{nameof(vehicle.VehicleId)} {vehicle.VehicleId} added");
            }

            return true;
        }

        public bool Delete()
        {
            Console.WriteLine("Enter vehicle id:");
            var vehicleId = Console.ReadLine();

            using (var ctx = new VehiclesContext())
            {
                var vehicleToDelete = ctx.VHT001_VEHICLE.FirstOrDefault(x => x.VehicleId == vehicleId);
                if (vehicleToDelete == null) return false;
                ctx.VHT001_VEHICLE.Remove(vehicleToDelete);
                ctx.SaveChanges();
            }

            return true;

            throw new ArgumentException($"{nameof(vehicleId)} {vehicleId} not found");
        }

        public bool Read()
        {
            Console.WriteLine("Enter vehicle id:");
            var vehicleId = Console.ReadLine();
            VHT001_VEHICLE vehicle;
            using (var ctx = new VehiclesContext())
            {
                vehicle = ctx.VHT001_VEHICLE.FirstOrDefault(x => x.VehicleId == vehicleId);
            }
            if (vehicle != null)
            {
                Console.WriteLine(vehicle.ToString());
                return true;
            }
            throw new ArgumentException($"{nameof(vehicleId)} {vehicleId} not found");
        }

        public bool Update()
        {
            Console.WriteLine("Enter vehicle id:");
            var vehicleId = Console.ReadLine();
            VHT001_VEHICLE vehicle;
            using (var ctx = new VehiclesContext())
            {
                vehicle = ctx.VHT001_VEHICLE.FirstOrDefault(x => x.VehicleId == vehicleId);

                if (vehicle != null)
                {
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

                        case "BOAT":
                            vehicle.VehicleTypeCode = (int?)Constants.VehicleType.Boat;
                            break;

                        default:
                            vehicle.VehicleTypeCode = (int?)Constants.VehicleType.Other;
                            break;
                    }
                    ctx.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}