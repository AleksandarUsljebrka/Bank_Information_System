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
    public class ObjekatUIHandler
    {
        private static readonly ObjekatService objekatService = new ObjekatService(); 
        public void HandleObjekat()
        {
            String answer;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Odaberite opciju za rad nad objektima:");
                Console.WriteLine("1 - Prikaz svih");
                Console.WriteLine("2 - Prikaz objekata koje pripadaju trazenom licu");
                Console.WriteLine("3 - Prikazi po identifikatoru");
                Console.WriteLine("4 - Unos vise objekata");
                Console.WriteLine("5 - Unesi jedan objekat");
                Console.WriteLine("6 - Izmeni objekat");
                
                Console.WriteLine("X - Izlazak iz rukovanja objektima");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        ShowAll();
                        break;
                    case "2":
                        PrikaziObjZaLica();
                        break;
                    case "3":
                        ShowById();
                        break;
                    case "4":
                        UnesiViseObjekata();
                        break;
                    case "5":
                        UnesiJedanObj();
                        break;
                    case "6":
                        Izmeni();
                        break;
                        
                }
            } while (!answer.ToUpper().Equals("X"));

        }

        private void ShowAll()
        {
            Console.WriteLine(Objekat.GetFormattedHeader());

            try
            {
                foreach (Objekat obj in objekatService.FindAll())
                {
                    Console.WriteLine(obj);
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void PrikaziObjZaLica()
        {
            Console.WriteLine("IDL: ");
            string idl =  Console.ReadLine();
            Console.WriteLine(Objekat.GetFormattedHeader());
            try
            {
                foreach (Objekat obj in objekatService.NadjiObjZaLice(idl))
                {
                    Console.WriteLine(obj);
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
            Console.WriteLine("Ukupna vrednost objekata: \t");
            Console.WriteLine(objekatService.UkupnaVrednost(idl));

        }

        private void ShowById()
        {
            Console.WriteLine("IDO: ");
            int ido = int.Parse(Console.ReadLine());

            try
            {
                Objekat scene = objekatService.FindById(ido);

                Console.WriteLine(Objekat.GetFormattedHeader());
                Console.WriteLine(scene);
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void UnesiViseObjekata()
        {
            List<Objekat> objList = new List<Objekat>();
            String answer;
            do
            {
                Console.WriteLine("IDO: ");
                int ido = int.Parse(Console.ReadLine());

                Console.WriteLine("IDL: ");
                string idl = Console.ReadLine();

                Console.WriteLine("IDVO: ");
                int idvo = int.Parse(Console.ReadLine());

                Console.WriteLine("Povrsina: ");
                int povrsina = int.Parse(Console.ReadLine());

                Console.WriteLine("Adresa: ");
                string adresa = Console.ReadLine();

                Console.WriteLine("Vrednost: ");
                double vrednost = double.Parse(Console.ReadLine());

                objList.Add(new Objekat(ido, idl, idvo, povrsina, adresa, vrednost));

                Console.WriteLine("Unesi još jedan objekat? (ENTER za potvrdu, X za odustanak)");
                answer = Console.ReadLine();
            } while (!answer.ToUpper().Equals("X"));

            try
            {
                int numInserted = objekatService.SaveAll(objList);
                Console.WriteLine("Uspešno uneto {0} pozorišta.", numInserted);
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void UnesiJedanObj()
        {
            Console.WriteLine("IDO: ");
            int ido = int.Parse(Console.ReadLine());

            Console.WriteLine("IDL: ");
            string idl = Console.ReadLine();

            Console.WriteLine("IDVO: ");
            int idvo = int.Parse(Console.ReadLine());

            Console.WriteLine("Povrsina: ");
            int povrsina = int.Parse(Console.ReadLine());

            Console.WriteLine("Adresa: ");
            string adresa = Console.ReadLine();

            Console.WriteLine("Vrednost: ");
            double vrednost = double.Parse(Console.ReadLine());

            try
            {
                int inserted = objekatService.Save(new Objekat(ido, idl, idvo, povrsina, adresa, vrednost));
                if (inserted != 0)
                {
                    Console.WriteLine("Objekat sa identifikatorom: \"{0}\" uspešno unet.", ido);
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void Izmeni()
        {
            Console.WriteLine("IDO: ");
            int id = int.Parse(Console.ReadLine());

            try
            {
                if (!objekatService.ExistsById(id))
                {
                    Console.WriteLine("Uneta vrednost ne postoji!");
                    return;
                }

                Console.WriteLine("IDO: ");
                int ido = int.Parse(Console.ReadLine());

                Console.WriteLine("IDL: ");
                string idl = Console.ReadLine();

                Console.WriteLine("IDVO: ");
                int idvo = int.Parse(Console.ReadLine());

                Console.WriteLine("Povrsina: ");
                int povrsina = int.Parse(Console.ReadLine());

                Console.WriteLine("Adresa: ");
                string adresa = Console.ReadLine();

                Console.WriteLine("Vrednost: ");
                double vrednost = double.Parse(Console.ReadLine());

                int updated = objekatService.Save(new Objekat(ido, idl, idvo, povrsina, adresa, vrednost));
                if (updated != 0)
                {
                    Console.WriteLine("Objekat \"{0}\" uspešno izmenjen.", ido);
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
