using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizMathLib
{
    public class BizMath
    {
        public decimal ApplicaIva(decimal Imponibile, decimal PercIva)
        {

            return ((Imponibile / 100) * PercIva) + Imponibile;
        }

        public decimal ScorporaIva(decimal Totale, decimal PercIva)
        {
            decimal BaseImponibile = Totale * (100 / (100 + PercIva));
            BaseImponibile = Math.Round(BaseImponibile,2);
            return Totale-BaseImponibile;
        }


    }
}
