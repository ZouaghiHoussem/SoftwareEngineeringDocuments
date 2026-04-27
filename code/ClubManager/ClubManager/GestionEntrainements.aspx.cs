using System;
using System.Web.UI.WebControls;

namespace ClubManager
{
    public partial class GestionEntrainements : System.Web.UI.Page
    {
        private ClubFacade facade = new ClubFacade();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null || Session["Role"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (Session["Role"].ToString() != "Entraineur")
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                string fullName = facade.GetCoachFullNameByUsername(Session["Username"].ToString());

                if (fullName != "")
                {
                    lblUser.Text = fullName;
                }
                else
                {
                    lblUser.Text = "Profil entraîneur introuvable";
                }
                ChargerJoueurs();
                ChargerTrainings();
                ChargerCoachResponsable();
            }
        }
        private void ChargerCoachResponsable()
        {
            int coachId = GetCoachIdConnecte();

            if (coachId == -1)
            {
                lblCoachResponsable.Text = "Aucun profil entraîneur trouvé";
            }
            else
            {
                string fullName = facade.GetCoachFullNameByUsername(Session["Username"].ToString());

                if (fullName != "")
                {
                    lblCoachResponsable.Text = fullName;
                }
                else
                {
                    lblCoachResponsable.Text = "Aucun profil entraîneur trouvé";
                }
            }
        }
        private int GetCoachIdConnecte()
        {
            string username = Session["Username"].ToString();
            return facade.GetCoachIdByUsername(username);
        }

        private void ChargerTrainings()
        {
            int coachId = GetCoachIdConnecte();

            if (coachId == -1)
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Aucun profil entraîneur trouvé pour ce compte.";
                gvTrainings.DataSource = null;
                gvTrainings.DataBind();
                return;
            }

            gvTrainings.DataSource = facade.GetTrainingsByCoach(coachId);
            gvTrainings.DataBind();
        }



        private void ChargerJoueurs()
        {
            var dt = facade.GetPlayers();

            cblJoueurs.Items.Clear();

            foreach (System.Data.DataRow row in dt.Rows)
            {
                string nom = row["Nom"].ToString();
                string etat = row["Etat"].ToString();

                ListItem item = new ListItem();
                item.Text = nom;
                item.Value = row["Id"].ToString();

                if (etat == "Blessé")
                {
                    item.Text += " (Blessé)";
                    item.Enabled = false;
                }

                cblJoueurs.Items.Add(item);
            }
        }

        protected void btnAjouter_Click(object sender, EventArgs e)
        {
            DateTime dateSeance;
            int coachId = GetCoachIdConnecte();

            if (coachId == -1)
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Impossible d'ajouter une séance : entraîneur non trouvé.";
                return;
            }

            if (!DateTime.TryParse(txtDate.Text.Trim(), out dateSeance))
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Date invalide.";
                return;
            }

            if (txtHeure.Text.Trim() == "" || txtLieu.Text.Trim() == "" || txtType.Text.Trim() == "")
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Veuillez remplir tous les champs.";
                return;
            }

            if (facade.HasTrainingConflict(dateSeance, txtHeure.Text.Trim(), coachId))
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Conflit : ce coach a déjà une séance à cette date et heure.";
                return;
            }

            int trainingId = facade.AddTrainingAndReturnId(
                dateSeance,
                txtHeure.Text.Trim(),
                txtLieu.Text.Trim(),
                txtType.Text.Trim(),
                coachId
            );

            foreach (ListItem item in cblJoueurs.Items)
            {
                if (item.Selected)
                {
                    int playerId = Convert.ToInt32(item.Value);
                    facade.AssignPlayerToTraining(trainingId, playerId);
                }
            }

            lblMsg.ForeColor = System.Drawing.Color.Green;
            lblMsg.Text = "Nouvelle séance ajoutée avec joueurs participants.";

            txtDate.Text = "";
            txtHeure.Text = "";
            txtLieu.Text = "";
            txtType.Text = "";

            foreach (ListItem item in cblJoueurs.Items)
            {
                item.Selected = false;
            }

            ChargerTrainings();
        }

        protected void gvTrainings_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvTrainings.DataKeys[e.RowIndex].Value);

            facade.DeleteTraining(id);

            lblMsg.ForeColor = System.Drawing.Color.Green;
            lblMsg.Text = "Séance supprimée avec succès.";

            ChargerTrainings();
        }
    }
}