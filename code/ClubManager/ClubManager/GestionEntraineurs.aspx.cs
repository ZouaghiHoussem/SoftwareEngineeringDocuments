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
            lblMessage.Text = "";
        }

        protected void btnAjouter_Click(object sender, EventArgs e)
        {
            string nom = txtNom.Text.Trim();
            string prenom = txtPrenom.Text.Trim();
            string specialite = txtSpecialite.Text.Trim();

            int experience;

            if (nom == "" || prenom == "" || specialite == "")
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Veuillez remplir tous les champs.";
                return;
            }

            if (!int.TryParse(txtExperience.Text.Trim(), out experience))
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Experience invalide.";
                return;
            }

            facade.AddCoach(nom, prenom, specialite, experience);

            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Entraineur ajoute avec succes.";

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

                    lblMessage.ForeColor = System.Drawing.Color.Blue;
                    lblMessage.Text = "Entraineur charge pour modification.";
                }
            }
        }

        protected void btnModifier_Click(object sender, EventArgs e)
        {
            if (hfCoachId.Value == "")
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Veuillez selectionner un entraineur.";
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
                lblMessage.Text = "Veuillez remplir tous les champs.";
                return;
            }

            if (!int.TryParse(txtExperience.Text.Trim(), out experience))
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Experience invalide.";
                return;
            }

            facade.UpdateCoach(id, nom, prenom, specialite, experience);

            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Entraineur modifie avec succes.";

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

            facade.DeleteCoach(id);

            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Entraineur supprime avec succes.";

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