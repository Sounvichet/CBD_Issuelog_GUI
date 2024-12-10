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

public partial class threshold_TRSHDCC : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    GridViewValues _grid = new GridViewValues();
    ThresholdDashboard _threshold = new ThresholdDashboard();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Name"] == null)
        {
            //  ClientScript.RegisterStartupScript(GetType(), "Load", "'<script type="text/javascript">window.location.href = "/mastercare/Default.aspx" </script>');
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '/mastercare/Default.aspx'; </script>");
        }
        if (!this.IsPostBack)
        {
            _getCassetteThreshold();
        }
    }

    public void _getCassetteThreshold()

    {
        GriViewcassette.HeaderStyle.BackColor = Color.FromName("#01559E");
        GriViewcassette.HeaderStyle.Font.Bold = true;
        GriViewcassette.HeaderStyle.ForeColor = Color.FromName("#f5f5f5");
        _grid._GridviewBinding(GriViewcassette, _threshold.D_getCassetteThreshold());
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //GriViewcassette.HeaderStyle.BackColor = Color.FromName("#01559E");
        GriViewcassette.HeaderStyle.Font.Bold = true;
        //GriViewcassette.HeaderStyle.ForeColor = Color.FromName("#f5f5f5");

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[9].HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[10].HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[11].HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[12].HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[13].HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[14].HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[15].HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[16].HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[17].HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[18].HorizontalAlign = HorizontalAlign.Center;
            int values1 = int.Parse(DataBinder.Eval(e.Row.DataItem, "CAS1_WARN").ToString());
            if (values1 <= 40)
            {
                e.Row.Cells[9].Font.Bold = true;
                e.Row.Cells[9].ForeColor = Color.FromName("#4F4FFF");
            }
            if (values1 <= 60 && values1 > 41)
            {
                e.Row.Cells[9].Font.Bold = true;
                e.Row.Cells[9].ForeColor = Color.FromName("#FF7300");
            }
            if (values1 <= 80 && values1 >60)
            {
                e.Row.Cells[9].Font.Bold = true;
                e.Row.Cells[9].ForeColor = Color.FromName("#ffDD1C");
            }

            if (values1 > 80)
            {
                e.Row.Cells[9].Font.Bold = true;
                e.Row.Cells[9].ForeColor = Color.FromName("#4F4FFF");
            }
            int values2 = int.Parse(DataBinder.Eval(e.Row.DataItem, "CAS2_WARN").ToString());
            if (values2 <= 100)
            {
                e.Row.Cells[10].Font.Bold = true;
                e.Row.Cells[10].ForeColor = Color.FromName("#4F4FFF");
            }
            if (values2 <= 150 && values2 > 100)
            {
                e.Row.Cells[11].Font.Bold = true;
                e.Row.Cells[11].ForeColor = Color.FromName("#FF7300");
            }
            if (values2 <= 200 && values2 >150)
            {
                e.Row.Cells[11].Font.Bold = true;
                e.Row.Cells[11].ForeColor = Color.FromName("#ffDD1C");
            }
            if (values2 > 200)
            {
                e.Row.Cells[11].Font.Bold = true;
                e.Row.Cells[11].ForeColor = Color.FromName("#4F4FFF");
            }
            int values3 = int.Parse(DataBinder.Eval(e.Row.DataItem, "CAS3_WARN").ToString());
            if (values3 <= 100)
            {
                e.Row.Cells[13].Font.Bold = true;
                e.Row.Cells[13].ForeColor = Color.FromName("#4F4FFF");
            }
            if (values3 <= 150 && values3 > 100)
            {
                e.Row.Cells[13].Font.Bold = true;
                e.Row.Cells[13].ForeColor = Color.FromName("#FF7300");
            }
            if (values3 <= 200 && values3 > 150)
            {
                e.Row.Cells[13].Font.Bold = true;
                e.Row.Cells[13].ForeColor = Color.FromName("#ffDD1C");
            }
            if (values3 > 200)
            {
                e.Row.Cells[13].Font.Bold = true;
                e.Row.Cells[13].ForeColor = Color.FromName("#4F4FFF");
            }
            int values4 = int.Parse(DataBinder.Eval(e.Row.DataItem, "CAS4_WARN").ToString());
            if (values4 <= 20)
            {
                e.Row.Cells[15].Font.Bold = true;
                e.Row.Cells[15].ForeColor = Color.FromName("#4F4FFF");
            }
            if (values4 <= 50 && values4 > 20)
            {
                e.Row.Cells[15].Font.Bold = true;
                e.Row.Cells[15].ForeColor = Color.FromName("#FF7300");
            }
            if (values4 <= 60 && values4 > 50)
            {
                e.Row.Cells[15].Font.Bold = true;
                e.Row.Cells[15].ForeColor = Color.FromName("#ffDD1C");
            }
            if (values4 > 60)
            {
                e.Row.Cells[15].Font.Bold = true;
                e.Row.Cells[15].ForeColor = Color.FromName("#4F4FFF");
            }
            int values5 = int.Parse(DataBinder.Eval(e.Row.DataItem, "RJC_WARN").ToString());
            if (values5 >= 250)
            {
                e.Row.Cells[15].Font.Bold = true;
                e.Row.Cells[15].ForeColor = Color.FromName("#4F4FFF");
            }
            if (values5 >= 200 && values5 < 250)
            {
                e.Row.Cells[15].Font.Bold = true;
                e.Row.Cells[15].ForeColor = Color.FromName("#FF7300");
            }
            if (values5 >= 150 && values5 < 200)
            {
                e.Row.Cells[15].Font.Bold = true;
                e.Row.Cells[15].ForeColor = Color.FromName("#ffDD1C");
            }
            if (values5 > 60)
            {
                e.Row.Cells[15].Font.Bold = true;
                e.Row.Cells[15].ForeColor = Color.FromName("#4F4FFF");
            }
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

    
