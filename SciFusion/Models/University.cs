using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SciFusion.Models
{
    public class University
    {
        private int universityId;

        public int UniversityId
        {
            get { return universityId; }
            set { universityId = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string city;

        public string City
        {
            get { return city; }
            set { city = value; }
        }
        private string state;

        public string State
        {
            get { return state; }
            set { state = value; }
        }
        private string country;

        public string Country
        {
            get { return country; }
            set { country = value; }
        }
        private string web;

        public string Web
        {
            get { return web; }
            set { web = value; }
        }

        

    }
}