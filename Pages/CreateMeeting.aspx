<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateMeeting.aspx.cs" Inherits="Voting.Pages.CreateMeeting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="../Style/StyleSheet1.css" />
    <title>Voting</title>
</head>
<body>
    <div class="login-page form" style="width:800px;max-width:800px;">

     <form runat="server">

        <div class="login-form">
          <h1>Details:</h1>
          <asp:TextBox runat="server" id="bodyCorp" type="text" placeholder="The Body Corporate of"/>
          <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
          <asp:TextBox runat="server" id="MeetingName" ReadOnly="true" type="text" placeholder="Meeting Name"/>
          <asp:TextBox runat="server" id="Password" type="password" placeholder="Password"/>
          <br/>
          <br/>
          <h1>Questions</h1>
          <asp:TextBox runat="server" id="Q1" type="text" placeholder="Q1"/>
          <asp:TextBox runat="server" id="Q2" type="text" placeholder="Q2"/>
          <asp:TextBox runat="server" id="Q3" type="text" placeholder="Q3"/>
          <asp:TextBox runat="server" id="Q4" type="text" placeholder="Q4"/>
          <asp:TextBox runat="server" id="Q5" type="text" placeholder="Q5"/>
          <asp:TextBox runat="server" id="Q6" type="text" placeholder="Q6"/>
          <asp:TextBox runat="server" id="Q7" type="text" placeholder="Q7"/>
          <asp:TextBox runat="server" id="Q8" type="text" placeholder="Q8"/>
          <asp:TextBox runat="server" id="Q9" type="text" placeholder="Q9"/>
          <asp:TextBox runat="server" id="Q10" type="text" placeholder="Q10"/>
          <asp:TextBox runat="server" id="Q11" type="text" placeholder="Q11"/>

          
          <asp:Button CssClass="btn btnPrimary" ID="btnBack" CausesValidation="False" runat="server" Text="Back" OnClick="btnBack_Click"/>

          <asp:Button CssClass="btn btnPrimary" ID="btnSave" CausesValidation="False" runat="server" Text="Save" OnClick="btnSave_Click"/>
               
          
        </div>

   </form>

    

 </div>
</body>
</html>
