using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for ServiceDashboard
/// </summary>
public class ServiceDashboard
{
    SqlConnection sqlc = new SqlConnection();
    dbcon obj1 = new dbcon();
    logger _logger = new logger();
    DbClientContext _context = new DbClientContext();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    public string _serviceNameK { get; set; }
    public string _Createby { get; set; }
    public string _Createdate { get; set; }
    public string _message { get; set; }
    public string getserviceID { get; set; }
    public decimal _price { get; set; }
    public string _ServiceID { get; set; }
    public string _Status { get; set; }
    public string _USERiD { get; set; }
    public string _RemoteAddr { get; set; }
    public DataTable _getServicesListingbyCust()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "Select A.serviceid , A.serviceNameK ,a.Price , A.SERVICEStatus, A.CreatedDate,A.CreatedBy from [tblServicestype] A Where A.SERVICESTATUS = 'ACT' order by a.id";
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
    public DataTable _getServicesListing()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_SERVICESLISTING";
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
    public DataTable _getServicesStatus()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "Select A.CUSSTATUSID , A.CUSSTATUS from tblCusStatus A";
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
    public bool _SERVICE_ADD()
    {
        try
        {
            DataTable dr = _getAutoIncrementID();
            string _ID = dr.Rows[0][0].ToString();
            //string _ID = AutoIncrementID();
            int _IdLimit = 5;
            string _SERVICEID = "SERV" + ZeroAppend("00000" + _ID, _IdLimit);
            _sqlcom._command_Stored("PR_SERVICES_ADD", ref cmd);
            cmd.Parameters.AddWithValue("@serviceid", _SERVICEID);
            cmd.Parameters.AddWithValue("@serviceNameK", _serviceNameK);
            cmd.Parameters.AddWithValue("@price", _price);
            cmd.Parameters.AddWithValue("@CreatedDate", _Createdate);
            cmd.Parameters.AddWithValue("@CreatedBy", _Createby);
            cmd.Parameters.Add("@retval", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            //int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0
            string retval = cmd.Parameters["@retval"].Value.ToString();
            getserviceID = retval;
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
    public bool _SERVICE_UPDATE()
    {
        try
        {
            _sqlcom._command_Stored("PR_SERVICES_UPDATE", ref cmd);
            cmd.Parameters.AddWithValue("@SERVICEID", _ServiceID);
            cmd.Parameters.AddWithValue("@Price", _price);
            cmd.Parameters.AddWithValue("@serviceNameK", _serviceNameK);
            cmd.Parameters.AddWithValue("@Status", _Status);
            cmd.Parameters.AddWithValue("@userid", _USERiD);
            cmd.Parameters.AddWithValue("@RemoteAddr", _RemoteAddr);
            cmd.Parameters.Add("@retval", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0
           // string retval = cmd.Parameters["@retval"].Value.ToString();
            //getserviceID = retval;
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
    public bool _SERVICE_DELETE()
    {
        try
        {
            _sqlcom._command_Stored("PR_SERVICES_DELETE", ref cmd);
            cmd.Parameters.AddWithValue("@SERVICEID", _ServiceID);
            cmd.Parameters.AddWithValue("@userid", _USERiD);
            cmd.Parameters.AddWithValue("@RemoteAddr", _RemoteAddr);
            cmd.Parameters.Add("@retval", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0
                                                                           // string retval = cmd.Parameters["@retval"].Value.ToString();
                                                                           //getserviceID = retval;
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
    public DataTable _getAutoIncrementID()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "SELECT ISNULL(MAX(ID),0) + 1 from [tblServicestype]";
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
    public DataTable _getServiceFundamentals()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "[PR_GetServiceFundamentals]";
            _sqlcom._command_Stored(query, ref cmd);
            cmd.Parameters.AddWithValue("@ServiceID", _ServiceID);
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
    public DataTable _GetDDLSERVICEID()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "Select SERVICEID , serviceNameK from [tblServicestype] WHERE SERVICEStatus = 'ACT' ORDER BY serviceid";
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
    public static string ZeroAppend(string data, int idLimit)
    {
        return data.Substring(data.Length - idLimit);
    }
}