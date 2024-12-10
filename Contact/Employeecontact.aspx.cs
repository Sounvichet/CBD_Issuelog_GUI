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

public partial class Contact_Employeecontact : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    dbcon obj1 = new dbcon();
    SqlConnectAndSqlCommand _sqlcmd = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    Employee_Info _employee = new Employee_Info();
    GridViewValues _grid = new GridViewValues();
    string storid;
    int rowIndex = 1;
    int _empid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_name"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }

        if (!this.IsPostBack)
        {
            
            _getEmplistContact();
            //GridView2.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            storid = DataBinder.Eval(e.Row.DataItem, "Project/Program").ToString();
            _empid = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "EmployeeID").ToString());
        }

        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    e.Row.Cells[5].Text = Convert.ToDateTime(e.Row.Cells[5].Text).ToString("dd/MMM/yyyy").Replace('/', '-');
        //}
       

    }

    protected void GridView2_RowCreated(object sender, GridViewRowEventArgs e)
    {
        bool newRow = false;

         
        if ((_empid >0) &&(DataBinder.Eval(e.Row.DataItem, "Project/Program") != null))
        {
            string _getitem = (DataBinder.Eval(e.Row.DataItem, "Project/Program").ToString());   // e.Row.Cells[11].Text.ToString();
            if (storid != _getitem)
                newRow = true;
                //rowIndex = 1;
        }

        if ((_empid >0)&&(DataBinder.Eval(e.Row.DataItem, "Project/Program") == null))
        {
                newRow = true;
                rowIndex = 0;
        }

        if (newRow)
        {
            AddNewRow(sender, e);
        }
    }


    public void AddNewRow(object sender, GridViewRowEventArgs e)
    {
        GridView GridView1 = (GridView)sender;
        GridViewRow NewTotalRow = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
        NewTotalRow.Font.Bold = true;
        NewTotalRow.BackColor = Color.FromName("#01559E");
        NewTotalRow.ForeColor = Color.FromName("#f5f5f5");
        TableCell HeaderCell = new TableCell();
        HeaderCell.Height = 10;
        HeaderCell.ColumnSpan = 12;
        HeaderCell.Font.Size = 10;
        HeaderCell.Text = storid;
        HeaderCell.HorizontalAlign = HorizontalAlign.Left;
        NewTotalRow.Cells.Add(HeaderCell);
        GridView1.Controls[0].Controls.AddAt(e.Row.RowIndex + rowIndex, NewTotalRow );
        rowIndex++;
    }


    public void _getEmplistContact()
    {
        _grid._GridviewBinding(GridView2, _employee._getEmployee_ListForContact(Session["BranchID"].ToString(), Session["user_name"].ToString()));
    }
}