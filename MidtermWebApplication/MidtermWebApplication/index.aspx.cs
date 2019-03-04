using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace MidtermWebApplication
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Midterm"].ConnectionString);
            string qry = "select UserId, Password, Type from Users where Login=@u";
            SqlCommand cmd = new SqlCommand(qry, conn);
            cmd.Parameters.AddWithValue("@u", tbxUserName.Text.ToString());
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                SHA1 sha1 = new SHA1CryptoServiceProvider();
                sha1.ComputeHash(ASCIIEncoding.ASCII.GetBytes(tbxPassword.Text.ToString()));
                byte[] result = sha1.Hash;
                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < result.Length; i++)
                {
                    strBuilder.Append(result[i].ToString("x2"));
                }
                rdr.Read();
                if (rdr["Password"].ToString().Equals(strBuilder.ToString()))
                {
                    string type = rdr["Type"].ToString();
                    Session["userid"] = rdr["UserID"].ToString();
                    if (type.Equals("Tester"))
                    {
                        Response.Redirect("Tester.aspx");
                    }
                    else if (type.Equals("Developer"))
                    {
                        Response.Redirect("Developer.aspx");
                    }
                    else if (type.Equals("Manager"))
                    {
                        Response.Redirect("Manager.aspx");
                    }
                    else if (type.Equals("Administrator"))
                    {
                        Response.Redirect("Administrator.aspx");
                    }
                    else
                    {
                        Response.Redirect("index.aspx");
                    }
                }
                else
                {
                    Response.Write("<strong>Incorrect password</strong>");
                }
            }
            else
            {
                Response.Write("<strong>Incorrect password</strong>");
            }
            rdr.Close();
            conn.Close();
        }
    }
}