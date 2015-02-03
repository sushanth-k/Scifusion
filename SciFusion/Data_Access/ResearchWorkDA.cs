using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SciFusion.Models;

namespace SciFusion.Data_Access
{
    public class ResearchWorkDA
    {
        #region search

        public List<ResearchWork> getResearchWorkByNameArea(string researchName,string workIDescription)
        {
            try
            {
                List<ResearchWork> researchList = new List<ResearchWork>();

                ConnectionManager connectionManager = new ConnectionManager();
                MySqlConnection connection = connectionManager.getConnection();
                connection.Open();
           
                string query = null;
                if ((researchName != null || researchName != string.Empty) && (workIDescription == null || workIDescription == string.Empty))
                {
                    query = "select rw.name, rw.links, r.FirstName, r.LastName, a.Description from researchwork rw, researcher r, workareaassociation wa, researchworkassociation rwa, area a where rw.name like '%" + researchName + "%'  and wa.ResearchWork_WorkID = rw.WorkID and a.areaid = wa.Area_AreaID and rwa.ResearchWork_WorkID = rw.WorkID and r.ResearcherID = rwa.Researcher_ResearcherID;";
                }
                else if ((researchName != null || researchName != string.Empty) && (workIDescription != null || workIDescription != string.Empty))
                {
                    query = "select rw.name, rw.links, r.FirstName, r.LastName, a.description from researchwork rw, researcher r, workareaassociation wa, researchworkassociation rwa, area a where a.Description like '%" + workIDescription + "%' and rw.name like '%"+ researchName + "%' and a.areaid = wa.Area_AreaID and wa.ResearchWork_WorkID = rw.WorkID and rwa.ResearchWork_WorkID = rw.WorkID and r.ResearcherID = rwa.Researcher_ResearcherID;";
                }
                else if ((researchName == null || researchName == string.Empty) && (workIDescription != null || workIDescription != string.Empty))
                {
                    query = " select rw.name, rw.links, r.FirstName, r.LastName, a.Description from researchwork rw, researcher r, workareaassociation wa, researchworkassociation rwa, area a where a.Description like '%"+workIDescription + "%' and a.areaid = wa.Area_AreaID and wa.ResearchWork_WorkID = rw.WorkID and rwa.ResearchWork_WorkID = rw.WorkID and r.ResearcherID = rwa.Researcher_ResearcherID;";
                }
                //command.CommandText = "select rw.*, u.name, a.description from researchwork rw, "+"\n"+
                //                           "area a, workareaassociation wa, university u" + "\n" +
                //                           "where rw.name like '%"+researchName+"%' and rw.workid = wa.researchwork_workid" + "\n" +
                //                            "and wa.area_areaid = a.areaid and a.description like '%"+workIDescription+"%';";

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ResearchWork researchWork = new ResearchWork();
                    Researcher researcher = new Researcher();


                    researchWork.Links = reader.GetString(1);
                    researchWork.Name = reader.GetString(0);

                    researcher.FirstName = reader.GetString(2);
                    researcher.LastName = reader.GetString(3);

                    researchWork.Researcher = researcher;

                    researchList.Add(researchWork);
                }
                reader.Close();
                connectionManager.closeConnection();
                return researchList;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public List<ResearchWork> getResearchWork()
        {
            try
            {
                List<ResearchWork> researchList = new List<ResearchWork>();

                ConnectionManager connectionManager = new ConnectionManager();
                MySqlConnection connection = connectionManager.getConnection();
                connection.Open();
                MySqlCommand command = connection.CreateCommand();

                command.CommandText = "select rw.* ,r.firstname , r.LastName,r.ResearcherId" + "\n" +
                                                "from researchwork rw" + "\n" +
                                                "left outer join researchworkassociation rwa" + "\n" +
                                                "on rwa.ResearchWork_WorkID =rw.WorkID" + "\n" +
                                                "left outer join  researcher r" + "\n" +
                                                "on r.ResearcherID = rwa.Researcher_ResearcherID" + "\n" +
                                               " order by rw.WorkID asc;";
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ResearchWork researchWork = new ResearchWork();
                    Researcher researcher = new Researcher();
                    researchWork.WorkId = int.Parse(reader["WorkId"].ToString());
                    researchWork.University_universityId = int.Parse(reader["University_UniversityID"].ToString());
                    researchWork.Links = (string)reader["links"].ToString();
                    researchWork.Name = reader["Name"].ToString();

                    //researcher.ResearcherID = int.Parse(reader["ResearcherId"].ToString());
                    researcher.FirstName = reader["FirstName"].ToString();
                    researcher.LastName = reader["LastName"].ToString();

                    researchWork.Researcher = researcher;

                    researchList.Add(researchWork);
                }
                reader.Close();
                connectionManager.closeConnection();
                return researchList;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public List<ResearchWork> getResearchWorkById(int researchWorkId)
        {
            try
            {
                List<ResearchWork> researchList = new List<ResearchWork>();

                ConnectionManager connectionManager = new ConnectionManager();
                MySqlConnection connection = connectionManager.getConnection();
                connection.Open();
                MySqlCommand command = connection.CreateCommand();

                command.CommandText = "select rw.* ,r.firstname , r.LastName,r.ResearcherId" + "\n" +
                                                "from researchwork rw" + "\n" +
                                                "left outer join researchworkassociation rwa" + "\n" +
                                                "on rwa.ResearchWork_WorkID =rw.WorkID" + "\n" +
                                                " and rw.workId = " + researchWorkId + " " + "\n" +
                                                "left outer join  researcher r" + "\n" +
                                                "on r.ResearcherID = rwa.Researcher_ResearcherID" + "\n" +
                                                " where rw.workId = " + researchWorkId + " " + "\n" +
                                               " order by rw.WorkID asc;";
                
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ResearchWork researchWork = new ResearchWork();
                    Researcher researcher = new Researcher();
                    researchWork.WorkId = int.Parse(reader["WorkId"].ToString());
                    researchWork.University_universityId = int.Parse(reader["University_UniversityID"].ToString());
                    researchWork.Links = (string)reader["links"].ToString();
                    researchWork.Name = reader["Name"].ToString();

                    researcher.ResearcherID = int.Parse(reader["ResearcherId"].ToString());
                    researcher.FirstName = reader["FirstName"].ToString();
                    researcher.LastName = reader["LastName"].ToString();

                    researchWork.Researcher = researcher;

                    researchList.Add(researchWork);
                }
                reader.Close();
                connectionManager.closeConnection();
                return researchList;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public List<ResearchWork> getResearchWorkByName(string researchName)
        {
            try
            {
                List<ResearchWork> researchList = new List<ResearchWork>();

                ConnectionManager connectionManager = new ConnectionManager();
                MySqlConnection connection = connectionManager.getConnection();
                connection.Open();
                MySqlCommand command = connection.CreateCommand();


                command.CommandText = "select rw.* ,r.firstname , r.LastName,r.ResearcherId" + "\n" +
                                                "from researchwork rw" + "\n" +
                                                "join researchworkassociation rwa" + "\n" +
                                                "on rwa.ResearchWork_WorkID =rw.WorkID" + "\n" +
                                                " and rw.Name = '" + researchName + "' " + "\n" +
                                                "join  researcher r" + "\n" +
                                                "on r.ResearcherID = rwa.Researcher_ResearcherID" + "\n" +
                                               " order by rw.WorkID asc;";
                
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ResearchWork researchWork = new ResearchWork();
                    Researcher researcher = new Researcher();
                    researchWork.WorkId = int.Parse(reader["WorkId"].ToString());
                    researchWork.University_universityId = int.Parse(reader["University_UniversityID"].ToString());
                    researchWork.Links = (string)reader["links"].ToString();
                    researchWork.Name = reader["Name"].ToString();
                    
                    researcher.FirstName = reader["FirstName"].ToString();
                    researcher.LastName = reader["LastName"].ToString();

                    researchWork.Researcher = researcher;

                    researchList.Add(researchWork);
                }
                reader.Close();
                connectionManager.closeConnection();
                return researchList;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public List<ResearchWork> getResearchWorkByProfName(string firstName, string lastName)
        {
            try
            {
                List<ResearchWork> researchList = new List<ResearchWork>();
                ConnectionManager connectionManager = new ConnectionManager();
                MySqlConnection connection = connectionManager.getConnection();
                connection.Open();
                MySqlCommand command = connection.CreateCommand();

                command.CommandText = "select rw.* ,r.firstname , r.LastName,r.ResearcherId" + "\n" +
                                                "from researchwork rw" + "\n" +
                                                "join researchworkassociation rwa" + "\n" +
                                                "on rwa.ResearchWork_WorkID =rw.WorkID" + "\n" +
                                                "join  researcher r" + "\n" +
                                                "on r.ResearcherID = rwa.Researcher_ResearcherID" + "\n" +
                                                "where r.FirstName like '%" + firstName + "%' or r.lastName like '%" + lastName + "%' " + "\n" +
                                               " order by rw.WorkID asc;";

                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ResearchWork researchWork = new ResearchWork();
                    Researcher researcher = new Researcher();
                    researchWork.WorkId = int.Parse(reader["WorkId"].ToString());
                    researchWork.University_universityId = int.Parse(reader["University_UniversityID"].ToString());
                    researchWork.Links = (string)reader["links"].ToString();
                    researchWork.Name = reader["Name"].ToString();

                    //researcher.ResearcherID = int.Parse(reader["ResearcherID"].ToString());
                    researcher.FirstName = reader["FirstName"].ToString();
                    researcher.LastName = reader["LastName"].ToString();

                    researchWork.Researcher = researcher;
                    researchList.Add(researchWork);
                }
                reader.Close();
                connectionManager.closeConnection();
                return researchList;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public List<ResearchWork> getResearchWorkByProfId(int profId)
        {
            try
            {
                List<ResearchWork> researchList = new List<ResearchWork>();
                ConnectionManager connectionManager = new ConnectionManager();
                MySqlConnection connection = connectionManager.getConnection();
                connection.Open();
                MySqlCommand command = connection.CreateCommand();

                command.CommandText = "select rw.* ,r.firstname , r.LastName,r.ResearcherId" + "\n" +
                                                "from researchwork rw" + "\n" +
                                                "join researchworkassociation rwa" + "\n" +
                                                "on rwa.ResearchWork_WorkID =rw.WorkID" + "\n" +
                                                "join  researcher r" + "\n" +
                                                "on r.ResearcherID = rwa.Researcher_ResearcherID" + "\n" +
                                                "and r.ResearcherId = " + profId + " " + "\n" +
                                               " order by rw.WorkID asc;";
                            

                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ResearchWork researchWork = new ResearchWork();
                    Researcher researcher = new Researcher();
                    researchWork.WorkId = int.Parse(reader["WorkId"].ToString());
                    researchWork.University_universityId = int.Parse(reader["University_UniversityID"].ToString());
                    researchWork.Links = (string)reader["links"].ToString();
                    researchWork.Name = reader["Name"].ToString();

                    //researcher.ResearcherID = int.Parse(reader["ResearcherID"].ToString());
                    researcher.FirstName = reader["FirstName"].ToString();
                    researcher.LastName = reader["LastName"].ToString();

                    researchWork.Researcher = researcher;
                    researchList.Add(researchWork);
                }
                reader.Close();
                connectionManager.closeConnection();
                return researchList;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public List<ResearchWork> getResearchWorkByUniv(string universityName)
        {
            try
            {
                List<ResearchWork> researchList = new List<ResearchWork>();
                ConnectionManager connectionManager = new ConnectionManager();
                MySqlConnection connection = connectionManager.getConnection();
                connection.Open();
                MySqlCommand command = connection.CreateCommand();

                command.CommandText = "select * from researchwork rw ,university u where rw.University_UniversityID = u.UniversityID and u.Name like '%" + universityName + "%' ;";

                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ResearchWork researchWork = new ResearchWork();
                    University university = new University();
                    researchWork.WorkId = int.Parse(reader["WorkId"].ToString());
                    researchWork.University_universityId = int.Parse(reader["University_UniversityID"].ToString());
                    researchWork.Links = (string)reader["links"].ToString();
                    researchWork.Name = reader["Name"].ToString();

                    university.UniversityId = researchWork.University_universityId;
                    university.Name = reader["Name"].ToString();
                    university.City = reader["City"].ToString();
                    university.State = reader["State"].ToString();
                    university.Country = reader["Country"].ToString();

                    researchWork.University = university;
                    researchList.Add(researchWork);
                }
                reader.Close();
                connectionManager.closeConnection();
                return researchList;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public List<ResearchWork> getResearchWorkByUnivId(int universityId)
        {
            try
            {
                List<ResearchWork> researchList = new List<ResearchWork>();
                ConnectionManager connectionManager = new ConnectionManager();
                MySqlConnection connection = connectionManager.getConnection();
                connection.Open();
                MySqlCommand command = connection.CreateCommand();

                command.CommandText = "select * from researchwork rw ,university u where rw.University_UniversityID = u.universityId and u.universityId = '" + universityId + "';";

                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ResearchWork researchWork = new ResearchWork();
                    University university = new University();
                    researchWork.WorkId = int.Parse(reader["WorkId"].ToString());
                    researchWork.University_universityId = int.Parse(reader["University_UniversityID"].ToString());
                    researchWork.Links = (string)reader["links"].ToString();
                    researchWork.Name = reader["Name"].ToString();

                    university.UniversityId = researchWork.University_universityId;
                    university.Name = reader["Name"].ToString();
                    university.City = reader["City"].ToString();
                    university.State = reader["State"].ToString();
                    university.Country = reader["Country"].ToString();

                    researchWork.University = university;
                    researchList.Add(researchWork);
                }
                reader.Close();
                connectionManager.closeConnection();
                return researchList;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        #endregion  
        #region save
        public void saveResearchWork(ResearchWork researchWork)
        {
            try
            {
                ConnectionManager connectionManager = new ConnectionManager();
                MySqlConnection connection = connectionManager.getConnection();
                Researcher researcher = new Researcher();
                researcher = researchWork.Researcher;
                connection.Open();

                MySqlCommand command2 = connection.CreateCommand();
                command2.CommandText = "Select u.universityid from university u where u.name = " + researchWork.University.Name;
                var universityId = command2.ExecuteNonQuery();


                MySqlCommand command = connection.CreateCommand();

               
               command.CommandText = "INSERT INTO researchwork(Links,university_universityId,Name)" +"\n" +
                                        "VALUES ('" + researchWork.Links + "','" + universityId + "' , '" + researchWork.Name + "')";
               int success = command.ExecuteNonQuery();

               command.CommandText = "SELECT LAST_INSERT_ID();";
               MySqlDataReader reader = command.ExecuteReader();
               reader.Read();
               int workId = int.Parse(reader[0].ToString());
               connection.Close();

               //new connection for new insert
               connection = connectionManager.getConnection();
               connection.Open();
               command = connection.CreateCommand();
               if (success != null)
               {
                   command.CommandText = "INSERT INTO researchworkassociation(ResearchWork_WorkId,Researcher_ResearcherId)" + "\n" +
                                            "VALUES ('" + workId + "','" + researcher.ResearcherID + "');";

                   command.ExecuteNonQuery();
                   connection.Close();
               }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        #endregion
        #region update
        public void updateResearchWork(ResearchWork reseachWork, Boolean updateRWA)
        {
            try
            {
                ConnectionManager connectionManager = new ConnectionManager();
                MySqlConnection connection = connectionManager.getConnection();
                Researcher researcher = new Researcher();
                researcher = reseachWork.Researcher;
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                reseachWork.University_universityId = reseachWork.University_universityId + 1;
                command.CommandText = "UPDATE researchwork" + "\n" +
                                         "SET researchwork.Links = '" + reseachWork.Links + "'" + "\n" +
                                           ",researchwork.university_universityId= '" + reseachWork.University_universityId +"' " + "\n" +
                                           ",researchwork.name ='"+reseachWork.Name+"' "+"\n"+
                                           "where researchwork.workId = '" + reseachWork.WorkId + "'";
                int success = command.ExecuteNonQuery();
                connection.Close();

                if (success != null && updateRWA)
                {
                    //new connection for new update
                    connection = connectionManager.getConnection();
                    connection.Open();
                    command = connection.CreateCommand();


                    command.CommandText = "UPDATE researchworkassociation" + "\n" +
                                         "SET ResearchWork_WorkId = '" + reseachWork.WorkId + "'" + "\n" +
                                           ",Researcher_ResearcherId= '" + researcher.ResearcherID + "'";


                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        #endregion
    }

}