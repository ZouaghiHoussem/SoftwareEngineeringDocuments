<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ClubManager.Login" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>ClubManager Login</title>
    <link rel="stylesheet" href="Assets/main.css" />
    <script src="Assets/main.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="pageWrapper">
            <div class="loginBox">
                <img src="Assets/club.png" class="logo" />
                <h2>ClubManager</h2>

                <div class="formGroup">
                    <label>Nom utilisateur</label>
                    <div class="inputBox">
                        <asp:TextBox ID="txtUser" runat="server" CssClass="formControl"></asp:TextBox>
                    </div>
                </div>

                <div class="formGroup">
                    <label>Mot de passe</label>
                    <div class="passwordBox">
                        <asp:TextBox ID="txtPass" runat="server" TextMode="Password" CssClass="formControl" ClientIDMode="Static"></asp:TextBox>
                        <button type="button" class="toggleBtn" onclick="togglePassword()">👁</button>
                    </div>
                </div>

                <asp:Label ID="lblError" runat="server" CssClass="error autoFade"></asp:Label>

                <br />

                <asp:Button ID="btnLogin" runat="server" Text="Se connecter" OnClick="btnLogin_Click" CssClass="btn btnBlock" />
            </div>
        </div>
    </form>
</body>
</html>