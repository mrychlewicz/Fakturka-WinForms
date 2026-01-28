using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakturka.DataBase
{
    internal class DbManager
    {
        private const string ConnectionString = "Data Source=localhost:1521/XE;User Id=hotel_db;Password=*****;"; // TODO: Move to config file

        public OracleConnection GetConnection()
        {
            OracleConnection oracleConnection = new OracleConnection(ConnectionString);
            return oracleConnection;
        }
    }
}
