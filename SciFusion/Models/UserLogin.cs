using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SciFusion.Models
{
    public class UserLogin
    {
        public Boolean IsLoginValid
        {
            get;
            set;
        }
        
        int researcherId;

        public int ResearcherId
        {
            get { return researcherId; }
            set { researcherId = value; }
        }
    }
}