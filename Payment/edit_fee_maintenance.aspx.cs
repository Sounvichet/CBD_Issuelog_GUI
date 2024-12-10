using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using MasterReportClass;

public partial class Payment_delete_ticket_dispute : System.Web.UI.Page
{
    string idedit;
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    dbcon obj1 = new dbcon();
    MaintenanceFeeDashBoard _fee = new MaintenanceFeeDashBoard();
    DropDownListValues _drop = new DropDownListValues();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Name"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        idedit = Request.QueryString["card_id"].ToString();
        if (!IsPostBack)
        {
            _drop.bindDropDownList(d_status, _fee._get_fee_status());
            BindTextBoxvalues();
        }
    }
    private void BindTextBoxvalues()
    {
        try
        {
            _fee.P_CARD_ID = idedit;
            DataTable dt = _fee._get_fee_pending_by_card_ID();
            t_card_id.Text = dt.Rows[0][0].ToString();
            t_acct_number.Text = dt.Rows[0][1].ToString();
            t_branch_code.Text = dt.Rows[0][2].ToString();
            t_amount.Text = dt.Rows[0][5].ToString();
            d_status.SelectedValue = dt.Rows[0][27].ToString();

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

    private bool _edit_card_status()
    {
        _fee.P_CARD_ID = t_card_id.Text;
        _fee.P_STATUS = d_status.SelectedItem.ToString();
        bool retval = _fee._Update_fee_status();

        if (retval == true)
        {
            ShowMessage("Update Status Successfully ..!", MessageType.Success);
            Linkbtnsave.Enabled = false;
        }
        else
        {
            ShowMessage("Update Fail please try again..!", MessageType.Error);

        }
        return retval;
    }

    protected void Btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Payment/PMSCST.aspx");
    }

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }


    protected void Linkbtnsave_Click(object sender, EventArgs e)
    {
        _edit_card_status();
    }
}