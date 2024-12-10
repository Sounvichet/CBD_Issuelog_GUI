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
    biller_Dashboard _biller = new biller_Dashboard();
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
            _biller.P_TICKET = t_Ticket_no.Text;
            DataTable dt = _biller._get_biller_dispute_fundamental();
            t_partner_name.Text = dt.Rows[0][0].ToString();
            t_branch_Code.Text = dt.Rows[0][1].ToString();
            t_trn_date.Text = dt.Rows[0][2].ToString();
            t_consumer_no.Text = dt.Rows[0][3].ToString();
            t_saving_acct.Text = dt.Rows[0][4].ToString();
            t_Currency.Text = dt.Rows[0][5].ToString();
            t_trn_amount.Text = dt.Rows[0][6].ToString();
            t_cbs_ref.Text = dt.Rows[0][7].ToString();
            t_cust_account_name.Text = dt.Rows[0][9].ToString();
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
            _biller.P_TYPE = "3";
            _drop.bindDropDownList(d_issue_type, _biller._get_issue_type());
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
        Response.Redirect("~/Payment/biller_disp_index.aspx");
    }

    public bool _register_biller_disputed()
    {

        _biller.P_PARTNER_NAME = t_partner_name.Text;
        _biller.P_BRANCH_CODE = t_branch_Code.Text;
        _biller.P_TRN_DATE = t_trn_date.Text;
        _biller.P_ORIGINAL_REF = t_Ticket_no.Text;
        _biller.P_CONSUMER_ID = t_consumer_no.Text;
        _biller.P_CONSUMER_NAME = t_cust_account_name.Text;
        _biller.P_SAVING_ACCT = t_saving_acct.Text;
        _biller.P_CCY = t_Currency.Text;
        _biller.P_TRN_AMOUNT = t_trn_amount.Text;
        _biller.P_CBS_REF = t_cbs_ref.Text;
        _biller.P_DISPUTE_TYPE = d_issue_type.SelectedValue;
        _biller.P_STATUS = d_status.SelectedItem.ToString();
        _biller.P_SOLUTION = t_Solution.Text;
        _biller.P_SOLVE_DATE = t_resolve_date.Text;
        _biller.P_REMARK = t_Remark.Text;
        _biller.P_USERID = Session["USERID"].ToString();
        bool _get_biller = _biller._register_biller_dispute();
        if (_get_biller == true)
        {
            ShowMessage("Biller Ticket is successful !", MessageType.Success);
            linkbtnsave.Enabled = false;
        }
        else
        {
            ShowMessage("Register Biller ticket is fail!" + _logger._message, MessageType.Error);
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