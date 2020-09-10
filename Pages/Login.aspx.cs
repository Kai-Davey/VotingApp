using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Voting.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        string connstr = "SERVER=154.0.168.132;PORT=3306;DATABASE=eagleunq_Voting;UID=eagleunq_Votes;PASSWORD=IUXOpgYbU6]n;";
        MySqlConnection conn;

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = connstr;
                conn.Open();

                string sID = edtid.Text;
                string sEmail = edtEmail.Text;
                string sPassword = edtPassword.Text;

                string qry = "INSERT INTO `Users`(`ID`,`Email`,`Password`,`Admin`) VALUES('"+ sID +"','"+sEmail + "','" +sPassword + "','false')";
                MySqlCommand cmd2 = new MySqlCommand(qry, conn);
                int i = cmd2.ExecuteNonQuery();//i holds how many rows where changed

                if (i>0)
                {
                    //went through
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Account added" + "');", true);
                    Response.Redirect("~/Pages/PersonalDetails.aspx");
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

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string sEmail = edtLoginEmail.Text;
            string sPassword = edtLoginPassword.Text;

            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = connstr;
                conn.Open();

                string qry = "Select * from Users where `Email`='"+sEmail+ "' and `Password`='"+sPassword + "';";
                MySqlCommand cmd2 = new MySqlCommand(qry, conn);

                bool blogin = false;

                MySqlDataReader datareader = cmd2.ExecuteReader();
                while (datareader.Read())
                {//datareader["Password"].ToString()
                    if (datareader["Email"].ToString() == sEmail)
                    { 
                        //went through
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Account added" + "');", true);
                        Session["ID"] = datareader["ID"].ToString();//save time of login
                        Session["admin"] = datareader["Admin"].ToString();
                        Response.Redirect("~/Pages/PersonalDetails.aspx");
                        blogin = true;
                        break;
                    }
                    else
                    {
                        //details are incorrect
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please check your details and try again" + "');", true);
                        break;
                    }


                }

                if (blogin == false)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please check your details and try again" + "');", true);
                    
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