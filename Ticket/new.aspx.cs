using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using IncidentDashBoard; 

public partial class Ticket_new : System.Web.UI.Page
{
    //SqlConnection sqlc = new SqlConnection();
    //logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    DropDownListValues _drop = new DropDownListValues();
    //IncidentDashBoards _incident = new IncidentDashBoards();
    //SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    TicketDashboard _ticket = new TicketDashboard();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_name"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        
        if (!this.IsPostBack)
        {
            t_user_input.Text =  Session["user_name"].ToString();
            bind_channel_info();
            _status();
            //Select_status();
            Assign_user();
            //Assign_user_load(Session["USERID"].ToString());
            //d_assign_to.SelectedValue = Session["user_name"].ToString();
            GetVendorID();
        }
    }
    public void _status()
    {
        _drop.bindDropDownList(D_Status, _ticket.D_getActions());
    }
    public void Select_status()
    {
        _drop.bindDropDownList(D_Status, _ticket.D_Select_getActions());
        //DataTable dt = _ticket.D_Select_getActions();
        //D_Status.DataValueField = dt.Columns[0].ColumnName.ToString(); //"GroupTypeID"
        //D_Status.DataTextField = dt.Columns[1].ColumnName.ToString();
        //D_Status.DataBind();
    }
    public void Assign_user_load(string _getUser)
    {
        //DataTable dt2 = _incident._getUserticketLoad(_getUser);
        //d_assign_to.DataValueField = dt2.Columns[0].ColumnName.ToString();
        //d_assign_to.DataTextField = dt2.Columns[1].ColumnName.ToString();
        //d_assign_to.DataBind();


        //_drop.bindDropDownList_String(d_assign_to, _ticket._getUserticketLoad(_getUser));

    }

    private void GetVendorID()
    {
        _drop.bindDropDownList(D_Support_by, _ticket._GetvendorIDDDL());
    }
    protected void Channel_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        if (Channel.SelectedItem.ToString() == "ATM")
        {
            _Bind_BranchName();
            Bind_Source_issue_ATM();
            Bind_Cause_of_issue_ATM();
            
        }
        if (Channel.SelectedItem.ToString() == "Mobile")
        {
            _Bind_BranchName();
            Bind_Source_issue_Mobile();
            Bind_Cause_of_issue_Mobile();

            t_Terminal.Enabled = false;
            T_OS.Enabled = false;
            t_Part_Serial.Enabled = false;
            t_ATM_serial.Enabled = false;
            t_Product_Type.Enabled = false;

        }

        if (Channel.SelectedItem.ToString() == "STM")
        {
            _Bind_BranchName_02();
            Bind_Source_issue_ATM();
            Bind_Cause_of_issue_ATM();

        }

        if  (Channel.SelectedItem.ToString() == "Mailler" )
        {
            _Bind_BranchName_01();
            Bind_Source_issue_ATM();
            Bind_Cause_of_issue_ATM();

        }
        if (Channel.SelectedItem.ToString() == "HSM")
        {
            _Bind_BranchName_01();
            Bind_Source_issue_ATM();
            Bind_Cause_of_issue_ATM();
        }
        if (Channel.SelectedItem.ToString() == "DATA_CARD")
        {
            _Bind_BranchName_01();
            Bind_Source_issue_ATM();
            Bind_Cause_of_issue_ATM();
        }

    }
    public void bind_channel_info()
    {
        try
        {
            _drop.bindDropDownList(Channel, _ticket._getServiceChannel());

        }
        catch (Exception ex)
        {
            ShowMessage(_ticket.get_message, MessageType.Error);
        }
        finally
        {
           
        }
    }
    public void _Bind_BranchName()
    {
        try
        {
            _drop.bindDropDownList(D_Branch_name, _ticket._Get_BranchName());
        }
        catch (Exception ex)
        {
            ShowMessage(_ticket.get_message, MessageType.Error);
        }
        finally
        {
           
        }
    }
    public void _Bind_BranchName_01()
    {
        try
        {
            _drop.bindDropDownList(D_Branch_name, _ticket._Get_BranchName_01());
        }
        catch (Exception ex)
        {
            ShowMessage(_ticket.get_message, MessageType.Error);
        }
        finally
        {
           
        }
    }
    public void _Bind_BranchName_02()
    {
        try
        {
            _drop.bindDropDownList(D_Branch_name, _ticket._Get_BranchName_02());
        }
        catch (Exception ex)
        {
            ShowMessage(_ticket.get_message, MessageType.Error);
        }
        finally
        {
           
        }
    }
    public void Bind_Source_issue_ATM()
    {
        try
        {
            _drop.bindDropDownList(D_Source_Issue, _ticket.D_getReasonGroup());

        }
        catch (Exception ex)
        {
            ShowMessage(_ticket.get_message, MessageType.Error);
        }
        finally
        {
            
        }
    }
    public void Bind_Source_issue_Mobile()
    {
        try
        {
            _drop.bindDropDownList(D_Source_Issue, _ticket.D_getReasonGroup_MB());

        }
        catch (Exception ex)
        {
            ShowMessage(_ticket.get_message, MessageType.Error);
        }
        finally
        {
            
        }
    }
    public void Bind_Cause_of_issue_ATM()
    {
        try
        {
            _drop.bindDropDownList(d_Cause_of_issue, _ticket.D_getReasons());
        }
        catch (Exception ex)
        {
            ShowMessage(_ticket.get_message, MessageType.Error);
        }
        finally
        {
            
        }
    }
    public void Bind_Cause_of_issue_Mobile()
    {
        try
        {
            _drop.bindDropDownList(d_Cause_of_issue, _ticket.D_getReasons_MB());
        }
        catch (Exception ex)
        {
            ShowMessage(_ticket.get_message, MessageType.Error);
        }
        finally
        {
            
        }
    }
    public void _ReasonType_Values(string ReasonGroupID)
    {
        try
        {
            _drop.bindDropDownList(d_Cause_of_issue, _ticket.D_getReasonTypes(ReasonGroupID));
        }
        catch (Exception ex)
        {
            ShowMessage(_ticket.get_message, MessageType.Error);
        }
        finally
        {
           
        }
    }
    //public void Bind_type_of_issue()
    //{
    //    try
    //    {
    //        _sqlcom._command_Stored("P_bind_type_issue_new_ticket", ref cmd);
    //        cmd.Parameters.AddWithValue("@cause_of_issue", d_Cause_of_issue.Text);
    //    }
    //    catch (Exception ex)
    //    {
    //        ShowMessage(_ticket.get_message, MessageType.Error);
    //    }
    //    finally
    //    {
    //        sqlc.Close();
    //    }
    //}
    public void Assign_user()
    {
        try
        {
            _drop.bindDropDownList(d_assign_to, _ticket._getUserticket());
            
        }
        catch (Exception ex)
        {
            ShowMessage(_ticket.get_message, MessageType.Error);
        }
        finally
        {
        }
    }

    protected void D_Source_Issue_SelectedIndexChanged(object sender, EventArgs e)
    {
        _ReasonType_Values(D_Source_Issue.SelectedValue);
        ClientScript.RegisterStartupScript(this.GetType(), "change icon", "pageLoad();", true);
    }
    protected void D_Status_SelectedIndexChanged(object sender, EventArgs e)
    {
        string status = D_Status.SelectedItem.Text;
        if (status == "Close")
        {
            l_end_date.Visible = true;
            t_end_date.Visible = true;
            Image3.Visible = true;
        }
        else if (status == "Pending")
        {
            l_end_date.Visible = false;
            t_end_date.Visible = false;
            Image3.Visible = false;
        }
    }
    public void Bind_terminal()
    {
        if (Channel.SelectedValue == "1")
        {
            _drop.bindDropDownList(t_Terminal, _ticket._Get_Terminal(D_Branch_name.SelectedValue));
        }
        if (Channel.SelectedValue == "2")
        {
            _drop.bindDropDownList(t_Terminal, _ticket._Get_Terminal_02(D_Branch_name.SelectedValue));
        }
        if (Channel.SelectedValue == "3")
        {
            _drop.bindDropDownList(t_Terminal, _ticket._Get_Terminal_01("Print Mailer", D_Branch_name.SelectedValue));
        }
        if (Channel.SelectedValue == "4")
        {
            _drop.bindDropDownList(t_Terminal, _ticket._Get_Terminal_01("HSM", D_Branch_name.SelectedValue));
        }
        if (Channel.SelectedValue == "5")
        {
            _drop.bindDropDownList(t_Terminal, _ticket._Get_Terminal_01("Data Card", D_Branch_name.SelectedValue));
        }
    }
    private bool _RegisterTicket()
    {
        bool retval = _ticket._Ticket_register(Channel.SelectedItem.ToString(), D_Branch_name.Text, t_Product_Type.Text, t_Terminal.Text.ToString()
                 , t_Start_date.Text//, D_Root_of_issue.Text
                 , t_inform.Text, D_Status.SelectedValue, t_user_input.Text
                 , t_Decription.Text, t_Solution.Text, t_end_date.Text, D_Source_Issue.Text, d_assign_to.SelectedItem.ToString()
                 , T_OS.Text, t_ATM_serial.Text, t_Part_Serial.Text, t_Issue_date.Text
                 , d_Cause_of_issue.Text, Session["user_name"].ToString(),D_Support_by.SelectedValue);
        if (retval == false)
        {
            ShowMessage("Register ticket is fail "+ _ticket.get_message + "", MessageType.Error); 
        }
        else
        {
            ShowMessage("Register new record with ticket = "+ _ticket._getticket + "", MessageType.Success);
        }
        return retval;
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {
        if (D_Status.SelectedValue != "" && D_Source_Issue.SelectedValue != "" && d_Cause_of_issue.SelectedValue != "" && t_Terminal.SelectedValue != "")
        {
            _RegisterTicket();
            linkbtnsave.Enabled = false;
        }
        else
        {
            Response.Write(@"<script language='javascript'>alert('Do not Allow Column Status Null!!')</script>");
        }

        //WCF_Register_issue();
    }
    protected void D_Branch_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_terminal();
        ClientScript.RegisterStartupScript(this.GetType(), "change icon", "pageLoad();", true);
    }
    public void bind_assign_user()
    {
        try
        {
            //obj.S_command("P_bind_user_name_new_ticket", ref cmd);
            //cmd.Parameters.AddWithValue("@channel", Channel.Text);
            //obj.bind_dt("user_name", d_assign_to);
            _drop.bindDropDownList_String(Channel, _ticket._getUserticket());
        }
        catch (Exception ex)
        {
            ShowMessage("Get user ticket is failed " + _ticket.get_message + "", MessageType.Error);
        }
        finally
        {
           
        }
    }
   public void _Terminal_fundamental()
    {
        DataTable dt = _ticket._Get_Terminal_Fundamental(t_Terminal.SelectedValue);
        if (dt.Rows.Count == 0)
        {
            T_OS.Text = "";
            t_Part_Serial.Text = "";
            t_ATM_serial.Text = "";
            t_Product_Type.Text = "";
        }
        else
        {
            T_OS.Text = dt.Rows[0][0].ToString();
            t_Part_Serial.Text = dt.Rows[0][1].ToString();
            t_ATM_serial.Text = dt.Rows[0][2].ToString();
            t_Product_Type.Text = dt.Rows[0][3].ToString();
        }
        
    }
    private string AutoIncrementID()
    {
        DataTable dt = _ticket._getAutoIncrementID();
        string id = dt.Rows[0][0].ToString();
        return id;
    }
    public static string ZeroAppend(string data, int idLimit)
    {
        return data.Substring(data.Length - idLimit);
    }
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ticket/index.aspx");
    }
    protected void t_Terminal_SelectedIndexChanged(object sender, EventArgs e)
    {
        _Terminal_fundamental();
        //ClientScript.RegisterStartupScript(this.GetType(), "change icon", "pageLoad();", true);
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    private void _getFC_staff()
    {
        try
        {
            _drop.bindDropDownList_String(d_assign_to, _ticket._GetFC_STAFF_DDL());
        }

        catch (Exception ex)
        {
            ShowMessage("Get user FC staff drop down list is failed " + _ticket.get_message + "", MessageType.Error);
        }
        
    }
    private void _getBP_staff()
    {
        try
        {
            _drop.bindDropDownList_String(d_assign_to, _ticket._GetBP_STAFF_DDL());
        }

        catch (Exception ex)
        {
            ShowMessage("Get user FC staff drop down list is failed " + _ticket.get_message + "", MessageType.Error);
        }
        
    }
    protected void D_Support_by_SelectedIndexChanged(object sender, EventArgs e)
    {
        string GetVendor = D_Support_by.SelectedValue;

        if (GetVendor == "FC")
        {
            _getFC_staff();
        }
        if (GetVendor == "BP")
        {
            _getBP_staff();
        }
        if (GetVendor == "HTB")
        {
            Assign_user();
        }
        else
        {
            return;
        }
    }
}