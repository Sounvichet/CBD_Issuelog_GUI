using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for get_sql_string
/// </summary>
public class get_sql_string
{
    public string Sqlcon()
    {
        String sqlstr = "";
        System.Data.DataSet ds = new System.Data.DataSet();
        ds.ReadXml(HttpContext.Current.Server.MapPath("~/sql_string.xml"));
        System.Data.DataTable dt = ds.Tables[0];
        foreach (System.Data.DataRow dr in dt.Rows)
        {
            sqlstr = dr["connectionSQL"].ToString();
        }
        return sqlstr;
    }
}