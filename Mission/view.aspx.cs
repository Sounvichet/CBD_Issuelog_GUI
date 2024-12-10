using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using IncidentDashBoard;

public partial class Mission_view : System.Web.UI.Page
{
    string idedit;
    //SqlConnection sqlc = new SqlConnection();
    //logger _logger = new logger();
    //SqlCommand cmd = new SqlCommand();
    //MissionDashBoard _miss = new MissionDashBoard();
    Mission_Dashboard _miss = new Mission_Dashboard();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Name"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        idedit = (Request.QueryString["ticket_No"].ToString());
        if (!IsPostBack)
        {
            _ticketMissionFundamentals();
        }
    }
    private void _ticketMissionFundamentals()
    {
        try
        {
            DataTable dt = _miss.D_MissionView_Fundamentals(idedit);
            ID_AUTO.Text = dt.Rows[0][0].ToString();
            t_branch_name.Text = dt.Rows[0][1].ToString();
            t_source_issue.Text = dt.Rows[0][2].ToString();
            t_problem_type.Text = dt.Rows[0][3].ToString();
            t_status.Text = dt.Rows[0][4].ToString();
            Start_date.Text = dt.Rows[0][5].ToString();
            End_date.Text = dt.Rows[0][6].ToString();
            t_Decription.Text = dt.Rows[0][7].ToString();
            t_Solution.Text = dt.Rows[0][8].ToString();
            //t_name.Text = dt.Rows[0][9].ToString();
            //t_type.Text = dt.Rows[0][10].ToString();
        }

        catch (Exception ex)
        {
            Response.Write(@"<script language='javascript'>alert('" + _miss._message + " !!')</script>");
        }

        finally
        {
        }
    }
    protected void btncancel_Click1(object sender, EventArgs e)
    {
        Response.Redirect("~/Mission/index.aspx");
    }
}