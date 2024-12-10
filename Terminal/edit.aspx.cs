using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using MasterReportClass;

public partial class Terminal_edit : System.Web.UI.Page
{
    string idedit;
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    SqlConnectAndSqlCommand _sqlcmd = new SqlConnectAndSqlCommand();
    DropDownListValues _drop = new DropDownListValues();
    TerminalDashboard _tid = new TerminalDashboard();
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
        idedit = Request.QueryString["TID"].ToString();
        if (!IsPostBack)
        {
            BindTextBoxvalues();
        }
    }
    private void BindTextBoxvalues()
    {
        try
        {
            _tid.P_TID = idedit;
            DataTable dt = _tid._get_Terminal_fundamental();
            t_tid.Text = idedit; 
            t_atm_type.Text = dt.Rows[0][1].ToString();
            t_atm_mode.Text = dt.Rows[0][2].ToString();
            t_atm_serail.Text = dt.Rows[0][4].ToString(); 
            t_atm_name.Text = dt.Rows[0][5].ToString();
            t_desc.Text = dt.Rows[0][9].ToString();

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

    //public bool _update_ticket_dispute()
    //{
    //    _biller.P_TICKET = Label8.Text;
    //    _biller.P_STATUS = d_status.SelectedItem.Text;
    //    _biller.P_REMARK = t_Remark.Text;
    //    _biller.P_SOLUTION = t_Solution.Text;
    //    _biller.P_USERID = Session["USERID"].ToString();
    //    bool _update = _biller._Update_biller_dispute();

    //    if (_update == true)
    //    {
    //        ShowMessage("Ticket is update successful !", MessageType.Success);
    //        Linkbtnupdate.Enabled = false;
    //    }
    //    else
    //    {
    //        ShowMessage("Ticket is update failed !" + _logger._message, MessageType.Error);
    //    }
    //    return _update;
    //}
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Payment/biller_disp_index.aspx");
    }
    protected void Linkbtnupdate_Click(object sender, EventArgs e)
    {
      //  _update_ticket_dispute();
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
}