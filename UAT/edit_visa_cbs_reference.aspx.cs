using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using MasterReportClass;

public partial class Payment_edit_visa_cbs_reference : System.Web.UI.Page
{
    string idedit;
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    dbcon obj1 = new dbcon();
    Visa_payment_dashboard_UAT _visa = new Visa_payment_dashboard_UAT();
    DropDownListValues _drop = new DropDownListValues();
    GridViewValues _grid = new GridViewValues();
    public enum MessageType { Success, Error, Info, Warning };
    string status; 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Name"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        idedit = Request.QueryString["refnum"].ToString();
        if (!IsPostBack)
        {
           // _drop.bindDropDownList(d_status, _fee._get_fee_status());
            BindTextBoxvalues();
            _drop.bindDropDownList(d_DRCR, _visa._get_Dropdownlist_DRCR());
            _drop.bindDropDownList(d_drcr_maskup, _visa._get_Dropdownlist_DRCR());
            _drop.bindDropDownList(d_drcr_icf, _visa._get_Dropdownlist_DRCR());

        }
    }
    private void BindTextBoxvalues()
    {
        try
        {
            _visa.p_RRN = idedit;
            DataTable dt = _visa._get_VISA_List_by_RRN();

            double Markup = Convert.ToDouble(dt.Rows[0][22]);
            double Visa_charge = Convert.ToDouble(dt.Rows[0][23]);
            status = dt.Rows[0][24].ToString();

            t_run_date.Text = dt.Rows[0][0].ToString();
            t_trn_date.Text = dt.Rows[0][9].ToString();
            t_refnum.Text = dt.Rows[0][3].ToString();
            t_trans_type.Text = dt.Rows[0][4].ToString();
            t_currency.Text = dt.Rows[0][5].ToString();
            t_trn_amount.Text = dt.Rows[0][7].ToString();
            t_trn_fee.Text = dt.Rows[0][8].ToString();
            t_iss_inst.Text = dt.Rows[0][11].ToString();
            t_acq_inst.Text = dt.Rows[0][12].ToString();
            t_resp.Text = dt.Rows[0][13].ToString();
            t_online_ref.Text = dt.Rows[0][15].ToString();
            t_offline_ref.Text = dt.Rows[0][16].ToString();
            t_proc_date.Text = dt.Rows[0][19].ToString();
            t_session_file_id.Text = dt.Rows[0][21].ToString();
            t_markup.Text = Markup.ToString("0.00");
            t_visa_charge.Text = Visa_charge.ToString("0.00");
            if (status == "REFUND")
            {
                Label19.Visible = true;
                d_DRCR.Visible = true;

                Label20.Visible = true;
                d_drcr_maskup.Visible = true;

                Label21.Visible = true;
                d_drcr_icf.Visible = true; 

            }
            d_DRCR.SelectedValue = dt.Rows[0][25].ToString();
            d_drcr_maskup.SelectedValue = dt.Rows[0][26].ToString();
            d_drcr_icf.SelectedValue = dt.Rows[0][27].ToString();
            //else
            //{
            //    Label19.Visible = true;
            //    d_DRCR.Visible = true;
            //}
            _grid._GridviewBinding(Grid_list_by_RRN, _visa._get_Check_CBS_ref_by_RRN());
            _grid._GridviewBinding(Grid_ito_pre_check, _visa._get_ITO_pre_check_by_RRN());
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
    private bool _edit_visa_CBS_reference()
    {
        _visa.p_RRN = t_refnum.Text;
        _visa.p_cbs_offline = t_offline_ref.Text;
        _visa.p_cbs_online = t_online_ref.Text;
        _visa.p_run_date = t_run_date.Text;
        _visa.p_proc_date = t_proc_date.Text;
        bool retval = _visa._UPDATE_VISA_CBS_TRN_REF();

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


    private bool _edit_visa_refund()
    {
        _visa.P_AUTH_CODE = t_refnum.Text;
        _visa.P_VCG = d_DRCR.SelectedValue.ToString();
        _visa.P_MARKUP = d_drcr_maskup.SelectedValue.ToString();
        _visa.P_ICF = d_drcr_icf.SelectedValue.ToString();
        bool retval = _visa._UPDATE_REFUND_DRCR();

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
        Response.Redirect("~/UAT/VISAUCR.aspx");
    }

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }


    protected void Linkbtnsave_Click(object sender, EventArgs e)
    {

        string trn_type = t_trans_type.Text;

        if (trn_type == "775")
        {
            _edit_visa_refund();
        }
        else
        {
            _edit_visa_CBS_reference();
        }
    }
}