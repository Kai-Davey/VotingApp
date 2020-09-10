<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonalDetails.aspx.cs" Inherits="Voting.Pages.PersonalDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="../Style/StyleSheet1.css" />
    <title>Voting</title>
</head>
<body>
    <div class="login-page form" style="width:800px;max-width:800px;">

     <form runat="server">

        <div class="register-form">
          <h1>Navigation</h1>
            <div >
               <asp:Button style="display:inline-block !important;width:250px;" CssClass="btn btnPrimary" ID="btnAttendMeeting" runat="server" Text="Attend Meeting" OnClick="btnAttendMeeting_Click"/>
               <asp:Button style="display:inline-block  !important;width:250px;" CssClass="btn btnPrimary" ID="btnCreateMeeting" runat="server" Text="Create Meeting" OnClick="btnCreateMeeting_Click"/>
               <asp:Button style="display:inline-block !important;width:250px;" CssClass="btn btnPrimary" ID="btnViewMeetings" runat="server" Text="View Meetings" OnClick="btnViewMeetings_Click"  />
            </div>
        </div>

        <div class="login-form">
          <h1>Check your details</h1>
          <asp:TextBox runat="server" id="Name" type="text" placeholder="Name"/>
          <asp:TextBox runat="server" id="ID"  placeholder="ID"/>
          <asp:TextBox runat="server" id="Email" type="text" placeholder="Email"/>
          <asp:TextBox runat="server" id="CellNumber"  placeholder="Cell Number"/>
          <asp:TextBox runat="server" id="LandLine" type="text" placeholder="Land Line"/>
          <asp:TextBox runat="server" id="PostalAddress"  placeholder="Postal Address"/>
          <asp:TextBox runat="server" id="Password"  placeholder="Password"/>
          <br/>
          <br/>
          <h1>Contact Two:</h1>
          <asp:TextBox runat="server" id="ContactTwoName"  placeholder="Contact Two Name"/>
          <asp:TextBox runat="server" id="ContactTwoEmail" type="text" placeholder="Contact Two Email"/>
          <asp:TextBox runat="server" id="ContactTwoCell"  placeholder="Contact Two Cell"/>
          <asp:TextBox runat="server" id="ContactTwoLandLine" type="text" placeholder="Contact Two Land Line"/>

          <br/>
          <br/>
          <h1>Trust:</h1>
          <asp:TextBox runat="server" id="TrustName" type="text" placeholder="Trust Name"/>
          <asp:TextBox runat="server" id="TrustReg"  placeholder="Trust Registration"/>
          
          <br/>
          <br/>
          <h1>CC:</h1>
          <asp:TextBox runat="server" id="CCName" type="text" placeholder="CC Name"/>
          <asp:TextBox runat="server" id="CCRegNum"  placeholder="CC Reg Number"/>

          <br/>
          <br/>
          <h1>PTY:</h1>
          <asp:TextBox runat="server" id="PTYName" type="text" placeholder="PTY Name"/>
          <asp:TextBox runat="server" id="PTYReg"  placeholder="PTY Registration Number"/>

          <br/>
          <br/>
          <h1>Body Corporate:</h1>
          <asp:TextBox runat="server" id="BodyCoprorateName" type="text" placeholder="Body Corporate Name"/>
          <asp:TextBox runat="server" id="BodyCoprorateNum"  placeholder="Body Corporate Registratcion Number"/>

           <br/>
          <br/>
          <h1>Rental Agent:</h1>
          <asp:TextBox runat="server" id="RentalAgentEmail" type="text" placeholder="Rental Agent Email"/>


          <asp:Button CssClass="btn btnPrimary" ID="btnSave" CausesValidation="False" runat="server" Text="Save" OnClick="btnSave_Click"/>
               
          
        </div>

   </form>

    

 </div>
</body>
</html>
