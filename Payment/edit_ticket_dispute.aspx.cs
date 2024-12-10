using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using MasterReportClass;

public partial class Payment_edit_ticket_dispute : System.Web.UI.Page
{
    string idedit;
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    SqlConnectAndSqlCommand _sqlcmd = new SqlConnectAndSqlCommand();
    DropDownListValues _drop = new DropDownListValues();
    Dispute_DashBoard _dis = new Dispute_DashBoard();
    public enum MessageType { Success, Error, Info, Warning };
    string filename = "";
    string ext = "";
    string contenttype = "";
    int filesize = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Name"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        idedit = Request.QueryString["ticket_id"].ToString();
        if (!IsPostBack)
        {
            _Bind_issue_type();
            _Bind_problem_type();
            BindTextBoxvalues();
        }
    }
    private void BindTextBoxvalues()
    {
        try
        {

            _dis.P_TICKET = idedit;
            DataTable dt = _dis._get_ticket_disp_pending_fundamental();
            Label8.Text = dt.Rows[0][0].ToString();
            branch_name.Text = dt.Rows[0][1].ToString();
            t_system_type.Text = dt.Rows[0][3].ToString();
            t_wrs_date.Text = dt.Rows[0][4].ToString();
            t_issue_date.Text = dt.Rows[0][5].ToString();
            t_resolved_date.Text = dt.Rows[0][6].ToString();
            t_terminal_id.Text = dt.Rows[0][7].ToString();
            t_trace_number.Text = dt.Rows[0][11].ToString();
            d_Currency.SelectedItem.Text = dt.Rows[0][12].ToString();
            t_trn_amount.Text = dt.Rows[0][13].ToString();
            t_fee_amount.Text = dt.Rows[0][14].ToString();
            d_issue_type.SelectedValue = dt.Rows[0][15].ToString();
            d_Problem_Type.SelectedValue = dt.Rows[0][17].ToString();
            d_status.SelectedItem.Text = dt.Rows[0][19].ToString();
            t_Remark.Text = dt.Rows[0][21].ToString();
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
            _drop.bindDropDownList(d_issue_type, _dis._get_issue_type());
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
            _drop.bindDropDownList(d_Problem_Type, _dis._get_problem_type());
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
    

    public bool _update_ticket_dispute()
    {
        _dis.P_RESOLVED_DATE = t_resolved_date.Text;
        _dis.P_ISSUE_TYPE = d_issue_type.SelectedValue;
        _dis.P_PROBLEM_TYPE = d_Problem_Type.SelectedValue;
        _dis.P_RECORD_STATUS = d_status.SelectedItem.ToString();
        _dis.P_REMARK = t_Remark.Text;
        _dis.P_TICKET = Label8.Text;
        bool _update = _dis._update_ticket_dispute_pending();

        if (_update == true)
        {
            ShowMessage("Ticket is update successful !", MessageType.Success);
            Linkbtnupdate.Enabled = false;
        }
        else
        {
            ShowMessage("Ticket is update failed !" + _logger._message, MessageType.Error);
        }
        return _update;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Payment/dispute_resolution.aspx");
    }
    protected void Linkbtnupdate_Click(object sender, EventArgs e)
    {
        _update_ticket_dispute();
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
}