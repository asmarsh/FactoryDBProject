using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using FactoryDBProject.Data;

namespace FactoryDBProject.DataConnection
{
    internal class AccessConnection : IDataConnection
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

            using (var cn = new OleDbConnection("Access"))
            {
                using (OleDbCommand cm = new OleDbCommand(sqlInsert, cn))
                {
                    var pm = new OleDbParameter("@VehicleTypeCode", OleDbType.Integer);
                    pm.Direction = ParameterDirection.Input;
                    pm.Value = vehicle.VehicleTypeCode;
                    cm.Parameters.Add(pm);

                    pm = new OleDbParameter("@VehicleId", OleDbType.VarChar, 50);
                    pm.Direction = ParameterDirection.Input;
                    pm.Value = vehicle.VehicleId;
                    cm.Parameters.Add(pm);

                    pm = new OleDbParameter("@VehicleColor", OleDbType.VarChar, 15);
                    pm.Direction = ParameterDirection.Input;
                    pm.Value = vehicle.VehicleColor;
                    cm.Parameters.Add(pm);

                    pm = new OleDbParameter("@VehicleAddDateTime", OleDbType.Date);
                    pm.Direction = ParameterDirection.Input;
                    pm.Value = vehicle.VehicleAddDateTime;
                    cm.Parameters.Add(pm);

                    cn.Open();
                    cm.ExecuteNonQuery();

                    using (OleDbCommand cmIdentity = new OleDbCommand("SELECT @@IDENTITY AS VehicleId;", cn))
                    {
                        using (OleDbDataReader drIdentity = cmIdentity.ExecuteReader())
                        {
                            return drIdentity.Read();
                        }
                    }
                }
            }
        }

        public bool Delete()
        {
            Console.WriteLine("Enter vehicle id:");
            var vehicleId = Console.ReadLine();

            using (OleDbConnection cn = new OleDbConnection("Access"))
            {
                using (OleDbCommand cm = new OleDbCommand(sqlDelete, cn))
                {
                    OleDbParameter pm = new OleDbParameter("@VehicleId", OleDbType.VarChar);
                    pm.Direction = ParameterDirection.Input;
                    pm.Value = vehicleId;
                    cm.Parameters.Add(pm);

                    cn.Open();
                    return cm.ExecuteNonQuery() == 1;
                }
            }

            throw new ArgumentException($"{nameof(vehicleId)} {vehicleId} not found");
        }

        public bool Read()
        {
            Console.WriteLine("Enter vehicle id:");
            var vehicleId = Console.ReadLine();

            using (var cn = new OleDbConnection("Access"))
            {
                using (var cm = new OleDbCommand(sqlSelect, cn))
                {
                    var pm = new OleDbParameter("@VehicleId", OleDbType.Integer, 4);
                    pm.Direction = ParameterDirection.Input;
                    pm.Value = vehicleId;
                    cm.Parameters.Add(pm);

                    cn.Open();
                    using (OleDbDataReader dr = cm.ExecuteReader())
                    {
                        if (dr.Read())  // Read() returns true if there is a record to read; false otherwise
                        {
                            var vehicle = new VHT001_VEHICLE()
                            {
                                VehicleId = (string)dr["VehicleId"],
                                VehicleColor = (string)dr["VehicleColor"],
                                VehicleTypeCode = (int?)dr["VehicleTypeCode"],
                                VehicleAddDateTime = (DateTime?)dr["VehicleAddDateTime"],
                                VehicleNo = (int)dr["VehicleNo"]
                            };
                            Console.WriteLine(vehicle.ToString());
                            return true;
                        }
                    }
                }
            }
            return false;

            throw new ArgumentException($"{nameof(vehicleId)} {vehicleId} not found");
        }

        public bool Update()
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

            using (OleDbConnection cn = new OleDbConnection("Access"))
            {
                using (OleDbCommand cm = new OleDbCommand(sqlUpdate, cn))
                {
                    var pm = new OleDbParameter("@VehicleTypeCode", OleDbType.Integer);
                    pm.Direction = ParameterDirection.Input;
                    pm.Value = vehicle.VehicleTypeCode;
                    cm.Parameters.Add(pm);

                    pm = new OleDbParameter("@VehicleColor", OleDbType.VarChar, 15);
                    pm.Direction = ParameterDirection.Input;
                    pm.Value = vehicle.VehicleColor;
                    cm.Parameters.Add(pm);

                    pm = new OleDbParameter("@VehicleId", OleDbType.VarChar, 50);
                    pm.Direction = ParameterDirection.Input;
                    pm.Value = vehicle.VehicleId;
                    cm.Parameters.Add(pm);

                    cn.Open();
                    return cm.ExecuteNonQuery() == 1;
                }
            }
        }

        #region "gross SQL strings"

        public static readonly string sqlSelect = @"SELECT
VehicleNo,
VehicleTypeCode,
VehicleId,
VehicleColor,
VehicleAddDateTime
FROM VHT001_VEHICLE
WHERE VehicleId = ?;";

        public static readonly string sqlInsert = @"
INSERT INTO VHT001_VEHICLE
(
VehicleTypeCode,
VehicleId,
VehicleColor,
VehicleAddDateTime
)
VALUES
(
?,
?,
?,
?
);
";

        public static readonly string sqlUpdate = @"
UPDATE VHT001_VEHICLE
SET
VehicleTypeCode = ?,
VehicleColor = ?
WHERE VehicleId = ?;
";

        public static readonly string sqlDelete = @"
DELETE FROM VHT001_VEHICLE
WHERE VehicleId = ?;
";

        #endregion "gross SQL strings"
    }
}