using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ClosedXML.Excel;

public partial class MASTERREPORTS_CUSTOMERS_CUSSEROPT : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    GridViewValues _grid = new GridViewValues();
    DropDownListValues _drop = new DropDownListValues();
    ReportCustDashboard _rptCus = new ReportCustDashboard();
    string _getposition;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        string currentdate1 = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
        if (!IsPostBack)
        {
            _getBranchID();
            d_branch.SelectedValue = Session["BRANCHCODE"].ToString();
            _getrulebranchid();
            txtS_date.Text = currentdate1;
            txtE_date.Text = currentdate1; 
        }
    }
    private void _getrulebranchid()
    {
        _getposition = Session["JOBID"].ToString();
        if (_getposition == "FOUND")
        {
            d_branch.Enabled = true;
        }
        else
        {
            d_branch.Enabled = false;
        }
    }

    private void _getBranchID()
    {
        _drop.bindDropDownList(d_branch, _rptCus._GetBranchCode());
    }
    private void _gridservice_trn()
    {
        _rptCus._branchID = d_branch.SelectedValue;
        _rptCus._s_date = txtS_date.Text;
        _rptCus._e_date = txtE_date.Text;
        _grid._GridviewBinding(GridCustreport, _rptCus._GetService_trn_bydate());
        Label4.Text = GridCustreport.Rows.Count.ToString();
    }

    private void _getexcel_service_trn()
    {
        try
        {
            _rptCus._branchID = d_branch.SelectedValue;
            _rptCus._s_date = txtS_date.Text;
            _rptCus._e_date = txtE_date.Text;
            XLWorkbook wb = new XLWorkbook();
            DataTable dt = new DataTable();

            dt = _rptCus._GetService_trn_bydate();
            wb.Worksheets.Add(dt, "Service_trn");
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=Service_trn.xlsx");
            System.IO.MemoryStream memory = new System.IO.MemoryStream();
            wb.SaveAs(memory);
            memory.WriteTo(Response.OutputStream);
            Response.Flush();
            Response.End();
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

    protected void linkbtnsave_Click(object sender, EventArgs e)
    {
        _gridservice_trn();
    }

    protected void Linkbtnrefresh_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }

    protected void Linkbtncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/index.aspx");
    }

    protected void Linkexport_Click(object sender, EventArgs e)
    {
        _getexcel_service_trn();
    }
}