using System;
using System.Web.UI;
using System.Data;
using BakongClearingDispute;


public partial class Payment_BAKGOBS : System.Web.UI.Page
{
    //SqlConnection sqlc = new SqlConnection();
    //SqlConnectAndSqlCommand _getsqlcon = new SqlConnectAndSqlCommand();
    //DataTable CSVTable = new DataTable();
    //WingDashBoard _wing = new WingDashBoard();
    GridViewValues _grid = new GridViewValues();
    DropDownListValues _drop = new DropDownListValues();
    BakongDashboard _bd = new BakongDashboard();
    bool isLoading = false;
    //CSSClearingClass.CSSSettlement _css = new CSSClearingClass.CSSSettlement();

    public enum MessageType { Success, Error, Info, Warning };

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        if (!IsPostBack)
        {

            string _get_current_date = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
            t_sttl_date.Text = _get_current_date;
            t_start_date.Text = _get_current_date;
            t_end_date.Text = _get_current_date;

            _bd.P_SDATE = t_start_date.Text;
            _bd.P_EDATE = t_end_date.Text;
            _grid._GridviewBinding(Grid_css_obs_settl, _bd._BAK_OBS_Settlement_bydate());

        }
    }



    //public void ReadCSVFile(string fileName)
    //{
    //    try
    //    {
    //        string connection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}\\;Extended Properties='Text;HDR=Yes;FMT=CSVDelimited'";

    //        connection = String.Format(connection, Path.GetDirectoryName(fileName));


    //        OleDbDataAdapter csvAdapter;
    //        csvAdapter = new OleDbDataAdapter("SELECT * FROM [" + Path.GetFileName(fileName) + "]", connection);

    //        if (File.Exists(fileName) && new FileInfo(fileName).Length > 0)
    //        {
    //            try
    //            {
    //                csvAdapter.Fill(CSVTable);
    //                if ((CSVTable != null) && (CSVTable.Rows.Count > 0))
    //                {
    //                    ViewState["CSVTable"] = CSVTable;
    //                    GridView _getGrid = new GridView();
    //                    _getGrid.DataSource = CSVTable;
    //                    _getGrid.DataBind();

    //                    _true._WING_Disputed_Insert(_getGrid);
    //                    // _CSS._CSS_LoopGrid(_getGrid);  //getgrid1
    //                    loading_Close();
    //                    ShowMessage("Insert records into Table Successful.", MessageType.Success);
                        
    //                }
    //                else
    //                {
    //                    String msg = "No records found";
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                throw new Exception(String.Format("Error reading Table {0}.\n{1}", Path.GetFileName(fileName), ex.Message));
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}

    private void loading()
    {
        //string script = isHide ? "$('#loading').hide(); " : "$('#loading').show(); ";
        //ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);
        ScriptManager.RegisterStartupScript(this,this.GetType(), "load", "$('#loading').show();", true);
    }
    private void loading_Close()
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "load", "$('#loading').hide();", true);
    }
    
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    protected void Update_ServerClick(object sender, EventArgs e)
    {
        
        loading_Close();
        ShowMessage("Uploaded Successful !!!", MessageType.Success);

    }
    public bool _register_BAKONG_Settlement()
    {
        _bd.P_STTL_DATE = t_sttl_date.Text;
        _bd.P_STTL_CCY = d_ccy.SelectedItem.Text;
        _bd.P_TOTAL_SETTLEMENT = t_css_settlement_bal.Text;
        // _css.P_TOTAL_FEE = t_css_settlement_fee.Text;
        _bd.P_DRCR_SETTLE = d_drcr_settle_trn.SelectedItem.Text;
       // _css.P_DRCR_FEE = d_drcr_settle_fee.SelectedItem.Text;

        bool _get_css_sttl = _bd._add_bakong_OBS_settlement();
        if (_get_css_sttl == true)
        {
            ShowMessage("Added CSS settlement is successful !", MessageType.Success);
            LinkBtnsave.Enabled = false;
        }
        else
        {
            ShowMessage("added CSS settlement is fail!" + _bd._getmessage, MessageType.Error);
        }
        return _get_css_sttl;
    }
    protected void LinkBtnsave_Click(object sender, EventArgs e)
    {
        DataTable dt1;
        string _getcount;
        _bd.P_DATE = t_sttl_date.Text;
        _bd.P_STTL_CCY = d_ccy.SelectedItem.Text;
        dt1 = _bd._BAK_OBS_pre_check();

        _getcount = dt1.Rows[0][0].ToString();

        if (_getcount == "1")
        {
            ShowMessage("OBS Settlement for Currency " + d_ccy.SelectedItem.Text + " is already existed", MessageType.Error);
        }
        else
        {
            _register_BAKONG_Settlement();
        }

        
    }

    protected void Linkapply_Click(object sender, EventArgs e)
    {
        // _css.P_STTL_CCY = d_settlement.SelectedItem.ToString();
        _bd.P_SDATE = t_start_date.Text;
        _bd.P_EDATE = t_end_date.Text;
        _grid._GridviewBinding(Grid_css_obs_settl, _bd._BAK_OBS_Settlement_bydate());
    }
}