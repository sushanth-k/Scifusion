using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SciFusion.Models;
using SciFusion.Data_Access;
using MySql.Data.MySqlClient;

namespace SciFusion.Data_Access
{
    public class ResearchArea
    {
        Boolean insert = true;
        int areaID;
        public void saveArea(Area a, int ResearcherID)
        {
            try
            {
                ConnectionManager connectionManager1 = new ConnectionManager();
                MySqlConnection connection1 = connectionManager1.getConnection();
                MySqlCommand command1 = connection1.CreateCommand();
                command1.CommandText = "select * from scifusion.area";
                MySqlDataReader reader1 = command1.ExecuteReader();
                while(reader1.Read())
                {
                
                    String description = reader1.GetString(2);
                    if (a.Description == description)
                    {
                        insert = false;
                        break;
                    }


                }
                connectionManager1.closeConnection();
                reader1.Close();

                ConnectionManager connectionManager2 = new ConnectionManager();
                MySqlConnection connection2 = connectionManager2.getConnection();
                MySqlCommand command2 = connection2.CreateCommand();
                if (insert == false)
                {
                   
                    command2.CommandText = "select * from scifusion.area where scifusion.area.Description='" + a.Description + "'";
                    MySqlDataReader reader2 = command2.ExecuteReader();
                    while (reader2.Read())
                    {
                        areaID = reader2.GetInt16(0);
                    }
                    connectionManager2.closeConnection();

                    ConnectionManager connectionManager3 = new ConnectionManager();
                    MySqlConnection connection3 = connectionManager3.getConnection();
                    MySqlCommand command3 = connection3.CreateCommand();
                    String query1 = "Insert into scifusion.researchareaassociation(Area_AreaID, Researcher_ResearcherID)values(" + areaID + "," + ResearcherID + ")";
                    
                    MySqlCommand cmd3 = new MySqlCommand(query1, connection3);
                    cmd3.ExecuteNonQuery();
                    connectionManager3.closeConnection();



                }
                if (insert == true)
                {
                    ConnectionManager connectionManager4 = new ConnectionManager();
                    MySqlConnection connection4 = connectionManager4.getConnection();
                   
                    String query2 = "Insert into scifusion.area(FieldName, Description, Speciality)values('" + a.FieldName + "','" + a.Description + "','" + a.Speciality + "')";
                    MySqlCommand cmd4 = new MySqlCommand(query2, connection4);
                    cmd4.ExecuteNonQuery();
                    connectionManager4.closeConnection();

                    ConnectionManager connectionManager5 = new ConnectionManager();
                    MySqlConnection connection5 = connectionManager5.getConnection();
                    MySqlCommand command5 = connection5.CreateCommand();
                    command5.CommandText = "select max(scifusion.area.AreaID) from scifusion.area";
                    MySqlDataReader reader5 = command5.ExecuteReader();
                    while (reader5.Read())
                    {
                        areaID = reader5.GetInt16(0);
                    }
                    connectionManager5.closeConnection();
                    reader5.Close();
                    ConnectionManager connectionManager6 = new ConnectionManager();
                    MySqlConnection connection6 = connectionManager6.getConnection();

                    String query1 = "Insert into scifusion.researchareaassociation(Area_AreaID, Researcher_ResearcherID)values(" + areaID + "," + ResearcherID + ")";
                    MySqlCommand cmd6 = new MySqlCommand(query1, connection6);
                    cmd6.ExecuteNonQuery();
                    
                    
                }




            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public void delete(int area_ID, int ResearcherID)
        {
            try
            {
                ConnectionManager connectionManager = new ConnectionManager();
                MySqlConnection connection = connectionManager.getConnection();
                MySqlCommand command = connection.CreateCommand();
                String query = "delete from scifusion.researchareaassociation where scifusion.researchareaassociation.Researcher_ResearcherID= "+ResearcherID+" and scifusion.researchareaassociation.Area_AreaID="+area_ID+" ";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        
    }
}