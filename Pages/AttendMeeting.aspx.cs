using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Voting.Pages
{
    public partial class AttendMeeting : System.Web.UI.Page
    {
        string connstr = "SERVER=154.0.168.132;PORT=3306;DATABASE=eagleunq_Voting;UID=eagleunq_Votes;PASSWORD=IUXOpgYbU6]n;";
        MySqlConnection conn;

        private static string smeetingid;

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
                    viewmeeting.Visible = false;
                    SearchMeeting.Visible = true;
                    btnopen.Visible = false;
                }
            }
            else
            {
                if (myTable.Rows.Count < 2)
                {
                    loadMeeting();
                }
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            List<string> lstQuestion = new List<string>();
            int i = 0;
            foreach (TableRow row in myTable.Rows)
            {
                if (i == 0)
                {
                    i++;
                }
                else
                {
                    CheckBox infav = row.Cells[2].Controls[0] as CheckBox;
                    CheckBox against = row.Cells[3].Controls[0] as CheckBox;
                    int QID = int.Parse(row.Cells[0].Text);

                    if (infav.Checked)
                    {
                        //Perform further processing
                        lstQuestion.Add("In Favour");
                    }
                    else if(against.Checked)
                    {
                        lstQuestion.Add("Against");
                    }else
                    {
                        lstQuestion.Add("Abstain");
                    }
                }
                
            }


            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = connstr;
                conn.Open();


                string qry = "INSERT INTO `Results` ( `UserID`, `MeetingID`, `Q1`, `Q2`, `Q3`, `Q4`, `Q5`, `Q6`, `Q7`, `Q8`, `Q9`, `Q10`, `Q11`) VALUES " +
                             "('" + Session["ID"].ToString() + "','" + smeetingid + "','" + lstQuestion[0] + "','" + lstQuestion[1] + "','" + lstQuestion[2] +
                             "','" + lstQuestion[3] + "','" + lstQuestion[4] + "','" + lstQuestion[5] + "','" + lstQuestion[6] + "','" +
                            lstQuestion[7] + "','" + lstQuestion[8] + "','" + lstQuestion[9]
                             + "','" + lstQuestion[10] +"')";



                MySqlCommand cmd2 = new MySqlCommand(qry, conn);
                int iPost = cmd2.ExecuteNonQuery();//i holds how many rows where changed

                if (iPost > 0)
                {
                    //went through
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Input added" + "');", true);
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

        protected bool loadMeeting()
        {
            if (myTable.Rows.Count > 2)
            {
                return true;
            }
                //Check if user is admin, to see if must display more buttons(for redirect)
                btnopen.Visible = false;

            //Get all meeting set by user

            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = connstr;
                conn.Open();

                bool bdone = false;

                //Stop someone from logging twice
                string check = "SELECT * FROM `Results` WHERE `UserID` = '" + Session["ID"].ToString() + "';";
                MySqlCommand cmdcheck = new MySqlCommand(check, conn);
                MySqlDataReader datareader1 = cmdcheck.ExecuteReader();
                while (datareader1.Read())
                {
                    bdone = true;
                }
                datareader1.Close();


                string qry = "SELECT * FROM `Meeting` WHERE `MeetingID` = '" + MeetingName.Text + "' AND `Password` = '" + Password.Text + "';";
                MySqlCommand cmd2 = new MySqlCommand(qry, conn);

                MySqlDataReader datareader = cmd2.ExecuteReader();
                int iQuestion = 0;
                while (datareader.Read())
                {
                    if (datareader["OwnerID"].ToString() != Session["ID"].ToString())
                    {
                        if (bdone == true)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "You have already voted for this meeting" + "');", true);
                            return false;
                        }
                        if (datareader["Open"].ToString() == "false")
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "The meeting is still closed." + "');", true);
                            return false;
                        }
                    }
                    else
                    {
                        btnopen.Visible = true;
                        if (datareader["Open"].ToString() == "true")
                        {
                            btnopen.Text = "close";
                        }
                            
                    }


                    smeetingid = datareader["ID"].ToString();
                    for (int i = 0; i < 11; i++)
                    {
                        iQuestion++;
                        TableRow row = new TableRow();
                        TableCell cell1 = new TableCell();
                        TableCell cell2 = new TableCell();
                        TableCell cell3 = new TableCell();
                        TableCell cell4 = new TableCell();
                        TableCell cell5 = new TableCell();

                        cell1.Text = iQuestion.ToString();
                        cell2.Text = datareader["Q" + iQuestion.ToString()].ToString();

                        CheckBox Check1 = new CheckBox();
                        cell3.Controls.Add(Check1);

                        CheckBox Check2 = new CheckBox();
                        cell4.Controls.Add(Check2);

                        CheckBox Check3 = new CheckBox();
                        cell5.Controls.Add(Check3);


                        row.Cells.Add(cell1);
                        row.Cells.Add(cell2);
                        row.Cells.Add(cell3);
                        row.Cells.Add(cell4);
                        row.Cells.Add(cell5);

                        myTable.Rows.Add(row);
                    }


                }
                if (iQuestion == 0)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Sorry something went wrong" + "');", true);
                return false;

            }
            return false;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/PersonalDetails.aspx");
        }

        protected void btnopen_Click(object sender, EventArgs e)
        {
            if (btnopen.Text != "close")
            {
               

                try
                {
                    conn = new MySqlConnection();
                    conn.ConnectionString = connstr;
                    conn.Open();


                    string qry = "UPDATE `Meeting` SET `Open` = 'true' where `ID` = '" + smeetingid + "';";



                    MySqlCommand cmd2 = new MySqlCommand(qry, conn);
                    int iPost = cmd2.ExecuteNonQuery();//i holds how many rows where changed

                    if (iPost > 0)
                    {
                        //went through
                        btnopen.Text = "close";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Meeting Open" + "');", true);
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
            else
            {
                //Close it off
                try
                {
                    conn = new MySqlConnection();
                    conn.ConnectionString = connstr;
                    conn.Open();


                    string qry = "UPDATE `Meeting` SET `Open` = 'false' where `ID` = '" + smeetingid + "';";



                    MySqlCommand cmd2 = new MySqlCommand(qry, conn);
                    int iPost = cmd2.ExecuteNonQuery();//i holds how many rows where changed

                    if (iPost > 0)
                    {
                        //went through
                        btnopen.Text = "close";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Meeting Closed, getting result now" + "');", true);
                        Session["MeetingID"] = smeetingid;
                        //Load results page

                        Response.Redirect("~/Pages/Results.aspx");
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

        protected void btnJoin_Click(object sender, EventArgs e)
        {
            if (loadMeeting() == false)
            {
                viewmeeting.Visible = false;
                SearchMeeting.Visible = true;
            }
            else
            {
                viewmeeting.Visible = true;
                SearchMeeting.Visible = false;
            }

        }
    }
}