<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DashboardEntraineur.aspx.cs" Inherits="ClubManager.DashboardEntraineur" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Dashboard Entraîneur</title>
    <link rel="stylesheet" href="Assets/main.css" />
    <script src="Assets/main.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="appLayout">

            <div class="sidebar">
                <h2>ClubManager</h2>
                <a href="DashboardEntraineur.aspx" class="active">Dashboard</a>
            </div>

            <div class="content">
                <div class="mainContainer">
                    <div class="topBar">
                        <div>
                            <h1 class="pageTitle">Dashboard Entraîneur</h1>
                            <p class="welcomeText">Bienvenue : <asp:Label ID="lblUser" runat="server"></asp:Label></p>
                        </div>

                        <asp:Button ID="btnLogout" runat="server" Text="Déconnexion" OnClick="btnLogout_Click" CssClass="btn btnDanger" />
                    </div>

                    <div class="dashboardGrid">
                        <div class="card">
                            <h3>Mon espace</h3>
                            <p>Consulter les séances, les joueurs et les activités liées à l’entraînement.</p>
                            <span class="smallBadge">Rôle : Entraîneur</span>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </form>
</body>
</html>