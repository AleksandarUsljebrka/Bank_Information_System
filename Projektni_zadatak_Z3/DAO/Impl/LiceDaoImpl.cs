using Projektni_zadatak_Z3.Connection;
using Projektni_zadatak_Z3.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_zadatak_Z3.DAO.Impl
{
    public class LiceDaoImpl : ILiceDAO
    {
        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Delete(Lice entity)
        {
            throw new NotImplementedException();
        }

        public int DeleteAll()
        {
            throw new NotImplementedException();
        }

        public int DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public bool ExistsById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Lice> FindAll()
        {
            
                string query = "select  idl, imel, przl, vrstal, mes_prihodil from lice";
                List<Lice> licaList = new List<Lice>();

                using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
                {
                    connection.Open();
                    using (IDbCommand command = connection.CreateCommand())
                    {
                        command.CommandText = query;
                        command.Prepare();

                        using (IDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Lice lice = new Lice(reader.GetString(0), reader.GetString(1),
                                    reader.GetString(2), reader.GetString(3), reader.GetDouble(4));
                                licaList.Add(lice);
                            }
                        }
                    }
                }
                return licaList;
            
        }

        public IEnumerable<Lice> FindAllById(IEnumerable<string> ids)
        {
            throw new NotImplementedException();
        }

        public Lice FindById(string id)
        {
            throw new NotImplementedException();
        }

        public int Save(Lice entity)
        {
            throw new NotImplementedException();
        }

        public int SaveAll(IEnumerable<Lice> entities)
        {
            throw new NotImplementedException();
        }
    }
}
