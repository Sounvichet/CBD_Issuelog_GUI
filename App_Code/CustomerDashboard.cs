using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for CustomerDashboard
/// </summary>
public class CustomerDashboard
{
    SqlConnection sqlc = new SqlConnection();
    dbcon obj1 = new dbcon();
    logger _logger = new logger();
    DbClientContext _context = new DbClientContext();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    public string _message { get; set; }
    public string _CompanyID { get; set; }
    public string _BranchID { get; set; }
    public string _CUSType { get; set; }
    public string _Fname { get; set; }
    public string _Lname { get; set; }
    public string _NameKhmer { get; set; }
    public string _DOB { get; set; }
    public string _Phone { get; set; }
    public string _Email { get; set; }
    public string _House { get; set; }
    public string _Street { get; set; }
    public string _Village { get; set; }
    public string _Commune { get; set; }
    public string _District { get; set; }
    public string _Province { get; set; }
    public string _Country { get; set; }
    public string _CreatedBy { get; set; }
    public string _CreatedDate { get; set; }
    public string _CreatedFrom { get; set; }
    public string _UpdatedBy { get; set; }
    public string _UpdatedFrom { get; set; }
    public string _customerID { get; set; }
    public string _ServicePKG { get; set; }
    public string _Service_no { get; set; }
    public string _checkerid { get; set; }
    public string _UserID { get; set; }
    public string _RemoteAddr { get; set; }
    public string _cyleid { get; set; }
    public int _schedule_no { get; set; }
    public string _Search { get; set; }
    public string _trn_date { get; set; }
    public string _GetService { get; set; }
    public string _CUSTDESC { get; set; }
    public decimal _AddPrice { get; set; }
    public decimal _getPrice { get; set; }
    public DataTable _getAutoIncrementID()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "SELECT ISNULL(MAX(CustomerID),0) + 1 from tblCustomers";
            _sqlcom._command_Query(query, ref cmd);
            dt.Load(cmd.ExecuteReader());
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
        return dt;
    }
    public DataTable _getCUSTOMERSERVICE()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "SELECT ISNULL(MAX(ID),0) + 1 from sysCust_schedule";
            _sqlcom._command_Query(query, ref cmd);
            dt.Load(cmd.ExecuteReader());
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
        return dt;
    }
    public DataTable _getCustomerlisting()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_GetCustomerListing";
            _sqlcom._command_Stored(query, ref cmd);
            cmd.Parameters.AddWithValue("@BranchID", _BranchID);
            dt.Load(cmd.ExecuteReader());
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
        return dt;
    }
    public DataTable _GetCustlistbySearch()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_GetCustlistbySearch";
            _sqlcom._command_Stored(query, ref cmd);
            cmd.Parameters.AddWithValue("@Search", _Search);
            dt.Load(cmd.ExecuteReader());
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
        return dt;
    }
    public DataTable _getCustomerlist_View()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_GetCustomerlist_View";
            _sqlcom._command_Stored(query, ref cmd);
            cmd.Parameters.AddWithValue("@Search", _Search);
            dt.Load(cmd.ExecuteReader());
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
        return dt;
    }
    public DataTable _getCustomerSchedulelist()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_GetCustomerSchedulelist";
            _sqlcom._command_Stored(query, ref cmd);
            cmd.Parameters.AddWithValue("@CustomerID", _customerID);
            dt.Load(cmd.ExecuteReader());
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
        return dt;
    }
    public DataTable _getCustServiceHIS()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_GetCustServiceHis";
            _sqlcom._command_Stored(query, ref cmd);
            cmd.Parameters.AddWithValue("@CustomerID", _customerID);
            dt.Load(cmd.ExecuteReader());
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
        return dt;
    }
    public DataTable _getCustPaymentHIS()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_GetCustPaymentHis";
            _sqlcom._command_Stored(query, ref cmd);
            cmd.Parameters.AddWithValue("@CustomerID", _customerID);
            dt.Load(cmd.ExecuteReader());
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
        return dt;
    }
    public DataTable _getCustomerScheduleCycle()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_GetCustomerScheduleCycle";
            _sqlcom._command_Stored(query, ref cmd);
            cmd.Parameters.AddWithValue("@CustomerID", _customerID);
            cmd.Parameters.AddWithValue("@Service_num", _Service_no);
            cmd.Parameters.AddWithValue("@CycleID", Convert.ToChar(_cyleid));
            dt.Load(cmd.ExecuteReader());
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
        return dt;
    }
    public DataTable _GetServiceimgScheduleCycle()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_GetServiceimgScheduleCycle";
            _sqlcom._command_Stored(query, ref cmd);
            cmd.Parameters.AddWithValue("@CustomerID", _customerID);
            cmd.Parameters.AddWithValue("@Service_num", _Service_no);
            cmd.Parameters.AddWithValue("@CycleID", _cyleid);
            dt.Load(cmd.ExecuteReader());
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
        return dt;
    }
    public DataTable __GetServicePkgbyschedule()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_GetServicePkgbyschedule";
            _sqlcom._command_Stored(query, ref cmd);
            cmd.Parameters.AddWithValue("@CustomerID", _customerID);
            cmd.Parameters.AddWithValue("@Service_num", _Service_no);
            cmd.Parameters.AddWithValue("@CycleID", _cyleid);
            cmd.Parameters.AddWithValue("@schedule_no", _schedule_no);
            dt.Load(cmd.ExecuteReader());
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
        return dt;
    }
    public DataTable _getProductCode()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_GetProductcode";
            _sqlcom._command_Stored(query, ref cmd);
            dt.Load(cmd.ExecuteReader());
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
        return dt;
    }
    public DataTable _getCusServiceCycle()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_GetCusServiceCycle";
            _sqlcom._command_Stored(query, ref cmd);
            cmd.Parameters.AddWithValue("@CustomerID", _customerID);
            cmd.Parameters.AddWithValue("@Service_num", _Service_no);
            dt.Load(cmd.ExecuteReader());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _message = ex.Message;

        }

        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;
    }
    public DataTable _getCustomerFundamentals()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_Customer_Fundamentals";
            _sqlcom._command_Stored(query, ref cmd);
            cmd.Parameters.AddWithValue("@CustomerID", _customerID);
            dt.Load(cmd.ExecuteReader());
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
        return dt;
    }
    public DataTable _getGetServicePackageDDL()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_GetServicePKG_DDL";
            _sqlcom._command_Stored(query, ref cmd);
            dt.Load(cmd.ExecuteReader());
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
        return dt;
    }
    public DataTable _PR_GetServiceIDbyCustDDL()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_GetServiceIDbyCust";
            _sqlcom._command_Stored(query, ref cmd);
            cmd.Parameters.AddWithValue("@CustomerID", _customerID);
            dt.Load(cmd.ExecuteReader());
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
        return dt;
    }
    public DataTable _getGetServicePackage(string product)
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_GetServicePackage";
            _sqlcom._command_Stored(query, ref cmd);
            cmd.Parameters.AddWithValue("@productCode", product);
            dt.Load(cmd.ExecuteReader());
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
        return dt;
    }
    public DataTable _getGetServiceDDL()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "Select A.serviceid , A.serviceNameK from [tblServicestype] A ";
            _sqlcom._command_Query(query, ref cmd);
            dt.Load(cmd.ExecuteReader());
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
        return dt;
    }
    public DataTable _getGetServicePackagePrice()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_GetServicePackagePrice";
            _sqlcom._command_Stored(query, ref cmd);
            cmd.Parameters.AddWithValue("@ServiceID", _ServicePKG);
            dt.Load(cmd.ExecuteReader());
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
        return dt;
    }
    public DataTable _getCustServicePKGOutstanding()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_GetCustServicePKGOustanding";
            _sqlcom._command_Stored(query, ref cmd);
            cmd.Parameters.AddWithValue("@Service_num", _Service_no);
            dt.Load(cmd.ExecuteReader());
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
        return dt;
    }
    public DataTable _getBranchID()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "Select A.BranchID , A.BranchNameK from sysBranch A";
            _sqlcom._command_Query(query, ref cmd);
            dt.Load(cmd.ExecuteReader());
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
        return dt;
    }
    public DataTable _getEmpUI()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "Select A.SIDCARD , A.NameKhmer from [v_empui] A Where A.JobTitleID = 'MSG-J' and BranchID = "+ _BranchID + "";
            _sqlcom._command_Query(query, ref cmd);
            dt.Load(cmd.ExecuteReader());
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
        return dt;
    }
    public DataTable _getdescbycust()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "Select * from [tbl_UserCust_Desc] where customerid = " + _customerID + "";
            _sqlcom._command_Query(query, ref cmd);
            dt.Load(cmd.ExecuteReader());
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
        return dt;
    }
    public DataTable _getmaxcustdesc()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_GetMaxcustdesc";
            _sqlcom._command_Stored(query, ref cmd);
            cmd.Parameters.AddWithValue("@customerid", _customerID);
            dt.Load(cmd.ExecuteReader());
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
        return dt;
    }
    public DataTable _Getrowschedulepending()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "Select A.* from tblCustomers_schedule A WHere A.CustomerID = '"+_customerID+"' and A.Service_num = '"+_Service_no+"' And a.ServiceStatus = 'Pending'";
            _sqlcom._command_Query(query, ref cmd);
            dt.Load(cmd.ExecuteReader());
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
        return dt;
    }
    public bool _CUSTOMER_ADD()
    {
        try
        {
            DataTable dr = _getAutoIncrementID();
            string _ID = dr.Rows[0][0].ToString();
            //string _ID = AutoIncrementID();
            int _IdLimit = 9;
            string _CUSTOMERID = ZeroAppend("000000000" + _ID, _IdLimit);
            _sqlcom._command_Stored("PR_CUSTOMER_ADD", ref cmd);
            cmd.Parameters.AddWithValue("@CompanyID", _CompanyID);
            cmd.Parameters.AddWithValue("@BranchID", _BranchID);
            cmd.Parameters.AddWithValue("@CustomerID", _CUSTOMERID);
            cmd.Parameters.AddWithValue("@Fname", _Fname);
            cmd.Parameters.AddWithValue("@Lname", _Lname);
            cmd.Parameters.AddWithValue("@NameKhmer", _NameKhmer);
            cmd.Parameters.AddWithValue("@DOB", _DOB);
            cmd.Parameters.AddWithValue("@Phone", _Phone);
            cmd.Parameters.AddWithValue("@Email", _Email);
            cmd.Parameters.AddWithValue("@House", _House);
            cmd.Parameters.AddWithValue("@Street", _Street);
            cmd.Parameters.AddWithValue("@Village", _Village);
            cmd.Parameters.AddWithValue("@Commune", _Commune);
            cmd.Parameters.AddWithValue("@District", _District);
            cmd.Parameters.AddWithValue("@Province", _Province);
            cmd.Parameters.AddWithValue("@Country", _Country);
            cmd.Parameters.AddWithValue("@ServicePKG", _ServicePKG);
            cmd.Parameters.AddWithValue("@CreatedBy", _CreatedBy);
            cmd.Parameters.AddWithValue("@CreatedDate", _CreatedDate);
            cmd.Parameters.AddWithValue("@CreatedFrom", _CreatedFrom);
            cmd.Parameters.Add("@retval", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            //int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0
            string retval = cmd.Parameters["@retval"].Value.ToString();
             _customerID = retval;
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
            _message = ex.Message;
            return false;

        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    public bool _CUSTOMER_EDIT()
    {
        try
        {
            _sqlcom._command_Stored("PR_CUSTOMER_EDIT", ref cmd);
            cmd.Parameters.AddWithValue("@customerid", _customerID);
            cmd.Parameters.AddWithValue("@NameKhmer", _NameKhmer);
            cmd.Parameters.AddWithValue("@Fname", _Fname);
            cmd.Parameters.AddWithValue("@Lname", _Lname);
            cmd.Parameters.AddWithValue("@DOB", _DOB);
            cmd.Parameters.AddWithValue("@Phone", _Phone);
            cmd.Parameters.AddWithValue("@Email", _Email);
            cmd.Parameters.AddWithValue("@House", _House);
            cmd.Parameters.AddWithValue("@Street", _Street);
            cmd.Parameters.AddWithValue("@Village", _Village);
            cmd.Parameters.AddWithValue("@Commune", _Commune);
            cmd.Parameters.AddWithValue("@District", _District);
            cmd.Parameters.AddWithValue("@Province", _Province);
            cmd.Parameters.AddWithValue("@UpdatedBy", _UpdatedBy);
            cmd.Parameters.AddWithValue("@UpdatedFrom", _UpdatedFrom);
            cmd.Parameters.Add("@retval", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0
            //string retval = cmd.Parameters["@retval"].Value.ToString();
            if (retval == 1)
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
            _message = ex.Message;
            return false;

        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    public bool _USERCUSTDESC_ADD()
    {
        try
        {
            _sqlcom._command_Stored("PR_USERCUSTDESC_ADD", ref cmd);
            cmd.Parameters.AddWithValue("@customerid", _customerID);
            cmd.Parameters.AddWithValue("@Desc", _CUSTDESC);
            cmd.Parameters.AddWithValue("@CreatedBy", _CreatedBy);
            cmd.Parameters.AddWithValue("@CreatedFrom", _CreatedFrom);
            cmd.Parameters.Add("@retval", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0
            //string retval = cmd.Parameters["@retval"].Value.ToString();
            if (retval == 1)
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
            _message = ex.Message;
            return false;

        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    public bool _CUSTOMERSERVICE_ADD()
    {
        try
        {
            DataTable dr = _getCUSTOMERSERVICE();
            string _ID = dr.Rows[0][0].ToString();
            //string _ID = AutoIncrementID();
            int _IdLimit = 8;
            string _CUSTOMERSERVICE ="S"+ ZeroAppend("00000000" + _ID, _IdLimit);
            _sqlcom._command_Stored("PR_CUSTOMERSERVICE_ADD", ref cmd);
            cmd.Parameters.AddWithValue("@Service_num", _CUSTOMERSERVICE);
            cmd.Parameters.AddWithValue("@BranchID", _BranchID);
            cmd.Parameters.AddWithValue("@CustomerID", _customerID);
            cmd.Parameters.AddWithValue("@ServicePKG", _ServicePKG);
            cmd.Parameters.AddWithValue("@CreatedBy", _CreatedBy);
            cmd.Parameters.AddWithValue("@CreatedDate", _CreatedDate);
            cmd.Parameters.AddWithValue("@CreatedFrom", _CreatedFrom);
            cmd.Parameters.AddWithValue("@Outstanding", _getPrice);
            cmd.Parameters.Add("@retval", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            //int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0
            string retval = cmd.Parameters["@retval"].Value.ToString();
            _GetService = retval;
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
            _message = ex.Message;
            return false;

        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    public bool _GetCust_schedule()
    {
        try
        {
            _sqlcom._command_Stored("PR_Customer_Schedule", ref cmd);
            cmd.Parameters.AddWithValue("@CustomerID", _customerID);
            cmd.Parameters.AddWithValue("@CreatedBy", _CreatedBy);
            cmd.Parameters.Add("@retval", SqlDbType.NVarChar, 10).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            //int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0
            string retval = cmd.Parameters["@retval"].Value.ToString();
            //_customerID = retval;
            if (retval  !="")
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
            _message = ex.Message;
            return false;

        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    public bool _customer_scheduleUpdate()
    {
        try
        {
            _sqlcom._command_Stored("PR_CustomerScheduleUpdate", ref cmd);
            cmd.Parameters.AddWithValue("@CustomerID", _customerID);
            cmd.Parameters.AddWithValue("@Service_num", _Service_no);
            cmd.Parameters.AddWithValue("@CycleID", _cyleid);
            cmd.Parameters.AddWithValue("@Schedule_NO", _schedule_no);
            cmd.Parameters.AddWithValue("@userid", _UserID);
            cmd.Parameters.AddWithValue("@checkerID", _checkerid);
            cmd.Parameters.AddWithValue("@branchID", _BranchID);
            cmd.Parameters.AddWithValue("@trn_date", _trn_date);
            cmd.Parameters.AddWithValue("@RemoteAddr", _RemoteAddr);
            cmd.Parameters.Add("@retval", SqlDbType.NVarChar, 10).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0
            //string retval = cmd.Parameters["@retval"].Value.ToString();
            //_customerID = retval;
            if (retval == 1)
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
            _message = ex.Message;
            return false;

        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    public bool _CusServiceUpdate()
    {
        try
        {
            _sqlcom._command_Stored("PR_CustServiceStatusUpdate", ref cmd);
            cmd.Parameters.AddWithValue("@CustomerID", _customerID);
            cmd.Parameters.AddWithValue("@service_num", _Service_no);
            cmd.Parameters.AddWithValue("@userid", _UserID);
            cmd.Parameters.AddWithValue("@RemoteAddr", _RemoteAddr);
            cmd.Parameters.Add("@retval", SqlDbType.NVarChar, 10).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0
            //string retval = cmd.Parameters["@retval"].Value.ToString();
            //_customerID = retval;
            if (retval == 1)
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
            _message = ex.Message;
            return false;

        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    public bool _CUSPRICEUpdate()
    {
        try
        {
            _sqlcom._command_Stored("PR_CUSPRICE_UPDATE", ref cmd);
            cmd.Parameters.AddWithValue("@customerID", _customerID);
            cmd.Parameters.Add("@retval", SqlDbType.NVarChar, 10).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0
            //string retval = cmd.Parameters["@retval"].Value.ToString();
            //_customerID = retval;
            if (retval == 1)
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
            _message = ex.Message;
            return false;

        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    public bool _CusServicePrice_UPDATE()
    {
        try
        {
            _sqlcom._command_Stored("PR_CusServicePrice_UPDATE", ref cmd);
            cmd.Parameters.AddWithValue("@customerID", _customerID);
            cmd.Parameters.AddWithValue("@AddPrice", _AddPrice);
            cmd.Parameters.AddWithValue("@PKGService", _ServicePKG);
            cmd.Parameters.AddWithValue("@Userid", _UserID);
            cmd.Parameters.AddWithValue("@updatedate", _trn_date);
            cmd.Parameters.AddWithValue("@remoteaddr", _RemoteAddr);
            cmd.Parameters.Add("@retval", SqlDbType.NVarChar, 10).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0
            //string retval = cmd.Parameters["@retval"].Value.ToString();
            //_customerID = retval;
            if (retval == 1)
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
            _message = ex.Message;
            return false;

        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    public bool _Cust_AddMoreSchedule()
    {
        try
        {
            _sqlcom._command_Stored("PR_Cust_AddMoreSchedule", ref cmd);
            cmd.Parameters.AddWithValue("@customerID", _customerID);
            cmd.Parameters.AddWithValue("@Service_num", _Service_no);
            cmd.Parameters.AddWithValue("@CreatedBy", _UserID);
            cmd.Parameters.Add("@retval", SqlDbType.NVarChar, 10).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0
            //string retval = cmd.Parameters["@retval"].Value.ToString();
            //_customerID = retval;
            if (retval == 1)
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
            _message = ex.Message;
            return false;

        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    public bool _CUSTPHO_DELETE()
    {
        try
        {
            _sqlcom._command_Stored("PR_CUSTPHOTO_DELETE", ref cmd);
            cmd.Parameters.AddWithValue("@CustomerID", _customerID);
            cmd.Parameters.Add("@retval", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0
            //string retval = cmd.Parameters["@retval"].Value.ToString();
            if (retval == 1)
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
            _message = ex.Message;
            return false;

        }
        finally
        {
            //sqlc.Close();
            //sqlc.Dispose();
            //SqlConnection.ClearPool(sqlc);
        }
    }
    public static string ZeroAppend(string data, int idLimit)
    {
        return data.Substring(data.Length - idLimit);
    }
    
}