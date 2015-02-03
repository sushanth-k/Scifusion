using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using SciFusion.Models;
using SciFusion.Data_Access;
using System.Collections.Generic;

namespace SciFusion.Account
{
    public partial class Profile : Page
    {
        Researcher researcher = new Researcher();

        protected void Page_Load(object sender, EventArgs e)
        {
            ResearcherDA researcherAccess = new ResearcherDA();

            researcher = researcherAccess.getResearcherById(Int32.Parse(Session["ResearcherId"].ToString()));
            if (!IsPostBack)
            {
                this.City.Text = researcher.City;
                this.State.Text = researcher.State;
                this.FirstName.Text = researcher.FirstName;
                this.LastName.Text = researcher.LastName;
                this.Type.Text = researcher.Type;
                this.Email.Text = researcher.Email;
                this.Contact.Text = researcher.ContactNumber;
                this.UniName.Text = researcher.University.Name;
            }  
        }

        protected void SaveProfile(object sender, EventArgs e)
        {
            this.SaveButton.Text = "Saving...";
            this.researcher.City = this.City.Text;
            this.researcher.State = this.State.Text;
            this.researcher.FirstName = this.FirstName.Text;
            this.researcher.LastName = this.LastName.Text;
            this.researcher.Type = this.Type.Text;
            this.researcher.Email = this.Email.Text;
            this.researcher.ContactNumber = this.Contact.Text;
            this.researcher.University.Name = this.UniName.Text;
            ResearcherDA researcherAccess = new ResearcherDA();
            researcherAccess.updateResearcher(this.researcher);
            this.SaveButton.Text = "Save Profile";
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}