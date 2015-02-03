using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SciFusion.Models
{
    public class Resource
    {
        private int resourceId;

        private string resourceName;

        private HyperLink resourceCalendar;
        
        private string universityName;

        private string universityLocation;

        public int ResourceId
        {
            get
            {
                return resourceId;
            }

            private set
            {
                this.resourceId = value;
            }
        }

        public string ResourceName
        {
            get
            {
                return resourceName;
            }

            private set
            {
                this.resourceName = value;
            }
        }

        public HyperLink ResourceCalendar
        {
            get
            {
                return resourceCalendar;
            }

            private set
            {
                this.resourceCalendar = value;
            }
        }

        public string UniversityName
        {
            get
            {
                return universityName;
            }

            private set
            {
                this.universityName = value;
            }
        }

        public string UniversityLocation
        {
            get
            {
                return universityLocation;
            }

            private set
            {
                this.universityLocation = value;
            }
        }

        public Resource(int resourceId, string resourceName, HyperLink resourceCalendar, string universityName, string universityLocation)
        {
            this.ResourceId = resourceId;
            this.ResourceName = resourceName;
            this.ResourceCalendar = resourceCalendar;
            this.UniversityName = universityName;
            this.UniversityLocation = universityLocation;
        }
    }
}