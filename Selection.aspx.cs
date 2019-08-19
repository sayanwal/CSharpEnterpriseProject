using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CommunityESwap
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSeeS_Click(object sender, EventArgs e)
        {
            Response.Redirect("AppliedApplicants.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Session["userid"] = null;
            Response.Redirect("StartHereTest.aspx");
        }

        protected void btnSeep_Click(object sender, EventArgs e)
        {

        }
    }
}