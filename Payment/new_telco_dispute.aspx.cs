using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using MasterReportClass;

public partial class Payment_new_biller_dispute : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    DropDownListValues _drop = new DropDownListValues();
    IncidentDashBoards _incident = new IncidentDashBoards();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    Telco_Dashboard _telco = new Telco_Dashboard();
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
            _telco.P_TICKET = t_Ticket_no.Text;
            DataTable dt = _telco._get_telco_dispute_fundamental();
            t_branch_Code.Text = dt.Rows[0][0].ToString();
            t_customer_id.Text = dt.Rows[0][1].ToString();
            t_customer_name.Text = dt.Rows[0][2].ToString();
            t_service_type.Text = dt.Rows[0][3].ToString();
            t_sub_service.Text = dt.Rows[0][4].ToString();
            t_type_of_pin.Text = dt.Rows[0][5].ToString();
            t_ccy.Text = dt.Rows[0][6].ToString();
            t_txn_amount.Text = dt.Rows[0][7].ToString();
            t_fee_amount.Text = dt.Rows[0][8].ToString();
            t_total_amount.Text = dt.Rows[0][9].ToString(); 
            t_cbs_ref.Text = dt.Rows[0][10].ToString();
            t_htb_ex_ref.Text = dt.Rows[0][11].ToString();
            t_debit_account.Text = dt.Rows[0][12].ToString();
            t_credit_account.Text = dt.Rows[0][13].ToString(); 
            t_txn_date.Text = dt.Rows[0][14].ToString();
            _telco.P_ORDER_ID = dt.Rows[0][15].ToString();
            t_partner_ref.Text = _telco._get_partner_ref();
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
          _telco.P_TYPE = "4";
           _drop.bindDropDownList(d_issue_type, _telco._get_issue_type());
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
         _register_biller_disputed();
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
        Response.Redirect("~/Payment/TELCO_disp_index.aspx");
    }

    public bool _register_biller_disputed()
    {
        _telco.P_BRANCH_CODE = t_branch_Code.Text;
        _telco.P_CONSUMER_ID = t_customer_id.Text;
        _telco.P_CONSUMER_NAME = t_customer_name.Text;
        _telco.P_SERVICE_TYPE = t_service_type.Text;
        _telco.P_SUB_SERVICE = t_sub_service.Text;
        _telco.P_TYPE_OF_PIN = t_type_of_pin.Text;
        _telco.P_PARTNER_REF = t_partner_ref.Text;
        _telco.P_TXN_CCY = t_ccy.Text;
        _telco.P_TXN_AMOUNT = t_txn_amount.Text;
        _telco.P_FEE_AMOUNT = t_fee_amount.Text;
        _telco.P_TOTAL_AMOUNT = t_total_amount.Text;
        _telco.P_CBS_REF = t_cbs_ref.Text;
        _telco.P_HTB_EX_REF = t_htb_ex_ref.Text;
        _telco.P_TXN_ACC = t_credit_account.Text;
        _telco.P_OFS_ACC = t_debit_account.Text;
        _telco.P_STATUS = d_status.SelectedItem.Text;
        _telco.P_ISSUE_TYPE = d_issue_type.SelectedValue;
        _telco.P_SOLUTION = t_Solution.Text;
        _telco.P_RESOLVED_DATE = t_resolved_date.Text;
        _telco.P_REMARK = t_Remark.Text;
        _telco.P_VALUE_DT = t_txn_date.Text;
        _telco.P_USERID = Session["USERID"].ToString();
        
        bool _get_biller = _telco._register_telco_dispute();
        if (_get_biller == true)
        {
            ShowMessage("Telco Ticket is successful !", MessageType.Success);
            linkbtnsave.Enabled = false;
        }
        else
        {
            ShowMessage("Register Telco ticket is fail!" + _logger._message, MessageType.Error);
        }
        return _get_biller;
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