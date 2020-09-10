<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewMeetings.aspx.cs" Inherits="Voting.Pages.ViewMeetings" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link rel="stylesheet" type="text/css" href="../Style/StyleSheet1.css" />
    <title>Voting</title>
</head>
<body>
    <div class="login-page form" style="width:100%;max-width:1200px;">
        <form id="form1" runat="server">
             <div class="login-form">
                <asp:Button CssClass="btn btnPrimary" ID="btnBack" CausesValidation="False" runat="server" Text="Back" OnClick="btnBack_Click"/>

                <asp:Table ID="myTable" runat="server" Width="100%"> 
                    <asp:TableRow>
                        <asp:TableCell>Meeting ID</asp:TableCell>
                        <asp:TableCell>Body Corporate</asp:TableCell>
                        <asp:TableCell>Password</asp:TableCell>
                        <asp:TableCell>Date</asp:TableCell>
                        <asp:TableCell>Q1</asp:TableCell>
                        <asp:TableCell>Q2</asp:TableCell>
                        <asp:TableCell>Q3</asp:TableCell>
                        <asp:TableCell>Q4</asp:TableCell>
                        <asp:TableCell>Q5</asp:TableCell>
                        <asp:TableCell>Q6</asp:TableCell>
                        <asp:TableCell>Q7</asp:TableCell>
                        <asp:TableCell>Q8</asp:TableCell>
                        <asp:TableCell>Q9</asp:TableCell>
                        <asp:TableCell>Q10</asp:TableCell>
                        <asp:TableCell>Q11</asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </div>
        </form> 
    </div>
</body>
</html>
