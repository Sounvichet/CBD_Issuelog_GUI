using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using MasterReportClass;

public partial class Payment_new_ticket_dispute : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    DropDownListValues _drop = new DropDownListValues();
    IncidentDashBoards _incident = new IncidentDashBoards();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    Dispute_DashBoard _dis = new Dispute_DashBoard();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_name"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }

        if (!IsPostBack)
        {
            _Bind_BranchName();
            _Bind_issue_type();
            _Bind_problem_type();
            _Bind_ISS_BIN();
            _Bind_ACQ_BIN();
            _Bind_SYSTEM_TYPE();
        }
    }
    public void _Bind_BranchName()
    {
        try
        {
            _drop.bindDropDownList(D_BRANCH_CODE, _dis._get_Branch_code());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }
        finally
        {
            sqlc.Close();
        }
    }

    public void _Bind_issue_type()
    {
        try
        {
            _dis.P_TYPE = "1";
            _drop.bindDropDownList(d_isse_type, _dis._get_issue_type());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }
        finally
        {
            sqlc.Close();
        }
    }

    public void _Bind_problem_type()
    {
        try
        {
            _drop.bindDropDownList(D_Problem_Type, _dis._get_problem_type());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }
        finally
        {
            sqlc.Close();
        }
    }
    public void _Bind_ISS_BIN()
    {
        try
        {
            _drop.bindDropDownList(d_ISS_BANK, _dis._get_css_bin());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }
        finally
        {
            sqlc.Close();
        }
    }
    public void _Bind_ACQ_BIN()
    {
        try
        {
            _drop.bindDropDownList(d_ACQ_BANK, _dis._get_css_bin());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }
        finally
        {
            sqlc.Close();
        }
    }
    public void _Bind_SYSTEM_TYPE()
    {
        try
        {
            _drop.bindDropDownList(d_System_Type, _dis._get_system_type());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }
        finally
        {
            sqlc.Close();
        }
    }

    protected void btn_save_Click(object sender, EventArgs e)
    {
        _register_ticket();
    }
    private string AutoIncrementID()
    {
        DataTable dt = _incident._getAutoIncrementID();
        string id = dt.Rows[0][0].ToString();
        sqlc.Close();
        return id;
    }
    public static string ZeroAppend(string data, int idLimit)
    {
        return data.Substring(data.Length - idLimit);
    }
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Payment/dispute_resolution.aspx");
    }
    protected void D_BRANCH_CODE_SelectedIndexChanged(object sender, EventArgs e)
    {
        _dis.P_BRN = D_BRANCH_CODE.SelectedValue.ToString();
        _drop.bindDropDownList(d_Terminal, _dis._get_tid_by_branch());
    }

    public bool _register_ticket()
    {
        _dis.P_BRANCH_CODE = D_BRANCH_CODE.SelectedValue.ToString();
        _dis.P_SYSTEM = d_System_Type.SelectedValue.ToString();
        _dis.P_TICKET_ID = t_Ticket_no.Text;
        _dis.P_WRS_DATE = t_WRS_DATE.Text;
        _dis.P_ISSUE_DATE = t_ISSUE_DATE.Text;
        _dis.P_RESOLVED_DATE = t_Resolve_Date.Text;
        _dis.P_ISSUE_TYPE = d_isse_type.SelectedValue.ToString();
        _dis.P_TERMINAL_ID = d_Terminal.SelectedValue.ToString();
        _dis.P_TERMINAL_NAME = d_Terminal.SelectedItem.ToString();
        _dis.P_ISS_NAME = d_ISS_BANK.SelectedValue.ToString();
        _dis.P_ACQ_NAME = d_ACQ_BANK.SelectedValue.ToString();
        _dis.P_TRACE_NUM = t_trace_number.Text;
        _dis.P_CCY = d_Currency.SelectedItem.ToString();
        _dis.P_TRN_AMT = t_trn_amount.Text;
        _dis.P_FEE_AMT = t_fee_amount.Text;
        _dis.P_PROBLEM_TYPE = D_Problem_Type.SelectedValue.ToString();
        _dis.P_REFUND_OTHER_BANK = t_refund_bank.Text;
        _dis.P_RECORD_STATUS = d_status.SelectedItem.ToString();
        _dis.P_REMARK = t_Remark.Text;
        _dis.P_USERID = Session["USERID"].ToString();

        bool _get_ticket = _dis._register_dispute_ticket();
        if (_get_ticket == true)
        {
            ShowMessage("Ticket is successful !", MessageType.Success);
            linkbtnsave.Enabled = false;
        }
        else
        {
            ShowMessage("Register ticket is fail!" + _logger._message, MessageType.Error);
        }
        return _get_ticket;
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
}