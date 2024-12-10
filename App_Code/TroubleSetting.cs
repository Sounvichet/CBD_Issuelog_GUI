using System.Data.SqlClient;
using System.Data;
using System;

/// <summary>
/// Summary description for TroubleSetting
/// </summary>
public class TroubleSetting
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    public string _messages { get; set; }

    public DataTable D_report_DDL(string _UserID)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Query("Select ReportCat ,ReportCatName  from v_reportcategoryuser where activeflag = 1  And ReportGroup='TBS' and userid = '" + _UserID + "' order by ReportCatName", ref cmd);
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
    public DataTable D_TroubleSettingDesc(string _UserID)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Stored("PR_TroubleSettingDesc", ref cmd);
            cmd.Parameters.AddWithValue("@UserID", _UserID);
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
    public DataTable D_TroubleSetting_Fundamentals(string _UserID,string _reportCat)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Stored("PR_Troublesetting_Fundamentals", ref cmd);
            cmd.Parameters.AddWithValue("@UserID", _UserID);
            cmd.Parameters.AddWithValue("@ReportCat", _reportCat);
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
    public bool update_Trouble(string _ReportCode,string _Issuename,string _Issuedesc,string _fileName,string _cotenttype, Byte _Bytes)
    {
        try
        {
            _sqlcom._command_Stored("PR_TroubleUpdate", ref cmd);
            //dat.UpdateCommand = new SqlCommand("NodeDownEvents_Update", sqlc);
            cmd.Parameters.AddWithValue("@ReportCat", _ReportCode);
            cmd.Parameters.AddWithValue("@ReportCatName", _Issuename);
            cmd.Parameters.AddWithValue("@Report_desc", _Issuedesc);
            cmd.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = _fileName;
            cmd.Parameters.AddWithValue("@type", SqlDbType.NVarChar).Value = _cotenttype;
            cmd.Parameters.AddWithValue("@Data", SqlDbType.Binary).Value = _Bytes;
            cmd.Parameters.Add("@retval", SqlDbType.Int, 8).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();

            int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0

            if (retval >= 1)
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
            _messages = ex.Message;
            return false;
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    public string ATM_issue_desc(string issuetype)
    {
        string sqlquery = "Select Report_desc from tbl_trouble_desc where Report_type = '"+ issuetype + "' ";
        _sqlcom._command_Query(sqlquery, ref cmd);
        SqlDataReader dr = cmd.ExecuteReader();
        string id = null;
        if (dr.Read())
        {
            id = dr[0].ToString();
        }

        return id;
        sqlc.Close();
        sqlc.Dispose();
        SqlConnection.ClearPool(sqlc);
    }
}