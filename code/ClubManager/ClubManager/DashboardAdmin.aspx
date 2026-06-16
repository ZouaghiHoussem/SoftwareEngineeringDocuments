<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DashboardAdmin.aspx.cs" Inherits="ClubManager.DashboardAdmin" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Dashboard Admin</title>
    <link rel="stylesheet" href="Assets/main.css" />
    <script src="Assets/main.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="appLayout">

            <div class="sidebar">
                <h2>ClubManager</h2>
                <a href="DashboardAdmin.aspx" class="active">Dashboard</a>
                <a href="GestionJoueurs.aspx">Joueurs</a>
                <a href="GestionEntraineurs.aspx">Entraineurs</a>
            </div>

            <div class="content">
                <div class="mainContainer">

                    <div class="topBar">
                        <div>
                            <h1 class="pageTitle">Dashboard Admin</h1>
                            <p class="welcomeText">
                                Bienvenue :
                                <asp:Label ID="lblUser" runat="server"></asp:Label>
                            </p>
                        </div>

                        <asp:Button ID="btnLogout" runat="server"
                            Text="Déconnexion"
                            OnClick="btnLogout_Click"
                            CssClass="btn btnDanger" />
                    </div>

                    <div class="dashboardGrid">
                        <div class="card">
                            <h3>Total Joueurs</h3>
                            <asp:Label ID="lblPlayers" runat="server" CssClass="bigNumber"></asp:Label>
                            <p>Nombre total des joueurs enregistrés dans le club.</p>
                        </div>

                        <div class="card">
                            <h3>Total Entraîneurs</h3>
                            <asp:Label ID="lblCoaches" runat="server" CssClass="bigNumber"></asp:Label>
                            <p>Nombre total des entraîneurs enregistrés dans le système.</p>
                        </div>

                        <div class="card">
                            <h3>Total Entraînements</h3>
                            <asp:Label ID="lblTrainings" runat="server" CssClass="bigNumber"></asp:Label>
                            <p>Nombre total des séances d'entraînement créées.</p>
                        </div>
                    </div>

                    <div class="dashboardGrid">
                        <div class="card">
                            <h3>Joueurs</h3>
                            <p>Gérer les joueurs du club, leurs informations et leur état.</p>
                            <asp:Button ID="btnJoueurs" runat="server"
                                Text="Accéder"
                                PostBackUrl="~/GestionJoueurs.aspx"
                                CssClass="btn" />
                        </div>

                        <div class="card">
                            <h3>Entraîneurs</h3>
                            <p>Ajouter, modifier ou supprimer les entraîneurs du club.</p>
                            <asp:Button ID="btnEntraineurs" runat="server"
                                Text="Accéder"
                                PostBackUrl="~/GestionEntraineurs.aspx"
                                CssClass="btn" />
                        </div>
                        <div class="card">
    <h3>Prochain entraînement</h3>
    <asp:Label ID="lblNextTraining" runat="server"></asp:Label>
</div>
                    </div>

                </div>
            </div>

        </div>
    </form>
</body>
</html>