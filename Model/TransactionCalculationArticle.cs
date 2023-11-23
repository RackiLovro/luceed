using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luceed.Model
{
    public class TransactionCalculationArticle
    {
        public string ArtiklUid { get; set; }
        public string NazivArtikla { get; set; }
        public decimal Kolicina { get; set; }
        public decimal Iznos { get; set; }
        public string Usluga { get; set; }
    }
}
