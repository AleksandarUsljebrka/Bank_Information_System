using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_zadatak_Z3.Model
{
    public class BilansStanja
    {
        public int Idbs { get; set; }
        public string Idl { get; set; }
        public double Saldo { get; set; }
        public double Dug { get; set; }
        public double Kamata { get; set; }

       public BilansStanja(int idbs, string idl, double saldo, double dug, double kamata)
        {
            this.Idbs = idbs;
            this.Idl = idl;
            this.Saldo = saldo;
            this.Dug = dug;
            this.Kamata = kamata;
        }
    }
}
