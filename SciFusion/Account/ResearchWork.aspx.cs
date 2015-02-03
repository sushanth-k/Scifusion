using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using SciFusion.Data_Access;
using System.Collections.Generic;


namespace SciFusion.Account
{
    public partial class ResearchWork : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ResearchWorkDA researchWorkAccess = new ResearchWorkDA();
            int researcherID = int.Parse(Session["ResearcherID"].ToString());
            List<SciFusion.Models.ResearchWork> researchWorkList = new List<SciFusion.Models.ResearchWork>();
            researchWorkList = researchWorkAccess.getResearchWorkByProfId(researcherID);
            ResearchWorkGrid.DataSource = researchWorkList;
            ResearchWorkGrid.DataBind();
        }     
    }
}