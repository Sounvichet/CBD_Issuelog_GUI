using System;
using TicketClassLibrary;
using System.Data.SqlClient;
using System.Data;
using System.Data.OracleClient;
using MasterReportClass;
using Oracle.ManagedDataAccess.Client;
/// <summary>
/// Summary description for FCDashboard
/// </summary>
public class FCDashboard
{
    ticketconnection obj2 = new ticketconnection();
    SqlConnection sqlc = new SqlConnection();
    dbcon obj1 = new dbcon();
    logger _logger = new logger();
    DbClientContext _context = new DbClientContext();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    Oracle.ManagedDataAccess.Client.OracleConnection _orac = new Oracle.ManagedDataAccess.Client.OracleConnection();
    masterreport_connect _con = new masterreport_connect();

    public string _FC_ID_AUTO { get; set; }
    public string _FC_U_ID_AUTO { get; set; }
    public string _FC_POSITION { get; set; }
    public string _FC_NAME { get; set; }
    public string _FC_SEX { get; set; }
    public string _FC_PHONE { get; set; }
    public string _FC_INST { get; set; }
    public string _FC_POSITION_KH { get; set; }
    public string _FC_NAME_KH { get; set; }
    public string _FC_SEX_KH { get; set; }
    public string _FC_INST_KH { get; set; }
    public string _message { get; set; }
    public Int32 _get_retval { get; set; }

    public DataTable D_get_FC_listing()
    {
        DataTable dt1 = new DataTable();
        try
        {
            _sqlcom._command_Query("Select * from [V_FC_STAFF_TBL]", ref cmd);
            dt1.Load(cmd.ExecuteReader());

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
        return dt1;
    }
    public DataTable D_get_FC_Fundamental()
    {
        DataTable dt1 = new DataTable();
        try
        {
            _sqlcom._command_Query("Select A.* from [V_FC_STAFF_TBL] A WHere a.ID_CARD = '"+ _FC_ID_AUTO + "'", ref cmd);
            dt1.Load(cmd.ExecuteReader());

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
        return dt1;
    }
    public bool _getDelete_FC_Info()
    {
        DataTable dt = new DataTable();
        try
        {
            _con.P_Connstring = "HKLDB1DBRW";
            string _getconn = _con._getconnstring();
            //string _get_sql_st = obj1.SQL_SCRIPT("css_trans_settlement");
            var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(_getconn);
            connection.Open();

            Oracle.ManagedDataAccess.Client.OracleCommand cmd1 = new Oracle.ManagedDataAccess.Client.OracleCommand("HTB_PKG_FC_INFO.PR_DELETE_FC_INFO", connection);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add("P_ID_CARD", OracleDbType.NVarchar2).Value = _FC_ID_AUTO;
            cmd1.Parameters.Add(new Oracle.ManagedDataAccess.Client.OracleParameter("P_retval",
                                       OracleDbType.Int32,
                                       ParameterDirection.Output));
            cmd1.ExecuteNonQuery();

            _get_retval = Convert.ToInt32(cmd1.Parameters["P_retval"].Value.ToString().Trim()); //This will 1 or 0

            if (_get_retval >= 1)
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
            _orac.Close();
            _orac.Dispose();
            Oracle.ManagedDataAccess.Client.OracleConnection.ClearAllPools();
        }
    }
    public bool _getupdateFC_Info()
    {
        DataTable dt = new DataTable();
        try
        {
            _con.P_Connstring = "HKLDB1DBRW";
            string _getconn = _con._getconnstring();
            //string _get_sql_st = obj1.SQL_SCRIPT("css_trans_settlement");
            var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(_getconn);
            connection.Open();

            Oracle.ManagedDataAccess.Client.OracleCommand cmd1 = new Oracle.ManagedDataAccess.Client.OracleCommand("HTB_PKG_FC_INFO.PR_UPDATE_FC_INFO", connection);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add("P_ID_CARD", OracleDbType.NVarchar2).Value = _FC_ID_AUTO;
            cmd1.Parameters.Add("S_POSITION", OracleDbType.NVarchar2).Value = _FC_POSITION;
            cmd1.Parameters.Add("S_NAME", OracleDbType.NVarchar2).Value = _FC_NAME;
            cmd1.Parameters.Add("S_PHONE", OracleDbType.NVarchar2).Value = _FC_PHONE;
            cmd1.Parameters.Add(new Oracle.ManagedDataAccess.Client.OracleParameter("P_retval",
                                       OracleDbType.Int32,
                                       ParameterDirection.Output));
            cmd1.ExecuteNonQuery();

            _get_retval = Convert.ToInt32(cmd1.Parameters["P_retval"].Value.ToString().Trim()); //This will 1 or 0

            if (_get_retval >= 1)
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
            _orac.Close();
            _orac.Dispose();
            Oracle.ManagedDataAccess.Client.OracleConnection.ClearAllPools();
        }
    }
    public void _getADDFC_Info()
    {
        try
        {
            _con.P_Connstring = "HKLDB1DBRW";
            string _getconn = _con._getconnstring();
            //string _get_sql_st = obj1.SQL_SCRIPT("css_trans_settlement");
            var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(_getconn);
            connection.Open();


            Oracle.ManagedDataAccess.Client.OracleCommand cmd1 = new Oracle.ManagedDataAccess.Client.OracleCommand("HTB_PKG_FC_INFO.PR_ADDFC_INFO", connection);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add("P_ID_CARD", OracleDbType.NVarchar2).Value = _FC_ID_AUTO;
            cmd1.Parameters.Add("S_NAME_US", OracleDbType.NVarchar2 ).Value = _FC_NAME;
            cmd1.Parameters.Add("S_SEX_US", OracleDbType.NVarchar2 ).Value =  _FC_SEX;
            cmd1.Parameters.Add("S_POSITION_US", OracleDbType.NVarchar2).Value = _FC_POSITION;
            cmd1.Parameters.Add("S_INST_US", OracleDbType.NVarchar2).Value = _FC_INST;
            cmd1.Parameters.Add("S_POSITION_KH", OracleDbType.NVarchar2 ).Value =  _FC_POSITION_KH;
            cmd1.Parameters.Add("S_NAME_KH", OracleDbType.NVarchar2 ).Value =  _FC_NAME_KH;
            cmd1.Parameters.Add("S_SEX_KH", OracleDbType.NVarchar2 ).Value =  _FC_SEX_KH;
            cmd1.Parameters.Add("S_INST_KH", OracleDbType.NVarchar2).Value =  _FC_INST_KH;
            cmd1.Parameters.Add("S_PHONE", OracleDbType.NVarchar2 ).Value = _FC_PHONE;
            cmd1.Parameters.Add(new Oracle.ManagedDataAccess.Client.OracleParameter("P_retval",
                                       OracleDbType.Int32,
                                       ParameterDirection.Output));
            //dt.Load(cmd.ExecuteReader());
            cmd1.ExecuteNonQuery();
            _get_retval = Convert.ToInt32(cmd1.Parameters["P_retval"].Value.ToString().Trim()); //This will 1 or 0
            //        P_rowcount = Convert.ToInt32(cmd.Parameters["P_rowcount"].Value);
           

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _logger._message = ex.Message;
        }
        finally
        {
            _orac.Close();
            _orac.Dispose();
            Oracle.ManagedDataAccess.Client.OracleConnection.ClearAllPools();
        }
    }
}