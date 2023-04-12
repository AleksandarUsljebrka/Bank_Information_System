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
    public class LiceService
    {
        private static readonly ILiceDAO liceDAO = new LiceDaoImpl();
        public List<Lice> FindAll()
        {
            return liceDAO.FindAll().ToList();
        }
    }
}
