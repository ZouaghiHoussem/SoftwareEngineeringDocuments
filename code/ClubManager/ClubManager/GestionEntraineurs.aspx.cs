using System;
using System.Data;
using System.Web.UI.WebControls;

namespace ClubManager
{
    public partial class GestionEntraineurs : System.Web.UI.Page
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
                ChargerEntraineurs();
                ReinitialiserChamps();
            }
        }

        private void ChargerEntraineurs()
        {
            gvEntraineurs.DataSource = facade.GetCoaches();
            gvEntraineurs.DataBind();
        }

        private void ReinitialiserChamps()
        {
            hfCoachId.Value = "";
            txtNom.Text = "";
            txtPrenom.Text = "";
            txtSpecialite.Text = "";
            txtExperience.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            lblMessage.Text = "";
        }

        protected void btnAjouter_Click(object sender, EventArgs e)
        {
            string nom = txtNom.Text.Trim();
            string prenom = txtPrenom.Text.Trim();
            string specialite = txtSpecialite.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            int experience;

            if (nom == "" || prenom == "" || specialite == "" || username == "" || password == "")
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Veuillez remplir tous les champs.";
                return;
            }

            if (!int.TryParse(txtExperience.Text.Trim(), out experience))
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Expérience invalide.";
                return;
            }

            if (facade.UserExists(username))
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Ce nom d'utilisateur existe déjà.";
                return;
            }

            facade.AddCoach(nom, prenom, specialite, experience, username);
            facade.AddUser(username, password, "Entraineur");

            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Entraîneur ajouté avec succès. Son compte de connexion a aussi été créé.";

            ReinitialiserChamps();
            ChargerEntraineurs();
        }

        protected void gvEntraineurs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SelectCoach")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                DataRow coach = facade.GetCoachById(id);

                if (coach != null)
                {
                    hfCoachId.Value = coach["Id"].ToString();
                    txtNom.Text = coach["Nom"].ToString();
                    txtPrenom.Text = coach["Prenom"].ToString();
                    txtSpecialite.Text = coach["Specialite"].ToString();
                    txtExperience.Text = coach["Experience"].ToString();

                    txtUsername.Text = "";
                    txtPassword.Text = "";

                    lblMessage.ForeColor = System.Drawing.Color.Blue;
                    lblMessage.Text = "Entraîneur chargé pour modification.";
                }
            }
        }

        protected void btnModifier_Click(object sender, EventArgs e)
        {
            if (hfCoachId.Value == "")
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Veuillez sélectionner un entraîneur.";
                return;
            }

            int id = Convert.ToInt32(hfCoachId.Value);
            string nom = txtNom.Text.Trim();
            string prenom = txtPrenom.Text.Trim();
            string specialite = txtSpecialite.Text.Trim();

            int experience;

            if (nom == "" || prenom == "" || specialite == "")
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Veuillez remplir les champs de l'entraîneur.";
                return;
            }

            if (!int.TryParse(txtExperience.Text.Trim(), out experience))
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Expérience invalide.";
                return;
            }

            facade.UpdateCoach(id, nom, prenom, specialite, experience);

            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Entraîneur modifié avec succès.";

            ReinitialiserChamps();
            ChargerEntraineurs();
        }

        protected void btnAnnuler_Click(object sender, EventArgs e)
        {
            ReinitialiserChamps();
        }

        protected void gvEntraineurs_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvEntraineurs.DataKeys[e.RowIndex].Value);

            if (facade.CoachHasTrainings(id))
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Impossible de supprimer cet entraîneur car il possède déjà des entraînements.";
                return;
            }

            facade.DeleteCoach(id);

            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Entraîneur supprimé avec succès.";

            ReinitialiserChamps();
            ChargerEntraineurs();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}