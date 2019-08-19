using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CommunityESwap
{
    public partial class WebForm3 : System.Web.UI.Page 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["orgname"] = "ABC Church"; //Gridview will filter AppliedApplicants table with Orgnization name
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Session["userid"] = null;
            Response.Redirect("StartHereTest.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("SearchStudents.aspx");
        }
    }
}