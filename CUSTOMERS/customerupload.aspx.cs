using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Drawing;
public partial class CUSTOMERS_customerupload : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    GridViewValues _grid = new GridViewValues();
    CustomerDashboard _cus = new CustomerDashboard();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    DropDownListValues _drop = new DropDownListValues();
    public enum MessageType { Success, Error, Info, Warning };
    string filename = "";
    string ext = "";
    string contenttype = "";
    int filesize = 0;
    string retval = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            string _getcustomerID = Request.QueryString["CUSTOMERID"].ToString();
            _GetCustFundamentals();
            _getServiceIDbyCust();
            _getCusServiceCycle();
            _getCyclscheduleID();
            _getservicePkgshcedule();
            _getCustSchedulelist();
            
            //   _GetCustFundamentals();
            //   grid_load();
            //   Label4.Text = grid1.Rows.Count.ToString();
        }
    }
    private void _GetCustFundamentals()
    {
        _cus._customerID = Request.QueryString["CUSTOMERID"].ToString();
        try
        {
            DataTable dt = _cus._getCustomerFundamentals();
            lblcustomerID.Text = dt.Rows[0]["CustomerID"].ToString();
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
    private void _getServiceIDbyCust()
    {
        _cus._customerID = Request.QueryString["CUSTOMERID"].ToString();
        _drop.bindDropDownList_String(d_serviceID, _cus._PR_GetServiceIDbyCustDDL());
    }
    private void _getCustSchedulelist()
    {
        _cus._customerID = Request.QueryString["CUSTOMERID"].ToString();
        _grid._GridviewBinding(gridschedule, _cus._getCustomerSchedulelist());
    }
    private void _getCyclscheduleID()

    {
        _cus._customerID = Request.QueryString["CUSTOMERID"].ToString();
        _cus._Service_no = d_serviceID.SelectedValue;
        _cus._cyleid = lblcycle.Text;
        _drop.bindDropDownList_String(d_cyschedule, _cus._GetServiceimgScheduleCycle());
    }
    private void _getCusServiceCycle()
    {
        try
        {
            _cus._customerID = Request.QueryString["CUSTOMERID"].ToString();
            _cus._Service_no = d_serviceID.SelectedValue;
            DataTable dt = _cus._getCusServiceCycle();

            lblcycle.Text = dt.Rows[0]["cycleID"].ToString();
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
    private void _getservicePkgshcedule()
    {
        try
        {
            _cus._customerID = Request.QueryString["CUSTOMERID"].ToString();
            _cus._Service_no = d_serviceID.SelectedValue;
            _cus._cyleid = lblcycle.Text;
            _cus._schedule_no = Convert.ToInt32(d_cyschedule.SelectedValue);

            _getServicePKGDDL();
            _getServiceDDL();
            DataTable dt = _cus.__GetServicePkgbyschedule();
            D_ServicePKG.SelectedValue  = dt.Rows[0]["PackageID"].ToString();
            d_product.SelectedValue = dt.Rows[0]["ServiceID"].ToString();

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
    private void _getServicePKGDDL ()

    {
        _drop.bindDropDownList_String(D_ServicePKG, _cus._getGetServicePackageDDL());
    }
    private void _getServiceDDL()
    {
        _drop.bindDropDownList_String(d_product, _cus._getGetServiceDDL());
    }

    //private void _getBranchID()
    //{
    //    _drop.bindDropDownList_String(D_branch, _cus._getBranchID());
    //}
    //private void _getEmpUI()
    //{
    //    _cus._BranchID = D_branch.SelectedValue;
    //    _drop.bindDropDownList_String(D_employee, _cus._getEmpUI());
    //}
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

    public bool _CUSTOMERPHOTO()
    {

        try
        {
            filename = Path.GetFileName(filcusUpload.PostedFile.FileName);
            ext = Path.GetExtension(filename);
            contenttype = String.Empty;
            switch (ext)
            {
                case ".jpg":
                    contenttype = "image/jpg";
                    break;
                case ".png":
                    contenttype = "image/png";
                    break;
            }
            filesize = filcusUpload.PostedFile.ContentLength;

            if (contenttype != String.Empty)
            {

                Stream fs = filcusUpload.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);                                 //reads the   binary files
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);                           //counting the file length into bytes


                _sqlcom._command_Stored("PR_CustServiceimageupload", ref cmd);

                cmd.Parameters.AddWithValue("@CustomerID", lblcustomerID.Text);
                cmd.Parameters.AddWithValue("@service_num", d_serviceID.SelectedValue);
                cmd.Parameters.AddWithValue("@CycleID", Convert.ToInt32(lblcycle.Text));
                cmd.Parameters.AddWithValue("@Schedule_NO", Convert.ToInt32(d_cyschedule.SelectedValue));
                cmd.Parameters.AddWithValue("@PackageID", D_ServicePKG.SelectedValue);
                cmd.Parameters.AddWithValue("@ServiceID ", d_product.SelectedValue);
                cmd.Parameters.AddWithValue("@ServiceStatus", "Completed");
                cmd.Parameters.AddWithValue("@Photo", SqlDbType.Binary).Value = bytes;
                cmd.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = filename;
                cmd.Parameters.AddWithValue("@file_size", filesize);
                cmd.Parameters.AddWithValue("@File_type", SqlDbType.NVarChar).Value = contenttype;
                cmd.Parameters.AddWithValue("@branchID", Session["BRANCHCODE"].ToString());
                cmd.Parameters.AddWithValue("@userid", Session["USER_NAME"].ToString());
                cmd.Parameters.AddWithValue("@RemoteAddr", _getlocalIP());

                cmd.Parameters.Add("@retval", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                retval = cmd.Parameters["@retval"].Value.ToString();
                //int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0
            }

            else if (contenttype == String.Empty)
            {
                ShowMessage("there is image to insert " + retval + "", MessageType.Warning);
            }
            if (retval != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _logger._message = ex.Message;
            return false;
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
    protected void d_cyschedule_SelectedIndexChanged(object sender, EventArgs e)
    {
        _getservicePkgshcedule();
    }

    protected void LinkAction_Click(object sender, EventArgs e)
    {
        bool getcutserviceimage = _CUSTOMERPHOTO();
        if (getcutserviceimage == true)
        {
            ShowMessage("CUSTOMER Registration Successfully " + retval + "", MessageType.Success);
        }
        else
        {
            ShowMessage("PLease try again ." + retval + "", MessageType.Error);
        }
    }


    //protected void D_branch_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    _getEmpUI();
    //}

    protected void gridschedule_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        for (int i = 0; i < e.Row.Cells.Count; i++)
        {
            e.Row.Cells[i].Attributes.Add("style", "white-space: nowrap;");
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string status = (string)DataBinder.Eval(e.Row.DataItem, "Status");
            if (status == "Completed")
            {
                e.Row.BackColor = Color.FromName("#669DF2");
            }
            if (status == "Pending")
            {
                e.Row.BackColor = Color.FromName("#E3EF8A");
            }
        }
    }

    protected void d_serviceID_SelectedIndexChanged(object sender, EventArgs e)
    {
        _getCusServiceCycle();
        _getCyclscheduleID();
        _getservicePkgshcedule();
    }

    protected void Linkbtnrefresh_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }
}