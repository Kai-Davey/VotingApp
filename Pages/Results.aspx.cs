using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Voting.Pages
{
    public partial class Results : System.Web.UI.Page
    {
        string connstr = "SERVER=154.0.168.132;PORT=3306;DATABASE=eagleunq_Voting;UID=eagleunq_Votes;PASSWORD=IUXOpgYbU6]n;";
        MySqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int iQuestion = 0;
                for (int i = 0; i < 11; i++)
                {
                    conn = new MySqlConnection();
                    conn.ConnectionString = connstr;
                    conn.Open();

                    iQuestion++;

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn; 

                    //Favour
                    cmd.CommandText = "GetFavour";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UQuestion", "Q" + iQuestion.ToString());
                    cmd.Parameters["@UQuestion"].Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@UID", Session["MeetingID"].ToString());
                    cmd.Parameters["@UID"].Direction = ParameterDirection.Input;
                    cmd.Parameters.AddWithValue("@UAmount", MySqlDbType.VarChar);
                    cmd.Parameters["@UAmount"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    string sGetFavour = cmd.Parameters["@UAmount"].Value.ToString();


                    //Abstain
                    cmd.Connection = conn;

                    cmd.CommandText = "GetAbstain";
                    cmd.CommandType = CommandType.StoredProcedure;

                    //cmd.Parameters.AddWithValue("@UQuestion", "Q" + iQuestion.ToString());
                    //cmd.Parameters["@UQuestion"].Direction = ParameterDirection.Input;
                    //cmd.Parameters.AddWithValue("@UID", Session["MeetingID"].ToString());
                    //cmd.Parameters["@UID"].Direction = ParameterDirection.Input;
                    //cmd.Parameters.AddWithValue("@UAmount", MySqlDbType.Int32);
                    //cmd.Parameters["@UAmount"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    string sGetAbstain = cmd.Parameters["@UAmount"].Value.ToString();

                    //Against
                    cmd.Connection = conn;

                    cmd.CommandText = "GetAgainst";
                    cmd.CommandType = CommandType.StoredProcedure;

                    //cmd.Parameters.AddWithValue("@UQuestion", "Q" + iQuestion.ToString());
                    //cmd.Parameters["@UQuestion"].Direction = ParameterDirection.Input;
                    //cmd.Parameters.AddWithValue("@UID", Session["MeetingID"].ToString());
                    //cmd.Parameters["@UID"].Direction = ParameterDirection.Input;
                    //cmd.Parameters.AddWithValue("@UAmount", MySqlDbType.Int32);
                    //cmd.Parameters["@UAmount"].Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    string sGetAgainst = cmd.Parameters["@UAmount"].Value.ToString();



                    conn.Close();

                    conn = new MySqlConnection();
                    conn.ConnectionString = connstr;
                    conn.Open();


                    //Question
                    /*BEGIN
                        SET @s=CONCAT('SELECT ',UQuestion,' into @UQuestion from `Meeting` where `MeetingID`= "',UID,'"');
                        PREPARE stmt1 FROM @s;

                        EXECUTE stmt1;
                        DEALLOCATE PREPARE stmt1;

                        SELECT @UQuestion INTO UAmount;

                        End
                        */
                    string sQuestion = "ERROR";

                    string qry = "SELECT Q"+ iQuestion.ToString() + " FROM `Meeting` WHERE `MeetingID` = '" + Session["MeetingID"].ToString() + "';";
                    MySqlCommand cmd2 = new MySqlCommand(qry, conn);

                    MySqlDataReader datareader = cmd2.ExecuteReader();
                    while (datareader.Read())
                    {
                        sQuestion = datareader["Q" + iQuestion.ToString()].ToString();
                    }

                    conn.Close();


                    TableRow row = new TableRow();
                    TableCell cell1 = new TableCell();
                    TableCell cell2 = new TableCell();
                    TableCell cell3 = new TableCell();
                    TableCell cell4 = new TableCell();
                    TableCell cell5 = new TableCell();

                    cell1.Text = iQuestion.ToString();
                    cell2.Text = sQuestion;

                    cell3.Text = sGetFavour;
                    cell4.Text = sGetAgainst;
                    cell5.Text = sGetAbstain;


                    row.Cells.Add(cell1);
                    row.Cells.Add(cell2);
                    row.Cells.Add(cell3);
                    row.Cells.Add(cell4);
                    row.Cells.Add(cell5);

                    myTable.Rows.Add(row);
                }
               
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Sorry something went wrong" + "');", true);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/PersonalDetails.aspx");
        }
    }
}
 