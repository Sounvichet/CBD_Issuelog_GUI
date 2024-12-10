using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;


/// <summary>
/// Summary description for PackageDashboard
/// </summary>
public class PackageDashboard
{
    SqlConnection sqlc = new SqlConnection();
    dbcon obj1 = new dbcon();
    logger _logger = new logger();
    DbClientContext _context = new DbClientContext();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    public string _PackageNameK { get; set; }
    public string _Createby { get; set; }
    public string _Createdate { get; set; }
    public string _message { get; set; }
    public string getPackageID { get; set; }
    public string _UserID { get; set; }
    public string _GETIP { get; set; }
    public decimal _PRICE { get; set; }
    public string _PACKAGEID { get; set; }
    public string _PKGSTATUS { get; set; }
    public string _RemoteAddr { get; set; }
    public int _SERPKGSCHEDULE { get; set; }
    public string _SERVICEID { get; set; }

    public DataTable _getPackagesListing()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_PACKAGESLISTING";
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
    public DataTable _getPKGFundamentals()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_GetPKGFundamentals";
            _sqlcom._command_Stored(query, ref cmd);
            cmd.Parameters.AddWithValue("@Packageid", _PACKAGEID);
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
    public DataTable _getPKGScheduleList()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_GetPKGSchedule";
            _sqlcom._command_Stored(query, ref cmd);
            cmd.Parameters.AddWithValue("@Packageid", _PACKAGEID);
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
    public bool _PACKAGES_ADD()
    {
        try
        {
            DataTable dr = _getAutoIncrementID();
            string _ID = dr.Rows[0][0].ToString();
            //string _ID = AutoIncrementID();
            int _IdLimit = 5;
            string _Packages = "PKG" + ZeroAppend("00000" + _ID, _IdLimit);
            _sqlcom._command_Stored("PR_PACKAGES_ADD", ref cmd);
            cmd.Parameters.AddWithValue("@Packageid", _Packages);
            cmd.Parameters.AddWithValue("@PackageNameK", _PackageNameK);
            cmd.Parameters.AddWithValue("@PRICE", _PRICE);
            cmd.Parameters.AddWithValue("@CreatedDate", _Createdate);
            cmd.Parameters.AddWithValue("@CreatedBy", _Createby);
            cmd.Parameters.AddWithValue("@userid", _UserID);
            cmd.Parameters.AddWithValue("@RemoteAddr", _GETIP);
            cmd.Parameters.Add("@retval", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            //int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0
            string retval = cmd.Parameters["@retval"].Value.ToString();
            getPackageID = retval;
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
    public bool _PACKAGES_UPDATE()
    {
        try
        {
            _sqlcom._command_Stored("PR_PACKAGES_UPDATE", ref cmd);
            cmd.Parameters.AddWithValue("@PackageID", _PACKAGEID);
            cmd.Parameters.AddWithValue("@Price", _PRICE);
            cmd.Parameters.AddWithValue("@PackageNameK", _PackageNameK);
            cmd.Parameters.AddWithValue("@Status", _PKGSTATUS);
            cmd.Parameters.AddWithValue("@userid", _UserID);
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
    public bool _PACKAGES_DELETE()
    {
        try
        {
            _sqlcom._command_Stored("PR_PACKAGES_DELETE", ref cmd);
            cmd.Parameters.AddWithValue("@PackageID", _PACKAGEID);
            cmd.Parameters.AddWithValue("@userid", _UserID);
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
    public bool _SERVICEPACKAGE_ADD()
    {
        try
        {
            _sqlcom._command_Stored("PR_SERVICEPACKAGE_ADD", ref cmd);
            cmd.Parameters.AddWithValue("@Schedule_NO", _SERPKGSCHEDULE);
            cmd.Parameters.AddWithValue("@Packageid", _PACKAGEID);
            cmd.Parameters.AddWithValue("@serviceid", _SERVICEID);
            cmd.Parameters.AddWithValue("@userid", _UserID);
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
    public DataTable _getPACKAGEStatus()
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
    public DataTable _getAutoIncrementID()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "SELECT ISNULL(MAX(ID),0) + 1 from [tblPackagestype]";
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