using Projektni_zadatak_Z3.Connection;

using Projektni_zadatak_Z3.Model;
using Projektni_zadatak_Z3.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektni_zadatak_Z3.DAO.Impl
{
    public class ObjekatDaoImpl : IObjekatDAO
    {
        public List<Objekat> ObjPoNazivuVrste(string naziv)
        {
            List<Objekat> objekti = new List<Objekat>();
            string query = "select * from objekat o, vrstaobjekta vo where o.idvo = vo.idvo and vo.nazivvo =:naziv";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "naziv", DbType.String);
                    command.Prepare();

                    ParameterUtil.SetParameterValue(command, "naziv", naziv);

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Objekat obj = new Objekat(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3),
                                            reader.GetString(4), reader.GetDouble(5));
                            objekti.Add(obj);
                        }
                    }
                }
            }
            return objekti;
        }
        public double DugLica(string vrsta)
        {
            string query = "select sum(dug) from bilansstanja bs, lice l where l.idl = bs.idl and l.vrstal = :vrstal";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "vrstal", DbType.String);
                    command.Prepare();

                    ParameterUtil.SetParameterValue(command, "vrstal", vrsta);

                    object result = command.ExecuteScalar();
                    double idvoRes = Convert.ToDouble(result);
                    return idvoRes;
                }
            }
        }
        public string VrstaObj(int idvo)
        {
            string query = "select nazivvo from vrstaobjekta where idvo = :idvo";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "idvo", DbType.Int32);
                    command.Prepare();

                    ParameterUtil.SetParameterValue(command, "idvo", idvo);

                    object result = command.ExecuteScalar();
                    string idvoRes = Convert.ToString(result);
                    return idvoRes;
                }
            }

        }
        public List<Objekat> ObjPoIdl (string idl)
        {
            List<Objekat> objekti = new List<Objekat>();
            string query = "select * from objekat where idl = :idl";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "idl", DbType.String);
                    command.Prepare();
                    
                    ParameterUtil.SetParameterValue(command, "idl", idl);

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Objekat obj = new Objekat(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3),
                                            reader.GetString(4), reader.GetDouble(5));
                            objekti.Add(obj);
                        }
                    }
                }
            }
            return objekti;
        }
        public Dictionary<string, List<Lice>> NadjiLiceZaVrstu(string vrsta)
        {
            Dictionary<string, List<Lice>> lica = new Dictionary<string, List<Lice>>();
            string query = "select idl, imel, przl, vrstal, mes_prihodil from lice where vrstal = :vrstal";
            
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "vrstal", DbType.String);
                    command.Prepare();
                    lica.Add(vrsta, new List<Lice>());
                    ParameterUtil.SetParameterValue(command, "vrstal", vrsta);
                    
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Lice lice = new Lice(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDouble(4));
                            lica[vrsta].Add(lice);
                        }
                    }
                }
            }

            return lica;
        }

        /*  public List<ObjStatsDTO> NadjiObjZaVrstuLica( string vrsta)
          {
              string query = "select ido, vo.nazivvo, vrednost, o.idl, imel, przl " +
                  "from objekat o, vrstaobjekta vo, lice l " +
                  "where l.idl = o.idl and o.idvo = vo.idvo and l.idl in (select idl from lice where vrstal = :vrstal)";
              List<ObjStatsDTO> obj = new List<ObjStatsDTO>();
              using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
              {
                  connection.Open();
                  using (IDbCommand command = connection.CreateCommand())
                  {
                      command.CommandText = query;
                      ParameterUtil.AddParameter(command, "vrstal", DbType.String);
                      command.Prepare();

                      ParameterUtil.SetParameterValue(command, "vrstal", vrsta);

                      using (IDataReader reader = command.ExecuteReader())
                      {
                          while (reader.Read())
                          {
                              ObjStatsDTO dto = new ObjStatsDTO(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
                              obj.Add(dto);
                          }
                      }
                  }
              }
              return obj;
          }*/

        /*  public List<ObjektiVrsteLicaDTO> NadjiObj()
          {
              string query = "select ido, vo.nazivvo, vrednost, o.idl, imel, przl " +
                  "from objekat o, vrstaobjekta vo, lice l " +
                  "where l.idl = o.idl and o.idvo = vo.idvo ";
              List<ObjektiVrsteLicaDTO> obj = new List<ObjektiVrsteLicaDTO>();
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
                              ObjektiVrsteLicaDTO dto = new ObjektiVrsteLicaDTO(reader.GetInt32(0), reader.GetString(1), reader.GetDouble(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
                              obj.Add(dto);
                          }
                      }
                  }
              }
              return obj;
          }*/
        public IEnumerable<Objekat> NadjiObjZaLice(string idl)
        {
            string query = "select ido, idl, idvo, povrsina, adresa, vrednost from objekat where idl = :idl";
                
            List<Objekat> objList = new List<Objekat>();

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "idl", DbType.String);
                    command.Prepare();

                    ParameterUtil.SetParameterValue(command, "idl", idl);

                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Objekat obj = new Objekat(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3),
                                            reader.GetString(4), reader.GetDouble(5));
                            objList.Add(obj);
                        }
                    }
                }

            }
            return objList;
        }



        public int UkupnaVrednost(string idl)
        {
            string query = "select  sum(vrednost) from objekat where idl = :idl";

           // List<Objekat> objList = new List<Objekat>();

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "idl", DbType.String);
                    command.Prepare();

                    ParameterUtil.SetParameterValue(command, "idl", idl);

                    object result = command.ExecuteScalar();
                    int resultAsInt = Convert.ToInt32(result);
                    return resultAsInt;
                }

            }
           
        }
        public int Count()
        {
            string query = "select count(*) from objekat";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Prepare();

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public int Delete(Objekat entity)
        {
            return DeleteById(entity.Ido);
        }

        public int DeleteAll()
        {
            string query = "delete from objekat";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Prepare();
                    return command.ExecuteNonQuery();
                }
            }
        }

        public int DeleteById(int id)
        {
            string query = "delete from objekat where ido=:ido";

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "ido", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "ido", id);
                    return command.ExecuteNonQuery();
                }
            }
        }

        public bool ExistsById(int id)
        {
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                return ExistsById(id, connection);
            }
        }

        private bool ExistsById(int id, IDbConnection connection)
        {
            string query = "select * from objekat where ido=:ido";

            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = query;
                ParameterUtil.AddParameter(command, "ido", DbType.Int32);
                command.Prepare();
                ParameterUtil.SetParameterValue(command, "ido", id);
                return command.ExecuteScalar() != null;
            }
        }

        public IEnumerable<Objekat> FindAll()
        {
            string query = "select ido, idl, idvo, povrsina, adresa, vrednost from objekat";
            List<Objekat> objekatList = new List<Objekat>();

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
                            Objekat objekat = new Objekat(reader.GetInt32(0), reader.GetString(1),
                                reader.GetInt32(2), reader.GetInt32(3), reader.GetString(4), reader.GetDouble(5));
                            objekatList.Add(objekat);
                        }
                    }
                }
            }
            return objekatList;
        }

        public IEnumerable<Objekat> FindAllById(IEnumerable<int> ids)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select ido, idl, idvo, povrsina, adresa, vrednost from objekat where ido in (");
            foreach (int id in ids)
            {
                sb.Append(":ido" + id + ",");
            }
            sb.Remove(sb.Length - 1, 1); // delete last ','
            sb.Append(")");

            List<Objekat> objekatList = new List<Objekat>();

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = sb.ToString();
                    foreach (int id in ids)
                    {
                        ParameterUtil.AddParameter(command, "ido" + id, DbType.Int32);
                    }
                    command.Prepare();

                    foreach (int id in ids)
                    {
                        ParameterUtil.SetParameterValue(command, "ido" + id, id);
                    }
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Objekat theatre = new Objekat(reader.GetInt32(0), reader.GetString(1),
                                reader.GetInt32(2), reader.GetInt32(3), reader.GetString(4), reader.GetDouble(5));
                            objekatList.Add(theatre);
                        }
                    }
                }
            }

            return objekatList;
        }

        public Objekat FindById(int id)
        {
            string query = "select ido, idl, idvo, povrsina, adresa, vrednost " +
                        "from objekat where ido = :ido";
            Objekat objekat = null;

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "ido", DbType.Int32);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "ido", id);
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            objekat = new Objekat(reader.GetInt32(0), reader.GetString(1),
                                reader.GetInt32(2), reader.GetInt32(3), reader.GetString(4), reader.GetDouble(5));
                        }
                    }
                }
            }

            return objekat;
        }
        /* public int FindCountByPlayId(int idPl)
         {
             string query = "select count(*) from role where play_id_pl=:id_pl";

             using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
             {
                 connection.Open();
                 using (IDbCommand command = connection.CreateCommand())
                 {
                     command.CommandText = query;
                     ParameterUtil.AddParameter(command, "id_pl", DbType.Int32);
                     command.Prepare();

                     ParameterUtil.SetParameterValue(command, "id_pl", idPl);
                     object result = command.ExecuteScalar();
                     int resultAsInt = Convert.ToInt32(result);
                     return resultAsInt;

                 }
             }
         }

         public int FindCountForRoleGender(int idPl, string gender)
         {
             string query = "select count(gender_ro) " +
                 "from role " +
                 "where play_id_pl=:play_id_pl and gender_ro=:gender_ro";

             using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
             {
                 connection.Open();
                 using (IDbCommand command = connection.CreateCommand())
                 {
                     command.CommandText = query;
                     ParameterUtil.AddParameter(command, "play_id_pl", DbType.Int32);
                     ParameterUtil.AddParameter(command, "gender_ro", DbType.StringFixedLength, 1);
                     command.Prepare();

                     ParameterUtil.SetParameterValue(command, "play_id_pl", idPl);
                     ParameterUtil.SetParameterValue(command, "gender_ro", gender);

                     object result = command.ExecuteScalar();
                     if (result == null) return -1;
                     return Convert.ToInt32(result);
                 }
             }
         }

         public List<Role> FindRoleByPlayId(int idPl)
         {
             string query = "select id_ro, name_ro, gender_ro, type_ro, play_id_pl " +
                 "from role " +
                 "where play_id_pl = :play_id_pl";

             List<Role> result = new List<Role>();

             using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
             {
                 connection.Open();
                 using (IDbCommand command = connection.CreateCommand())
                 {
                     command.CommandText = query;
                     ParameterUtil.AddParameter(command, "play_id_pl", DbType.Int32);                    
                     command.Prepare();

                     ParameterUtil.SetParameterValue(command, "play_id_pl", idPl);

                     using (IDataReader reader = command.ExecuteReader())
                     {
                         while (reader.Read())
                         {
                             Role u = new Role(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4));
                             result.Add(u);
                         }
                     }
                 }

             }

             return result;
         }*/

        public int Save(Objekat entity)
        {
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                return Save(entity, connection);
            }
        }

        private int Save(Objekat objekat, IDbConnection connection)
        {
            string insertSql = "insert into objekat (idl, idvo, povrsina, adresa, vrednost, ido) " +
                "values (:idl, :idvo, :povrsina, :adresa, :vrednost,:ido)";
            string updateSql = "update objekat set idl=:idl, " +
                "idvo=:idvo, povrsina=:povrsina where ido=:ido";
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = ExistsById(objekat.Ido, connection) ? updateSql : insertSql;
                ParameterUtil.AddParameter(command, "idl", DbType.String, 50);
                ParameterUtil.AddParameter(command, "idvo", DbType.Int32);
                ParameterUtil.AddParameter(command, "povrsina", DbType.Int32);
                ParameterUtil.AddParameter(command, "adresa", DbType.String, 50);
                ParameterUtil.AddParameter(command, "vrednost", DbType.Double);
                ParameterUtil.AddParameter(command, "ido", DbType.Int32);
                command.Prepare();

                ParameterUtil.SetParameterValue(command, "idl", objekat.Idl);
                ParameterUtil.SetParameterValue(command, "idvo", objekat.Idvo);
                ParameterUtil.SetParameterValue(command, "povrsina", objekat.Povrsina);
                ParameterUtil.SetParameterValue(command, "adresa", objekat.Adresa);
                ParameterUtil.SetParameterValue(command, "vrednost", objekat.Vrednost);
                ParameterUtil.SetParameterValue(command, "ido", objekat.Ido);
                return command.ExecuteNonQuery();
            }
        }


        public int SaveAll(IEnumerable<Objekat> entities)
        {
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                IDbTransaction transaction = connection.BeginTransaction();

                int numSaved = 0;


                foreach (Objekat entity in entities)
                {

                    numSaved += Save(entity, connection);
                }


                transaction.Commit();

                return numSaved;
            }
        }
    }
}
