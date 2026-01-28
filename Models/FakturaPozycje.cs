using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakturka.Models
{
    internal class FakturaPozycje
    {
        public int IdPozycji { get; set; }
        public int IdFaktury { get; set; }
        public string Usluga { get; set; }
        public int Ilosc { get; set; }
        public decimal KwotaNetto { get; set; }
        public decimal StawkaVat { get; set; }
        public decimal KwotaBrutto { get; set; }
    }
}
