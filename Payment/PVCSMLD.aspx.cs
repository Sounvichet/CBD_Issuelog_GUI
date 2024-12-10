using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MasterReportClass; 
public partial class Payment_PVCSMLD : System.Web.UI.Page
{
    GridViewValues _grid = new GridViewValues();
    ConsumerDashboard _csm = new ConsumerDashboard();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
    }
    private void loading_Close()
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "load", "$('#loading').hide();", true);
    }

    protected void Linkbtnproccess_Click(object sender, EventArgs e)
    {
        GridView _getgrid = new GridView();
        _getgrid.DataSource = _csm._getconsumer_list();
        _getgrid.DataBind();

        _csm._GET_UpdateBill_ID_INH_PRI(_getgrid);
        loading_Close();

    }
}