using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using MasterReportClass;
using System.Drawing;
using ClosedXML.Excel;
using System.IO;
using System.Data;
using EpowerCommissionSharingFee;

public partial class Payment_E_POWER : System.Web.UI.Page
{
    //EpowerDashboard _epower = new EpowerDashboard();
    GridViewValues _grid = new GridViewValues();
    EpowerCommissionReport _erpt = new EpowerCommissionReport();
    EpowerUploadITO _upload = new EpowerUploadITO();
    EpowerITOFunction _func = new EpowerITOFunction();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        string currentdate = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
        string previousdate = DateTime.Now.AddDays(-30).ToString("dd/MMM/yyyy").Replace('/', '-');

        if (!IsPostBack)
        {
            t_start_date.Text = previousdate;
            t_end_date.Text = currentdate;
            l_count_epower.Text = grid_epower.Rows.Count.ToString();
        }
    }
    private void loading_Close()
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "load", "$('#loading').hide();", true);
    }

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }


    protected void ITO_REVIEW_ServerClick(object sender, EventArgs e)
    {
        _erpt.P_SDATE = t_start_date.Text.ToString();
        _erpt.P_EDATE = t_end_date.Text.ToString();
        _erpt.P_CCY = d_CCY.SelectedItem.ToString();
        _grid._GridviewBinding(grid_epower, _erpt._ITO_EPOWER_CCY_BY_MONTHLY());
        loading_Close();
        l_count_epower.Text = grid_epower.Rows.Count.ToString();
    }

    protected void ITO_PUSH_DETB_ITO_ServerClick(object sender, EventArgs e)
    {
        _upload.P_USERID = Session["USER_NAME"].ToString();
        _upload._EPOWER_ITO_UPLOADS(grid_epower);
        loading_Close();
        ShowMessage("Uploaded records into detb ITO successful !", MessageType.Success);
    }

    protected void ITO_FN_PUSH_ServerClick(object sender, EventArgs e)
    {
        _func.p_type = "CBDAPP";
        _func.p_source = "CBD_SYSTEM";
        _func.p_reference = "E-POWER_" + d_CCY.SelectedItem.ToString();
        _func._GET_ITO_FN_PUSH_ENTRIES();
        loading_Close();
        ShowMessage("Push records to detb ITO successful !", MessageType.Success);
    }

    protected void ITO_FN_DEL_ServerClick(object sender, EventArgs e)
    {
        _func.p_source = "CBD_SYSTEM";
        _func.p_reference = "E-POWER_" + d_CCY.SelectedItem.ToString();
        _func._GET_ITO_FN_DEL_ENTRIES();
        _func._GET_ITO_DEL_DETB_UPLOAD();
        loading_Close();
        ShowMessage("Deleted records in detb ITO successful !", MessageType.Success);
    }
}