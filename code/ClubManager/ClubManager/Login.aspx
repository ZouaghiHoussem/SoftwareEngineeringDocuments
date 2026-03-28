<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ClubManager.Login" %>

<!DOCTYPE html>

<html>

<head runat="server">

<title>ClubManager Login</title>

<link rel="stylesheet" href="Assets/login.css">

<script src="Assets/login.js"></script>

</head>

<body>

   <form id="form1" runat="server">

        <div class="loginBox">

           <img src="Assets/club.png" class="logo"/>

             <h2>ClubManager</h2>

             <label>Nom utilisateur :</label>

             <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>

             <label>Mot de passe :</label>

         <div>

         <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>

          <button type="button" onclick="togglePassword()">👁</button>

         </div>

          <asp:Label ID="lblError" runat="server" CssClass="error"></asp:Label>

           <asp:Button ID="btnLogin" runat="server" Text="Se connecter" OnClick="btnLogin_Click"/>

          </div>

  </form>

</body>

</html>