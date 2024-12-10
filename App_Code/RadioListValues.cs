using System;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for RadioListValues
/// </summary>
public class RadioListValues
{
    logger _logger = new logger();
    public void bindRadioButtonList(RadioButtonList rbl, DataTable dt1)
    {

        try
        {
            rbl.DataSource = dt1;
            rbl.DataValueField = dt1.Columns[0].ColumnName.ToString(); //"GroupTypeID"
            rbl.DataTextField = dt1.Columns[1].ColumnName.ToString(); //"ReasonGroupDesc"
            rbl.DataBind();
            //ddl.Items.Insert(0, new ListItem("", ""));
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