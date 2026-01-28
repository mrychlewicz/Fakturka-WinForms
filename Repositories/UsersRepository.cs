using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fakturka.DataBase;
using Fakturka.Models;
using Oracle.ManagedDataAccess.Client;

namespace Fakturka.Repositories
{
    internal class UsersRepository
    {

        public async Task<bool> czyIstnieje(string username, string password)
        {
            DbManager dbManager = new DbManager();
            string zapytanie = "Select Count(*) From Users where username = :Username AND password = :Password";
            int wynik;
            using(var conn = dbManager.GetConnection())
            {
                await conn.OpenAsync();
                OracleCommand oc = new OracleCommand(zapytanie, conn);
                oc.Parameters.Add("Username", username);
                oc.Parameters.Add("Password", password);
                wynik = Convert.ToInt32(await oc.ExecuteScalarAsync());
            }
            if(wynik > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
