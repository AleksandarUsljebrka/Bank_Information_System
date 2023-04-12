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
    public class LicaUIHandler
    {
        private static readonly LiceService liceService = new LiceService();

        public void HandleLica()
        {
            String answer;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Odaberite opciju za rad nad objektima:");
                Console.WriteLine("1 - Prikazi sva lica");
                
                Console.WriteLine("X - Izlazak iz rukovanja objektima");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        ShowAll();
                        break;
                        

                }
            } while (!answer.ToUpper().Equals("X"));
        }

        private void ShowAll()
        {
            Console.WriteLine(Lice.GetFormattedHeader());

            try
            {
                foreach (Lice lice in liceService.FindAll())
                {
                    Console.WriteLine(lice);
                }
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
    }
}
