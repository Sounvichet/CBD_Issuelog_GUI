using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI.WebControls;
/// <summary>
/// Summary description for ListBoxvalues
/// </summary>
public class ListBoxvalues
{
    logger _logger = new logger();
    public void bindListBox(ListBox _listbox, DataTable dt1)
    {

        try
        {
            _listbox.DataSource = dt1;
            _listbox.DataValueField = dt1.Columns[0].ColumnName.ToString(); //"GroupTypeID"
            _listbox.DataTextField = dt1.Columns[1].ColumnName.ToString(); //"ReasonGroupDesc"
            _listbox.DataBind();
            _listbox.Items.Insert(0, new ListItem("", ""));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }

        finally
        {

        }

    }
    public void bindListBox_String(ListBox _listbox, DataTable dt1)
    {

        try
        {
            _listbox.DataSource = dt1;
            _listbox.DataValueField = dt1.Columns[0].ColumnName.ToString(); //"GroupTypeID"
            _listbox.DataTextField = dt1.Columns[1].ColumnName.ToString(); //"ReasonGroupDesc"
            _listbox.DataBind();
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