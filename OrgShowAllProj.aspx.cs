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
            if (Session["user"] == null)
            {
                Server.Transfer("StartHereTest.aspx");
            }
            else
            {
                Users user = (Users)Session["user"];
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            //GridViewRow row = GridView1.SelectedRow;

            //Label1.Text = row.Cells[1].Text;
            //Label2.Text = row.Cells[2].Text;
            //Label3.Text = row.Cells[3].Text;

            Session["projectid"] = GridView1.SelectedDataKey.Value.ToString();
            Response.Redirect("OrgViewProj.aspx");

        }

        protected void btnAddProject_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrgAddProj.aspx");
        }

        protected void lbProjects_Click(object sender, EventArgs e)
        {
            Server.Transfer("OrgShowAllProj.aspx");
        }

        protected void lbStudents_Click(object sender, EventArgs e)
        {
            Server.Transfer("OrgViewStud.aspx");
        }

        protected void lbLogout_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Session["userid"] = null;
            Response.Redirect("StartHereTest.aspx");
        }
    }
}