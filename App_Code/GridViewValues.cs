using System.Web.UI.WebControls;
using System.Data;

/// <summary>
/// Summary description for GridViewValues
/// </summary>
public class GridViewValues
{
    public void _GridviewBinding(GridView bind_grid,DataTable dt)
    {
        bind_grid.DataSource = dt;
        bind_grid.DataBind();

    }
}