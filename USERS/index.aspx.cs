using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.IO;
using System.Drawing;
using ClosedXML;
using ClosedXML.Excel;
using System.Data;
using System.Net;
public partial class USERS_index : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    GridViewValues _grid = new GridViewValues();
    UserDashboard _user = new UserDashboard();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
           // ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        if (!IsPostBack)
        {
            grid_load();
            Label4.Text = grid1.Rows.Count.ToString();
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


    protected void linkbtnnew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/USERS/new.aspx");
    }
    protected void Linkbtnedit_Click1(object sender, EventArgs e)
    {
        ShowMessage("PACKAGE Registration Successfully", MessageType.Success);
    }

    protected void LinkBtndel_Click(object sender, EventArgs e)
    {

    }

    protected void LinkBtnview_Click(object sender, EventArgs e)
    {

    }

    protected void Linkprint_Click(object sender, EventArgs e)
    {

    }
    protected void grid1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "lnkedit")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grid1.Rows[index];
            Response.Redirect("~/ticket/edit.aspx?ticket_no=" + row.Cells[1].Text);
        }
        else if (e.CommandName == "InkDelete")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grid1.Rows[index];
            Response.Redirect("~/ticket/delete.aspx?ticket_no=" + row.Cells[1].Text);
        }
        else if (e.CommandName == "lnkView")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grid1.Rows[index];
            Response.Redirect("~/ticket/view.aspx?ticket_no=" + row.Cells[1].Text);
        }
    }
    protected void grid1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grid1.PageIndex = e.NewPageIndex;
        this.grid_load();
        Label4.Text = grid1.Rows.Count.ToString();
    }
    protected void grid_load()
    {
        _grid._GridviewBinding(grid1, _user._getUserlisting());
        Label4.Text = grid1.Rows.Count.ToString();
    }


    protected void Grid_by_search()
    {
        _user._UserID = TxtUser.Text;
        _grid._GridviewBinding(grid1, _user._getUserbysearch());
        Label4.Text = grid1.Rows.Count.ToString();
    }

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    protected void adisacc_ServerClick1(object sender, EventArgs e)
    {
        ShowMessage("PACKAGE Registration Successfully", MessageType.Success);
    }

    protected void enaacc_ServerClick(object sender, EventArgs e)
    {
        ShowMessage("PACKAGE Registration Successfully", MessageType.Warning);
    }

    protected void clearlog_ServerClick(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grid1.Rows)
        {
            CheckBox checkbox = (CheckBox)row.FindControl("check");
            if (checkbox.Checked)
            {
                string _getUserID = Convert.ToString(row.Cells[3].Text);
                _user._UserID = _getUserID;
                _user._Remoteaddr = _getlocalIP();
                _Account_logout(_getUserID);
            }
        }
    }

    private bool _Account_logout(string USERID)
    {
        bool _logout = _user._Account_Logout();
        if (_logout == false)
        {
            ShowMessage("can not clear log please raise to admin", MessageType.Success);
        }

        else
        {
            ShowMessage("Clear log with user " + USERID + " successfully", MessageType.Success);
        }
        return _logout;
    }
    protected void refresh_pwd_ServerClick(object sender, EventArgs e)
    {

    }
    protected void userppermission_ServerClick(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grid1.Rows)
        {
            CheckBox checkbox = (CheckBox)row.FindControl("check");
            if (checkbox.Checked)
            {
                string _getUserID = Convert.ToString(row.Cells[1].Text);
                _user._UserID = _getUserID;
                Response.Redirect("~/USERS/userpermission.aspx?userid=" + _getUserID);
                //ShowMessage("Hello "+ _user._UserID + "", MessageType.Success);
            }
        }
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        Grid_by_search();
    }
}