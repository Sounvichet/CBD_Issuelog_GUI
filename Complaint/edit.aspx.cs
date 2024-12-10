using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using IncidentDashBoard; 



public partial class Complaint_edit : System.Web.UI.Page
{
    string idedit;
    SqlConnection sqlc = new SqlConnection();
    //logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    //MissionDashBoard _miss = new MissionDashBoard();
    //SqlConnectAndSqlCommand _sqlcmd = new SqlConnectAndSqlCommand();
    //ComplaintDashBoard _comlaint = new ComplaintDashBoard();
    //IncidentDashBoards _incident = new IncidentDashBoards();
    DropDownListValues _drop = new DropDownListValues();
    TicketDashboard _ticket = new TicketDashboard();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Name"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        idedit = Request.QueryString["ticket_no"].ToString();
        if (!IsPostBack)
        {
            _reasonGroup();
            _actionType();
            _ReasonType();
            BindTextBoxvalues();
        }
    }
    private void BindTextBoxvalues()
    {
        try
        {
            DataTable dt = _ticket.D_complaintticketfundamental(idedit);
            T_ticket_no.Text = dt.Rows[0][0].ToString();
            Start_date.Text = dt.Rows[0][1].ToString();
            End_date.Text = dt.Rows[0][2].ToString();
            T_solution.Text = dt.Rows[0][3].ToString();
            t_branch_name.Text = dt.Rows[0][4].ToString();
            D_ReasonGroup.SelectedValue = dt.Rows[0][5].ToString();
            D_ReasonType.SelectedValue = dt.Rows[0][6].ToString();
            D_Status.SelectedValue = dt.Rows[0][7].ToString();
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"" + _ticket.get_message + "\");", true);
        }
        finally
        {
            sqlc.Close();
        }
    }
    public bool _Update_ticket()
    {
        _ticket._Branch_Name = t_branch_name.Text;
        _ticket._Source_Issue = D_ReasonGroup.SelectedValue; 
        _ticket._Problem_Type = D_ReasonType.SelectedValue;
        _ticket._Solution = T_solution.Text;
        _ticket._Start_date = Start_date.Text; //DateTime.Parse(Start_date.Text);
        _ticket._End_date = End_date.Text;  //DateTime.Parse(End_date.Text);
        _ticket._Status = D_Status.SelectedValue;
        _ticket._ticket_no = idedit;
        _ticket._userAD = Session["USER_NAME"].ToString(); 
        bool retval = _ticket.Update_Ticket();
        if (retval == false)
        {
            ShowMessage(_ticket.get_message, MessageType.Error);
        }
        else
        {
            ShowMessage("Update record!", MessageType.Success);
            Linkbtnsave.Enabled = false;
            Linkbtnedit.Enabled = true;           
        }
        return retval;
    }
    public void _reasonGroup()
    {
        _drop.bindDropDownList( D_ReasonGroup, _ticket.D_getReasonGroup());
    }
    public void _actionType()
    {
        _drop.bindDropDownList(D_Status, _ticket.D_getActions());
    }
    public void _ReasonType()
    {
        _drop.bindDropDownList(D_ReasonType, _ticket.D_getReasons());
    }

    protected void btnUpdate_click(object sender, EventArgs e)
    {
        _Update_ticket();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Complaint/index.aspx");
    }
    protected void btnedit_Click(object sender, EventArgs e)
    {
        Linkbtnsave.Enabled = true;
        D_ReasonGroup.Enabled = true;
        D_ReasonType.Enabled = true;

        //branch_name.Enabled = true;
        Start_date.Enabled = true;
        End_date.Enabled = true;
        D_Status.Enabled = true;
        T_solution.Enabled = true;
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    protected void D_ReasonGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        _drop.bindDropDownList(D_ReasonType, _ticket.D_getReasonTypes(D_ReasonGroup.SelectedValue));
    }

}