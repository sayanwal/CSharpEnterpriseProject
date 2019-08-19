using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace CommunityESwap
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        Users user;
        Projects project;
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (Session["user"] == null)
            {
                Server.Transfer("StartHereTest.aspx");
            }
            else
            {
                user = (Users)Session["user"];
                project = (Projects)Session["project"];
                tbAsset.Text = project.CompensateAssets;
                tbBudget.Text = project.CompensateAssets;
                tbDesc.Text = project.Description;
                tbDuration.Text = project.Duration;
                tbLoc.Text = project.Location;
                tbOrgName.Text = project.OrgName;
                tbPMngr.Text = project.ProjectManager;
                tbPName.Text = project.ProjectName;
                tbWeb.Text = project.Website;
                tbSkills.Text = project.Skills;
            }
            
        }

        protected void lbLogout_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Session["userid"] = null;
            Response.Redirect("StartHereTest.aspx");
        }

        protected void lbProjects_Click(object sender, EventArgs e)
        {
            Server.Transfer("OrgShowAllProj.aspx");
        }

        protected void lbStudents_Click(object sender, EventArgs e)
        {
            Server.Transfer("OrgShowStud.aspx");
        }

        protected void btnUpdateProject_Click(object sender, EventArgs e)
        {
            string projName = tbPName.Text;
            string projMngr = tbPMngr.Text;
            string orgName = tbOrgName.Text;
            string desc = tbDesc.Text;
            string loc = tbLoc.Text;
            
            string web = tbWeb.Text;
            string dur = tbDuration.Text;
            string skills = "";
            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected)
                {
                    skills += CheckBoxList1.Items[i].Text + " ";
                }
            }
            skills += tbSkills.Text;



            string compensateAssets = "";

            if (cbAssets.Checked)
            {
                compensateAssets += tbAsset.Text;
            }
            if (cbBudget.Checked)
            {
                compensateAssets += tbBudget.Text;
            }


            ProjectsDataSet ds1 = new ProjectsDataSet();
            ProjectsDataSetTableAdapters.ProjectsTableTableAdapter taProjects = new ProjectsDataSetTableAdapters.ProjectsTableTableAdapter();

            taProjects.Fill(ds1.ProjectsTable);

            int selected = project.projectid;
            DataRow[] dr = ds1.ProjectsTable.Select("projectid=" + selected);
            

            dr[0]["ProjectName"] = projName;
            dr[0]["ProjectManager"] = projMngr;
            dr[0]["OrgName"] = orgName;
            dr[0]["Description"] = desc;
            dr[0]["Location"] = loc;

            dr[0]["Website"] = web;
            dr[0]["Skills"] = skills;
            dr[0]["Duration"] = dur;

            taProjects.Update(ds1.ProjectsTable);

            //string userid = user.userid.ToString();
            //SqlConnection cn = new SqlConnection();
            //try
            //{
            //    cn.ConnectionString = "Server=(local);Database=CommunityESwap;Integrated Security = SSPI;";
            //    cn.Open();
            //    SqlDataAdapter da = new SqlDataAdapter("select * from ProjectsTable", cn);

            //    SqlCommand update = new SqlCommand();
            //    update.Connection = cn;
            //    update.CommandType = System.Data.CommandType.Text;
            //    update.CommandText = "UPDATE ProjectsTable SET ProjectName=@ProjName, ProjectManager=@ProjMgr, OrgName=@OrgName, Description=@Desc, Location=@Loc, Website=@Web, Skills=@Skills, Duration=@Duration, CompensateAssets=@CompensateAssets WHERE projectid=@projectid";

            //    update.Parameters.AddWithValue("@ProjName", projName);
            //    update.Parameters.AddWithValue("@ProjMgr", projMngr);
            //    update.Parameters.AddWithValue("@OrgName", orgName);
            //    update.Parameters.AddWithValue("@Desc", desc);
            //    update.Parameters.AddWithValue("@Loc", loc);
            //    update.Parameters.AddWithValue("@Web", web);
            //    update.Parameters.AddWithValue("@Skills", skills);
            //    update.Parameters.AddWithValue("@Duration", dur);
            //    update.Parameters.AddWithValue("@CompensateAssets", compensateAssets);
            //    update.Parameters.AddWithValue("@projectid", project.projectid.ToString());

            //    da.UpdateCommand = update;

            //    ProjectsDataSet ds = new ProjectsDataSet();
            //    da.Fill(ds, "ProjectsTable");


            //    ds.Tables[0].Rows[0]["ProjectName"] = projName;
            //    ds.Tables[0].Rows[0]["ProjectManager"] = projMngr;
            //    ds.Tables[0].Rows[0]["OrgName"] = orgName;
            //    ds.Tables[0].Rows[0]["Description"] = desc;
            //    ds.Tables[0].Rows[0]["Location"] = loc;

            //    ds.Tables[0].Rows[0]["Website"] = web;
            //    ds.Tables[0].Rows[0]["Skills"] = skills;
            //    ds.Tables[0].Rows[0]["Duration"] = dur;

            //    ds.Tables[0].Rows[0]["CompensateAssets"] = compensateAssets;

            //    da.Update(ds.Tables[0]);

            //    Label3.Visible = true;
            //    Label3.Text = "Successfully Updated!";

            //}
            //catch (SqlException ex)
            //{
            //    Label3.Visible = true;
            //    Label3.Text = ex.Message;
            //}
            //finally
            //{
            //    cn.Close();
            //}
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (CheckBoxList1.SelectedItem != null || (tbSkills.Text != ""));
            if (!args.IsValid)
            {
                Session["ErrorMessage"] = "Skills cannot be empty";
                Server.Transfer("OrgAddProj.aspx");
            }
        }
    }
}