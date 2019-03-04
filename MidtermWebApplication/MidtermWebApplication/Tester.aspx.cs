using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace MidtermWebApplication
{
    public partial class Tester : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ddlPriorityOfBug.Items.Add(new ListItem("Low", "Low"));
                ddlPriorityOfBug.Items.Add(new ListItem("Medium", "Medium"));
                ddlPriorityOfBug.Items.Add(new ListItem("High", "High"));
            }
        }

        protected void btnSubmitBug_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Midterm"].ConnectionString);
            string qry = "INSERT into Bugs(EnteredBy, Subject, Priority, Description, Status) VALUES(@e, @s, @p, @d, @st)";
            SqlCommand cmd = new SqlCommand(qry, conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@e", Session["userid"]);
            cmd.Parameters.AddWithValue("@s", tbxSubjectOfBug.Text.ToString());
            cmd.Parameters.AddWithValue("@p", ddlPriorityOfBug.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@d", tbxDescriptionOfBug.Text.ToString());
            cmd.Parameters.AddWithValue("@st", "Open");
            int numRows = cmd.ExecuteNonQuery();
            conn.Close();
            if (numRows == 1)
            {
                Response.Write("<strong>Bug report submitted</strong>");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["userid"] = null;
            Response.Redirect("index.aspx");
        }
    }
}