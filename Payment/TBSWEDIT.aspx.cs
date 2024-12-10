using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MasterReportClass;
using System.Data.OracleClient;
using System.Data;
using System.Globalization;

public partial class Payment_TBSWEDIT : System.Web.UI.Page
{
    public enum MessageType { Success, Error, Info, Warning };
    Dispute_DashBoard _dis = new Dispute_DashBoard();
    logger _logger = new logger();
    DropDownListValues _drop = new DropDownListValues();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        
        if (!IsPostBack)
        {
            
            _Bind_issue_type();
            W_trn_Fundamental();
        }
    }

    public void _Bind_issue_type()
    {
        try
        {
            _dis.P_TYPE = "2";
            _drop.bindDropDownList(d_Dispute_type, _dis._get_issue_type());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }
        finally
        {
           // sqlc.Close();
        }
    }

    public void W_trn_Fundamental()
    {
        try
        {
            _dis.P_TICKET = Request.QueryString["original_ref"].ToString(); 
            DataTable dt = _dis._get_ticket_in_progress_fundamental();
            t_Received_date.Text = dt.Rows[0][2].ToString();
            t_Correct_Amount.Text = dt.Rows[0][10].ToString();
            t_Adjustment_Amount.Text = dt.Rows[0][11].ToString();
            d_channel.SelectedItem.Text = dt.Rows[0][22].ToString();
            l_trn_ref.Text = dt.Rows[0][0].ToString();
            d_Dispute_type.SelectedValue = dt.Rows[0][9].ToString();
            d_Adjustment_Method.Text = dt.Rows[0][12].ToString();
            t_status.SelectedItem.Text = dt.Rows[0][13].ToString();
            t_htb_confirm_date.Text = dt.Rows[0][15].ToString();
            t_party_confirm_date.Text = dt.Rows[0][16].ToString();
            t_dept_remark.Text = dt.Rows[0][19].ToString();
            t_send_to_branch.Text = dt.Rows[0][20].ToString();

        }
        catch
        {
            throw;
        }
        finally
        {
            
        }
    }
    

        protected void Linkbtnsave_Click(object sender, EventArgs e)
    {
        _update_ticket_dispute();
    }


    public bool _update_ticket_dispute()
    {
        _dis.P_TICKET = l_trn_ref.Text;
        _dis.P_CHANNEL = d_channel.SelectedItem.ToString();
        _dis.P_RECORD_STATUS = t_status.SelectedItem.ToString();
        _dis.P_HTB_CONFIRM_DATE = t_htb_confirm_date.Text;
        _dis.P_WING_CONFIRM_DATE = t_party_confirm_date.Text;
        _dis.P_SEND_TO_BRANCH = t_send_to_branch.Text;
        _dis.P_DEPT_REMARK = t_dept_remark.Text;
        _dis.P_RECEIVED_DATE = t_Received_date.Text;
        _dis.P_DISPUTE_TYPE = d_Dispute_type.SelectedValue;
        _dis.P_CORRECT_AMOUNT = t_Correct_Amount.Text;
        _dis.P_ADJ_AMOUNT = t_Adjustment_Amount.Text;
        _dis.P_ADJ_METHOD = d_Adjustment_Method.SelectedItem.ToString();
        _dis.P_USERID = Session["USERID"].ToString();
        bool _update = _dis._update_loan_dispute_pending();

        if (_update == true)
        {
            ShowMessage("Ticket is update successful !", MessageType.Success);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Disable", "javascript:Disable();", true);
        }
        else
        {
            ShowMessage("Ticket is update failed !" + _logger._message, MessageType.Error);
        }
        return _update;
    }

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    protected void LinkBtncal_Click(object sender, EventArgs e)
    {
        Response.Redirect("TBSWDSL.aspx");
    }
}