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
    public partial class Developer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Midterm"].ConnectionString);
                string bugqry = "select BugID, Subject from Bugs where Status = @s and AssignedTo = @d";
                SqlCommand cmd = new SqlCommand(bugqry, conn);
                cmd.Parameters.AddWithValue("@s", "Open");
                cmd.Parameters.AddWithValue("@d", Session["userid"]);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ListItem li = new ListItem(rdr["Subject"].ToString() + ", " + rdr["BugID"].ToString(), rdr["BugID"].ToString());
                    ddlNewBugs.Items.Add(li);
                }
                rdr.Close();
                conn.Close();

            }
            if (ddlNewBugs.Items.Count == 0)
            {
                Response.Write("<strong>All assigned bugs have been closed</strong>");
                gvBugInfo.Columns.Clear();
                gvBugInfo.DataBind();
            }


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

        protected void btnSubmitChanges_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxBugChanges.Text.ToString()))
            {
                Response.Write("<strong>The changes box is empty. Add something to continue.");
                return;
            }
            else
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Midterm"].ConnectionString);
                string qry = "Update Bugs Set Changes = @c , Status = @st where BugID = @bi";
                SqlCommand cmd = new SqlCommand(qry, conn);
                cmd.Parameters.AddWithValue("@c", tbxBugChanges.Text.ToString());
                cmd.Parameters.AddWithValue("@st", "Closed");
                cmd.Parameters.AddWithValue("@bi", ddlNewBugs.SelectedValue);
                conn.Open();
                int numRows = cmd.ExecuteNonQuery();
                if (numRows == 1)
                {
                    Response.Write("<strong>The changes have been logged to BugID: " + ddlNewBugs.SelectedValue + " and the it has been closed.</strong>");
                    ddlNewBugs.Items.RemoveAt(ddlNewBugs.SelectedIndex);

                }
            }

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["userid"] = null;
            Response.Redirect("index.aspx");
        }
    }
}