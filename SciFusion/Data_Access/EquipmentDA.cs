using MySql.Data.MySqlClient;
using SciFusion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SciFusion.Data_Access
{
    public class EquipmentDA
    {
        public List<Equipment> getEquipment(string Type)
        {
            List<Equipment> equipmentList = new List<Equipment>();
            ConnectionManager connMgr = new ConnectionManager();
            MySqlConnection conn = new MySqlConnection();
            MySqlConnection connection = connMgr.getConnection();
            connection.Open();
            string query = null;
            if ((Type != null || Type != string.Empty))
            {
                query = "select e.equipmentid, e.type, e.name, e.yearsinuse, u.name from equipment e, university u where u.universityid = e.university_universityid and e.type like '%" + Type + "%'";
            }

            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Equipment eq = new Equipment();
                    eq.EquipmentID = reader.GetInt32(0);
                    eq.Type = reader.GetString(1);
                    eq.Name = reader.GetString(2);
                    eq.YearsInUse = reader.GetString(3);
                    eq.University = new University();
                    eq.University.Name = reader.GetString(4);
                    equipmentList.Add(eq);
                }


            }
            return equipmentList;
        }
    }
}