using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDBProject.DataConnection
{
    internal class ConnectionFactory
    {
        internal IDataConnection GetConnection(string connectionType)
        {
            if (string.IsNullOrWhiteSpace(connectionType))
            {
                return null;
            }
            if (string.Equals(connectionType, "Access", StringComparison.OrdinalIgnoreCase))
            {
                return new AccessConnection();
            }
            if (string.Equals(connectionType, "SQL", StringComparison.OrdinalIgnoreCase))
            {
                return new SqlConnection();
            }

            return null;
        }
    }
}