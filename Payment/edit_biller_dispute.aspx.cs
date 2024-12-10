using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using MasterReportClass;

public partial class Payment_edit_biller_dispute : System.Web.UI.Page
{
    string idedit;
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    SqlConnectAndSqlCommand _sqlcmd = new SqlConnectAndSqlCommand();
    DropDownListValues _drop = new DropDownListValues();
    biller_Dashboard _biller = new biller_Dashboard();
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
        idedit = Request.QueryString["original_ref"].ToString();
        if (!IsPostBack)
        {
            _Bind_issue_type();
            BindTextBoxvalues();
        }
    }
    private void BindTextBoxvalues()
    {
        try
        {

            _biller.P_TICKET = idedit;
            DataTable dt = _biller._get_biller_pending_fundamental();
            Label8.Text = dt.Rows[0][3].ToString();
            branch_name.Text = dt.Rows[0][1].ToString();
            t_cbs_ref.Text = dt.Rows[0][9].ToString();
            t_trn_date.Text = dt.Rows[0][2].ToString();
            t_resolved_date.Text = dt.Rows[0][13].ToString();
            d_status.SelectedItem.Text = dt.Rows[0][11].ToString();
            d_issue_type.SelectedValue = dt.Rows[0][10].ToString();
            t_Remark.Text = dt.Rows[0][14].ToString();
            t_Solution.Text = dt.Rows[0][12].ToString();
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

    public bool _update_ticket_dispute()
    {
        _biller.P_TICKET = Label8.Text;
        _biller.P_STATUS = d_status.SelectedItem.Text;
        _biller.P_REMARK = t_Remark.Text;
        _biller.P_SOLUTION = t_Solution.Text;
        _biller.P_USERID = Session["USERID"].ToString();
        bool _update = _biller._Update_biller_dispute();

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
        Response.Redirect("~/Payment/biller_disp_index.aspx");
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