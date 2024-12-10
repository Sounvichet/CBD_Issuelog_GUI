using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;


/// <summary>
/// Summary description for ReportSVMigration
/// </summary>
public class ReportSVMigration
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    dbcon _oracon = new dbcon();
    public string _getUSERID { get; set; }
    public string _MSG { get; set; }
    public DataTable D_Migration_DDL(string USERID)
    {
        //------DDL = dropdownlist
        DataTable dt = new DataTable();
        try
        {

            string query = "Select a.ReportCat ,a.ReportCatName  from v_reportcategoryuser a left outer join V_sysUserAD b on b.UserID = a.userid where a.activeflag = 1  And a.ReportGroup ='DATAMIG' And b.UserAD = '" + USERID + "'  order by ReportCatName ;";
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
    public DataTable D_get_DDL_BO()
    {
        //------DDL = dropdownlist
        DataTable dt = new DataTable();
        try
        {

            string query = "PR_DDL_MIG_BO";
            _sqlcom._command_Stored(query, ref cmd);
            cmd.Parameters.AddWithValue("@userid", _getUSERID);
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
    public DataTable D_get_DDL_FE()
    {
        //------DDL = dropdownlist
        DataTable dt = new DataTable();
        try
        {

            string query = "PR_DDL_MIG_FE";
            _sqlcom._command_Stored(query, ref cmd);
            cmd.Parameters.AddWithValue("@userid", _getUSERID);
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
    public DataTable D_get_DDL_SMY()
    {
        //------DDL = dropdownlist
        DataTable dt = new DataTable();
        try
        {

            string query = "PR_DDL_MIG_SMY";
            _sqlcom._command_Stored(query, ref cmd);
            cmd.Parameters.AddWithValue("@userid", _getUSERID);
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
    public DataTable D_bind_reportcode(string _groupreport)
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "Select ReportCode , ReportName from sysReport where reportcat = '" + _groupreport + "' and status = '1' order by ReportCode";
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