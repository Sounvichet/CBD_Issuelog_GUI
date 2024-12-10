using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using IncidentDashBoard;

public partial class Ticket_edit : System.Web.UI.Page
{
    string idedit;
    //SqlConnection sqlc = new SqlConnection();
    //logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    //IncidentDashBoards _incident = new IncidentDashBoards();
    DropDownListValues _drop = new DropDownListValues();
    TicketDashboard _ticket = new TicketDashboard();
    public enum MessageType { Success, Error, Info, Warning };

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        idedit = Request.QueryString["ticket_no"].ToString();
        if (!IsPostBack)
        {
            _actionType();
            _reasonGroup();
            _ReasonType();
            BindTextBoxvalues();
        }
    }
    public void BindTextBoxvalues()
    {
        try
        {
            DataTable dt = _ticket._get_EditFundamentals(idedit);

            Label8.Text = dt.Rows[0]["ticket_no"].ToString();
            Start_date.Text = dt.Rows[0]["Start_Date"].ToString();
            End_date.Text = dt.Rows[0]["End_Date"].ToString();
            T_Description.Text = dt.Rows[0]["Decription"].ToString();
            solution.Text = dt.Rows[0]["Solution"].ToString();
            branch_name.Text = dt.Rows[0]["Terminal_name"].ToString();
            D_ReasonGroup.SelectedValue = dt.Rows[0]["GroupTypeID"].ToString();
            D_reasonType.SelectedValue = dt.Rows[0]["ReasonTypeID"].ToString();
            D_Status.SelectedValue = dt.Rows[0]["status"].ToString();

        }
        catch (Exception ex)
        {
            ShowMessage("Get edit fundamental is failed "+ _ticket.get_message, MessageType.Error);
        }
        finally
        {
        }
    }
    public bool _Update_ticket()
    {
        bool retval = _ticket._update_Ticket(solution.Text, D_Status.SelectedValue, Start_date.Text,End_date.Text, branch_name.Text, D_reasonType.SelectedValue, D_ReasonGroup.SelectedValue, Label8.Text, Session["USER_NAME"].ToString(),T_Description.Text);
        if (retval == false)
        {
            ShowMessage(_ticket.get_message, MessageType.Error);
            //Response.Write("<script>alert('" + _incident._message + "')</script>");
        }
        else
        {
            ShowMessage("Record updated successfully !", MessageType.Success);
            Linkbtnsave.Enabled = false;
            Linkbtnedit.Enabled = true;
        }
        return retval;
    }
    public void _reasonGroup()
    {
        try
        {
            _drop.bindDropDownList(D_ReasonGroup, _ticket.D_getReasonGroup());
        }
        catch (Exception ex)
        {
            ShowMessage("Get reasongroup is failed "+ _ticket.get_message, MessageType.Error);
        }
        
    }
    public void _actionType()
    {
        try
        {
            _drop.bindDropDownList(D_Status, _ticket.D_getActions());
        }

        catch (Exception ex)
        {
            ShowMessage("Get action is failed " + _ticket.get_message, MessageType.Error);
        }
        
    }
    public void _ReasonType()
    {
        try
        {
            _drop.bindDropDownList(D_reasonType, _ticket.D_getReasons());
        }

        catch (Exception ex)
        {
            ShowMessage("Get action is failed " + _ticket.get_message, MessageType.Error);
        }
        
    }
    protected void btnUpdate_click(object sender, EventArgs e)
    {
        _Update_ticket();
    }
    public void _selectchangeReasonGroup()
    {
        try
        {
            _drop.bindDropDownList(D_reasonType, _ticket.D_getReasonTypes(D_ReasonGroup.SelectedValue));
        }

        catch (Exception ex)

        {
            ShowMessage("Get reason type  is failed " + _ticket.get_message, MessageType.Error);
        }
        
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ticket/index.aspx");
    }
    protected void btnedit_Click(object sender, EventArgs e)
    {
        Linkbtnsave.Enabled = true;
        D_ReasonGroup.Enabled = true;
        D_reasonType.Enabled = true;

        //branch_name.Enabled = true;
        Start_date.Enabled = true;
        End_date.Enabled = true;
        D_Status.Enabled = true;
        solution.Enabled = true;
        T_Description.Enabled = true;
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        _Update_ticket();
    }
    protected void D_ReasonGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        _selectchangeReasonGroup();

    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
}