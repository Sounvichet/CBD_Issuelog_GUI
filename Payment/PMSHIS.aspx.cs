using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MasterReportClass;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

public partial class Payment_PMSHIS : System.Web.UI.Page
{
    MaintenanceFeeDashBoard _fee = new MaintenanceFeeDashBoard();
    GridViewValues _grid = new GridViewValues();
    DropDownListValues _drop = new DropDownListValues();
    MaintenanceFee _Main = new MaintenanceFee();
    logger _logger = new logger();
    SqlConnection sqlc = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        if (!IsPostBack)
        {
            _getService();
            _SelectDate();
            _SelectToday();
           
        }
        }

    private void _getgridhis()
    {
        _fee.Service = D_service.SelectedValue;
        _fee.P_SDATE = T_SDATE.Text;
        _fee.P_EDATE = T_EDATE.Text;
        GetGrid1.HeaderStyle.BackColor = Color.FromName("#01559E");
        GetGrid1.HeaderStyle.Font.Bold = true;
        GetGrid1.HeaderStyle.ForeColor = Color.FromName("#f5f5f5");
        _grid._GridviewBinding(GetGrid1, _fee.D_get_FEE_CHARGE_HIS());
    }

    private void _getgridhis_BK()
    {
        _fee.Service = D_service.SelectedValue;
        _fee.P_SDATE = T_SDATE.Text;
        _fee.P_EDATE = T_EDATE.Text;
        GetGrid2.HeaderStyle.BackColor = Color.FromName("#01559E");
        GetGrid2.HeaderStyle.Font.Bold = true;
        GetGrid2.HeaderStyle.ForeColor = Color.FromName("#f5f5f5");
        _grid._GridviewBinding(GetGrid2, _fee.D_get_FEE_CHARGE_BK_HIS());
    }


    private void _getService()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("ID", typeof(string));
        dt.Columns.Add("Service", typeof(string));

        DataRow dr = dt.NewRow();
        dr["ID"] = "A";
        dr["Service"] = "ATM";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr["ID"] = "M";
        dr["Service"] = "Mobile";
        dt.Rows.Add(dr);

        _drop.bindDropDownList(D_service, dt);
    }

    public void _SelectDate()
    {
        _drop.bindDropDownList(D_selectdate, _Main.D_Select_date());
    }
    public void _SelectToday()
    {
        try
        {
            DataTable dt = _Main.D_Select_date_today();
            D_selectdate.SelectedValue = dt.Rows[0]["LookupCode"].ToString();
            _Frequency_Fundamental(D_selectdate.SelectedValue);

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
    public void _Frequency_Fundamental(string lookup)
    {
        DataTable dt = _Main.D_Frequency_Fundamental(lookup);

        if (dt.Rows.Count == 0)
        {
            Response.Write("<script>alert('Not Yet implement!')</script>");
        }

        if (dt.Rows.Count > 0)
        {
            T_SDATE.Text = dt.Rows[0][3].ToString();
            T_EDATE.Text = dt.Rows[0][4].ToString();
        }
    }
    protected void Linkbtnapply_Click(object sender, EventArgs e)
    {
        _getgridhis();
        _getgridhis_BK();
    }

    protected void D_selectdate_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectdate = D_selectdate.SelectedValue;
        if (selectdate == "LD")
        {
            T_SDATE.Text = _Main._getStartPeriod(D_selectdate.SelectedValue);
            T_EDATE.Text = _Main._getEndPeriod(D_selectdate.SelectedValue);
        }
        else
        {
            _Frequency_Fundamental(D_selectdate.SelectedValue);

        }
    }
}