<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Voting.Pages.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="../Style/StyleSheet1.css" />
    <title>Voting</title>
</head>
<body>

 <div class="login-page form">

     <form runat="server">

        <div class="register-form">
          <h1>Create an account</h1>
          <asp:TextBox runat="server" type="text" id="edtid" placeholder="ID" />
          <asp:TextBox runat="server" type="text" id="edtEmail" placeholder="Email" />
          <asp:TextBox runat="server" type="password" id="edtPassword" placeholder="Password"/>
          <asp:Button  CssClass="btn btnPrimary" ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
        </div>

        <div class="login-form">
          <h1>Login</h1>
          <asp:TextBox runat="server" id="edtLoginEmail" type="text" placeholder="Email"/>
          <asp:TextBox runat="server" id="edtLoginPassword" type="password" placeholder="password"/>
          <asp:Button CssClass="btn btnPrimary" ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
        </div>

   </form>

    

 </div>

</body>
</html>
