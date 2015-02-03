using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using SciFusion.Models;
using SciFusion.Data_Access;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace SciFusion.Account
{
    public partial class Search : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Tab1.CssClass = "Clicked";
                MainView.ActiveViewIndex = 0;
            }
        }

        protected void Tab1_Click(object sender, EventArgs e)
        {
            Tab1.CssClass = "Clicked";
            Tab2.CssClass = "Initial";
            Tab3.CssClass = "Initial";
            MainView.ActiveViewIndex = 0;
        }

        protected void Tab2_Click(object sender, EventArgs e)
        {
            Tab1.CssClass = "Initial";
            Tab2.CssClass = "Clicked";
            Tab3.CssClass = "Initial";
            MainView.ActiveViewIndex = 1;
        }

        protected void Tab3_Click(object sender, EventArgs e)
        {
            Tab1.CssClass = "Initial";
            Tab2.CssClass = "Initial";
            Tab3.CssClass = "Clicked";
            MainView.ActiveViewIndex = 2;
        }

        protected void SearchResearcher(object sender, EventArgs e)
        {
            ResearcherDA searchResearcher = new ResearcherDA();
            var areaName = this.AreName.Text;
            var researcherName = this.ResearcherName.Text;
            List<Researcher> researcherList = new List<Researcher>();
            researcherList =  searchResearcher.getResearcher(researcherName, areaName);
            ResearcherGrid.DataSource = researcherList;
            ResearcherGrid.DataBind();
        }

        protected void SearchResearch(object sender, EventArgs e)
        {
            List<SciFusion.Models.ResearchWork> researchWork = new List<SciFusion.Models.ResearchWork>();
            ResearchWorkDA searchResearchWork = new ResearchWorkDA();
            researchWork = searchResearchWork.getResearchWorkByNameArea(this.ResearchName.Text, this.AreaName.Text);
            GridView3.DataSource = researchWork;
            GridView3.DataBind();
        }

        protected void SearchResource(object sender, EventArgs e)
        {

            HyperLink hyp = new HyperLink();
            hyp.NavigateUrl = "www.google.com";
            hyp.Text = "Calendar";
            EquipmentDA equipmentSearch = new EquipmentDA();
            List<Equipment> equipmentList = new List<Equipment>();
            equipmentList = equipmentSearch.getEquipment(ResourceName.Text);
            GridView1.DataSource = equipmentList;
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView gridView = sender as GridView;
            var id = Convert.ToInt32(gridView.SelectedRow.Cells[0].Text);
            Session["ResearcherID"] = id;
            this.OpenNewWindow("ResearchWork");
        }

        public void OpenNewWindow(string url)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", url));

        }      
    }
}

