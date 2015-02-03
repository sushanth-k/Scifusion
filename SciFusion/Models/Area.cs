using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SciFusion.Models
{
    public class Area
    {
        int areaId;

        public int AreaId
        {
            get { return areaId; }
            set { areaId = value; }
        }
        string fieldName;

        public string FieldName
        {
            get { return fieldName; }
            set { fieldName = value; }
        }
        string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        string speciality;

        public string Speciality
        {
            get { return speciality; }
            set { speciality = value; }
        }
    }
}