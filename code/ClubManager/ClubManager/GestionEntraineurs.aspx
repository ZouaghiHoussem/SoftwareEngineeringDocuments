<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionEntraineurs.aspx.cs" Inherits="ClubManager.GestionEntraineurs" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Gestion des Entraîneurs</title>
    <link rel="stylesheet" href="Assets/main.css" />
    <script src="Assets/main.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="appLayout">

            <div class="sidebar">
                <h2>ClubManager</h2>
                <a href="DashboardAdmin.aspx">Dashboard</a>
                <a href="GestionJoueurs.aspx">Joueurs</a>
                <a href="GestionEntraineurs.aspx" class="active">Entraineurs</a>
                <a href="GestionEntrainements.aspx">Entrainements</a>
            </div>

            <div class="content">
                <div class="mainContainer">
                    <div class="topBar">
                        <div>
                            <h1 class="pageTitle">Gestion des Entraîneurs</h1>
                            <p class="welcomeText">Admin connecté : <asp:Label ID="lblUser" runat="server"></asp:Label></p>
                        </div>
                    </div>

                    <div class="sectionBox">
                        <asp:HiddenField ID="hfCoachId" runat="server" />

                        <h2 class="sectionTitle">Ajouter / Modifier un entraîneur</h2>

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
                                <label>Spécialité</label>
                                <asp:TextBox ID="txtSpecialite" runat="server" CssClass="formControl"></asp:TextBox>
                            </div>

                            <div class="formGroup">
                                <label>Expérience</label>
                                <asp:TextBox ID="txtExperience" runat="server" CssClass="formControl"></asp:TextBox>
                            </div>

                            <div class="formGroup">
                                <label>Nom d'utilisateur</label>
                                <asp:TextBox ID="txtUsername" runat="server" CssClass="formControl"></asp:TextBox>
                            </div>

                            <div class="formGroup">
                                <label>Mot de passe</label>
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="formControl"></asp:TextBox>
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
                        <h2 class="sectionTitle">Liste des entraîneurs</h2>

                        <div class="gridWrapper">
                            <asp:GridView ID="gvEntraineurs" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
                                OnRowDeleting="gvEntraineurs_RowDeleting"
                                OnRowCommand="gvEntraineurs_RowCommand">
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="Id" />
                                    <asp:BoundField DataField="Nom" HeaderText="Nom" />
                                    <asp:BoundField DataField="Prenom" HeaderText="Prénom" />
                                    <asp:BoundField DataField="Specialite" HeaderText="Spécialité" />
                                    <asp:BoundField DataField="Experience" HeaderText="Expérience" />

                                    <asp:TemplateField HeaderText="Modifier">
                                        <ItemTemplate>
                                            <asp:Button ID="btnSelect" runat="server" Text="Sélectionner"
                                                CommandName="SelectCoach"
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