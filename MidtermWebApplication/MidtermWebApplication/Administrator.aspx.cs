using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace MidtermWebApplication
{
    public partial class Administrator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ddlEmployeeType.Items.Add(new ListItem("Tester", "Tester"));
                ddlEmployeeType.Items.Add(new ListItem("Developer", "Developer"));
                ddlEmployeeType.Items.Add(new ListItem("Manager", "Manager"));
                ddlEmployeeType.Items.Add(new ListItem("Administrator", "Administrator"));
            }
        }

        protected void btnCreateUser_Click(object sender, EventArgs e)
        {
            //checking password length and contains numbers
            string password = tbxNewUserPassword.Text.ToString();
            if (password.Length < 8)
            {
                Response.Write("<strong>Password is not long enough</strong>");
                return;
            }
            if (!password.Any(char.IsDigit))
            {
                Response.Write("<strong>Password does not contain at least one(1) number</strong>");
                return;
            }
            //hash password here, get process from the login.aspx.cs file
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            sha1.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));
            byte[] result = sha1.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Midterm"].ConnectionString);
            string idqry = "select MAX(UserID) from Users";
            SqlCommand cmd = new SqlCommand(idqry, conn);
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            int maxID = 0;
            if (rdr.HasRows)
            {
                rdr.Read();
                maxID = rdr.GetInt32(0);

            }
            rdr.Close();
            //checking login to make sure it is unique 
            string loginqry = "Select Login from Users where Login = @l";
            cmd.Parameters.AddWithValue("@l", tbxNewUserLogin.Text.ToString());
            cmd.CommandText = loginqry;
            SqlDataReader rdr2 = cmd.ExecuteReader();
            if (rdr2.HasRows)
            {
                Response.Write("<strong>There is already a user with that Login");
                return;
            }
            rdr2.Close();
            //inserting new user into users database
            string insertqry = "INSERT into Users(UserID, Name, Login, Password, Type) VALUES(@u, @n, @lo, @p, @t)";
            cmd.Parameters.AddWithValue("@u", maxID + 1);
            cmd.Parameters.AddWithValue("@n", tbxNewUsername.Text.ToString());
            cmd.Parameters.AddWithValue("@lo", tbxNewUserLogin.Text.ToString());
            cmd.Parameters.AddWithValue("@p", strBuilder.ToString());
            cmd.Parameters.AddWithValue("@t", ddlEmployeeType.SelectedValue.ToString());
            cmd.CommandText = insertqry;
            int numRows = cmd.ExecuteNonQuery();
            if (numRows == 1)
            {
                Response.Write("<strong>User " + tbxNewUsername.Text.ToString() + "(" + tbxNewUserLogin.Text.ToString() + ") Created</strong>");
            }
            conn.Close();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["userid"] = null;
            Response.Redirect("index.aspx");
        }
    }
}