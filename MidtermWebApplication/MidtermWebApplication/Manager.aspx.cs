using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace MidtermWebApplication
{
    public partial class Manager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Midterm"].ConnectionString);
                string bugqry = "select BugID, Subject from Bugs where Status =@st ";
                SqlCommand cmd = new SqlCommand(bugqry, conn);
                cmd.Parameters.AddWithValue("@st", "Open");
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ListItem listItems = new ListItem(rdr["Subject"].ToString() + ", " + rdr["BugID"].ToString(), rdr["BugID"].ToString());
                    ddlNewBugs.Items.Add(listItems);
                }
                rdr.Close();
                string developerqry = "select Name, UserID from Users where Type = @d";
                cmd.Parameters.AddWithValue("@d", "Developer");
                cmd.CommandText = developerqry;
                SqlDataReader rdr2 = cmd.ExecuteReader();
                while (rdr2.Read())
                {
                    ListItem li = new ListItem(rdr2["Name"].ToString() + ", " + rdr2["UserID"].ToString(), rdr2["UserID"].ToString());
                    ddlListOfDevelopers.Items.Add(li);
                }
                rdr2.Close();
                conn.Close();
            }
        }

        protected void btnAssign_Click(object sender, EventArgs e)
        {
            //do update query to change assignedTo to the userID of a developer
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Midterm"].ConnectionString);
            string bugqry = "Update Bugs Set AssignedTo = @de where BugID = @bi";
            SqlCommand cmd = new SqlCommand(bugqry, conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@de", ddlListOfDevelopers.SelectedValue);
            cmd.Parameters.AddWithValue("@bi", ddlNewBugs.SelectedValue);
            int numRows = cmd.ExecuteNonQuery();
            if (numRows == 1)
            {
                Response.Write("<strong>The bug has been assigned to " + ddlListOfDevelopers.SelectedItem.Text + ".</strong>");
            }
            conn.Close();
        }

        protected void ddlNewBugs_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Midterm"].ConnectionString);
            string bugqry = "select * from Bugs where BugID = @b";
            SqlCommand cmd = new SqlCommand(bugqry, conn);
            cmd.Parameters.AddWithValue("@b", ddlNewBugs.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvBugInfo.DataSource = dt;
            gvBugInfo.DataBind();

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["userid"] = null;
            Response.Redirect("index.aspx");
        }
    }
}