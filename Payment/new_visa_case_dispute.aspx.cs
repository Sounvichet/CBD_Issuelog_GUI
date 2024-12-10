using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
//using MasterReportClass;
using VisaClearingClass; 

public partial class Payment_new_visa_case_dispute : System.Web.UI.Page
{
    //SqlConnection sqlc = new SqlConnection();
    //logger _logger = new logger();
    //SqlCommand cmd = new SqlCommand();
    DropDownListValues _drop = new DropDownListValues();
    //IncidentDashBoards _incident = new IncidentDashBoards();
    //SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    //Case_Disputes_Dashboard _case_dis = new Case_Disputes_Dashboard();
    //biller_Dashboard _biller = new biller_Dashboard();
    CaseDisputeDashboard _case = new CaseDisputeDashboard();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_name"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }

        if (!IsPostBack)
        {
            
        }
    }

    private void BindTextBoxvalues()
    {
        try
        {
            _case.P_REFNUM = t_Ticket_no.Text;
            DataTable dt = _case._get_refnum_fundamental();
            l_txn_amount.Text = dt.Rows[0][1].ToString();
            l_opr_ccy.Text = dt.Rows[0][2].ToString();
            l_opr_date.Text = dt.Rows[0][3].ToString();
            l_COMMISSION_FEE.Text = dt.Rows[0][4].ToString();
            l_Auth_code.Text = dt.Rows[0][5].ToString();
            l_settlement_type.Text = dt.Rows[0][6].ToString();
            l_session_file_id.Text = dt.Rows[0][7].ToString();
        }
        catch (Exception ex)
        {
            ShowMessage("Error get refnum fundamental " + _case._get_message, MessageType.Error);
        }
        finally
        {
            
        }
    }


    protected void btn_save_Click(object sender, EventArgs e)
    {
        _register_visa_case_disputed();
    }
    //private string AutoIncrementID()
    //{
    //    DataTable dt = _incident._getAutoIncrementID();
    //    string id = dt.Rows[0][0].ToString();
    //    sqlc.Close();
    //    return id;
    //}
    public static string ZeroAppend(string data, int idLimit)
    {
        return data.Substring(data.Length - idLimit);
    }
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Payment/VISACDI.aspx");
    }

    public bool _register_visa_case_disputed()
    {

        _case.P_REFNUM = t_Ticket_no.Text;
        _case.P_OPER_AMOUNT = l_txn_amount.Text;
        _case.P_OPER_CURRENCY = l_opr_ccy.Text;
        _case.P_OPER_DATE = l_opr_date.Text;
        _case.P_COMMISSION_FEE = l_COMMISSION_FEE.Text;
        _case.P_AUTH_CODE = l_Auth_code.Text;
        _case.P_SETTLEMENT_FLAG = l_settlement_type.Text;
        _case.P_SESSION_ID = l_session_file_id.Text;
        _case.P_PROC_DATE = t_prc_date.Text;
        _case.P_STATUS = d_status.SelectedItem.ToString();
        _case.P_REMARK = t_Remark.Text;
        _case.P_USERID = Session["USERID"].ToString();
        bool _get_case_dis = _case._register_visa_case_dispute();
        if (_get_case_dis == true)
        {
            ShowMessage("VISA Case dispute is successful !!", MessageType.Success);
            linkbtnsave.Enabled = false;
        }
        else
        {
            ShowMessage("Register Visa Case dispute is fail!" + _case._get_message, MessageType.Error);
        }
        return _get_case_dis;
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