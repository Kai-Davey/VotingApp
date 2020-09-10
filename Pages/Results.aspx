<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Results.aspx.cs" Inherits="Voting.Pages.Results" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link rel="stylesheet" type="text/css" href="../Style/StyleSheet1.css" />
    <title>Voting</title>
</head>
<body>
   <div class="login-page form" style="width:800px;max-width:800px;">

     <form runat="server">


        <div runat="server" class="login-form" id="viewmeeting">
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
          
               
          
        </div>

   </form>

    

 </div>
</body>
</html>
