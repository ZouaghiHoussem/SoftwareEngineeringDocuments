using ClubManager.Observer;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace ClubManager
{
    public partial class GestionEntrainements : System.Web.UI.Page
    {
        ClubFacade facade = new ClubFacade();
        EntrainementSubject subject = new EntrainementSubject();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
                Response.Redirect("Login.aspx");

            lblUser.Text = Session["Username"].ToString();

            if (!IsPostBack)
            {
                ChargerTrainings();
                ChargerCoachs();
            }
        }

        void ChargerTrainings()
        {
            gvTrainings.DataSource = facade.GetTrainings();
            gvTrainings.DataBind();
        }

        void ChargerCoachs()
        {
            ddlCoach.DataSource = facade.GetCoaches();
            ddlCoach.DataTextField = "Nom";
            ddlCoach.DataValueField = "Id";
            ddlCoach.DataBind();
        }

        protected void btnAjouter_Click(object sender, EventArgs e)
        {
            DateTime dateSeance;
            int coachId;

            if (!DateTime.TryParse(txtDate.Text.Trim(), out dateSeance))
            {
                lblMsg.Text = "Date invalide. Utilise un format valide, par exemple 2026-04-20.";
                return;
            }

            if (!int.TryParse(ddlCoach.SelectedValue, out coachId))
            {
                lblMsg.Text = "Coach invalide.";
                return;
            }

            if (txtHeure.Text.Trim() == "" || txtLieu.Text.Trim() == "" || txtType.Text.Trim() == "")
            {
                lblMsg.Text = "Veuillez remplir tous les champs.";
                return;
            }

            facade.AddTraining(
                dateSeance,
                txtHeure.Text.Trim(),
                txtLieu.Text.Trim(),
                txtType.Text.Trim(),
                coachId
            );

            lblMsg.Text = "Seance ajoutee";

            ChargerTrainings();
        }
        protected void gvTrainings_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvTrainings.DataKeys[e.RowIndex].Value);

            facade.DeleteTraining(id);

            Notification notif = new Notification(lblMsg);
            subject.Attach(notif);
            subject.Notify("Seance supprimee");

            ChargerTrainings();
        }
    }
}