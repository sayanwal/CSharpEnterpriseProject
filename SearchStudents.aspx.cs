using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CommunityESwap
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void tbSkillset_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnBrowsest_Click(object sender, EventArgs e)
        {
            Session["skillset"] = tbSkillset.Text;
            GridView1.Visible = true;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Session["userid"] = null;
            Response.Redirect("StartHereTest.aspx");
        }
    }
}