using System;
using System.Data;
using IncidentDashBoard; 

public partial class Mission_Mission_letter : System.Web.UI.Page
{
    string idedit;
    //MissionDashBoard _miss = new MissionDashBoard();
    Mission_Dashboard _miss = new Mission_Dashboard();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Name"] == null)
        {
          ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        idedit = Request.QueryString["ticket_no"].ToString();
        if (!IsPostBack)
        {
            _get_printFuncdamentals();
        }
    }

    private void _get_printFuncdamentals()
    {
        DataTable dt = _miss.D_mission_printFuncdamentals(idedit);
        //DataTable dt = _miss.D_mission_printFuncdamentals("CBD-0017019");
        lblBranchName.Text = dt.Rows[0]["TerminalName"].ToString();
        lblpurpose.Text = dt.Rows[0]["ReasonFullDesc"].ToString();
        lblproblem_desc.Text = dt.Rows[0]["Problem_desc"].ToString();
        lblfcname1.Text = dt.Rows[0]["FC_name1"].ToString();
        lblgender1.Text = dt.Rows[0]["gender1"].ToString();
        lblposition1.Text = dt.Rows[0]["Position1"].ToString();
        lblcom1.Text = dt.Rows[0]["company1"].ToString();
        lblphone1.Text = dt.Rows[0]["phone1"].ToString();
        lblcard1.Text = dt.Rows[0]["ID_CARD1"].ToString();

        lblfcname2.Text = dt.Rows[0]["FC_name2"].ToString();
        lblgender2.Text = dt.Rows[0]["gender2"].ToString();
        lblposition2.Text = dt.Rows[0]["Position2"].ToString();
        lblcom2.Text = dt.Rows[0]["company2"].ToString();
        lblphone2.Text = dt.Rows[0]["phone2"].ToString();
        lblcard2.Text = dt.Rows[0]["ID_CARD2"].ToString();

        lblstartdate.Text = dt.Rows[0]["Start_date"].ToString();
        lblenddate.Text = dt.Rows[0]["End_date"].ToString();
        lbldays.Text = dt.Rows[0]["miss_day"].ToString();
        lblnights.Text = dt.Rows[0]["miss_night"].ToString();

    }
}