using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_zadatak_Z3.UIHandler
{
    public class MainUIHandler
    {
        private readonly LicaUIHandler liceUIHandler = new LicaUIHandler();
        private readonly ObjekatUIHandler objekatUIHandler = new ObjekatUIHandler();
        private readonly KompleksniUpitiUIHandler kompleksniUpitiUIHandler = new KompleksniUpitiUIHandler();




        public void HandleMainMenu()
        {
            string answer;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Odaberite opciju:");
                Console.WriteLine("1 - Rukovanje objektima");
                Console.WriteLine("2 - Rukovanje licima ");
                Console.WriteLine("3 - Kompleksni upiti");
                Console.WriteLine("X - Izlazak iz programa");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        objekatUIHandler.HandleObjekat();
                        break;
                    case "2":
                        liceUIHandler.HandleLica();
                        break;
                    case "3":
                        kompleksniUpitiUIHandler.HandleKompleksniUpiti();
                        break;
                }

            } while (!answer.ToUpper().Equals("X"));
        }
    }
}
