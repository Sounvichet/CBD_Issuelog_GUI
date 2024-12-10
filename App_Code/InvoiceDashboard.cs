using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for InvoiceDashboard
/// </summary>
public class InvoiceDashboard
{
    SqlConnection sqlc = new SqlConnection();
    dbcon obj1 = new dbcon();
    logger _logger = new logger();
    DbClientContext _context = new DbClientContext();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    public string _getInvoice { get; set; }
    public string _CustomerID { get; set; }
    public string _ServiceID { get; set; }
    public decimal _Outstanding { get; set; }
    public decimal _seroutstanding { get; set; }
    public decimal _ReceiveAmt { get; set; }
    public string _trn_date { get; set; }
    public string _BranchID { get; set; }
    public string _USERID { get; set; }
    public string _Remoteaddr { get; set; }
    public decimal _getending_bal { get; set; }
    public decimal _getSERPKGending_bal { get; set; }
    public string _Cashtype { get; set; }
    public string _message { get; set; }


    public DataTable _getAutoIncrementID()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "SELECT ISNULL(MAX(ID),0) + 1 from [tblCusServicePaid]";
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
    public DataTable _getPaymentListbyCust()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_GetPaymentListbycust";
            _sqlcom._command_Stored(query, ref cmd);
            cmd.Parameters.AddWithValue("@CustomerID", _CustomerID);
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
    public DataTable _GetCashTypeDDL()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_GetCashTypeDDL";
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
    public bool _GETReceiveAMTE_ADD()
    {
        try
        {
            DataTable dr = _getAutoIncrementID();
            string _ID = dr.Rows[0][0].ToString();
            //string _ID = AutoIncrementID();
            int _IdLimit = 7;
            string _InvoiceID = "INV" + ZeroAppend("0000000" + _ID, _IdLimit); 
            _sqlcom._command_Stored("PR_GETReceiveAMT", ref cmd);
            cmd.Parameters.AddWithValue("@InvoiceID", _InvoiceID);
            cmd.Parameters.AddWithValue("@CustomerID", _CustomerID);
            cmd.Parameters.AddWithValue("@ServiceID", _ServiceID);
            cmd.Parameters.AddWithValue("@Outstanding", _Outstanding);
            cmd.Parameters.AddWithValue("@ReceiveAmt", _ReceiveAmt);
            cmd.Parameters.AddWithValue("@Trn_date", _trn_date);
            cmd.Parameters.AddWithValue("@BranchiD", _BranchID);
            cmd.Parameters.AddWithValue("@UserID", _USERID);
            cmd.Parameters.AddWithValue("@RemoteAddr", _Remoteaddr);
            cmd.Parameters.AddWithValue("@CASH_TYPE", _Cashtype);
            cmd.Parameters.Add("@retval", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            //int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0
            string retval = cmd.Parameters["@retval"].Value.ToString();
            _getInvoice = retval;
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
    public bool _ENDING_BAL_UPDATE()
    {
        try
        {
            _sqlcom._command_Stored("PR_ServiceOustandingUpdate", ref cmd);
            cmd.Parameters.AddWithValue("@CustomerID", _CustomerID);
            cmd.Parameters.AddWithValue("@ending_bal", _getending_bal);
            cmd.Parameters.AddWithValue("@userid", _USERID);
            cmd.Parameters.AddWithValue("@RemoteAddr", _Remoteaddr);
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
    public bool _SERPKG_BAL_UPDATE()
    {
        try
        {
            _sqlcom._command_Stored("PR_SerPKGoutstanding_update", ref cmd);
            cmd.Parameters.AddWithValue("@CustomerID", _CustomerID);
            cmd.Parameters.AddWithValue("@service_no", _ServiceID);
            cmd.Parameters.AddWithValue("@ending_bal", _getSERPKGending_bal);
            cmd.Parameters.AddWithValue("@userid", _USERID);
            cmd.Parameters.AddWithValue("@RemoteAddr", _Remoteaddr);
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
    public static string ZeroAppend(string data, int idLimit)
    {
        return data.Substring(data.Length - idLimit);
    }
}