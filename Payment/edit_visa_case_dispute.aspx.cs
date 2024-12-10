using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using VisaClearingClass; 

public partial class Payment_edit_visa_case_dispute : System.Web.UI.Page
{
    string idrefnum;
    //SqlConnection sqlc = new SqlConnection();
    //logger _logger = new logger();
    //SqlCommand cmd = new SqlCommand();
    //SqlConnectAndSqlCommand _sqlcmd = new SqlConnectAndSqlCommand();
    DropDownListValues _drop = new DropDownListValues();
    //Case_Disputes_Dashboard _case_dis = new Case_Disputes_Dashboard();
    CaseDisputeDashboard _case_dis = new CaseDisputeDashboard();
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
        idrefnum = Request.QueryString["refnum"].ToString();
        if (!IsPostBack)
        {
            _drop.bindDropDownList(d_status, _case_dis._get_status());
            BindTextBoxvalues();
        }
    }
    private void BindTextBoxvalues()
    {
        try
        {
            string _get_status; 
            _case_dis.P_REFNUM = idrefnum;
            DataTable dt = _case_dis._get_visa_cases_dispute_RRN_fundamental();
            l_rrn.Text = dt.Rows[0][0].ToString();
            l_trn_amount.Text = dt.Rows[0][1].ToString();
            l_opr_ccy.Text = dt.Rows[0][2].ToString();
            l_opr_date.Text = dt.Rows[0][3].ToString();
            _get_status = dt.Rows[0][9].ToString();
            if (_get_status == "PENDING")
            {
                d_status.SelectedValue = "1";
            }
            if (_get_status == "SOLVED")
            {
                d_status.SelectedValue = "2";
            }
            t_remark.Text = dt.Rows[0][10].ToString();
        }
        catch (Exception ex)
        {
            ShowMessage("Error RRN fundamental "+ _case_dis._get_message+ "", MessageType.Error);
        }
        finally
        {
            
        }
    }

    public bool _update_visa_case_dispute()
    {
        _case_dis.P_REFNUM = l_rrn.Text;
        _case_dis.P_STATUS = d_status.SelectedItem.Text;
        _case_dis.P_REMARK = t_remark.Text;
        bool _update = _case_dis._edit_visa_case_dispute();

        if (_update == true)
        {
            ShowMessage("Visa case dispute was updated successfully !", MessageType.Success);
            Linkbtnupdate.Enabled = false;
        }
        else
        {
            ShowMessage("Visa case dispute was updated fail !" + _case_dis._get_message, MessageType.Error);
        }
        return _update;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Payment/VISACDI.aspx");
    }
    protected void Linkbtnupdate_Click(object sender, EventArgs e)
    {
        _update_visa_case_dispute();
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
}