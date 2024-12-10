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
using ClosedXML.Excel;

public partial class Payment_CSSVW : System.Web.UI.Page
{
    
    GridViewValues _grid = new GridViewValues();
    DropDownListValues _drop = new DropDownListValues();
    MaintenanceFee _Main = new MaintenanceFee();
    logger _logger = new logger();
    SqlConnection sqlc = new SqlConnection();
    CSSdashboard _CSS = new CSSdashboard();
    get_sql_string sql_string = new get_sql_string();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        string currentdate = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
        if (!IsPostBack)
        {
            txtForm.Text = currentdate;
            L_rowcount.InnerText = getgrid1.Rows.Count.ToString();
        }
        }

    public void _getgrid_List_ACQ()
    {
        getgrid1.HeaderStyle.BackColor = Color.FromName("#01559E");
        getgrid1.HeaderStyle.Font.Bold = true;
        getgrid1.HeaderStyle.ForeColor = Color.FromName("#f5f5f5");
        _CSS.P_SDATE = txtForm.Text;
        _grid._GridviewBinding(getgrid1, _CSS._CSS_PRE_CHECK_SETTLEMENT_ACQ());
        L_rowcount.InnerText = getgrid1.Rows.Count.ToString();
    }
    private void get_excel_CSS_Trasaction()
    {
        _CSS.P_SDATE = txtForm.Text;
        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = _CSS._CSS_PRE_CHECK_SETTLEMENT_ACQ();
        wb.Worksheets.Add(dt, "CSS_TRANS");

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=CSS_TRANS"+ _CSS.P_SDATE + ".xlsx");
        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        wb.SaveAs(memory);
        memory.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();
        //Response.Write("<script>alert('Update Successful!!')</script>");
        //Server.Transfer("~/TestPro/Default.aspx");
    }
    //public void _getgrid_List_ISS()
    //{
    //    getgrid1.HeaderStyle.BackColor = Color.FromName("#01559E");
    //    getgrid1.HeaderStyle.Font.Bold = true;
    //    getgrid1.HeaderStyle.ForeColor = Color.FromName("#f5f5f5");
    //    _CSS.P_SDATE = txtForm.Text;
    //    _CSS.P_EDATE = txtto.Text;
    //    _grid._GridviewBinding(getgrid1, _CSS._CSS_PRE_CHECK_SETTLEMENT_ISS());
    //    L_rowcount.InnerText = getgrid1.Rows.Count.ToString();
    //}
    protected void Linkbtnapply_Click(object sender, EventArgs e)
    {
        _getgrid_List_ACQ();
    }

    protected void Linkbtnexport_Click(object sender, EventArgs e)
    {
        get_excel_CSS_Trasaction();
    }
}