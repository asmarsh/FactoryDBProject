using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDBProject.DataConnection
{
    internal interface IDataConnection
    {
        bool Create();

        bool Read();

        bool Update();

        bool Delete();
    }
}