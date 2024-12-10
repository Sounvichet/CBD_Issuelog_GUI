using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;

public partial class Reportchart_solarwindbranch : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    dbcon obj1 = new dbcon();
    SqlCommand cmd = new SqlCommand();
    logger _logger = new logger();
    SolarWindBranchDashBoard _SolarWindBrn = new SolarWindBranchDashBoard();
    GridViewValues _gridview = new GridViewValues();
    NodeDownEvent _objNodedownEvent = new NodeDownEvent();
    ReportSolarWinds _rptsolarwind = new ReportSolarWinds();
    DropDownListValues _dropdown = new DropDownListValues();
    string _office = "";
    string _brn = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
        //    ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        string date = DateTime.Now.ToString("dd/MMM/yyyy HH:mm:ss").Replace('/', '-');
        lblcurrentdate.Text = date;

        //*********Gridview*********\\


        lbldailyuppercent.Text = strDailyuppercent();

        if (!IsPostBack)
        {
            _SelectDate();
            _SelectToday();
            _get_branchName();
            _getchart();
            _Nodedownlisting();
            _CurrentBRNNodeDown();
            
        }

    }
    public void _getchart()
    {
        try
        {
            _office = Session["office"].ToString();
            _brn = Session["BRANCHCODE"].ToString();
            if (_office == "Head Office" && _brn == "003")
            {

                BindChart_NodeDown(_SolarWindBrn.D_NodeDowns()); //  getdata_NodeDowns()
                //BindChart_NodeDownhourly(_SolarWindBrn.D_NodeDownhourly()); //getdata_NodeDownhourly()
                _getmultiChart();
            }
            else

            {
                Chart2.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                Chart2.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
                Chart2.Series["Series1"].Enabled = false;
                ///
                Chart5.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                Chart5.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            }


        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _logger._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert(' " + _logger._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    public void _getmultiChart()
    {
        DataTable dt = _SolarWindBrn.D_NodeDownhourly();
        List<string> GetDayID = (from p in dt.AsEnumerable()
                                 select p.Field<string>("DayID")).Distinct().ToList();

        foreach (string dayid in GetDayID)
        {
            int[] x = (from p in dt.AsEnumerable()
                       where p.Field<string>("DayID") == dayid
                       orderby p.Field<int>("Hourid") ascending
                       select p.Field<int>("Hourid")).ToArray();

            int[] y = (from p in dt.AsEnumerable()
                       where p.Field<string>("DayID") == dayid
                       orderby p.Field<int>("Hourid") ascending
                       select p.Field<int>("getMinute")).ToArray();

            Chart5.Series.Add(new Series(dayid));
            Chart5.Series[dayid].IsValueShownAsLabel = true;
            Chart5.Series[dayid].BorderWidth = 2;
            Chart5.Series[dayid].ChartType = SeriesChartType.Line;
            Chart5.Series[dayid].Points.DataBindXY(x, y);

            Chart5.ChartAreas["ChartArea1"].Area3DStyle.Inclination = -25;
            Chart5.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = -50;
            Chart5.ChartAreas["ChartArea1"].AxisX.TitleFont = new System.Drawing.Font("Verdana", 8, System.Drawing.FontStyle.Bold);
            Chart5.ChartAreas["ChartArea1"].AxisY.TitleFont = new System.Drawing.Font("Verdana", 8, System.Drawing.FontStyle.Bold);
            Chart5.ChartAreas["ChartArea1"].AxisX.Minimum = 0;
            Chart5.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            Chart5.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = true;
            Chart5.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineColor = ColorTranslator.FromHtml("#e5e5e5");
            Chart5.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = true;
            Chart5.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineColor = ColorTranslator.FromHtml("#e5e5e5");
            Chart5.ChartAreas["ChartArea1"].AxisX.LabelStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
            Chart5.ChartAreas["ChartArea1"].AxisY.LabelStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
            Chart5.Series[0].IsValueShownAsLabel = true;
            Chart5.ChartAreas["ChartArea1"].AxisY.Title = "Minutes";
            Chart5.ChartAreas["ChartArea1"].AxisX.Title = "Hours";
        }

    }
    public void _get_branchName()
    {
        _dropdown.bindDropDownList(D_BranchName, _SolarWindBrn.D_BranchName());
    }
    private void BindChart_NodeDown(DataTable dtReport)
    {

        //string[] x = new string[dtReport.Rows.Count];
        //double[] y = new double[dtReport.Rows.Count];
        //for (int i = 0; i < dtReport.Rows.Count; i++)
        //{
        //    x[i] = dtReport.Rows[i][0].ToString();
        //    y[i] = Convert.ToDouble(dtReport.Rows[i][1]);
        //}
        //Chart2.Series[0].Points.DataBindXY(x, y);
        //Chart2.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Doughnut;
        //Chart2.Series[0].LabelForeColor = Color.White;
        //Chart2.Series[0].Font = new Font("Arial", 12, FontStyle.Regular);
        //Chart2.Series[0].Label = "#VALY"; // ; #PERCENT{P1}
        //Chart2.Series[0].LegendText = "#VALX (#PERCENT)";
        //Chart2.Width = 500;

        // Define colors for categories
        Dictionary<string, Color> categoryColors = new Dictionary<string, Color>();
        categoryColors.Add("UP", Color.Blue);
        categoryColors.Add("Down", Color.Red);
        categoryColors.Add("Warning", Color.Orange);

        // Arrays to hold x-values (labels) and y-values (data)
        string[] x = new string[dtReport.Rows.Count];
        double[] y = new double[dtReport.Rows.Count];
        Color[] pointColors = new Color[dtReport.Rows.Count];

        // Populate x-values (labels) and y-values (data)
        for (int i = 0; i < dtReport.Rows.Count; i++)
        {
            x[i] = dtReport.Rows[i][0].ToString();
            y[i] = Convert.ToDouble(dtReport.Rows[i][1]);

            // Determine color based on category
            string category = dtReport.Rows[i]["Name"].ToString();
            if (categoryColors.ContainsKey(category))
            {
                pointColors[i] = categoryColors[category];
            }
            else
            {
                // Default color if category is not found in dictionary
                pointColors[i] = ColorTranslator.FromHtml("#268CF3");
            }
        }

        // Bind data to chart
        Chart2.Series[0].Points.DataBindXY(x, y);

        // Set individual point colors
        for (int i = 0; i < dtReport.Rows.Count; i++)
        {
            Chart2.Series[0].Points[i].Color = pointColors[i];
        }

        // Additional chart properties
        Chart2.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Doughnut;
        Chart2.Series[0].LabelForeColor = Color.White;
        Chart2.Series[0].Font = new Font("Arial", 12, FontStyle.Regular);
        Chart2.Series[0].Label = "#VALY"; // ; #PERCENT{P1}
        Chart2.Series[0].LegendText = "#VALX (#PERCENT)";
        Chart2.Width = 500;
    }
    private void BindChart_NodeDownhourly(DataTable dtReport)
    {
        string[] x = new string[dtReport.Rows.Count];
        double[] y = new double[dtReport.Rows.Count];
        for (int i = 0; i < dtReport.Rows.Count; i++)
        {
            x[i] = dtReport.Rows[i][0].ToString();
            y[i] = Convert.ToDouble(dtReport.Rows[i][1]);
        }
        Chart5.Series[0].Points.DataBindXY(x, y);

        Chart5.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
        //Chart5.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
        Chart5.ChartAreas["ChartArea1"].Area3DStyle.Inclination = -25;
        Chart5.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = -50;
        Chart5.ChartAreas["ChartArea1"].AxisX.TitleFont = new System.Drawing.Font("Verdana", 8, System.Drawing.FontStyle.Bold);
        Chart5.ChartAreas["ChartArea1"].AxisY.TitleFont = new System.Drawing.Font("Verdana", 8, System.Drawing.FontStyle.Bold);
        Chart5.ChartAreas["ChartArea1"].AxisX.Minimum = 0;
        Chart5.ChartAreas["ChartArea1"].AxisX.Interval = 1;
        Chart5.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = true;
        Chart5.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineColor = ColorTranslator.FromHtml("#e5e5e5");
        Chart5.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = true;
        Chart5.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineColor = ColorTranslator.FromHtml("#e5e5e5");
        Chart5.ChartAreas["ChartArea1"].AxisX.LabelStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
        Chart5.ChartAreas["ChartArea1"].AxisY.LabelStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
        Chart5.Series[0].IsValueShownAsLabel = true;
        Chart5.ChartAreas["ChartArea1"].AxisY.Title = "Minutes";
        Chart5.ChartAreas["ChartArea1"].AxisX.Title = "Hours";
    }
    private void bind_grid1(DataTable dtgrid)
    {
        GridView1.DataSource = dtgrid;
        GridView1.DataBind();
    }
    private string strDailyuppercent()
    {
        string _id = null;
        DataTable dt = _SolarWindBrn.D_CurBranchdownPercent();

        if (dt.Rows.Count > 1)
        {
            _id = dt.Rows[1][1].ToString();
        }

        else
        {
            _id = dt.Rows[0][1].ToString();
        }
        return _id;
    }
    private bool get_NodeDownEvent(string NodeID)
    {
        try
        {
            string date = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
            _objNodedownEvent._rundate = date;
            _objNodedownEvent._NodeID = NodeID;
            _objNodedownEvent._userID = Session["USER_NAME"].ToString();
            bool retval = _objNodedownEvent._NodeDownEvent_AddByDate();
            if (retval == false)
            {
                Response.Write("<script>alert('" + _objNodedownEvent.Message + "')</script>");
            }
            else
            {
            }
            return retval;

        }

        catch (Exception ex)
        {
            _logger.LogError(ex);
            return false;
        }
        finally
        {
            sqlc.Close();
        }
    }
    protected void Node_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Nodeedit")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView2.Rows[index];
            string NodeID = row.Cells[2].Text;
            string _action = row.Cells[8].Text;
            if (_action == null)
            {
                get_NodeDownEvent(NodeID);
            }
            Response.Redirect("~/Reportchart/NodeGroupReason.aspx?EventID=" + row.Cells[1].Text + "&Channel=BRANCH"); //"&ReasonGroup=" + row.Cells[6].Text +"&ReasonType="+ row.Cells[7].Text);
        }
    }
    protected void grid1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "lnkedit")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[index];
            Response.Redirect("~/Reportchart/NodeGroupReason.aspx?EventID=" + row.Cells[2].Text + "&Channel=BRANCH"); //"&ReasonGroup=" + row.Cells[6].Text +"&ReasonType="+ row.Cells[7].Text);
        }

        if (e.CommandName == "LinkView")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[index];
            Response.Redirect("~/Reportchart/ViewNodeDownEvent.aspx?EventID=" + row.Cells[2].Text); //"&ReasonGroup=" + row.Cells[6].Text +"&ReasonType="+ row.Cells[7].Text);
        }

    }
    protected void D_Date_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectdate = D_Date.SelectedValue;
        if (selectdate == "LD")
        {
            T_Form.Text = _rptsolarwind._getStartPeriod(D_Date.SelectedValue);
            T_To.Text = _rptsolarwind._getStartPeriod(D_Date.SelectedValue);
        }
        else
        {
            _Frequency_Fundamental(D_Date.SelectedValue);
        }
        // ScriptManager.RegisterStartupScript(this, typeof(Page), "Datepicker", "setUpScript();", true);
    }
    public void _Frequency_Fundamental(string lookup)
    {
        DataTable dt = _rptsolarwind.D_Frequency_Fundamental(lookup);

        if (dt.Rows.Count == 0)
        {
            Response.Write("<script>alert('Not Yet implement!')</script>");
        }

        if (dt.Rows.Count > 0)
        {
            T_Form.Text = dt.Rows[0][3].ToString();
            T_To.Text = dt.Rows[0][4].ToString();
        }

    }
    public void _SelectNodeName()
    {
        _dropdown.bindDropDownList(D_NodeName, _SolarWindBrn.D_NodeName(D_BranchName.SelectedValue));

    }
    public void _SelectDate()
    {
        _dropdown.bindDropDownList(D_Date, _rptsolarwind.D_Select_date());
    }
    public void _SelectToday()
    {
        try
        {
            DataTable dt = _rptsolarwind.D_Select_date_today();
            D_Date.SelectedValue = dt.Rows[0]["LookupCode"].ToString();
            _Frequency_Fundamental(D_Date.SelectedValue);
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
    public void _NodeDownMunite()
    {
        _gridview._GridviewBinding(GridView1, _SolarWindBrn.D_NodeDownMinute(D_BranchName.SelectedValue, D_NodeName.SelectedValue, T_Form.Text, T_To.Text));
        Label8.Text = GridView1.Rows.Count.ToString();
    }
    protected void D_BranchName_SelectedIndexChanged(object sender, EventArgs e)
    {

        _SelectNodeName();
        string branch = D_BranchName.SelectedItem.Text;
        if (branch == "")
        {
            D_NodeName.SelectedItem.Text = "";
        }
    }
    public void _CurrentBRNNodeDown()
    {
        try
        {
            _office = Session["office"].ToString();
            _brn = Session["BRANCHCODE"].ToString();
            if (_office == "Head Office" && _brn == "003")
            {

                _gridview._GridviewBinding(GridView2, _SolarWindBrn.D_current_Branch_Down());
                Label10.Text = GridView2.Rows.Count.ToString();
               
            }
            else
            {
                _gridview._GridviewBinding(GridView2, _SolarWindBrn.D_current_Branch_Down_byBrn(_brn));
                Label10.Text = GridView2.Rows.Count.ToString();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _logger._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert(' " + _logger._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    public void _Nodedownlisting()
    {
        _gridview._GridviewBinding(GridView1, _SolarWindBrn.D_top10_BranchDown());
        Label8.Text = GridView1.Rows.Count.ToString();
    }
    protected void grid1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        _NodeDownMunite();
        GridView1.DataBind();
        Label8.Text = GridView1.Rows.Count.ToString();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //GridView1.HeaderStyle.BackColor = Color.FromName("#01559E");
        //GridView1.HeaderStyle.Font.Bold = true;
        //GridView1.HeaderStyle.ForeColor = Color.FromName("#f5f5f5");
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int values = (int)DataBinder.Eval(e.Row.DataItem, "DownMinute");
            if (values <= 60)
            {
                e.Row.Cells[6].Font.Bold = true;
                e.Row.Cells[6].ForeColor = Color.FromName("Blue");
            }
            if (values > 60)
            {
                e.Row.Cells[6].Font.Bold = true;
                e.Row.Cells[6].ForeColor = Color.FromName("Orange");
            }
            if (values >= 300)
            {
                e.Row.Cells[6].Font.Bold = true;
                e.Row.Cells[6].ForeColor = Color.FromName("Red");
            }
            string _days = (string)DataBinder.Eval(e.Row.DataItem, "GetDays");
            if (_days == "WeekendDay")
            {
                e.Row.BackColor = Color.LightYellow;
            }

            if (_days == "WorkingDay")
            {
                e.Row.BackColor = Color.LightBlue;
            }
            //string _edit = (string)DataBinder.Eval(e.Row.DataItem, "Edit");
            //{
            //    e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
            //}

        }
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //GridView2.HeaderStyle.BackColor = Color.FromName("#01559E");
        //GridView2.HeaderStyle.Font.Bold = true;
        //GridView2.HeaderStyle.ForeColor = Color.FromName("#f5f5f5");
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int values = (int)DataBinder.Eval(e.Row.DataItem, "LastDownMinute");
            if (values <= 60)
            {
                e.Row.Cells[6].Font.Bold = true;
                e.Row.Cells[6].ForeColor = Color.FromName("Blue");
            }
            if (values > 60)
            {
                e.Row.Cells[6].Font.Bold = true;
                e.Row.Cells[6].ForeColor = Color.FromName("Orange");
            }
            if (values >= 300)
            {
                e.Row.Cells[6].Font.Bold = true;
                e.Row.Cells[6].ForeColor = Color.FromName("Red");
            }
        }
    }
    protected void btnApply_Click(object sender, EventArgs e)
    {
        _NodeDownMunite();
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/index.aspx");
    }
}