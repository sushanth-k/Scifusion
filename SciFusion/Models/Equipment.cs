using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SciFusion.Models
{
    public class Equipment
    {
        private int equipmentID;

        public int EquipmentID
        {
            get { return equipmentID; }
            set { equipmentID = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string yearsInUse;

        public string YearsInUse
        {
            get { return yearsInUse; }
            set { yearsInUse = value; }
        }
        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        private University university;

        public University University
        {
            get { return university; }
            set { university = value; }
        }

        private HyperLink link;

        public HyperLink Link
        {
            get { return link; }
            set { link = value; }
        
        }


    }
}