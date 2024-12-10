using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using IncidentDashBoard;

public partial class Ticket_getmission : System.Web.UI.Page
{
    //SqlConnection sqlc = new SqlConnection();
    //logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    DropDownListValues _drop = new DropDownListValues();
    //SqlConnectAndSqlCommand _sqlcmd = new SqlConnectAndSqlCommand();
    //MissionDashBoard _miss = new MissionDashBoard();
    Mission_Dashboard _miss = new Mission_Dashboard();
    string ticket;
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Name"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        ticket = Request.QueryString["ticket_no"].ToString();
        L_ticket_no.Text = ticket;
        if (!IsPostBack)
        {
            //bind_Channel_infor();
            bind_FC_1();
            bind_FC_2();
            bind_problem_type();
            _getAction();
            GetMissionFundamentals();
            
        }
    }
    private void GetMissionFundamentals()
    {
        try
        {

            DataTable dt = _miss._getMissionFundamentals(L_ticket_no.Text);
            t_branch_name.Text = dt.Rows[0][0].ToString();
            t_Terminal.Text = dt.Rows[0][1].ToString();
            t_Product_Type.Text = dt.Rows[0][2].ToString();
            t_Model_Type.Text = dt.Rows[0][3].ToString();
            d_Problem_Type.SelectedValue = dt.Rows[0][4].ToString();
            T_Problem_desc.Text = dt.Rows[0][5].ToString();
        }
        catch (Exception ex)
        {
            ShowMessage(_miss._message, MessageType.Error);
        }
        finally
        {
           
        }
    }
    //public void bind_Channel_infor()
    //{
    //    _drop.bindDropDownList(d_Branch_Name, _miss.D_branch_name());
    //}
    public void bind_problem_type()
    {
        _drop.bindDropDownList(d_Problem_Type, _miss.D_problem_type());
    }
    public void bind_FC_1()
    {
        _drop.bindDropDownList(d_Name_1, _miss.D_FC_STAFFNAME());
    }
    public void bind_FC_2()
    {
        _drop.bindDropDownList(d_Name_2, _miss.D_FC_STAFFNAME());
    }
    public void _getAction()
    {
        _drop.bindDropDownList(D_ActionType, _miss.D_getActions());
    }
    public void bind_Terminal_info()
    {

        try
        {
            DataTable dt = _miss.D_Mission_Terminal_info(t_Terminal.Text);
            if (dt.Rows.Count > 0)
            {
                t_Product_Type.Text = dt.Rows[0]["ATM_TYPE"].ToString();
                t_Model_Type.Text = dt.Rows[0]["ATM_SERIES"].ToString();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"" + _miss._message + "\");", true);
            }

        }
        catch (Exception ex)
        {
            ShowMessage(_miss._message, MessageType.Error);
        }
        finally
        {
            
        }
    }
    private string AutoIncrementID()
    {
        DataTable dt = _miss.D_get_AutoIncrementID();
        string id = dt.Rows[0][0].ToString();
        return id;
    }
    private DataTable D_bind_terminalName()
    {
        DataTable dt = new DataTable();

        return dt;
    }
    private bool _RegisterMIssion()
    {
        _miss._branch_name = t_branch_name.Text;
        _miss._terminal = t_Terminal.Text;
        _miss._product_type = t_Product_Type.Text;
        _miss._model_type = t_Model_Type.Text;
        _miss._problem_type = d_Problem_Type.SelectedValue;
        _miss._equitment = t_Equitment.Text;
        _miss._start_date = t_Start_date.Text;
        _miss._end_date = t_End_date.Text;
        _miss._day = D_days.Text;
        _miss._night = d_nights.Text;
        _miss._name_1 = d_Name_1.SelectedValue;
        _miss._position1 = "N'" + t_Position_1.Text + "'";
        _miss._company1 = t_Company_1.Text;
        _miss._phone1 = t_Phone_1.Text;
        _miss._staff_id1 = t_Staff_ID_1.Text;
        _miss._gender1 = t_Gender_1.Text;
        _miss._name_2 = d_Name_2.SelectedValue;
        _miss._position2 = "N'" + t_Position_2.Text + "'";
        _miss._company2 = t_Company_2.Text;
        _miss._phone2 = t_Phone_2.Text;
        _miss._staff_id2 = t_Staff_ID_2.Text;
        _miss._gender2 = t_Gender_2.Text;
        _miss._Status = D_ActionType.SelectedValue;
        _miss._Problem_desc = T_Problem_desc.Text;
        _miss._username = "02237" ; //Session["User_Name"].ToString();
        _miss._ticketno = L_ticket_no.Text;
        bool retval = _miss.ticketMission_register();

        if (retval == false)
        {
            // Response.Write("<script>alert('" + _miss._message + "')</script>");
            ShowMessage("Registerd Fail please try again " + _miss._message, MessageType.Error);
        }
        else
        {
            ShowMessage("registerd record..!", MessageType.Success);

        }
        return retval;
    }
    protected void d_Name_1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = _miss.D_FC_Fundamental(d_Name_1.SelectedValue);
        t_Position_1.Text = dt.Rows[0][3].ToString();
        t_Company_1.Text = dt.Rows[0][4].ToString();
        t_Phone_1.Text = dt.Rows[0][09].ToString();
        t_Staff_ID_1.Text = dt.Rows[0][0].ToString();
        t_Gender_1.Text = dt.Rows[0][2].ToString();

    }
    protected void d_Name_2_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = _miss.D_FC_Fundamental(d_Name_2.SelectedValue);
        t_Position_2.Text = dt.Rows[0][3].ToString();
        t_Company_2.Text = dt.Rows[0][4].ToString();
        t_Phone_2.Text = dt.Rows[0][09].ToString();
        t_Staff_ID_2.Text = dt.Rows[0][0].ToString();
        t_Gender_2.Text = dt.Rows[0][2].ToString();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        _RegisterMIssion();

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ticket/index.aspx");
    }
    private string strDailyuppercent()
    {
        _miss._start_date = t_Start_date.Text;
        _miss._end_date = t_End_date.Text;
        DataTable dt = _miss._Getmissionday();
        string _ID = "";
        if (dt.Rows.Count >= 1)
        {
            _ID = dt.Rows[1][1].ToString();
        }

        else
        {
            _ID = dt.Rows[0][1].ToString();
        }
        return _ID;
    }
    
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    protected void t_End_date_TextChanged1(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(t_Start_date.Text))
            {
                DateTime d1 = DateTime.Parse(t_End_date.Text);
                DateTime d2 = DateTime.Parse(t_Start_date.Text);

                string get1 = d1.ToString("dd/MM/yyyy");
                string get2 = d2.ToString("dd/MM/yyyy");
                if (get1 == get2)
                {
                    D_days.Text = "1";
                    d_nights.Text = "0";
                }

                else
                {
                    D_days.Text = "" + Convert.ToInt32((d1 > d2) ? (d1 - d2).TotalDays : (d1 - d2).TotalDays);
                    int days = Convert.ToInt32(D_days.Text);
                    int night = days - 1;
                    d_nights.Text = night.ToString();
                }


            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}