using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luceed.Model
{
    public class TransactionCalculationType
    {
        public string VrstePlacanjaUid { get; set; }
        public string Naziv { get; set; }
        public double Iznos { get; set; }

        public string Nadgrupa_placanja_uid { get; set; }
        public string Nadgrupa_placanja_naziv { get; set; }
    }
}

