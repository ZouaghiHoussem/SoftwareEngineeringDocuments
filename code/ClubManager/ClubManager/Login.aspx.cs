using System;
using System.Data;

namespace ClubManager
{
    public partial class Login : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPass.Text.Trim();

            ClubFacade facade = new ClubFacade();
            DataRow user = facade.LoginUser(username, password);

            if (user != null)
            {
                string role = user["Role"].ToString();

                Session["Username"] = user["Username"].ToString();
                Session["Role"] = role;

                if (role == "Admin")
                {
                    Response.Redirect("DashboardAdmin.aspx");
                }
                else if (role == "Entraineur")
                {
                    Response.Redirect("DashboardEntraineur.aspx");
                }
                else
                {
                    lblError.Text = "Role non reconnu";
                }
            }
            else
            {
                lblError.Text = "Login incorrect";
            }
        }
    }
}