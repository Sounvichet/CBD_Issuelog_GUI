using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MasterReportClass;

public partial class Payment_visa_payment_edit : System.Web.UI.Page
{
    string idedit;
    Visa_payment_dashboard _visa = new Visa_payment_dashboard();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        
        idedit = Request.QueryString["RRN"].ToString();
        l_RRN.Text = idedit;
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

    protected void t_AMOUNT_TextChanged(object sender, EventArgs e)
    {
        int getrate = int.Parse (L_rate.Text);

        if (getrate == 1)
        {
            decimal _amount = decimal.Parse(t_AMOUNT.Text);
            int _rate = int.Parse(L_rate.Text);
            decimal _get_lcy;
            string decimalString = "";
            _get_lcy = _amount / _rate;
            decimalString = _get_lcy.ToString("#.##");
            t_LCY_AMOUNT.Text = decimalString;
            return;
        }
        else if (getrate != 1)
        {
            decimal _amount = decimal.Parse(t_AMOUNT.Text);
            int _rate = int.Parse(L_rate.Text);
            decimal _get_lcy;
            string decimalString = "";
            _get_lcy = (_amount / _rate);
            decimalString = _get_lcy.ToString("#.##");
            t_LCY_AMOUNT.Text = decimalString;
            return;
        }
    }
    public bool _Get_update_VISA_Payment_ITO_pre()
    {
        _visa.p_RRN = l_RRN.Text;
        _visa.p_amount = t_AMOUNT.Text;
        _visa.p_amount_lcy = t_LCY_AMOUNT.Text;
        bool update_ito_pre = _visa._UPDATE_VISA_PAYEMNT_ITO_PRE();

        if (update_ito_pre == true)
        {
            ShowMessage("Update RRN is successfully!!", MessageType.Success);
            Linkbtnsave.Enabled = false;
            t_AMOUNT.Enabled = false;
        }
        else
        {
            ShowMessage("Update failed !!", MessageType.Error);
        }
        return update_ito_pre; 
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    protected void Linkbtnsave_Click(object sender, EventArgs e)
    {
        _Get_update_VISA_Payment_ITO_pre();
    }

    //protected void Linkbtnedit_Click(object sender, EventArgs e)
    //{
    //    Linkbtnsave.Enabled = true;
    //    t_AMOUNT.Enabled = true; 
    //}

    protected void Linkbtnedit_Click(object sender, EventArgs e)
    {
            Linkbtnsave.Enabled = true;
            t_AMOUNT.Enabled = true; 
    }
}