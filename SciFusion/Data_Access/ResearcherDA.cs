using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using model = SciFusion.Models;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace SciFusion.Data_Access
{
    public class ResearcherDA
    {

        public void saveResearcher(model.Researcher researcher)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(DBConstants.connectionString);
                connection.Open();

                MySqlCommand command = connection.CreateCommand();
                string query = "Insert into scifusion.researcher ( FirstName, LastName, Email, ContactNumber, Type, State, City, Major, LatestDegree, TotalRators, TotalRatings, University_UniversityID) values ('" + researcher.FirstName + "', '" + researcher.LastName + "','" + researcher.Email + "','" + researcher.ContactNumber + "','" + researcher.Type + "','" + researcher.State + "','" + researcher.City + "','" + researcher.Major + "','" + researcher.LatestDegree + "','" + researcher.TotalRators + "','" + researcher.TotalRatings + "','" + researcher.University_universityID + "')";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public void updateResearcher(model.Researcher researcher)
        {
            try
            {
                ConnectionManager connMgr = new ConnectionManager();
                MySqlConnection connection = connMgr.getConnection();
                connection.Open();
                string query = "update scifusion.researcher set FirstName = '" + researcher.FirstName + "', LastName ='" + researcher.LastName + "', Email ='" + researcher.Email + "', ContactNumber ='" + researcher.ContactNumber + "', Type ='" + researcher.Type + "', State = '" + researcher.State + "', City = '" + researcher.City + "', Major='" + researcher.Major + "', LatestDegree ='" + researcher.LatestDegree + "', TotalRators='" + researcher.TotalRators + "', TotalRatings='" + researcher.TotalRatings + "' where researcherid = " + researcher.ResearcherID + "";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                connMgr.closeConnection();
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public model.Researcher getResearcherById(int researcherId)
        {
            model.Researcher researcher = new model.Researcher();
            ConnectionManager connMgr = new ConnectionManager();
            MySqlConnection connection = connMgr.getConnection();
            connection.Open();
            string query = "select r.*,u.name from researcher r, university u where r.researcherid = " + researcherId + " and u.universityid = r.university_universityid";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    researcher.ResearcherID = reader.GetInt32(0);
                    researcher.FirstName = reader.GetString(1);
                    researcher.LastName = reader.GetString(2);
                    researcher.Email = reader.GetString(3);
                    researcher.ContactNumber = reader.GetString(4);
                    researcher.Type = reader.GetString(5);
                    researcher.State = reader.GetString(6);
                    researcher.City = reader.GetString(7);
                    researcher.Major = reader.GetString(8);
                    researcher.LatestDegree = reader.GetString(9);
                    researcher.TotalRators = reader.GetInt32(10);
                    researcher.TotalRatings = reader.GetInt32(11);
                    researcher.University = new model.University();
                    researcher.University.Name = reader.GetString(13);
                }
            }
            connection.Close();
            return researcher;
        }

        public List<model.Researcher> getResearcher(string lastName, String area)
        {
            List<model.Researcher> researcherList = new List<model.Researcher>();
            ConnectionManager connMgr = new ConnectionManager();
            MySqlConnection connection = connMgr.getConnection();
            connection.Open();
            string query = null;
            if (lastName != null && lastName!= String.Empty && (area == string.Empty || area == null))
            {
                 query = "select r.*,u.name from researcher r, university u where lastname like '%" + lastName + "%' and u.universityid = r.university_universityid ";
            }
            else if ((lastName==null || lastName == String.Empty) && area != null && area != string.Empty)
            {
                query = "select r.*, u.name from researcher r, area a, researchareaassociation ra, university u where a.description like '%" + area + "%' and ra.area_areaid = a.areaid and r.researcherid = ra.researcher_researcherid and u.universityid = r.university_universityid";
            }
            else if (lastName != null && lastName != string.Empty && (area != null && area == string.Empty))
            {
                query = "select r.*, u.name from area a, researcher r, researchareaassociation ra, university u where a.description like '%" + area + "%' and ra.area_areaid = a.areaid and r.researcherid = ra.researcher_researcherid and r. lastName like '%" + lastName + "%' and u.universityid = r.university_universityid";
            }
            
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    model.Researcher researcher = new model.Researcher();
                    researcher.ResearcherID = reader.GetInt32(0);
                    researcher.FirstName = reader.GetString(1);
                    researcher.LastName = reader.GetString(2);
                    researcher.Email = reader.GetString(3);
                    researcher.ContactNumber = reader.GetString(4);
                    researcher.Type = reader.GetString(5);
                    researcher.State = reader.GetString(6);
                    researcher.City = reader.GetString(7);
                    researcher.Major = reader.GetString(8);
                    researcher.LatestDegree = reader.GetString(9);
                    researcher.TotalRators = reader.GetInt32(10);
                    researcher.TotalRatings = reader.GetInt32(11);
                    researcher.University = new model.University();
                    researcher.University.Name = reader.GetString(13);
                    researcherList.Add(researcher);
                }
            }
            connection.Close();
            return researcherList;
            
        }

    }
}