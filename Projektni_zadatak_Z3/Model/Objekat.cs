using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_zadatak_Z3.Model
{
    public class Objekat
    {
        public int Ido { get; set; }
        public string Idl { get; set; }
        public int Idvo { get; set; }
        public int Povrsina { get; set; }
        public string Adresa { get; set; }
        public double Vrednost { get; set; }

        public Objekat(int ido, string idl, int idvo, int povrsina, string adresa, double vrednost)
        {
            this.Ido = ido;
            this.Idl = idl;
            this.Idvo = idvo;
            this.Povrsina = povrsina;
            this.Adresa = adresa;
            this.Vrednost = vrednost;
        }

        public override string ToString()
        {
            return string.Format("{0,-6} {1,-6} {2,-10} {3,-20} {4,-35} {5,-30}",
                Ido, Idl, Idvo, Povrsina, Adresa, Vrednost);
        }
        public static string GetFormattedHeader()
        {
            return string.Format("{0,-6} {1,-6} {2,-10} {3,-20} {4,-35} {5,-30}",
                "IDO", "IDL", "IDVO", "POVRSINA", "ADRESA", "VREDNOST");
        }
       
    }
}
