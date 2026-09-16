<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionEntrainements.aspx.cs" Inherits="ClubManager.GestionEntrainements" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Gestion des Entraînements</title>
    <link rel="stylesheet" href="Assets/main.css" />
    <script src="Assets/main.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="appLayout">

            <div class="sidebar">
                <h2>ClubManager</h2>
                <a href="DashboardEntraineur.aspx">Dashboard</a>
                <a href="GestionEntrainements.aspx" class="active">Entraînements</a>
            </div>

            <div class="content">
                <div class="mainContainer">
                    <div class="topBar">
                        <div>
                            <h1 class="pageTitle">Gestion des Entraînements</h1>
                            <p class="welcomeText">Entraîneur connecté : <asp:Label ID="lblUser" runat="server"></asp:Label></p>
                        </div>
                    </div>

                    <div class="sectionBox">
                        <h2 class="sectionTitle">Ajouter une séance</h2>

                        <div class="formGrid">
                            <div class="formGroup">
                                <label>Date</label>
                                <asp:TextBox ID="txtDate" runat="server" TextMode="Date" CssClass="formControl"></asp:TextBox>
                            </div>

                            <div class="formGroup">
                                <label>Heure</label>
                                <asp:TextBox ID="txtHeure" runat="server" CssClass="formControl"></asp:TextBox>
                            </div>

                            <div class="formGroup">
                                <label>Lieu</label>
                                <asp:TextBox ID="txtLieu" runat="server" CssClass="formControl"></asp:TextBox>
                            </div>

                            <div class="formGroup">
                                <label>Type d'entraînement</label>
                                <asp:TextBox ID="txtType" runat="server" CssClass="formControl"></asp:TextBox>
                            </div>

                            <div class="formGroup">
    <label>Coach responsable</label>
    <asp:Label ID="lblCoachResponsable" runat="server" CssClass="formControl"></asp:Label>
</div>
                        </div>

                        <div class="sectionBox">
                            <h2 class="sectionTitle">Joueurs participants</h2>
                            <asp:CheckBoxList ID="cblJoueurs" runat="server" CssClass="checkboxList"></asp:CheckBoxList>
                        </div>

                        <div class="actionRow">
                            <asp:Button ID="btnAjouter" runat="server" Text="Ajouter" OnClick="btnAjouter_Click" CssClass="btn" />
                        </div>

                        <asp:Label ID="lblMsg" runat="server" CssClass="notificationLabel autoFade"></asp:Label>
                    </div>

                    <div class="sectionBox">
                        <h2 class="sectionTitle">Liste des entraînements</h2>

                        <div class="gridWrapper">
                            <asp:GridView ID="gvTrainings" runat="server" AutoGenerateColumns="True"
                                DataKeyNames="Id"
                                OnRowDeleting="gvTrainings_RowDeleting">
                                <Columns>
                                    <asp:CommandField ShowDeleteButton="True" DeleteText="Supprimer" />
                                </Columns>
                            </asp:GridView>
                        </div>

                        <div class="footerActions">
                            <asp:Button ID="btnRetour" runat="server" Text="Retour Dashboard" PostBackUrl="~/DashboardEntraineur.aspx" CssClass="btn btnSecondary" />
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </form>
</body>
</html>