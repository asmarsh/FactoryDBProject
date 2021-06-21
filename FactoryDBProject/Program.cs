using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            var selection = Console.ReadKey();
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
        }

        private static bool AddVehicle()
        {
            throw new NotImplementedException();
        }

        private static bool UpdateVehicle()
        {
            throw new NotImplementedException();
        }

        private static bool RetrieveVehicle()
        {
            throw new NotImplementedException();
        }

        private static bool DeleteVehicle()
        {
            throw new NotImplementedException();
        }
    }
}