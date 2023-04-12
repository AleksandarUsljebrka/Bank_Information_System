using Projektni_zadatak_Z3.DAO;

using Projektni_zadatak_Z3.DAO.Impl;

using Projektni_zadatak_Z3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_zadatak_Z3.Service
{

    public class KompleksniUpitiService
    {
        private static readonly IObjekatDAO objekatDAO = new ObjekatDaoImpl();
        private static readonly ILiceDAO liceDAO = new LiceDaoImpl();

        public Dictionary<string,List<Lice>> NadjiLiceZaVrstu(string vrsta)
        {
            return objekatDAO.NadjiLiceZaVrstu(vrsta);
        }
        public string VrstaObj(int idvo)
        {
            return objekatDAO.VrstaObj(idvo);
        }
        public List<Objekat> ObjPoIdl(string idl)
        {
            return objekatDAO.ObjPoIdl(idl);
        }
        public double DugLica(string vrsta)
        {
            return objekatDAO.DugLica(vrsta);
        }
        public List<Objekat> ObjPoNazivuVrste(string naziv)
        {
            return objekatDAO.ObjPoNazivuVrste(naziv);
        }
       /* public List<ObjektiVrsteLicaDTO> DobaviObjPoVrstiLica()
        {
            List<ObjektiVrsteLicaDTO> res = new List<ObjektiVrsteLicaDTO>();

            foreach (Lice lice in liceDAO.FindAll())
            {
                ObjektiVrsteLicaDTO obvlDto = new ObjektiVrsteLicaDTO(lice);
                foreach (ObjStatsDTO objDTO in objekatDAO.NadjiObjZaVrstuLica(lice.VrstaL))
                {
                    obvlDto.objekti.Add(objDTO);
                }
                res.Add(obvlDto);
            }
            return res;
        }*/
    }
}
