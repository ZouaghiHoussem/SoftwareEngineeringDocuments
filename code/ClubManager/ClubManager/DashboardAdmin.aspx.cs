using System;

namespace ClubManager
{
    public partial class DashboardAdmin : System.Web.UI.Page
    {
        private ClubFacade facade = new ClubFacade();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null || Session["Role"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (Session["Role"].ToString() != "Admin")
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                lblUser.Text = Session["Username"].ToString();

                lblPlayers.Text = facade.GetPlayersCount().ToString();
                lblCoaches.Text = facade.GetCoachesCount().ToString();
                lblTrainings.Text = facade.GetTrainingsCount().ToString();
            }
            var next = facade.GetNextTraining();

            if (next != null)
            {
                lblNextTraining.Text =
                    Convert.ToDateTime(next["DateSeance"]).ToString("dd/MM/yyyy")
                    + " - " + next["Heure"].ToString()
                    + " - " + next["Lieu"].ToString();
            }
            else
            {
                lblNextTraining.Text = "Aucun entraînement prévu.";
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}