using System;
using System.Data;

namespace ClubManager
{

    public partial class Login : System.Web.UI.Page
    {

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            string username = txtUser.Text;

            string password = txtPass.Text;

            DataRow user = DbSingleton.Instance.GetUser(username, password);

            if (user != null)
            {
                Session["Username"] = user["Username"].ToString();
                Session["Role"] = user["Role"].ToString();

                string role = user["Role"].ToString();

                if (role == "Admin")
                {
                    Response.Redirect("DashboardAdmin.aspx");
                }
                else if (role == "Entraineur")
                {
                    Response.Redirect("DashboardEntraineur.aspx");
                }
            }
            else
            {
                lblError.Text = "Login incorrect";
            }

        }

    }

}