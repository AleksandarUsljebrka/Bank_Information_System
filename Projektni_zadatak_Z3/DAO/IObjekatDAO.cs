
using Projektni_zadatak_Z3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_zadatak_Z3.DAO
{
    public interface IObjekatDAO : ICRUDDao<Objekat, int>
    {
        IEnumerable<Objekat> NadjiObjZaLice(string idl);
        int UkupnaVrednost(string idl);
        Dictionary<string, List<Lice>> NadjiLiceZaVrstu(string vrsta);
        List<Objekat> ObjPoIdl(string idl);
        string VrstaObj(int idvo);
        double DugLica(string vrsta);
        List<Objekat> ObjPoNazivuVrste(string naziv);

       // List<ObjStatsDTO> NadjiObjZaVrstuLica(string vrsta);
       //   List<ObjektiVrsteLicaDTO> NadjiObj();
    }
}
