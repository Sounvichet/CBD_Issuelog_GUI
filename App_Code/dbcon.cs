using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for dbcon
/// </summary>
public class dbcon
{
   public static SqlConnection con = null;
    public SqlConnection Sqlc
    {
        get { return Sqlc; }
        set { Sqlc = value; }
    }
    public DataTable getDatatable()
    {
        DataTable dt = new DataTable();
        try
        {

        }
        catch (Exception ex)
        {

        }
        finally
        {

        }
        return dt;
    }
    public string Sqlcon()
    {
        String sqlstr = "";
        System.Data.DataSet ds = new System.Data.DataSet();
        ds.ReadXml(HttpContext.Current.Server.MapPath("~/sqlconnect.xml"));
        System.Data.DataTable dt = ds.Tables[0];
        foreach (System.Data.DataRow dr in dt.Rows)
        {
            sqlstr = dr["connectionSQL"].ToString();
        }
        return sqlstr;
    }
    public string oracleconfe() 
    {
        String sqlstr = "";
        System.Data.DataSet ds = new System.Data.DataSet();
        ds.ReadXml(HttpContext.Current.Server.MapPath("~/oracleconnect.xml"));
        System.Data.DataTable dt = ds.Tables[0];
        foreach (System.Data.DataRow dr in dt.Rows)
        {
            sqlstr = dr["connectionoracle_FEDB"].ToString();
        }
        return sqlstr;
    }
    public string oracleconbo()
    {
        String sqlstr = "";
        System.Data.DataSet ds = new System.Data.DataSet();
        ds.ReadXml(HttpContext.Current.Server.MapPath("~/oracleconnect.xml"));
        System.Data.DataTable dt = ds.Tables[0];
        foreach (System.Data.DataRow dr in dt.Rows)
        {
            sqlstr = dr["conectionoracle_bodb"].ToString();
        }
        return sqlstr;
    }
    public string oracleconUAT5()
    {
        String sqlstr = "";
        System.Data.DataSet ds = new System.Data.DataSet();
        ds.ReadXml(HttpContext.Current.Server.MapPath("~/oracleconnect.xml"));
        System.Data.DataTable dt = ds.Tables[0];
        foreach (System.Data.DataRow dr in dt.Rows)
        {
            sqlstr = dr["connectionOracle_CBSUAT5"].ToString();
        }
        return sqlstr;
    }
    public string oracleconUAT1()
    {
        String sqlstr = "";
        System.Data.DataSet ds = new System.Data.DataSet();
        ds.ReadXml(HttpContext.Current.Server.MapPath("~/oracleconnect.xml"));
        System.Data.DataTable dt = ds.Tables[0];
        foreach (System.Data.DataRow dr in dt.Rows)
        {
            sqlstr = dr["connectionOracle_CBSUAT1"].ToString();
        }
        return sqlstr;
    }
    public string oracleconcbs()
    {
        String sqlstr = "";
        System.Data.DataSet ds = new System.Data.DataSet();
        ds.ReadXml(HttpContext.Current.Server.MapPath("~/oracleconnect.xml"));
        System.Data.DataTable dt = ds.Tables[0];
        foreach (System.Data.DataRow dr in dt.Rows)
        {
            sqlstr = dr["connectionOracle_HKLPRD"].ToString();
        }
        return sqlstr;
    }
}