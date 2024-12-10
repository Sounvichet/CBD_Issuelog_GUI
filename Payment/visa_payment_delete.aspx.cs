using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MasterReportClass;
using System.Data;

public partial class Payment_visa_payment_delete : System.Web.UI.Page
{
    string iddelete;
    Visa_payment_dashboard _visa = new Visa_payment_dashboard();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        iddelete = Request.QueryString["RRN"].ToString();
        l_RRN.Text = iddelete;
        if (!Page.IsPostBack)
        {
            get_RRN_binding();

        }
    }

    void get_RRN_binding()
    {
        _visa.p_RRN = Request.QueryString["RRN"].ToString();
        DataTable dt = _visa._get_VISA_RRN_BINDING();
        L_rate.Text = dt.Rows[0][0].ToString();
        t_AMOUNT.Text = dt.Rows[0][1].ToString();
        t_LCY_AMOUNT.Text = dt.Rows[0][2].ToString();
    }

    protected void Linkbtncacel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Payment/visa_payment.aspx");
    }
    public bool _Get_DELETE_VISA_Payment_ITO_pre()
    {
        _visa.p_RRN = l_RRN.Text;
        bool update_ito_pre = _visa._DELETE_VISA_PAYEMNT_ITO_PRE();

        if (update_ito_pre == true)
        {
            ShowMessage("Delete RRN is successfully!!", MessageType.Success);
            Linkbtndelete.Enabled = false;
        }
        else
        {
            ShowMessage("Delete failed !!", MessageType.Error);
        }
        return update_ito_pre;
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    protected void Linkbtndelete_Click(object sender, EventArgs e)
    {
        _Get_DELETE_VISA_Payment_ITO_pre();
    }
}