using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace MidtermWebApplication
{
    public partial class Tester : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmitBug_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Week8CS"].ConnectionString);
            string qry = "insert into Bugs (subject, priority, description)";
            SqlCommand cmd = new SqlCommand(qry, conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@subject", tbxBugSubject);
            cmd.Parameters.AddWithValue("@priority", ddlBugPriority);
            cmd.Parameters.AddWithValue("@description", tbxBugDiscription);

            conn.Close();

        }
    }
}