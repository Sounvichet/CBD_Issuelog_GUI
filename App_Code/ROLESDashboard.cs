using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for ROLESDashboard
/// </summary>
public class ROLESDashboard
{
    SqlConnection sqlc = new SqlConnection();
    dbcon obj1 = new dbcon();
    logger _logger = new logger();
    DbClientContext _context = new DbClientContext();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    public string _userid { get;set;}
    public string _ROle { get; set; }
    public string _GroupID { get; set; }
    public string _GName { get; set; }
    public string _GDesc { get; set; }
    public string _GStatus { get; set; }
    public string _GLevel { get; set; }
    public string _GOrder { get; set; }
    public int _Holiday { get; set; }
    public string _RemoteAddr { get; set; }
    public string _msg { get; set; }
    public string _usergroup { get; set; }
    public string _jobtitle { get; set; }
    public DataTable _PR_GetROLESDDL()
    {
        DataTable dt = new DataTable();
        try
        {
            //string query = "PR_GetROLES_DDL";  for mastercambodia
            string query = "PR_GetROLESAD_DDL";
            _sqlcom._command_Stored(query, ref cmd);
            cmd.Parameters.AddWithValue("@UserID", _userid);
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
    public DataTable _GetSYSGROUPLIST()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_GetSysgroupList";
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
    public DataTable _GetSYSJOBTITLEGROUPLIST()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "Select a.JobTitleID , a.JobTitle from tbljobtitle a where a.AuthStatus = 'A'";
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
    public DataTable _GetSYSGROUPLISTBYROLE()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_GetSysgroupListByRole";
            _sqlcom._command_Stored(query, ref cmd);
            cmd.Parameters.AddWithValue("@Groupid", _ROle);
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
    public DataTable _GetjobtitlelistbyTitle()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_GetSysJobtitleListByTitle";
            _sqlcom._command_Stored(query, ref cmd);
            cmd.Parameters.AddWithValue("@jobtitleID", _jobtitle);
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
    public DataTable _GetGroupidbytitile_fundamentals()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_GetGroupidbytitile_fundamentals";
            _sqlcom._command_Stored(query, ref cmd);
            cmd.Parameters.AddWithValue("@jobtitleID", _jobtitle);
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
    public DataTable _GetROLE_FUNDAMENTAL()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_GetRoleFundamental";
            _sqlcom._command_Stored(query, ref cmd);
            cmd.Parameters.AddWithValue("@Groupid", _ROle);
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
    public DataTable _GetMainMenubyGroupid()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_GetMainMenubyGroupid";
            _sqlcom._command_Stored(query, ref cmd);
            cmd.Parameters.AddWithValue("@Groupid", _ROle);
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
    public DataTable _GetGrouprightListbyRole()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_GetGrouprightListbyRole";
            _sqlcom._command_Stored(query, ref cmd);
            cmd.Parameters.AddWithValue("@Groupid", _ROle);
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
    public DataTable _getAccountGroup_GetLevelList()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "AccountGroup_GetLevelList";
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
    public DataTable _getAccountGroup_Fundamentals()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "AccountGroup_Fundamentals";
            _sqlcom._command_Stored(query, ref cmd);
            cmd.Parameters.AddWithValue("@GroupID", _GroupID);
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

    public DataTable _getusergroupid()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "Select top 1 t.UserID from sysUserGroup t where t.groupid ='"+ _GroupID + "' ";
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

    public void _GetGroup_SavePermission(GridView gv)
    {
        foreach (GridViewRow gvr in gv.Rows)
        {
            try
            {
                string query = "AccountGroup_SavePermission";
                _sqlcom._command_Stored(query, ref cmd);
                cmd.Parameters.AddWithValue("@GroupID", _ROle);
                cmd.Parameters.AddWithValue("@RightID", gvr.Cells[2].Text);
                cmd.Parameters.AddWithValue("@AllowView", gvr.Cells[3].Controls.OfType<CheckBox>().FirstOrDefault().Checked);
                cmd.Parameters.AddWithValue("@AllowNew", gvr.Cells[4].Controls.OfType<CheckBox>().FirstOrDefault().Checked);
                cmd.Parameters.AddWithValue("@AllowEdit", gvr.Cells[5].Controls.OfType<CheckBox>().FirstOrDefault().Checked);
                cmd.Parameters.AddWithValue("@AllowDelete", gvr.Cells[6].Controls.OfType<CheckBox>().FirstOrDefault().Checked);
                cmd.Parameters.AddWithValue("@UserID", _userid);
                cmd.Parameters.Add("@retval", SqlDbType.Int, 8).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();  
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                _msg = ex.Message;
            }
            finally
            {
                sqlc.Close();
                sqlc.Dispose();
                SqlConnection.ClearPool(sqlc);
            }
        }
    }
    public bool _AccountGroup_Add()
    {
        try
        {
            _sqlcom._command_Stored("AccountGroup_Add", ref cmd);
            cmd.Parameters.AddWithValue("@GroupID", _GroupID);
            cmd.Parameters.AddWithValue("@GName", _GName);
            cmd.Parameters.AddWithValue("@GDesc", _GDesc);
            cmd.Parameters.AddWithValue("@GStatus", _GStatus);
            cmd.Parameters.AddWithValue("@GLevel", _GLevel);
            cmd.Parameters.AddWithValue("@GOrder", _GOrder);
            cmd.Parameters.AddWithValue("@Holiday", _Holiday);
            cmd.Parameters.AddWithValue("@UserID", _userid);
            cmd.Parameters.AddWithValue("@RemoteAddr", _RemoteAddr);
            cmd.Parameters.Add("@retval", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0
                                                                           // string retval = cmd.Parameters["@retval"].Value.ToString();
                                                                           //getserviceID = retval;
            if (retval != 0)
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
            _msg = ex.Message;
            return false;

        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    public bool _AccountGroup_Update()
    {
        try
        {
            _sqlcom._command_Stored("AccountGroup_Update", ref cmd);
            cmd.Parameters.AddWithValue("@GroupID", _GroupID);
            cmd.Parameters.AddWithValue("@GName", _GName);
            cmd.Parameters.AddWithValue("@GDesc", _GDesc);
            cmd.Parameters.AddWithValue("@GStatus", _GStatus);
            cmd.Parameters.AddWithValue("@GLevel", _GLevel);
            cmd.Parameters.AddWithValue("@GOrder", _GOrder);
            cmd.Parameters.AddWithValue("@Holiday", _Holiday);
            cmd.Parameters.AddWithValue("@UserID", _userid);
            cmd.Parameters.AddWithValue("@RemoteAddr", _RemoteAddr);
            cmd.Parameters.Add("@retval", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0
                                                                           // string retval = cmd.Parameters["@retval"].Value.ToString();
                                                                           //getserviceID = retval;
            if (retval != 0)
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
            _msg = ex.Message;
            return false;

        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    public bool _AccountGroup_InitPermission()
    {
        try
        {
            _sqlcom._command_Stored("AccountGroup_InitPermission", ref cmd);
            cmd.Parameters.AddWithValue("@GroupID", _GroupID);
            cmd.Parameters.Add("@retval", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0
                                                                           // string retval = cmd.Parameters["@retval"].Value.ToString();
                                                                           //getserviceID = retval;
            if (retval != 0)
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
            _msg = ex.Message;
            return false;

        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    public bool _AccountGroup_Delete()
    {
        try
        {
            _sqlcom._command_Stored("AccountGroup_Delete", ref cmd);
            cmd.Parameters.AddWithValue("@GroupID", _GroupID);
            cmd.Parameters.AddWithValue("@UserID", _userid);
            cmd.Parameters.AddWithValue("@RemoteAddr", _RemoteAddr);
            cmd.Parameters.Add("@retval", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0
                                                                           // string retval = cmd.Parameters["@retval"].Value.ToString();
                                                                           //getserviceID = retval;
            if (retval != 0)
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
            _msg = ex.Message;
            return false;

        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    public bool _sysusergroup_delete()
    {
        try
        {
           
            _sqlcom._command_Stored("PR_SYSUSERGROUP_DELETE", ref cmd);
            cmd.Parameters.AddWithValue("@UserID", _usergroup);
            cmd.Parameters.Add("@retval", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0
                                                                           // string retval = cmd.Parameters["@retval"].Value.ToString();
                                                                           //getserviceID = retval;
            if (retval != 0)
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
            _msg = ex.Message;
            return false;

        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    public void _sysusergroup_ADD(ListBox _listbox)
    {
        foreach (ListItem item in _listbox.Items)
        {
            try
            {
                string getitem = item.Value;
                _sqlcom._command_Stored("PR_SYSUSERGROUP_ADD", ref cmd);
                cmd.Parameters.AddWithValue("@UserID", _usergroup);
                cmd.Parameters.AddWithValue("@GroupID", item.Value.ToString());
                cmd.Parameters.AddWithValue("@CreatedBy", _userid);
                cmd.Parameters.AddWithValue("@CreatedFrom", _RemoteAddr);
                cmd.Parameters.Add("@retval", SqlDbType.Int, 8).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                _msg = ex.Message;
            }
            finally
            {
                sqlc.Close();
                sqlc.Dispose();
                SqlConnection.ClearPool(sqlc);
            }
        }

        
    }
    public void _SYSJOBTITLEGROUP_ADD(ListBox _listbox)
    {
        foreach (ListItem item in _listbox.Items)
        {
            try
            {
                string getitem = item.Value;
                _sqlcom._command_Stored("PR_SYSJOBTITLEGROUP_ADD", ref cmd);
                cmd.Parameters.AddWithValue("@GroupID", item.Value.ToString());
                cmd.Parameters.AddWithValue("@JobTitleid", _jobtitle);
                cmd.Parameters.Add("@retval", SqlDbType.Int, 8).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                _msg = ex.Message;
            }
            finally
            {
                sqlc.Close();
                sqlc.Dispose();
                SqlConnection.ClearPool(sqlc);
            }
        }


    }
    public bool _SYSJOBTITLEGROUP_DELETE()
    {
        try
        {

            _sqlcom._command_Stored("PR_SYSJOBTITLEGROUP_DELETE", ref cmd);
            cmd.Parameters.AddWithValue("@JobTitleid", _jobtitle);
            cmd.Parameters.Add("@retval", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0
                                                                           // string retval = cmd.Parameters["@retval"].Value.ToString();
                                                                           //getserviceID = retval;
            if (retval != 0)
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
            _msg = ex.Message;
            return false;

        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    public string _getmessage()
    {

        string currentdate = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
        string sqlquery = "select Top 1 ErrorMessage  from procedurelog order by LogDate desc";
        _sqlcom._command_Query(sqlquery, ref cmd);
        SqlDataReader dr = cmd.ExecuteReader();
        string id = null;
        if (dr.Read())
        {
            id = dr[0].ToString();
        }

        return id;
        string Test;
        Test = id;
        sqlc.Close();
        sqlc.Dispose();
        SqlConnection.ClearPool(sqlc);
    }
}