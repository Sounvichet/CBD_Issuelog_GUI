using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Trouble_Setting_index : System.Web.UI.Page
{
    TroubleSetting _seting = new TroubleSetting();
    DropDownListValues _drop = new DropDownListValues();
    GridViewValues _grid = new GridViewValues();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }

        if (!this.IsPostBack)
        {
            _gridviewtrouble();
        }
    }
    protected void Gridview_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "EditTrouble")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = Gridtrouble.Rows[index];
            Response.Redirect("~/Trouble_Setting/edit.aspx?ReportCode=" + row.Cells[2].Text); //"&ReasonGroup=" + row.Cells[6].Text +"&ReasonType="+ row.Cells[7].Text);
        }
        if (e.CommandName == "ViewTrouble")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = Gridtrouble.Rows[index];
            Response.Redirect("~/Trouble_Setting/view.aspx?ReportCode=" + row.Cells[2].Text); //"&ReasonGroup=" + row.Cells[6].Text +"&ReasonType="+ row.Cells[7].Text);
        }
    }
    private void _gridviewtrouble()
    {
        _grid._GridviewBinding(Gridtrouble, _seting.D_TroubleSettingDesc(Session["USERID"].ToString()));
        Label10.Text = Gridtrouble.Rows.Count.ToString();
    }
}