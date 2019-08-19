using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CommunityESwap
{
    public partial class WebForm3 : System.Web.UI.Page
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


                int projectid = Convert.ToInt32(Session["projectid"]);
                pid.Text = " " + projectid;
                ProjectsDataSet ds = new ProjectsDataSet();
                ProjectsDataSetTableAdapters.ProjectsTableTableAdapter taProjects =
                    new ProjectsDataSetTableAdapters.ProjectsTableTableAdapter();
                taProjects.Fill(ds.ProjectsTable);

                DataTable table = ds.Tables["ProjectsTable"];
                string expression = "projectid = " + projectid;
                DataRow[] foundRows;
                foundRows = table.Select(expression);
                for (int i = 0; i < foundRows.Length; i++)
                {

                    pid.Text = "" + foundRows[i][0];
                    ptitle.Text = "" + foundRows[i][1];
                    pmn.Text = "" + foundRows[i][2];
                    porg.Text = "" + foundRows[i][3];
                    pDate.Text = "" + foundRows[i][4];
                    pdesc.Text = "" + foundRows[i][5];
                    ploc.Text = "" + foundRows[i][6];
                    papps.Text = "" + foundRows[i][7];
                    pweb.Text = "" + foundRows[i][8];
                    pskills.Text = "" + foundRows[i][9];
                    pdur.Text = "" + foundRows[i][10];
                    pAssets.Text = "" + foundRows[i][12];

                }
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Projects project = new Projects();
            project.projectid=Convert.ToInt32(pid.Text);
            project.ProjectName=ptitle.Text;
            project.ProjectManager=pmn.Text;
            project.OrgName=porg.Text;
            project.PostedDate=pDate.Text;
            project.Description=pdesc.Text;
            project.Location=ploc.Text;
            project.AppCount=papps.Text;
            project.Website=pweb.Text;
            project.Skills=pskills.Text;
            project.Duration=pdur.Text;
            project.CompensateAssets = pAssets.Text;

            Session["project"] = project;
            Response.Redirect("OrgEditProj.aspx");
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

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ProjectsDataSet ds1 = new ProjectsDataSet();
            ProjectsDataSetTableAdapters.ProjectsTableTableAdapter taProjects = new ProjectsDataSetTableAdapters.ProjectsTableTableAdapter();

            taProjects.Fill(ds1.ProjectsTable);

            int selected = Convert.ToInt32(Session["projectid"]);
            DataRow[] dr = ds1.ProjectsTable.Select("projectid=" + selected);



            dr[0].Delete();
         

            taProjects.Update(ds1.ProjectsTable);
            taProjects.Fill(ds1.ProjectsTable);
            Label1.Text = "Deleted This Project Successfully";
        }
    }
}