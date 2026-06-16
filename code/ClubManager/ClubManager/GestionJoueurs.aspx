<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionJoueurs.aspx.cs" Inherits="ClubManager.GestionJoueurs" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Gestion des Joueurs</title>
    <link rel="stylesheet" href="Assets/main.css" />
    <script src="Assets/main.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="appLayout">

            <div class="sidebar">
                <h2>ClubManager</h2>
                <a href="DashboardAdmin.aspx">Dashboard</a>
                <a href="GestionJoueurs.aspx" class="active">Joueurs</a>
                <a href="GestionEntraineurs.aspx">Entraineurs</a>
                <a href="GestionEntrainements.aspx">Entrainements</a>
            </div>

            <div class="content">
                <div class="mainContainer">
                    <div class="topBar">
                        <div>
                            <h1 class="pageTitle">Gestion des Joueurs</h1>
                            <p class="welcomeText">Admin connecté : <asp:Label ID="lblUser" runat="server"></asp:Label></p>
                        </div>
                    </div>

                    <div class="sectionBox">
                        <asp:HiddenField ID="hfPlayerId" runat="server" />

                        <h2 class="sectionTitle">Ajouter / Modifier un joueur</h2>

                        <div class="formGrid">
                            <div class="formGroup">
                                <label>Nom</label>
                                <asp:TextBox ID="txtNom" runat="server" CssClass="formControl"></asp:TextBox>
                            </div>

                            <div class="formGroup">
                                <label>Prénom</label>
                                <asp:TextBox ID="txtPrenom" runat="server" CssClass="formControl"></asp:TextBox>
                            </div>

                            <div class="formGroup">
                                <label>Âge</label>
                                <asp:TextBox ID="txtAge" runat="server" CssClass="formControl"></asp:TextBox>
                            </div>

                            <div class="formGroup">
                                <label>Poste</label>
                                <asp:TextBox ID="txtPoste" runat="server" CssClass="formControl"></asp:TextBox>
                            </div>

                            <div class="formGroup">
                                <label>Numéro</label>
                                <asp:TextBox ID="txtNumero" runat="server" CssClass="formControl"></asp:TextBox>
                            </div>

                            <div class="formGroup">
                                <label>État</label>
                                <asp:DropDownList ID="ddlEtat" runat="server" CssClass="formControl">
                                    <asp:ListItem Text="Actif" Value="Actif"></asp:ListItem>
                                    <asp:ListItem Text="Blessé" Value="Blessé"></asp:ListItem>
                                   
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="actionRow">
                            <asp:Button ID="btnAjouter" runat="server" Text="Ajouter" OnClick="btnAjouter_Click" CssClass="btn" />
                            <asp:Button ID="btnModifier" runat="server" Text="Modifier" OnClick="btnModifier_Click" CssClass="btn btnSecondary" />
                            <asp:Button ID="btnAnnuler" runat="server" Text="Annuler" OnClick="btnAnnuler_Click" CssClass="btn btnSecondary" />
                        </div>

                        <asp:Label ID="lblMessage" runat="server" CssClass="notificationLabel autoFade"></asp:Label>
                    </div>

                    <div class="sectionBox">
                        <div class="formGrid">
    <div class="formGroup">
        <label>Rechercher un joueur</label>
        <asp:TextBox ID="txtSearch" runat="server" CssClass="formControl" placeholder="Nom ou prénom"></asp:TextBox>
    </div>
</div>

<div class="actionRow">
    <asp:Button ID="btnSearch" runat="server" Text="Rechercher" OnClick="btnSearch_Click" CssClass="btn" />
    <asp:Button ID="btnResetSearch" runat="server" Text="Afficher tous" OnClick="btnResetSearch_Click" CssClass="btn btnSecondary" />
</div>
                        <h2 class="sectionTitle">Liste des joueurs</h2>

                        <div class="gridWrapper">
                            <asp:GridView ID="gvJoueurs" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
                                OnRowDeleting="gvJoueurs_RowDeleting"
                                OnRowCommand="gvJoueurs_RowCommand">
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="Id" />
                                    <asp:BoundField DataField="Nom" HeaderText="Nom" />
                                    <asp:BoundField DataField="Prenom" HeaderText="Prénom" />
                                    <asp:BoundField DataField="Age" HeaderText="Âge" />
                                    <asp:BoundField DataField="Poste" HeaderText="Poste" />
                                    <asp:BoundField DataField="Numero" HeaderText="Numéro" />
                                    <asp:BoundField DataField="Etat" HeaderText="État" />

                                    <asp:TemplateField HeaderText="Modifier">
                                        <ItemTemplate>
                                            <asp:Button ID="btnSelect" runat="server" Text="Sélectionner"
                                                CommandName="SelectPlayer"
                                                CommandArgument='<%# Eval("Id") %>'
                                                CssClass="btn btnSecondary" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:CommandField ShowDeleteButton="True" DeleteText="Supprimer" />
                                </Columns>
                            </asp:GridView>
                        </div>

                        <div class="footerActions">
                            <asp:Button ID="btnRetour" runat="server" Text="Retour Dashboard" PostBackUrl="~/DashboardAdmin.aspx" CssClass="btn btnSecondary" />
                            <asp:Button ID="btnLogout" runat="server" Text="Déconnexion" OnClick="btnLogout_Click" CssClass="btn btnDanger" />
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </form>
</body>
</html>