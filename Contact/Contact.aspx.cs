using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;

public partial class ContactTest : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    dbcon obj1 = new dbcon();
    SqlConnectAndSqlCommand _sqlcmd = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    GridViewValues _grid = new GridViewValues();
    EmployeeDashboard _emp = new EmployeeDashboard();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_name"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        if (!this.IsPostBack)
        {
            _getbranchid();
            _getEmpcontactListing();
            rowcount.InnerText = GridView2.Rows.Count.ToString();
        }
    }
    public void _getEmpcontactListing()
    {
        //_emp._BranchID = Session["BRANCHCODE"].ToString();
        _emp._deptid = Session["deptID"].ToString();
      //  GridView2.HeaderStyle.BackColor = Color.FromName("#01559E");
       // GridView2.HeaderStyle.Font.Bold = true;
       // GridView2.HeaderStyle.ForeColor = Color.FromName("#f5f5f5");
        _grid._GridviewBinding(GridView2, _emp._getEmpContactlist());
    }
    private void _getbranchid()

    {
        _emp._deptid = Session["deptID"].ToString();
        DataTable dt = _emp._getEmpBranch();
        lbldept.Text = dt.Rows[0]["DeptNameU"].ToString();
    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[2].ForeColor = Color.FromName("#4F4FFF");
            e.Row.Cells[2].CssClass = "proxy-content";
            //e.Row.Cells[6].ForeColor = Color.FromName("#4F4FFF");
            //e.Row.Cells[6].CssClass = "proxy-content";
            //string _days = (string)DataBinder.Eval(e.Row.DataItem, "THRESHOLD1");
            //if (_days == "50")
            //{
            //    e.Row.Cells[7].ForeColor = Color.FromName("RED");
            //}

        }




        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{



        //int values = (int)DataBinder.Eval(e.Row.DataItem, "CAS1_WARN");

        //if (values <= 60)
        //{
        //    e.Row.Cells[6].Font.Bold = true;
        //    e.Row.Cells[6].ForeColor = Color.FromName("Blue");
        //}
        //}

    }

}