using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using IncidentDashBoard;

public partial class Ticket_delete : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    //logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    string idedit;
    //IncidentDashBoards _incident = new IncidentDashBoards();
    //SqlConnectAndSqlCommand _sqlcmd = new SqlConnectAndSqlCommand();
    TicketDashboard _ticket = new TicketDashboard();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        idedit = Request.QueryString["ticket_no"].ToString();
        if (!this.IsPostBack)
        {
            BindTextBoxvalues();
        }
            

    }
    private void BindTextBoxvalues()
    {
        try
        {
            DataTable dt = _ticket._get_DeleteFundamentals(idedit);
            Problem_ID.Text = dt.Rows[0][0].ToString();
            Branch_name.Text = dt.Rows[0][1].ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            sqlc.Close();
        }
    }
    public bool _delete_ticket()
    {
        bool retval = _ticket._Delete_ticket(Problem_ID.Text);
        if (retval == false)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"" + _ticket.get_message + "\");", true);
        }
        else
        {
            Response.Write("<script>alert('Delete Successful')</script>");
            Response.Redirect("~/ticket/index.aspx");
        }
        return retval;
    }
    protected void Btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ticket/index.aspx");
    }
    protected void Btndelete_Click(object sender, EventArgs e)
    {
        _delete_ticket();
    }
}