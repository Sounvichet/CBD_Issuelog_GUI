using System.Data.SqlClient;
using System.Data;
using System;

/// <summary>
/// Summary description for ReportCASHBACKDashboard
/// </summary>
public class ReportCASHBACKDashboard
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    dbcon _oracon = new dbcon();
    public DataTable D_CASH_DDL(string USERID)
    {
        //------DDL = dropdownlist
        DataTable dt = new DataTable();
        try
        {

            string query = "Select a.ReportCat ,a.ReportCatName  from v_reportcategoryuser a left outer join V_sysUserAD b on b.UserID = a.userid where a.activeflag = 1  And a.ReportGroup ='PMS' and substring (a.formCode,1,4) = 'CASH' And b.UserAD = '" + USERID + "'  order by ReportCatName ;";
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