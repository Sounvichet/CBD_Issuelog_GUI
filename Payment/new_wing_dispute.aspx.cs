using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using MasterReportClass;

public partial class Payment_new_wing_dispute : System.Web.UI.Page
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
            _Bind_issue_type();
        }
    }

    private void BindTextBoxvalues()
    {
        try
        {
            _dis.P_TICKET = t_Ticket_no.Text;
            DataTable dt = _dis._get_wing_dispute_fundamental();
            t_branch_Code.Text = dt.Rows[0][0].ToString();
            t_trn_date.Text = dt.Rows[0][1].ToString();
            t_cust_account_name.Text = dt.Rows[0][3].ToString();
            t_loan_account.Text = dt.Rows[0][4].ToString();
            t_saving_acct.Text = dt.Rows[0][5].ToString();
            t_Currency.Text = dt.Rows[0][6].ToString();
            t_trn_amount.Text = dt.Rows[0][7].ToString();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }

    public void _Bind_issue_type()
    {
        try
        {
            _dis.P_TYPE = "2";
            _drop.bindDropDownList(d_dispute_type, _dis._get_issue_type());
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
        Response.Redirect("~/Payment/TBSWDSL.aspx");
    }

    public bool _register_ticket()
    {

        _dis.P_BRANCH_CODE = t_branch_Code.Text;
        _dis.P_RECEIVED_DATE = t_received_date.Text;
        _dis.P_TRN_DATE = t_trn_date.Text;
        _dis.P_ORIGINAL_REF = t_Ticket_no.Text;
        _dis.P_CUSTOMER_NAME = t_cust_account_name.Text;
        _dis.P_LOAN_ACCOUNT = t_loan_account.Text;
        _dis.P_SAVING_ACCOUNT = t_saving_acct.Text;
        _dis.P_CURRENCY = t_Currency.Text;
        _dis.P_AMOUNT = t_trn_amount.Text;
        _dis.P_DISPUTE_TYPE = d_dispute_type.SelectedValue;
        _dis.P_CORRECT_AMOUNT = t_Current_Amount.Text;
        _dis.P_ADJ_AMOUNT = t_adjustment_amount.Text;
        _dis.P_ADJ_METHOD = d_Adjustment_Method.Text;
        _dis.P_RECORD_STATUS = d_status.Text;
        _dis.P_SOLUTION = t_Solution.Text;
        _dis.P_HTB_CONFIRM_DATE = t_htb_confirm_date.Text;
        _dis.P_WING_CONFIRM_DATE = t_wing_confirm_date.Text;
        //_dis.P_REFUND_OTHER_BANK = t_refund_other_bank.Text;
        _dis.P_REMARK = t_remark.Text;
        _dis.P_DEPT_REMARK = t_dept_remark.Text;
        _dis.P_SEND_TO_BRANCH = t_send_to_branch.Text;
        _dis.P_USERID = Session["USERID"].ToString();
        _dis.P_CHANNEL = d_channel.SelectedItem.ToString();
        bool _get_ticket = _dis._register_loan_dispute();
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

    protected void Linkbtnsearch_Click(object sender, EventArgs e)
    {
        BindTextBoxvalues();
    }
}