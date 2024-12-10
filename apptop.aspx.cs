using System;
using System.Data;
using System.Data.SqlClient;
using TicketClassLibrary;
using System.ComponentModel;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserADClass;
using MasterConnection;
using MasterDebugLog; 

public partial class Testapptop : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    // dbcon con = new dbcon();
    SqlDataAdapter sqlda;
    SqlCommand cmd = new SqlCommand();
    string submenuID;
    string breadcrumb1 = "";
    string breadcrumb2 = "";
    string _staffID = "";
    
    //logger _log = new logger();
    //ClassApptop _apptop = new ClassApptop();
    //UserDashboard _user = new UserDashboard();


    UserADClass.EmployeeDashboard _emp = new UserADClass.EmployeeDashboard();
    UserADClass.UserADDashboard _userad = new UserADClass.UserADDashboard();
    ATMSqlConnection _sqlcmd = new ATMSqlConnection();
    DebugLog _log = new DebugLog();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_name"] == null)
        {
            _account_logout();

        }
        
        if (!IsPostBack)
        {

            L_USER.InnerText = Session["FamilyName"].ToString();
            _staffID = (Session["USERID"].ToString());
            bind_mainmenu();
            lblyear.InnerText = DateTime.Now.Year.ToString();
            Getempimage();
        }
    }


    public void Getempimage()
    {

        _emp._staffID = (Session["USERID"].ToString());
        _emp.ShowEmpImage(image1);

    }
    private void bind_mainmenu()
    {
        try
        {
            _emp._staffID = (Session["USER_NAME"].ToString()); 
            this.rptMenu.DataSource = _emp.getdata_mainmenu();
            this.rptMenu.DataBind();
            //string menucount;
            //menucount = rptMenu.Items.Count.ToString();

            for (int i = 0; i < rptMenu.Items.Count; i++)
            {
                Label lbl1 = rptMenu.Items[i].FindControl("l_values1") as Label;
                if (lbl1 != null)
                {
                    lbl1.Text = (i + 1).ToString();
                }
            }
        }
        catch (Exception ex)
        {
            _log.logfile(ex);
            _log._messageError = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _log._messageError + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    public string _getlocalIP()
    {
        IPHostEntry host;
        string localID = "?";
        host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily.ToString() == "InterNetwork")
            {
                localID = ip.ToString();
            }
        }

        return localID;
    }
    private bool _account_logout()
    {
        if (_userad._UserID == null)
        {
            Response.Redirect("default.aspx");
            return true; 
        }
        _userad._UserID = Session["user_name"].ToString();
        _userad._Remoteaddr = _getlocalIP();
        bool getlog_out = _userad._Account_Logout();
        if (getlog_out == false)
        {
            Response.Write(@"<script language='javascript'>alert('Please contact admin for logout !!')</script>");
        }

        else
        {
            
        }
        return getlog_out;
    }
    protected void Logout_onclick(object sender, EventArgs e)
    {
        _account_logout();
    }
    protected void rptMenu_OnItemBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            string getuserid = Session["USER_NAME"].ToString();
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rptSubMenu = e.Item.FindControl("rptChildMenu") as Repeater;
                string funcType = ((System.Data.DataRowView)(e.Item.DataItem)).Row["FuncType"].ToString();

                _sqlcmd._command_Stored("Account_WebMenu", ref cmd);
                cmd.Parameters.AddWithValue("@UserID", getuserid);
                cmd.Parameters.AddWithValue("@WebMenu", funcType);
                rptSubMenu.DataSource = cmd.ExecuteReader();
                rptSubMenu.DataBind();

                for (int i = 0; i < rptSubMenu.Items.Count; i++)
                {
                    Label lbl1 = rptSubMenu.Items[i].FindControl("l_values2") as Label;
                    if (lbl1 != null)
                    {
                        lbl1.Text = (i + 1).ToString();
                    }
                }
                //foreach (RepeaterItem item in rptSubMenu.Items)
                //{
                //    var lbl = (Label)item.FindControl("SubLabelID");
                //    var lblCount = (Label)item.FindControl("SubLabelCount");
                //    if (lbl != null)
                //    {
                //        string lblvalue = lbl.Text;
                //        if (lblvalue == "12" || lblvalue == "1")
                //        {
                //            // Label4.Text = "";
                //            // BindSubmenuID(lblvalue);
                //            Countgridticket();
                //            lblCount.Text = grid1.Rows.Count.ToString();


                //        }
                //        if (lblvalue == "19" || lblvalue == "3")
                //        {
                //            Countgridmission();
                //            lblCount.Text = grid2.Rows.Count.ToString();

                //        }
                //        if (lblvalue == "28" || lblvalue == "29")
                //        {
                //            Countgridcomplaint();
                //            lblCount.Text = grid3.Rows.Count.ToString();

                //        }
                //        if (lblvalue == "1048")
                //        {
                //            lblCount.Text = "Chart";

                //        }
                //        if (lblvalue == "1049" || lblvalue == "1052")
                //        {
                //            lblCount.Text = "Chart";

                //        }
                //        if (lblvalue == "1050")
                //        {
                //            lblCount.Text = "Chart";

                //        }
                //        if (lblvalue == "1051")
                //        {
                //            lblCount.Text = "Chart";

                //        }
                //        if (lblvalue == "1035")
                //        {
                //            lblCount.Text = "Card";

                //        }
                //        if (lblvalue == "1036")
                //        {
                //            lblCount.Text = "Card";

                //        }
                //        if (lblvalue == "1041")
                //        {
                //            lblCount.Text = "Card";

                //        }
                //        if (lblvalue == "1046")
                //        {
                //            lblCount.Text = "Card";

                //        }
                //        if (lblvalue == "8")
                //        {
                //            lblCount.Text = "Report";

                //        }
                //        if (lblvalue == "9")
                //        {
                //            lblCount.Text = "Report";

                //        }
                //        if (lblvalue == "1047")
                //        {
                //            lblCount.Text = "Report";

                //        }
                //        if (lblvalue == "11")
                //        {
                //            lblCount.Text = "Guide";

                //        }
                //    }
                //}
            }
        }
        catch (Exception ex)
        {
            _log.logfile(ex);
            _log._messageError = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _log._messageError + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
}