using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
public partial class CUSTOMERS_new : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    GridViewValues _grid = new GridViewValues();
    DropDownListValues _drop = new DropDownListValues();
    CustomerDashboard _CUS = new CustomerDashboard();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    EntriesDashboard _ent = new EntriesDashboard();
    public enum MessageType { Success, Error, Info, Warning };
    string filename = "";
    string ext = "";
    string contenttype = "";
    int filesize = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        if (!this.IsPostBack)
        {
            string currentdate1 = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
            txtcreateby.Text = Session["USER_NAME"].ToString();
            _getproductcode();
            txtdob.Text = currentdate1;
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

    private bool _CUSTOMER_ADD()
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

        string currentdate = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
        _CUS._CompanyID = Session["COMPANY"].ToString();
        _CUS._BranchID = Session["BRANCHCODE"].ToString();
        _CUS._Fname = txtfname.Text;
        _CUS._Lname = txtlname.Text;
        _CUS._NameKhmer = txtkhname.Text;
        _CUS._DOB = txtdob.Text;
        _CUS._Phone = txtphone.Text;
        _CUS._Email = txtemail.Text;
        _CUS._House = txthouse.Text;
        _CUS._Street = txtstreet.Text;
        _CUS._Village = txtvillage.Text;
        _CUS._Commune = txtcommune.Text;
        _CUS._District = txtDistrict.Text;
        _CUS._Province = txtProvince.Text;
        _CUS._Country = txtCountry.Text;
        _CUS._ServicePKG = D_SERCPKG.SelectedValue;
        _CUS._CreatedBy = txtcreateby.Text;
        _CUS._CreatedDate = currentdate;
        _CUS._CreatedFrom = _getlocalIP();
        _CUS._getPrice = Convert.ToDecimal(lblPrice.Text);


        bool _Customer = _CUS._CUSTOMER_ADD();
        if (_Customer == false)
        {
            ShowMessage(_CUS._message, MessageType.Error);
        }
        else
        {
            bool _getCstService = _CUS._CUSTOMERSERVICE_ADD();
            {
                if (_getCstService == false)
                {
                    ShowMessage(_CUS._message, MessageType.Error);
                }
                else
                {
                        bool _getcust_schedule = _CUS._GetCust_schedule();
                        if (_getcust_schedule == false)
                        {
                            ShowMessage(_CUS._message, MessageType.Error);
                        }

                        else
                        {
                            bool _getPrice = _CUS._CUSPRICEUpdate();
                            if (_getPrice== false)
                            {
                                ShowMessage(_CUS._message, MessageType.Error);
                            }
                            else
                            {
                            _ent._CUS_branch = Session["BRANCHCODE"].ToString();
                            _ent._CustomerID = _CUS._customerID;
                            _ent._ServiceID = _CUS._GetService;
                            _ent._ReceiveAmt = _CUS._getPrice;
                            _ent._BranchiD = Session["BRANCHCODE"].ToString();
                            _ent._userID = Session["USER_NAME"].ToString();
                            bool _ENTRIES_ADD = _ent._CUSSERICE_ENTRIES_ADD();
                            if (_ENTRIES_ADD == false)
                            {
                                ShowMessage(_ent._message, MessageType.Error);
                            }

                            else
                            {
                                bool getcustimage = _CUSTOMERPHOTO();
                                if (getcustimage == false)
                                {
                                    ShowMessage(_CUS._message, MessageType.Error);
                                }
                                else
                                {
                                    ShowMessage("CUSTOMER Registration Successful " + _CUS._customerID.ToString() + "", MessageType.Success);
                                }
                                return getcustimage;
                            }
                            return _ENTRIES_ADD;

                        }                            
                        }
                        return _getcust_schedule;
                    }

                return _getCstService;
            }
        }
        return _Customer;
    }

    public bool _CUSTOMERPHOTO()
    {
        
        try
        {
            string retval = "";
            if (contenttype != String.Empty)
            {

                Stream fs = filcusUpload.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);                                 //reads the   binary files
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);                           //counting the file length into bytes


                _sqlcom._command_Stored("PR_CUSTOMERPHOTO_ADD", ref cmd);

                cmd.Parameters.AddWithValue("@CompanyID", _CUS._CompanyID);
                cmd.Parameters.AddWithValue("@BranchID", _CUS._BranchID);
                cmd.Parameters.AddWithValue("@CustomerID", _CUS._customerID);
                cmd.Parameters.AddWithValue("@Photo", SqlDbType.Binary).Value = bytes;
                cmd.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = filename;
                cmd.Parameters.AddWithValue("@file_size", filesize);
                cmd.Parameters.AddWithValue("@File_type", SqlDbType.NVarChar).Value = contenttype;
                cmd.Parameters.AddWithValue("@CreatedBy", _CUS._CreatedBy);
                cmd.Parameters.AddWithValue("@CreatedDate", _CUS._CreatedDate);
                cmd.Parameters.Add("@retval", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                retval = cmd.Parameters["@retval"].Value.ToString();
                //int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0
            }

            else if (contenttype == String.Empty)
            {
                ShowMessage("CUSTOMER Registration Successfully " + _CUS._customerID.ToString() + "", MessageType.Success);
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
    private void _getproductcode()
    {
        _drop.bindDropDownList(D_PRODUCT, _CUS._getProductCode());
    }
    private void _getServicePackage()
    {
        _drop.bindDropDownList(D_SERCPKG, _CUS._getGetServicePackage(D_PRODUCT.SelectedValue));
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    protected void linkbtnsave_Click(object sender, EventArgs e)
    {
        _CUSTOMER_ADD();
    }
    protected void Linkbtncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/index.aspx");
    }
    protected void D_PRODUCT_SelectedIndexChanged(object sender, EventArgs e)
    {
        _getServicePackage();
    }

    protected void Linkbtnrefresh_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }

    protected void D_SERCPKG_SelectedIndexChanged(object sender, EventArgs e)
    {
        _CUS._ServicePKG = D_SERCPKG.SelectedValue;

        DataTable dt = _CUS._getGetServicePackagePrice();
        lblPrice.Text = dt.Rows[0]["Price"].ToString();
      
    }
}