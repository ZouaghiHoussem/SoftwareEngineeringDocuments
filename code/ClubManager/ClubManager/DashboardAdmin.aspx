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
                <a href="GestionEntrainements.aspx">Entrainements</a>
            </div>

            <div class="content">
                <div class="mainContainer">
                    <div class="topBar">
                        <div>
                            <h1 class="pageTitle">Dashboard Admin</h1>
                            <p class="welcomeText">Bienvenue : <asp:Label ID="lblUser" runat="server"></asp:Label></p>
                        </div>

                        <asp:Button ID="btnLogout" runat="server" Text="Déconnexion" OnClick="btnLogout_Click" CssClass="btn btnDanger" />
                    </div>

                    <div class="dashboardGrid">
                        <div class="card">
                            <h3>Joueurs</h3>
                            <p>Gérer les joueurs du club, leurs informations et leur état.</p>
                            <a href="GestionJoueurs.aspx" class="btn">Accéder</a>
                        </div>

                        <div class="card">
                            <h3>Entraîneurs</h3>
                            <p>Ajouter, modifier ou supprimer les entraîneurs du club.</p>
                            <a href="GestionEntraineurs.aspx" class="btn">Accéder</a>
                        </div>

                        <div class="card">
                            <h3>Entraînements</h3>
                            <p>Organiser les séances et gérer les notifications.</p>
                            <a href="GestionEntrainements.aspx" class="btn">Accéder</a>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </form>
</body>
</html>