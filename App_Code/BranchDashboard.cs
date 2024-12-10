using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;


/// <summary>
/// Summary description for BranchDashboard
/// </summary>
public class BranchDashboard
{
    SqlConnection sqlc = new SqlConnection();
    dbcon obj1 = new dbcon();
    logger _logger = new logger();
    DbClientContext _context = new DbClientContext();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    public string _branchID { get; set; }
    public string _branchName { get; set; }
    public string _branchNameK { get; set; }
    public string _BranchShort { get; set; }
    public string _UserID { get; set; }
    public string _RemoteAddr { get; set; }
    public string _message { get; set; }
    public DataTable _getBranchnum()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "SELECT ISNULL(MAX(Branchid),0) + 1 from sysBranch";
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
    public bool _BRANCH_UPDATE()
    {
        try
        {
            _sqlcom._command_Stored("PR_BRANCH_UPDATE", ref cmd);
           // cmd.Parameters.AddWithValue("@Branchid", _branchID);
            cmd.Parameters.AddWithValue("@userid", _UserID);
            cmd.Parameters.AddWithValue("@BranchName", _branchName);
            cmd.Parameters.AddWithValue("@BranchNameK", _branchNameK);
            cmd.Parameters.AddWithValue("@RemoteAddr", _RemoteAddr);
            cmd.Parameters.Add("@retval", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0
            // string retval = cmd.Parameters["@retval"].Value.ToString();
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
    public bool _BRANCH_ADD()
    {
        try
        {

            DataTable dt = new DataTable();
            string _ID = dt.Rows[0][0].ToString();
            int _gebrn_num = Convert.ToInt32(_ID);
            _sqlcom._command_Stored("PR_BRANCH_ADD", ref cmd);
             cmd.Parameters.AddWithValue("@Branchid", _branchID);
            cmd.Parameters.AddWithValue("@userid", _UserID);
            cmd.Parameters.AddWithValue("@BranchName", _branchName);
            cmd.Parameters.AddWithValue("@BranchNameK", _branchNameK);
            cmd.Parameters.AddWithValue("@BranchShort", _BranchShort);
            cmd.Parameters.AddWithValue("@BranchNumber", _gebrn_num);
            cmd.Parameters.AddWithValue("@RemoteAddr", _RemoteAddr);
            cmd.Parameters.Add("@retval", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            //int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0
            string retval = cmd.Parameters["@retval"].Value.ToString();
            _branchID = retval;
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
    public DataTable _getBrancheslisting()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "Select A.BranchID,A.BranchName,BranchShort,A.BranchNameK,A.ExtBranchID from sysBranch A ORDER BY Branchid";
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
    public DataTable _GETBRANCHFundamentals()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_GetBranchFundamentals";
            _sqlcom._command_Stored(query, ref cmd);
            cmd.Parameters.AddWithValue("@BranchID", _branchID);
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
    public DataTable _GETBRANCHDDL()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "Select BranchID , BranchName from sysBranch";
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
}