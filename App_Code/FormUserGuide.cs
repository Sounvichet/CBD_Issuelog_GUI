using System.Data.SqlClient;
using System.Data;
using System;

/// <summary>
/// Summary description for FormUserGuide
/// </summary>
public class FormUserGuide
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    public string _messages { get; set; }

    public DataTable D_grid_formuserguide()
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Stored("P_Form_reqeust", ref cmd);
            dt.Load(cmd.ExecuteReader());

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _messages = ex.Message;
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;
    }
    public DataTable D_grid_formuserguidebyservice(string _Indicator , string _service)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Stored("P_upload_form_by_service", ref cmd);
            cmd.Parameters.AddWithValue("@indicator", _Indicator);
            cmd.Parameters.AddWithValue("@channel", _service);
            dt.Load(cmd.ExecuteReader());

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _messages = ex.Message;
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;
    }
    public DataTable D_bind_indicatorbyService(string _indicator)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Stored("P_bind_service_by_indicator", ref cmd);
            cmd.Parameters.AddWithValue("@Indicator", _indicator);
            dt.Load(cmd.ExecuteReader());

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _messages = ex.Message;
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