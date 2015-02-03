using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SciFusion.Models
{
    public class Researcher
    {
        private int researcherID;

        public int ResearcherID
        {
            get { return researcherID; }
            set { researcherID = value; }
        }
        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string contactNumber;

        public string ContactNumber
        {
            get { return contactNumber; }
            set { contactNumber = value; }
        }
        private string type;

        public string Type
        {
            get
            {
                if (type.ToLower() == "p") return "Professor";
                else return "Student";
            }
            set { type = value; }
        }
        private string state;

        public string State
        {
            get { return state; }
            set { state = value; }
        }
        private string city;

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string Address
        {
            get { return this.city + "," + this.state; }
        }

        private string major;

        public string Major
        {
            get { return major; }
            set { major = value; }
        }
        private string latestDegree;

        public string LatestDegree
        {
            get { return latestDegree; }
            set { latestDegree = value; }
        }
        private int totalRators;

        public int TotalRators
        {
            get { return totalRators; }
            set { totalRators = value; }
        }
        private int totalRatings;

        public string ResearcherFullName
        {
            get { return firstName + " " + lastName; }
        }

        public int TotalRatings
        {
            get { return totalRatings; }
            set { totalRatings = value; }
        }
        private int university_universityID;

        public int University_universityID
        {
            get { return university_universityID; }
            set { university_universityID = value; }
        }

        private Area area;

        public Area Area
        {
            get { return area; }
            set { area = value; }
        }
        private University university;

        public University University
        {
            get { return university; }
            set { university = value; }
        }

    }
}