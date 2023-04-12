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
    public class ObjekatService
    {
        private static readonly IObjekatDAO objekatDAO = new ObjekatDaoImpl();
        
       public List<Objekat> NadjiObjZaLice(string idl)
        {
            return objekatDAO.NadjiObjZaLice(idl).ToList();
        }
        public int UkupnaVrednost(string idl)
        {
            return objekatDAO.UkupnaVrednost(idl);
        }

        public List<Objekat> FindAll()
        {
            return objekatDAO.FindAll().ToList();
        }
        public Objekat FindById(int ido)
        {
            return objekatDAO.FindById(ido);
        }

        public int SaveAll(List<Objekat> objlist)
        {
            return objekatDAO.SaveAll(objlist);
        }
        public int Save(Objekat o)
        {
            return objekatDAO.Save(o);
        }
        public bool ExistsById(int id)
        {
            return objekatDAO.ExistsById(id);
        }
    }
}
