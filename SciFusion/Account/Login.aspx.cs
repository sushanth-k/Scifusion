using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using SciFusion.Models;
using SciFusion.Data_Access;
using System.Web.UI.WebControls;

namespace SciFusion.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            //OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user password
                var username = this.UserName.Text;
                var password = this.Password.Text;

                DBUtility dbUtil = new DBUtility();        
                UserLogin userLogin = new UserLogin();
                userLogin = dbUtil.AuthenticateLogin(username, password);
                if (userLogin.IsLoginValid)
                {
                    Session["LoginStatus"] = "Log Off " + username;
                    Session["ResearcherId"] = userLogin.ResearcherId;
                    Response.Redirect("/Account/Search");
                }
            }
        }
    }
}