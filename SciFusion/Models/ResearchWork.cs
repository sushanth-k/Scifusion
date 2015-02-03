using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SciFusion.Models
{
    public class ResearchWork
    {
        int workId;

        public int WorkId
        {
            get { return workId; }
            set { workId = value; }
        }
        string links;

        public string Links
        {
            get { return links; }
            set { links = value; }
        }
        int university_universityId;

        public int University_universityId
        {
            get { return university_universityId; }
            set { university_universityId = value; }
        }

        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        Researcher researcher;

        public Researcher Researcher
        {
            get { return researcher; }
            set { researcher = value; }
        }
        University university;

        public University University
        {
            get { return university; }
            set { university = value; }
        }
    }
}