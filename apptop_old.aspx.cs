using System;
using System.Data;
using System.Data.SqlClient;
using TicketClassLibrary;
using System.ComponentModel;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class apptop : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    // dbcon con = new dbcon();
    SqlDataAdapter sqlda;
    SqlCommand cmd = new SqlCommand();
    string submenuID;
    string breadcrumb1 = "";
    string breadcrumb2 = "";
    string _staffID = "";
    SqlConnectAndSqlCommand _sqlcmd = new SqlConnectAndSqlCommand();
    logger _log = new logger();
    ClassApptop _apptop = new ClassApptop();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_name"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        Label1.Text = Session["FamilyName"].ToString();
        Label2.Text = Session["FamilyName"].ToString();
        Label3.Text = Session["Email"].ToString();
        Label4.Text = Session["FamilyName"].ToString();
        _staffID = (Session["ID_staff"].ToString());

        if (!IsPostBack)
        {
            ShowEmpImage();
            User_image();
            ShowEmpImage_menu();
            bind_mainmenu();
        }
    }

    private void bind_mainmenu()
    {
        try
        {

            this.rptMenu.DataSource = _apptop.getdata_mainmenu(Session["user_name"].ToString());
            this.rptMenu.DataBind();
            //string menucount;
            //menucount = rptMenu.Items.Count.ToString();

            for (int i = 0; i < rptMenu.Items.Count; i++)
            {
                Label lbl1 = rptMenu.Items[i].FindControl("Label2") as Label;
                if (lbl1 != null)
                {
                    lbl1.Text = (i+1).ToString();
                }
            }
        }
        catch (Exception ex)
        {
            _log.LogError(ex);
            _log._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _log._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    public void ShowEmpImage()
    {
        try
        {

            _sqlcmd._command_Stored("P_setupImage", ref cmd);
            cmd.Parameters.AddWithValue("@EmployeeID", _staffID);
            byte[] bytes = (byte[])cmd.ExecuteScalar();
            if (bytes != null)
            {
                string strbase64 = Convert.ToBase64String(bytes);
                Image1.ImageUrl = "data:image/png;base64," + strbase64;
            }

        }
        catch (Exception ex)
        {
            _log.LogError(ex);
            _log._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _log._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    public void ShowEmpImage_menu()
    {
        try
        {
            string StaffID = (Session["ID_staff"].ToString());
            _sqlcmd._command_Stored("P_setupImage", ref cmd);
            cmd.Parameters.AddWithValue("@EmployeeID", StaffID);
            byte[] bytes = (byte[])cmd.ExecuteScalar();
            if (bytes != null)
            {
                string strbase64 = Convert.ToBase64String(bytes);
                Image3.ImageUrl = "data:image/png;base64," + strbase64;
            }

        }
        catch (Exception ex)
        {
            _log.LogError(ex);
            _log._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _log._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    public void User_image()
    {
        try
        {
            _sqlcmd._command_Stored("P_setupImage", ref cmd);
            cmd.Parameters.AddWithValue("@EmployeeID", _staffID);
            byte[] bytes = (byte[])cmd.ExecuteScalar();
            if (bytes != null)
            {
                string strbase64 = Convert.ToBase64String(bytes);
                Image2.ImageUrl = "data:image/png;base64," + strbase64;
            }

        }
        catch (Exception ex)
        {
            _log.LogError(ex);
            _log._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _log._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    protected void rptMenu_OnItemBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rptSubMenu = e.Item.FindControl("rptChildMenu") as Repeater;
                string funcType = ((System.Data.DataRowView)(e.Item.DataItem)).Row["FuncType"].ToString();
                _sqlcmd._command_Stored("Account_webmenu", ref cmd);
                cmd.Parameters.AddWithValue("@UserID", "Administrator");
                cmd.Parameters.AddWithValue("@FuncType", funcType);
                rptSubMenu.DataSource = cmd.ExecuteReader();
                rptSubMenu.DataBind();

                for (int i = 0; i < rptSubMenu.Items.Count; i++)
                {
                    Label lbl1 = rptSubMenu.Items[i].FindControl("Label3") as Label;
                    if (lbl1 != null)
                    {
                        lbl1.Text = (i+1).ToString();
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
            _log.LogError(ex);
            _log._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _log._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    protected void sign_out_Click(object sender, EventArgs e)
    {
        try
        {
            string _IP = _getlocalIP();
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["REMOTE_ADDR"];
            _sqlcmd._command_Stored("Account_Logout", ref cmd);
            cmd.Parameters.AddWithValue("@UserID", Session["user_name"].ToString());
            cmd.Parameters.AddWithValue("@RemoteAddr", _IP);
            cmd.Parameters.Add("@retval", SqlDbType.Int, 8).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0

            if (retval == 1)
            {
                ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
            }
        }
        catch (Exception ex)
        {

            // _log.LogError(ex);
            // _log._message = ex.Message;
            //  Response.Write(@"<script language='javascript'>alert('"+ _log._message + "')</script>");
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

}