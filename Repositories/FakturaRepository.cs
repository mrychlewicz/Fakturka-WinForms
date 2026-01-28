using Fakturka.DataBase;
using Fakturka.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakturka.Repositories
{
    internal class FakturaRepository
    {

        public void DodajFakture(Faktura faktura)
        {
            DbManager dbManager = new DbManager();
            string zapytanie = "Insert into Faktura(numer_faktury, data_wystawienia, rodzaj_faktury) VALUES (:Numer, :Data, :Rodzaj)";

            using (var conn = dbManager.GetConnection())
            {
                conn.Open();
                OracleCommand oc = new OracleCommand(zapytanie, conn);
                oc.Parameters.Add(":Numer", faktura.NumerFaktury);
                oc.Parameters.Add(":Data", faktura.DataWystawienia);
                oc.Parameters.Add(":Rodzaj", faktura.RodzajFaktury);
                oc.ExecuteNonQuery();
            }
        }


        public List<Faktura> PobierzFaktury(string SzukanyNumer, DateTime DataOd, DateTime DataDo, int CzyAktywna)
        {
            List<Faktura> faktury = new List<Faktura>();
            DbManager dbManager = new DbManager();
            string zapytanie = "Select f.id_faktury, f.numer_faktury, f.data_wystawienia, f.rodzaj_faktury, f.czy_aktywna, (Select NVL(SUM(fp.cena_netto), 0) from Faktura_Pozycje fp Where fp.id_faktury = f.id_faktury) AS kwota_netto from Faktura f where f.numer_faktury like :SzukanyNumer AND data_wystawienia BETWEEN :DataOd AND :DataDo";
            if (CzyAktywna == 1)
            {
                zapytanie = zapytanie + " AND f.czy_aktywna = 1";
            }
            string parametr = $"%{SzukanyNumer}%";

            using (var conn = dbManager.GetConnection())
            {
                conn.Open();
                OracleCommand oc = new OracleCommand(zapytanie, conn);
                oc.Parameters.Add("SzukanyNumer", parametr);
                oc.Parameters.Add("DataOd", DataOd);
                oc.Parameters.Add("DataDo", DataDo);
                var reader = oc.ExecuteReader();

                while (reader.Read())
                {
                    var id = Convert.ToInt32(reader["id_faktury"]);
                    var numer = reader["numer_faktury"].ToString();
                    var data = Convert.ToDateTime(reader["data_wystawienia"]);
                    var rodzaj = reader["rodzaj_faktury"].ToString();
                    var netto = Convert.ToDecimal(reader["kwota_netto"]);
                    var aktywna = Convert.ToInt32(reader["czy_aktywna"]);

                    Faktura faktura = new Faktura()
                    {
                        IdFaktury = id,
                        NumerFaktury = numer,
                        DataWystawienia = data,
                        RodzajFaktury = rodzaj,
                        KwotaNetto = netto,
                        CzyAktywna = aktywna,

                    };
                    faktury.Add(faktura);
                }
            }
            return faktury;
        }

        public void EdytujFakture(Faktura faktura)
        {
            DbManager dbManager = new DbManager();
            string zapytanie = "Update Faktura SET numer_faktury = :Numer, data_wystawienia = :Data, rodzaj_faktury = :Rodzaj where id_faktury = :Id";
            using (var conn = dbManager.GetConnection())
            {
                conn.Open();
                OracleCommand oc = new OracleCommand(zapytanie, conn);
                oc.Parameters.Add("Numer", faktura.NumerFaktury);
                oc.Parameters.Add("Data", faktura.DataWystawienia);
                oc.Parameters.Add("Rodzaj", faktura.RodzajFaktury);
                oc.Parameters.Add("Id", faktura.IdFaktury);
                oc.ExecuteNonQuery();
            }
        }

        public void UsunFakture(int fakturaId)
        {
            DbManager dbManager = new DbManager();
            string zapytanie = "Update Faktura set czy_aktywna = 0 where id_faktury = :Id";

            using(var conn = dbManager.GetConnection())
            {
                conn.Open();
                OracleCommand oc = new OracleCommand(zapytanie, conn);
                oc.Parameters.Add("Id", fakturaId);
                oc.ExecuteNonQuery();
            }
        }
    }
}
