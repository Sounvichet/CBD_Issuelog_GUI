using System.Data.SqlClient;
using System.Data;
using System;
using System.Data.OracleClient;
/// <summary>
/// Summary description for ReportVISADashboard
/// </summary>
public class ReportVISADashboard
{

    SqlConnection sqlc = new SqlConnection();
    OracleConnection Orac = new OracleConnection();
    logger _logger = new logger();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    dbcon _oracon = new dbcon();


    public DataTable D_VISA_DDL(string USERID)
    {
        //------DDL = dropdownlist
        DataTable dt = new DataTable();
        try
        {

            string query = "Select a.ReportCat ,a.ReportCatName  from v_reportcategoryuser a left outer join V_sysUserAD b on b.UserID = a.userid where a.activeflag = 1  And a.ReportGroup ='PMS' and substring (a.formCode,1,4) = 'VISA' And b.UserID = '" + USERID + "'  order by ReportCatName ;";
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
    public DataTable D_VISA_DDL_UAT(string USERID)
    {
        //------DDL = dropdownlist
        DataTable dt = new DataTable();
        try
        {

            string query = "Select a.ReportCat ,a.ReportCatName  from v_reportcategoryuser a left outer join V_sysUserAD b on b.UserID = a.userid where a.activeflag = 1  And a.ReportGroup ='PMS' and substring (a.formCode,1,4) = 'VISA' and a.ReportCat in ('VISAWFL','VISAROF','VISAUCR') And b.UserID = '" + USERID + "'  order by ReportCatName ;";
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