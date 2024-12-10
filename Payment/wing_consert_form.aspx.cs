using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MasterReportClass;

public partial class payment_wing_consert_form : System.Web.UI.Page
{
    string idedit;
    WingDashBoard _wing = new WingDashBoard();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Name"] == null)
        {
          ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        idedit = Request.QueryString["TRN_ID"].ToString();
        if (!IsPostBack)
        {
            _get_printFuncdamentals();
        }
    }

    private void _get_printFuncdamentals()
    {
        _wing.P_WING_TRN = idedit;//"UCN228522";
        DataTable dt = _wing._get_WING_CUS_CONSERT_FORM();
        l_customer.Text = dt.Rows[0]["Cust_Name"].ToString();
        l_customer1.Text = dt.Rows[0]["Cust_Name"].ToString();
        l_National_ID.Text = dt.Rows[0]["National_ID"].ToString();
        l_cust_acct.Text = dt.Rows[0]["CUST_ACCOUNT"].ToString();
        l_amt.Text = dt.Rows[0]["AMOUNT"].ToString();
        L_rec_date.Text = dt.Rows[0]["RECEIVED_DATE"].ToString(); 
        l_branch.Text = dt.Rows[0]["Branch_Name"].ToString();
        //DataTable dt = _miss.D_mission_printFuncdamentals("CBD-0017019");


    }
}