using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Voting.Pages
{
    public partial class PersonalDetails : System.Web.UI.Page
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
                    if (Session["admin"].ToString() == "true")
                    {
                        btnViewMeetings.Visible = true;
                        btnCreateMeeting.Visible = true;
                    }
                    else
                    {
                        btnViewMeetings.Visible = false;
                        btnCreateMeeting.Visible = false;
                    }

                    //Pull all details
                    try
                    {
                        conn = new MySqlConnection();
                        conn.ConnectionString = connstr;
                        conn.Open();

                        string qry = "Select * from Users where `ID`='" + Session["ID"].ToString() + "';";
                        MySqlCommand cmd2 = new MySqlCommand(qry, conn);

                        MySqlDataReader datareader = cmd2.ExecuteReader();
                        while (datareader.Read())
                        {//datareader["Password"].ToString()
                            if (datareader["ID"].ToString() == Session["ID"].ToString())
                            {
                                //went through
                                Name.Text = datareader["OwnerName"].ToString();
                                ID.Text = datareader["ID"].ToString();
                                Email.Text = datareader["Email"].ToString();
                                Session["Email"] = datareader["Email"].ToString();
                                CellNumber.Text = datareader["Cell"].ToString();
                                LandLine.Text = datareader["Landline"].ToString();
                                ContactTwoName.Text = datareader["C2Name"].ToString();
                                ContactTwoEmail.Text = datareader["C2Email"].ToString();
                                ContactTwoCell.Text = datareader["C2Cell"].ToString();
                                ContactTwoLandLine.Text = datareader["C2LandLine"].ToString();
                                PostalAddress.Text = datareader["PostalAddress"].ToString();
                                TrustName.Text = datareader["TrustName"].ToString();
                                TrustReg.Text = datareader["TrustReg"].ToString();
                                CCName.Text = datareader["CCName"].ToString();
                                CCRegNum.Text = datareader["CCRegNo"].ToString();
                                PTYName.Text = datareader["PTYName"].ToString();
                                PTYReg.Text = datareader["PTYRegNo"].ToString();
                                BodyCoprorateName.Text = datareader["BodyCorporateName"].ToString();
                                BodyCoprorateNum.Text = datareader["BodyCorporateRegNo"].ToString();
                                RentalAgentEmail.Text = datareader["RentalAgentEmail"].ToString();
                                Password.Text = datareader["Password"].ToString();



                                break;
                            }
                            else
                            {
                                //details are incorrect
                                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Error, please try again" + "');", true);
                                Response.Redirect("~/Pages/Login.aspx");
                                break;
                            }


                        }

                        datareader.Close();
                        conn.Close();
                    }
                    catch (Exception error)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Sorry, Something went wrong" + "');", true);
                    }
                }
            }
            
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = connstr;
                conn.Open();

             
                string qry = "UPDATE `Users` SET" +
                              "`OwnerName`='" + Name.Text + "',`ID`='" + ID.Text + "',`Email`='" + Email.Text + "',`Cell`='" + CellNumber.Text + "',`Landline`='" + LandLine.Text + "'," +
                              "`C2Name`='" + ContactTwoName.Text + "', `C2Email`='" + ContactTwoEmail.Text + "',`C2Cell`='" + ContactTwoCell.Text + "',`C2LandLine`='" + ContactTwoLandLine.Text + "'," +
                              "`PostalAddress`='" + PostalAddress.Text + "',`TrustName`='" + TrustName.Text + "', `TrustReg`='" + TrustReg.Text + "'," +
                              "`CCName`='" + CCName.Text + "',`CCRegNo`='" + CCRegNum.Text + "',`PTYName`='" + PTYName.Text + "',`PTYRegNo`='" + PTYReg.Text + "'," +
                              "`BodyCorporateName`='" + BodyCoprorateName.Text + "',`BodyCorporateRegNo`='" + BodyCoprorateNum.Text + "',`RentalAgentEmail`='" + RentalAgentEmail.Text + "', " +
                              "`Password`='" + Password.Text +"' "+
                              " WHERE  `ID` = '" + Session["ID"].ToString() + "' AND `Email`= '"+ Session["Email"].ToString() + "';";



                MySqlCommand cmd2 = new MySqlCommand(qry, conn);
                int i = cmd2.ExecuteNonQuery();//i holds how many rows where changed

                if (i > 0)
                {
                    //went through
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Details Updated" + "');", true);

                    Session["ID"] = ID.Text;
                    Session["Email"] = Email.Text;
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



        protected void btnAttendMeeting_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/AttendMeeting.aspx");

        }

        protected void btnCreateMeeting_Click(object sender, EventArgs e)
        {
            if (Session["admin"].ToString() != "true")
            {
                Response.Redirect("~/Pages/Login.aspx");
            }
            else
            {
                Response.Redirect("~/Pages/CreateMeeting.aspx");
            }
        }

        protected void btnViewMeetings_Click(object sender, EventArgs e)
        {
            if (Session["admin"].ToString() != "true")
            {
                Response.Redirect("~/Pages/Login.aspx");
            }
            else
            {
                Response.Redirect("~/Pages/ViewMeetings.aspx");
            }
        }

       
    }
}