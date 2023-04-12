using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_zadatak_Z3.Model
{
    public class Lice
    {
        public string Idl { get; set; }
        public string ImeL { get; set; }
        public string PrzL { get; set; }
        public string VrstaL { get; set; }
        public double Mes_PrihodiL { get; set; }

        public Lice(string idl, string imel, string przl, string vrstal, double mes_prihodil)
        {
            this.Idl = idl;
            this.ImeL = imel;
            this.PrzL = przl;
            this.VrstaL = vrstal;
            this.Mes_PrihodiL = mes_prihodil;
        }

        public override string ToString()
        {
            return string.Format("{0,-6} {1,-35} {2,-35} {3,-30} {4,-35} ",
                Idl, ImeL, PrzL, VrstaL, Mes_PrihodiL);
        }

      
        public static string GetFormattedHeader()
        {
            return string.Format("{0,-6} {1,-35} {2,-35} {3,-30} {4,-35}",
                "IDL", "IMEL", "PRZL", "VRSTAL", "MES_PRIHODI");
        }

    }
}
