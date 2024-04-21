using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace LoginWithSP
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_Login",con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            cmd.Parameters.AddWithValue("@Username", TextBox1.Text);
            cmd.Parameters.AddWithValue("@Password", TextBox2.Text);
            con.Open();
            int usercount = (Int32)cmd.ExecuteScalar();
            if (usercount == 1)
            {
                Response.Redirect("Welcome.aspx");
            }
            else
            {
                con.Close();
                Label1.Text = "Invalid UserName or Password";
            }
        }
    }
}