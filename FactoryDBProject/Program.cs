using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryDBProject.Data;
using FactoryDBProject.DataConnection;

namespace FactoryDBProject
{
    internal class Program
    {
        internal static IDataConnection DataConnection;

        private static void Main(string[] args)
        {
            string dbConfig = ConfigurationManager.AppSettings["DbConfig"];
            var factory = new ConnectionFactory();
            DataConnection = factory.GetConnection(dbConfig);

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
            return DataConnection.Create();
        }

        private static bool UpdateVehicle()
        {
            return DataConnection.Update();
        }

        private static bool RetrieveVehicle()
        {
            return DataConnection.Read();
        }

        private static bool DeleteVehicle()
        {
            return DataConnection.Delete();
        }
    }
}