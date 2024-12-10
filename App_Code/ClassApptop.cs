using System.Data.SqlClient;
using System.Data;
using System;

/// <summary>
/// Summary description for ClassApptop
/// </summary>
public class ClassApptop
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();


    public DataTable getdata_mainmenu(string _userID)
    {
        DataTable dt = new DataTable();
        try
        {

            _sqlcom._command_Stored("Account_WebMenu", ref cmd); //Account_WebMenuAD
            cmd.Parameters.AddWithValue("@UserID", _userID);
            cmd.Parameters.AddWithValue("@WebMenu", ""); //@FuncType
            dt.Load(cmd.ExecuteReader());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _logger._message = ex.Message;
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