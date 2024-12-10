using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI;
using System.IO;
using System.Drawing;
using System.Data;
using System.Net;

public partial class ROLES_PERMISSION : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    GridViewValues _grid = new GridViewValues();
    ROLESDashboard _role = new ROLESDashboard();
    ClassApptop _apptop = new ClassApptop();
    SqlConnectAndSqlCommand _sqlcmd = new SqlConnectAndSqlCommand();    
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }

        if (!IsPostBack)
        {
             string _getroleid = Request.QueryString["ROLEID"].ToString();
            txtgroupid.Text = _getroleid;
            _getrolefundamental();
            bind_mainmenu();
            _getGetGrouprightListbyRole();
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
    private void _getrolefundamental()
    {
        _role._ROle = txtgroupid.Text;
        DataTable dt = _role._GetROLE_FUNDAMENTAL();
        txtgroupname.Text = dt.Rows[0]["Gname"].ToString();
    }
    private void _getGetGrouprightListbyRole()
    {
        _role._ROle = txtgroupid.Text;
        _grid._GridviewBinding(gridpermission, _role._GetGrouprightListbyRole());
    }
    private void _SaveRolePermission()
    {
        try
        {
            _role._ROle = txtgroupid.Text;
            _role._userid = Session["USER_NAME"].ToString();
            _role._GetGroup_SavePermission(gridpermission);
            
        }
        catch (Exception ex)
        {
            
            ShowMessage(""+_role._msg+"", MessageType.Error);
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
            ShowMessage("Group Permission Save Successful..!", MessageType.Success);
        }
    }
    protected void linkbtnsave_Click(object sender, EventArgs e)
    {
        _SaveRolePermission();
    }
    protected void Linkbtncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("GNRROLE.aspx");
    }
    private void bind_mainmenu()
    {
        try
        {
            _role._ROle = txtgroupid.Text;
            this.rptMenu.DataSource = _role._GetMainMenubyGroupid();
            //this.rptMenu.DataSource = _apptop.getdata_mainmenu(Session["user_name"].ToString());
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
            _logger.LogError(ex);
            _logger._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _logger._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    protected void rptMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            string get_groupid = _get_reference(Request.QueryString["ROLEID"].ToString());


            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rptSubMenu = e.Item.FindControl("rptChildMenu") as Repeater;
                string funcType = ((System.Data.DataRowView)(e.Item.DataItem)).Row["FuncType"].ToString();
                _sqlcmd._command_Stored("Account_webmenu", ref cmd);
                cmd.Parameters.AddWithValue("@UserID", get_groupid);
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
            _logger.LogError(ex);
            _logger._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _logger._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }

    public string _get_reference(string P_groupid)

    {

        string _id = null;
        _role._GroupID = P_groupid;
        DataTable dt = _role._getusergroupid();

        _id = dt.Rows[0][0].ToString();

        return _id;

    }

    protected void gridpermission_DataBound(object sender, EventArgs e)
    {
        for (int rowIndex = gridpermission.Rows.Count - 2; rowIndex >= 0; rowIndex--)
        {
            GridViewRow row = gridpermission.Rows[rowIndex];
            GridViewRow previousRow = gridpermission.Rows[rowIndex + 1];

            if (row.Cells[0].Text == previousRow.Cells[0].Text)
            {
                row.Cells[0].RowSpan = previousRow.Cells[0].RowSpan < 2 ? 2 :
                                       previousRow.Cells[0].RowSpan + 1;
                previousRow.Cells[0].Visible = false;
            }
        }
    }
}