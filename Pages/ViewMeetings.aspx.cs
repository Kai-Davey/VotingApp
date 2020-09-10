using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Voting.Pages
{
    public partial class ViewMeetings : System.Web.UI.Page
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
                        //Get all meeting set by user

                        try
                        {
                            conn = new MySqlConnection();
                            conn.ConnectionString = connstr;
                            conn.Open();
                            string qry = "SELECT * FROM `Meeting` WHERE `OwnerID` = '" + Session["ID"].ToString() + "';";
                            MySqlCommand cmd2 = new MySqlCommand(qry, conn);

                            MySqlDataReader datareader = cmd2.ExecuteReader();
                            while (datareader.Read())
                            {
                                TableRow row = new TableRow();
                                TableCell cell1 = new TableCell();
                                TableCell cell2 = new TableCell();
                                TableCell cell3 = new TableCell();
                                TableCell cell4 = new TableCell();
                                TableCell cell5 = new TableCell();
                                TableCell cell6 = new TableCell();
                                TableCell cell7 = new TableCell();
                                TableCell cell8 = new TableCell();
                                TableCell cell9 = new TableCell();
                                TableCell cell10 = new TableCell();
                                TableCell cell11 = new TableCell();
                                TableCell cell12 = new TableCell();
                                TableCell cell13 = new TableCell();
                                TableCell cell14 = new TableCell();
                                TableCell cell15 = new TableCell();

                                cell1.Text = datareader["MeetingID"].ToString();
                                cell2.Text = datareader["BodyCorporate"].ToString();
                                cell3.Text = datareader["Password"].ToString();
                                cell4.Text = datareader["Date"].ToString();
                                cell5.Text = datareader["Q1"].ToString();
                                cell6.Text = datareader["Q2"].ToString();
                                cell7.Text = datareader["Q3"].ToString();
                                cell8.Text = datareader["Q4"].ToString();
                                cell9.Text = datareader["Q5"].ToString();
                                cell10.Text = datareader["Q6"].ToString();
                                cell11.Text = datareader["Q7"].ToString();
                                cell12.Text = datareader["Q8"].ToString();
                                cell13.Text = datareader["Q9"].ToString();
                                cell14.Text = datareader["Q10"].ToString();
                                cell15.Text = datareader["Q11"].ToString();

                                row.Cells.Add(cell1);
                                row.Cells.Add(cell2);
                                row.Cells.Add(cell3);
                                row.Cells.Add(cell4);
                                row.Cells.Add(cell5);
                                row.Cells.Add(cell6);
                                row.Cells.Add(cell7);
                                row.Cells.Add(cell8);
                                row.Cells.Add(cell9);
                                row.Cells.Add(cell10);
                                row.Cells.Add(cell11);
                                row.Cells.Add(cell12);
                                row.Cells.Add(cell13);
                                row.Cells.Add(cell14);
                                row.Cells.Add(cell15);


                                myTable.Rows.Add(row);
                            }
                            

                        }
                        catch (Exception ex)
                        {
                        }


                    }
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/PersonalDetails.aspx");
        }
    }
}