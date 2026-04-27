using System;
using System.Data;
using System.Web.UI.WebControls;

namespace ClubManager
{
    public partial class GestionJoueurs : System.Web.UI.Page
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
                ChargerJoueurs();
                ReinitialiserChamps();
            }
        }

        private void ChargerJoueurs()
        {
            gvJoueurs.DataSource = facade.GetPlayers();
            gvJoueurs.DataBind();
        }

        private void ReinitialiserChamps()
        {
            hfPlayerId.Value = "";
            txtNom.Text = "";
            txtPrenom.Text = "";
            txtAge.Text = "";
            txtPoste.Text = "";
            txtNumero.Text = "";
            ddlEtat.SelectedIndex = 0;
            lblMessage.Text = "";
        }

        protected void btnAjouter_Click(object sender, EventArgs e)
        {
            string nom = txtNom.Text.Trim();
            string prenom = txtPrenom.Text.Trim();
            string poste = txtPoste.Text.Trim();
            string etat = ddlEtat.SelectedValue;

            int age;
            int numero;

            if (nom == "" || prenom == "" || poste == "")
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Veuillez remplir tous les champs.";
                return;
            }

            if (!int.TryParse(txtAge.Text.Trim(), out age))
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Age invalide.";
                return;
            }

            if (!int.TryParse(txtNumero.Text.Trim(), out numero))
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Numero invalide.";
                return;
            }

            facade.AddPlayer(nom, prenom, age, poste, numero, etat);

            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Joueur ajoute avec succes.";

            ReinitialiserChamps();
            ChargerJoueurs();
        }

        protected void gvJoueurs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SelectPlayer")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                DataRow joueur = facade.GetPlayerById(id);

                if (joueur != null)
                {
                    hfPlayerId.Value = joueur["Id"].ToString();
                    txtNom.Text = joueur["Nom"].ToString();
                    txtPrenom.Text = joueur["Prenom"].ToString();
                    txtAge.Text = joueur["Age"].ToString();
                    txtPoste.Text = joueur["Poste"].ToString();
                    txtNumero.Text = joueur["Numero"].ToString();
                    ddlEtat.SelectedValue = joueur["Etat"].ToString();

                    lblMessage.ForeColor = System.Drawing.Color.Blue;
                    lblMessage.Text = "Joueur charge pour modification.";
                }
            }
        }

        protected void btnModifier_Click(object sender, EventArgs e)
        {
            if (hfPlayerId.Value == "")
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Veuillez selectionner un joueur.";
                return;
            }

            int id = Convert.ToInt32(hfPlayerId.Value);
            string nom = txtNom.Text.Trim();
            string prenom = txtPrenom.Text.Trim();
            string poste = txtPoste.Text.Trim();
            string etat = ddlEtat.SelectedValue;

            int age;
            int numero;

            if (nom == "" || prenom == "" || poste == "")
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Veuillez remplir tous les champs.";
                return;
            }

            if (!int.TryParse(txtAge.Text.Trim(), out age))
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Age invalide.";
                return;
            }

            if (!int.TryParse(txtNumero.Text.Trim(), out numero))
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Numero invalide.";
                return;
            }

            facade.UpdatePlayer(id, nom, prenom, age, poste, numero, etat);

            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Joueur modifie avec succes.";

            ReinitialiserChamps();
            ChargerJoueurs();
        }

        protected void btnAnnuler_Click(object sender, EventArgs e)
        {
            ReinitialiserChamps();
        }

        protected void gvJoueurs_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvJoueurs.DataKeys[e.RowIndex].Value);

            facade.DeletePlayer(id);

            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Joueur supprime avec succes.";

            ReinitialiserChamps();
            ChargerJoueurs();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (keyword == "")
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Veuillez entrer un nom ou un prénom.";
                return;
            }

            gvJoueurs.DataSource = facade.SearchPlayersByName(keyword);
            gvJoueurs.DataBind();

            lblMessage.ForeColor = System.Drawing.Color.Blue;
            lblMessage.Text = "Résultat de recherche pour : " + keyword;
        }
        protected void btnResetSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            ChargerJoueurs();

            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Liste complète des joueurs affichée.";
        }
    }

}