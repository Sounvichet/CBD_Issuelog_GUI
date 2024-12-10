using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for ReportCustDashboard
/// </summary>
public class ReportCustDashboard
{
    SqlConnection sqlc = new SqlConnection();
    dbcon obj1 = new dbcon();
    logger _logger = new logger();
    DbClientContext _context = new DbClientContext();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    public string _userid { get; set; }
    public string _branchID { get; set; }
    public string _s_date { get; set; }
    public string _e_date { get; set; }
    public DataTable _PR_GetCUSTREPORTDDL()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_GetCustREport_DDL";
            _sqlcom._command_Stored(query, ref cmd);
            cmd.Parameters.AddWithValue("@UserID", _userid);
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
    public DataTable _GetBranchCode()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "Select BranchID , BranchName from sysBranch WHere Branchid <>'000' order by BranchID ";
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
    public DataTable _Getcustomer_service_bydate()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_rpt_customer_service_bydate";
            _sqlcom._command_Stored(query, ref cmd);
            cmd.Parameters.AddWithValue("@Branch_name",_branchID);
            cmd.Parameters.AddWithValue("@start_date",_s_date);
            cmd.Parameters.AddWithValue("@End_date", _e_date);
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
    public DataTable _GetService_trn_bydate()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_rpt_Service_trn_bydate";
            _sqlcom._command_Stored(query, ref cmd);
            cmd.Parameters.AddWithValue("@Branch_name", _branchID);
            cmd.Parameters.AddWithValue("@start_date", _s_date);
            cmd.Parameters.AddWithValue("@End_date", _e_date);
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
}