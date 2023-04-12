using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_zadatak_Z3.Model
{
    public class VrstaObjekta
    {
        public int Idvo { get; set; }
        public string NazivVo { get; set; }

        public VrstaObjekta(int idvo, string nazivvo)
        {
            this.Idvo = idvo;
            this.NazivVo = nazivvo;
        }
    }
}
