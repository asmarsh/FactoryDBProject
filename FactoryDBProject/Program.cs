using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryDBProject.Data;
using FactoryDBProject.DataConnection;

namespace FactoryDBProject
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("(1) Add a vehicle");
                Console.WriteLine("(2) Update a vehicle");
                Console.WriteLine("(3) Retrieve a vehicle");
                Console.WriteLine("(4) Delete a vehicle");
                Console.WriteLine("(5) Exit");

                var selection = Console.ReadLine();
                bool success;
                if (int.TryParse(selection.ToString(), out var parsed) && parsed >= 1 && parsed <= 5)
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

                        case 5:
                            Environment.Exit(1);
                            success = true;
                            break;

                        default:
                            throw new ArgumentOutOfRangeException(selection, "Selection must be a numeric value between 1 and 5");
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException(selection, "Selection must be a numeric value between 1 and 5");
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
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Invalid selection");
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Invalid selection");
                Console.WriteLine(ex.Message);
            }
            Main(null);
        }

        private static bool AddVehicle()
        {
            var reader = new SqlConnection();

            return reader.Create();
        }

        private static bool UpdateVehicle()
        {
            var reader = new SqlConnection();

            return reader.Update();
        }

        private static bool RetrieveVehicle()
        {
            var reader = new SqlConnection();

            return reader.Read();
        }

        private static bool DeleteVehicle()
        {
            var reader = new SqlConnection();

            return reader.Delete();
        }
    }
}