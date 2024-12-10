using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using IncidentDashBoard; 

public partial class Ticket_view : System.Web.UI.Page
{
    //SqlConnection sqlc = new SqlConnection();
    string idedit;
    //logger _logger = new logger();
    //SqlCommand cmd = new SqlCommand();
    //dbcon con = new dbcon();
    //SqlConnectAndSqlCommand _sqlcmd = new SqlConnectAndSqlCommand();
    //IncidentDashBoards _incident = new IncidentDashBoards();
    GridViewValues _grid = new GridViewValues();
    TicketDashboard _ticket = new TicketDashboard();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        idedit = Request.QueryString["ticket_no"].ToString();
        if (!IsPostBack)
        {
            _getFundamentals();
            Griduser_pending();
        }
    }

    public void _getFundamentals()
    {
        DataTable dt = _ticket._getViewFundamentals(idedit);
        l_ticket_no.Text = dt.Rows[0]["ticket_no"].ToString();
        t_Channel.Text = dt.Rows[0]["Product_Name"].ToString();
        t_Branch.Text = dt.Rows[0]["Branch_Name"].ToString();
        t_phone.Text = dt.Rows[0]["Phone"].ToString();
        t_Terminal.Text = dt.Rows[0]["Terminal"].ToString();
        t_atm_serial.Text = dt.Rows[0]["ATM_Serial"].ToString();
        t_part_serial.Text = dt.Rows[0]["Part_Serail"].ToString();
        t_Part_Decription.Text = dt.Rows[0]["Part_Decription"].ToString();
        t_source_issue.Text = dt.Rows[0]["Source_Issue"].ToString();
        t_problem_type.Text = dt.Rows[0]["Problem_Type"].ToString();
        t_root_issue.Text = dt.Rows[0]["Root_Issue"].ToString();
        t_status.Text = dt.Rows[0]["Status"].ToString();
        t_user_name.Text = dt.Rows[0]["User_Name"].ToString();
        t_assign_to.Text = dt.Rows[0]["Assign_To"].ToString();
        T_inform.Text = dt.Rows[0]["Contact"].ToString();
        t_router_type.Text = dt.Rows[0]["Router_Type"].ToString();
        t_issue_date.Text = dt.Rows[0]["Issue_Date"].ToString();
        t_start_date.Text = dt.Rows[0]["Start_Date"].ToString();
        t_end_date.Text = dt.Rows[0]["End_Date"].ToString();
        T_dec.Text = dt.Rows[0]["Decription"].ToString();
        t_solution.Text = dt.Rows[0]["Solution"].ToString();

    }
    private void Griduser_pending()
    {
        _grid._GridviewBinding(grid1, _ticket._GridTicketView(idedit));
        Label4.Text = grid1.Rows.Count.ToString();
    }
    protected void btncancel_Click1(object sender, EventArgs e)
    {
        Response.Redirect("~/ticket/index.aspx");
    }

}