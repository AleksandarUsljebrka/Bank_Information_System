
using Projektni_zadatak_Z3.Model;
using Projektni_zadatak_Z3.Service;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_zadatak_Z3.UIHandler
{
    public class KompleksniUpitiUIHandler
    {
        private static readonly KompleksniUpitiService kompleksniService = new KompleksniUpitiService();
        public void HandleKompleksniUpiti()
        {
            String answer;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Odaberite opciju za rad nad objektima:");
                Console.WriteLine("1 - Prikazi sve objekte po vrsti lica");
                Console.WriteLine("2 - Prikazi objekte po nazivu vrste");
                Console.WriteLine("X - Izlazak iz rukovanja objektima");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        ObjPoVrsti();
                        break;
                    case "2":
                        ObjPoNazivuVrste();
                        break;


                }
            } while (!answer.ToUpper().Equals("X"));

        }
        public void ObjPoVrsti()
        {
            try
            {

                int count = 0;
                Console.WriteLine("OBJEKTI FIZICKIH LICA:\n");
                Console.WriteLine(string.Format("{0,-6} {1,-25} {2,-20} {3,-6} {4,-30} {5,-30}",
                    "IDO" ,"VRSTA OBJEKTA", "VREDNOST(e)", "IDL", "IMEL", "PRZL"));

                foreach(Lice l in kompleksniService.NadjiLiceZaVrstu("FIZICKO")["FIZICKO"])
                {
                    foreach(Objekat o in kompleksniService.ObjPoIdl(l.Idl))
                    {
                        Console.WriteLine(string.Format("{0,-6} {1,-25} {2,-20} {3,-6} {4,-30} {5,-30}",
                            o.Ido, kompleksniService.VrstaObj(o.Idvo),o.Vrednost, l.Idl, l.ImeL, l.PrzL ));
                        count++;
                    }
                }
                Console.WriteLine("UKUPAN BROJ OBJEKATA: "+count);
                Console.WriteLine("UKUPAN DUG LICA: " + kompleksniService.DugLica("FIZICKO"));

                Console.WriteLine();


                count = 0;
                Console.WriteLine("OBJEKTI PRAVNIH LICA:\n");
                Console.WriteLine(string.Format("{0,-6} {1,-25} {2,-20} {3,-6} {4,-30} {5,-30}",
                     "IDO", "VRSTA OBJEKTA", "VREDNOST(e)", "IDL", "IMEL", "PRZL"));

                foreach (Lice l in kompleksniService.NadjiLiceZaVrstu("PRAVNO")["PRAVNO"])
                {
                    foreach (Objekat o in kompleksniService.ObjPoIdl(l.Idl))
                    {
                        Console.WriteLine(string.Format("{0,-6} {1,-25} {2,-20} {3,-6} {4,-30} {5,-30}",
                            o.Ido, kompleksniService.VrstaObj(o.Idvo), o.Vrednost, l.Idl, l.ImeL, l.PrzL));
                        count++;
                    }
                }
                Console.WriteLine("UKUPAN BROJ OBJEKATA: " + count);
                Console.WriteLine("UKUPAN DUG LICA: "+kompleksniService.DugLica("PRAVNO"));

            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ObjPoNazivuVrste()
        {
            try
            {
                Console.WriteLine("Unesi naziv vrste objekta: ");
                string naziv = Console.ReadLine();
                Console.WriteLine(Objekat.GetFormattedHeader());
                foreach(Objekat obj in kompleksniService.ObjPoNazivuVrste(naziv))
                {
                    Console.WriteLine(obj);
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
