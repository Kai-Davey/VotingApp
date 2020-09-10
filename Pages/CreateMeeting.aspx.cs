using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Voting.Pages
{
    public partial class CreateMeeting : System.Web.UI.Page
    {
        string connstr = "SERVER=154.0.168.132;PORT=3306;DATABASE=eagleunq_Voting;UID=eagleunq_Votes;PASSWORD=IUXOpgYbU6]n;";
        MySqlConnection conn;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["ID"] == null)//Redirect
                {
                    Response.Redirect("~/Pages/Login.aspx");
                }
                else
                {
                    //Check if user is admin, to see if must display more buttons(for redirect)
                    if (Session["admin"].ToString() != "true")
                    {
                        Response.Redirect("~/Pages/Login.aspx");
                    }
                    else
                    {
                        //Random random = new Random();
                        //int num = random.Next(10);
                        MeetingName.Text = Membership.GeneratePassword(6, 0).ToString();
                        while (getRandom() == true)
                        {
                            //num = random.Next(10);
                            MeetingName.Text = Membership.GeneratePassword(6, 0).ToString();
                        }
                        

                        

                    }
                }
            }

        }//End of Page Load

        private bool getRandom()
        {
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = connstr;
                conn.Open();
                string qry = "SELECT * FROM `Meeting` WHERE `MeetingID` = '" + MeetingName.Text.ToString() + "';";
                MySqlCommand cmd2 = new MySqlCommand(qry, conn);

                MySqlDataReader datareader = cmd2.ExecuteReader();
                while (datareader.Read())
                {
                    if (MeetingName.Text.Equals(datareader["MeetingID"]))
                    {
                        return true;
                    }
                }
                return false;

            }
            catch(Exception ex)
            {
                return false;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/PersonalDetails.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = connstr;
                conn.Open();


                string qry = "INSERT INTO `Meeting`(`Password`, `Q1`, `Q2`, `Q3`, `Q4`, `Q5`, `Q6`, `Q7`, `Q8`, `Q9`, `Q10`, `Q11`,"+
                             "`MeetingID`, `BodyCorporate`, `Date`, `OwnerID`, `Open`) VALUES " +
                             "('"+ Password.Text +"','" + Q1.Text +"','" + Q2.Text + "','" + Q3.Text + "','" + Q4.Text + "','" + Q5.Text
                             + "','" + Q6.Text + "','" + Q7.Text + "','" + Q8.Text + "','" + Q9.Text + "','" + Q10.Text + "','" + Q11.Text 
                             + "','" + MeetingName.Text +"','" + bodyCorp.Text +"','" + Calendar1.SelectedDate.ToString("yyyy-MM-dd") + 
                             "','" + Session["ID"] + "','false')";



                MySqlCommand cmd2 = new MySqlCommand(qry, conn);
                int i = cmd2.ExecuteNonQuery();//i holds how many rows where changed

                if (i > 0)
                {
                    //went through
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Meeting Created" + "');", true);
                }
                else
                {
                    //error
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Sorry, Something went wrong" + "');", true);
                }

                conn.Close();
            }
            catch (Exception error)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Sorry, Something went wrong" + "');", true);
            }

        }
    }
}