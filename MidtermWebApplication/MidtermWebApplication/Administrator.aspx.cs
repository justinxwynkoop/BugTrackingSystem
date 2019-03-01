using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MidtermWebApplication
{
    public partial class Administrator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateUser_Click(object sender, EventArgs e)
        {
            string password = tbxUniquePassword.Text.ToString();
            if (password.Length < 8)
            {
                Response.Write("Password is not long enough");
                return;
            }
            if (!password.Any(char.IsDigit))
            {
                Response.Write("Password does not contain at least one number");
            }

        }
    }
}