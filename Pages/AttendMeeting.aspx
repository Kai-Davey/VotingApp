<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AttendMeeting.aspx.cs" Inherits="Voting.Pages.AttendMeeting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link rel="stylesheet" type="text/css" href="../Style/StyleSheet1.css" />
    <title>Voting</title>
</head>
<body>
   <div class="login-page form" style="width:800px;max-width:800px;">

     <form runat="server">


         <div runat="server" class="login-form" id="SearchMeeting">
             <asp:TextBox runat="server" id="MeetingName" type="text" placeholder="Meeting Name"/>
             <asp:TextBox runat="server" id="Password" type="password" placeholder="Password"/>
             <asp:Button CssClass="btn btnPrimary" ID="btnJoin" CausesValidation="False" runat="server" Text="Join" OnClick="btnJoin_Click" />
             <asp:Button CssClass="btn btnPrimary" ID="Button1" CausesValidation="False" runat="server" Text="Back" OnClick="btnBack_Click" />
         </div>
        

        <div runat="server" class="login-form" id="viewmeeting">
             <asp:Button CssClass="btn btnPrimary" Visible="false" ID="btnopen" CausesValidation="False" runat="server" Text="Open" OnClick="btnopen_Click"/>
          <h1>Questions</h1>
           <asp:Table ID="myTable" runat="server" Width="100%"> 
                    <asp:TableRow>
                        <asp:TableCell>Number</asp:TableCell>
                        <asp:TableCell>Question</asp:TableCell>
                        <asp:TableCell>In Favour</asp:TableCell>
                        <asp:TableCell>Against</asp:TableCell>
                        <asp:TableCell>Abstain</asp:TableCell>
                    </asp:TableRow>
            </asp:Table>

          
            <asp:Button CssClass="btn btnPrimary" ID="btnBack" CausesValidation="False" runat="server" Text="Back" OnClick="btnBack_Click" />
           

          <asp:Button CssClass="btn btnPrimary" ID="btnsubmit" CausesValidation="False" runat="server" Text="submit" OnClick="btnsubmit_Click"/>
               
          
        </div>

   </form>

    

 </div>
</body>
</html>
