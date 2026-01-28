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
    internal class FakturaPozycjeRepository
    {

        public List<FakturaPozycje> PobierzPozycjeFaktury(int idFaktury)
        {
            DbManager dbManager = new DbManager();
            string zapytanie = "Select id_pozycji, id_faktury, usluga, ilosc, cena_netto, cena_brutto, stawka_vat from FAKTURA_POZYCJE where id_faktury = :Faktura";
            List<FakturaPozycje> pozycjeFaktur = new List<FakturaPozycje>();

            using(var conn = dbManager.GetConnection())
            {
                conn.Open();
                OracleCommand oc = new OracleCommand(zapytanie, conn);
                oc.Parameters.Add("Faktura", idFaktury);
                var pozycje = oc.ExecuteReader();

                while(pozycje.Read())
                {
                    var idPozycji = Convert.ToInt32(pozycje["id_pozycji"]);
                    var fakturaId = Convert.ToInt32(pozycje["id_faktury"]);
                    var usluga = pozycje["usluga"].ToString();
                    var ilosc = Convert.ToInt32(pozycje["ilosc"]);
                    var netto = Convert.ToDecimal(pozycje["cena_netto"]);
                    var brutto = Convert.ToDecimal(pozycje["cena_brutto"]);
                    var vat = Convert.ToDecimal(pozycje["stawka_vat"]);

                    FakturaPozycje fp = new FakturaPozycje()
                    {
                        IdPozycji = idPozycji,
                        IdFaktury = fakturaId,
                        Usluga = usluga,
                        Ilosc = ilosc,
                        KwotaNetto = netto,
                        KwotaBrutto = brutto,
                        StawkaVat = vat,
                    };

                    pozycjeFaktur.Add(fp);
                }

                return pozycjeFaktur;

            }

        }

        public void DodajPozycjeFaktury(FakturaPozycje fp)
        {
            DbManager dbManager = new DbManager();
            string zapytanie = "Insert Into Faktura_Pozycje(id_faktury, usluga, ilosc, cena_netto, cena_brutto, stawka_vat) Values (:Faktura, :Usluga, :Ilosc, :Netto, :Brutto, :Vat)";


            using(var conn = dbManager.GetConnection())
            {
                conn.Open();
                OracleCommand oc = new OracleCommand(zapytanie, conn);
                oc.Parameters.Add("Faktura", fp.IdFaktury);
                oc.Parameters.Add("Usluga", fp.Usluga);
                oc.Parameters.Add("Ilosc", fp.Ilosc);
                oc.Parameters.Add("Netto", fp.KwotaNetto);
                oc.Parameters.Add("Brutto", fp.KwotaBrutto);
                oc.Parameters.Add("Vat", fp.StawkaVat);

                oc.ExecuteNonQuery();
            }
        }

        public void EdytujPozycjeFaktury(FakturaPozycje fp)
        {
            DbManager dbManager = new DbManager();
            string zapytanie = "Update FAKTURA_POZYCJE Set id_faktury = :IdFaktury, usluga = :Usluga, ilosc = :Ilosc, cena_netto = :Netto, cena_brutto = :Brutto, stawka_vat = :Vat Where id_pozycji = :IdPozycji";

            using(var conn = dbManager.GetConnection())
            {
                conn.Open();
                OracleCommand oc = new OracleCommand(zapytanie, conn);
                oc.Parameters.Add("IdFaktury", fp.IdFaktury);
                oc.Parameters.Add("Usluga", fp.Usluga);
                oc.Parameters.Add("Ilosc", fp.Ilosc);
                oc.Parameters.Add("Netto", fp.KwotaNetto);
                oc.Parameters.Add("Brutto", fp.KwotaBrutto);
                oc.Parameters.Add("Vat", fp.StawkaVat);
                oc.Parameters.Add("IdPozycji", fp.IdPozycji);
                oc.ExecuteNonQuery();
            }
        }

        public void UsunPozycjeFaktury(int idPozycji)
        {
            DbManager dbManager = new DbManager();
            string zapytanie = "Delete from Faktura_Pozycje where id_pozycji = :Id";

            using( var conn = dbManager.GetConnection())
            {
                conn.Open();
                OracleCommand oc = new OracleCommand(zapytanie, conn);
                oc.Parameters.Add("Id", idPozycji);
                oc.ExecuteNonQuery();
            }
        }
    }
}
