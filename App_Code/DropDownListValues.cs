using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for DropDownListValues
/// </summary>
public class DropDownListValues
{
    logger _logger = new logger();

    public void bindDropDownList(DropDownList ddl, DataTable dt1)
    {

        try
        {
            ddl.DataSource = dt1;
            ddl.DataValueField = dt1.Columns[0].ColumnName.ToString(); //"GroupTypeID"
            ddl.DataTextField = dt1.Columns[1].ColumnName.ToString(); //"ReasonGroupDesc"
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("", ""));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }

        finally
        {

        }

    }
    public void bindDropDownList_String(DropDownList ddl, DataTable dt1)
    {

        try
        {
            ddl.DataSource = dt1;
            ddl.DataValueField = dt1.Columns[0].ColumnName.ToString(); //"GroupTypeID"
            ddl.DataTextField = dt1.Columns[1].ColumnName.ToString(); //"ReasonGroupDesc"
            ddl.DataBind();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }

        finally
        {

        }

    }
    public void binddropdownlist_status(DropDownList ddl, DataTable dt1)
    {

        try
        {
            ddl.DataSource = dt1;
            ddl.DataValueField = dt1.Columns[0].ColumnName.ToString(); //"GroupTypeID"
            ddl.DataTextField = dt1.Columns[1].ColumnName.ToString(); //"ReasonGroupDesc"
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("All", "All"));
            ddl.Items.Insert(1, new ListItem("Closed", "Closed"));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }

        finally
        {

        }

    }
    public void binddropdownlist_css_dispute(DropDownList ddl, DataTable dt1)
    {

        try
        {
            ddl.DataSource = dt1;
            ddl.DataValueField = dt1.Columns[0].ColumnName.ToString(); //"GroupTypeID"
            ddl.DataTextField = dt1.Columns[1].ColumnName.ToString(); //"ReasonGroupDesc"
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("All", "All"));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }

        finally
        {

        }

    }
}
