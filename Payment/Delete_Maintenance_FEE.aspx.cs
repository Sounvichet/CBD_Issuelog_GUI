using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Payment_Delete_Maintenance_FEE : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'> window.top.location.href = '../Default.aspx'; </script>");
        }
    }
}