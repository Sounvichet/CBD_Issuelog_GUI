using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for EntriesDashboard
/// </summary>
public class EntriesDashboard
{
    SqlConnection sqlc = new SqlConnection();
    dbcon obj1 = new dbcon();
    logger _logger = new logger();
    DbClientContext _context = new DbClientContext();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();

    public string _getTrn_ref { get; set; }
    public string _CUS_branch { get; set; }
    public string _CustomerID { get; set; }
    public string _ServiceID { get; set; }
    public decimal _ReceiveAmt { get; set; }
    public string _BranchiD { get; set; }
    public string _userID { get; set; }
    public string _message { get; set; }


    public DataTable _getAutoIDEntries()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "SELECT ISNULL(MAX(AC_ENTRY_SR_NO),0) + 1 from [ACVW_ALL_AC_ENTRIES]";
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

    public bool _CUSSERICE_ENTRIES_ADD()
    {
        try
        {
            DataTable dr = _getAutoIDEntries();
            string _ID = dr.Rows[0][0].ToString();
            //string _ID = AutoIncrementID();
            int _IdLimit = 8;
            string _trnref = _CUS_branch + "BIL" + ZeroAppend("00000000" + _ID, _IdLimit);
            _sqlcom._command_Stored("PR_CUSSERICE_ENTRIES_ADD", ref cmd);
            cmd.Parameters.AddWithValue("@TRN_REF_NO", _trnref);
            cmd.Parameters.AddWithValue("@CUS_branch", _CUS_branch);
            cmd.Parameters.AddWithValue("@CustomerID", _CustomerID);
            cmd.Parameters.AddWithValue("@ServiceID", _ServiceID);
            cmd.Parameters.AddWithValue("@ReceiveAmt", _ReceiveAmt);
            cmd.Parameters.AddWithValue("@BranchID", _BranchiD);
            cmd.Parameters.AddWithValue("@userID", _userID);
            cmd.Parameters.Add("@retval", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            //int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0
            string retval = cmd.Parameters["@retval"].Value.ToString();
            _getTrn_ref = retval;
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
    public bool _CUSSERICE_ENTRIES_PAID()
    {
        try
        {
            DataTable dr = _getAutoIDEntries();
            string _ID = dr.Rows[0][0].ToString();
            //string _ID = AutoIncrementID();
            int _IdLimit = 8;
            string _trnref = _CUS_branch + "ASP" + ZeroAppend("00000000" + _ID, _IdLimit);
            _sqlcom._command_Stored("PR_CUSSERICE_ENTRIES_PAID", ref cmd);
            cmd.Parameters.AddWithValue("@TRN_REF_NO", _trnref);
            cmd.Parameters.AddWithValue("@CUS_branch", _CUS_branch);
            cmd.Parameters.AddWithValue("@CustomerID", _CustomerID);
            cmd.Parameters.AddWithValue("@ServiceID", _ServiceID);
            cmd.Parameters.AddWithValue("@ReceiveAmt", _ReceiveAmt);
            cmd.Parameters.AddWithValue("@BranchID", _BranchiD);
            cmd.Parameters.AddWithValue("@userID", _userID);
            cmd.Parameters.Add("@retval", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            //int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0
            string retval = cmd.Parameters["@retval"].Value.ToString();
            _getTrn_ref = retval;
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
    public static string ZeroAppend(string data, int idLimit)
    {
        return data.Substring(data.Length - idLimit);
    }

}