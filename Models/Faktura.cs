using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakturka.Models
{
    internal class Faktura
    {
        public int IdFaktury { get; set; }
        public string NumerFaktury { get; set; }
        public DateTime DataWystawienia { get; set; }
        public string RodzajFaktury { get; set; }

        public decimal KwotaNetto { get; set; }
        public int CzyAktywna { get; set; }
    }
}
