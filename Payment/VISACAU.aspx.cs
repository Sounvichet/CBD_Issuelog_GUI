using System;
using System.Web.UI;
using System.Data;
using System.IO;
using System.Xml;
using System.Text;
using VisaClearingClass;

public partial class Payment_VISACAU : System.Web.UI.Page
{
    //SqlConnection sqlc = new SqlConnection();
    //SqlConnectAndSqlCommand _getsqlcon = new SqlConnectAndSqlCommand();
    DataTable CSVTable = new DataTable();
    //WingDashBoard _wing = new WingDashBoard();
    GridViewValues _grid = new GridViewValues();
    DropDownListValues _drop = new DropDownListValues();
    //OracleCommand oracmd = new OracleCommand();
    //OracleConnection obj2 = new OracleConnection();
    //SqlCommand cmd = new SqlCommand();
    //logger _logger = new logger();
    bool isLoading = false;
    //masterreport_connect obj1 = new masterreport_connect();
    //Visa_payment_dashboard _visa = new Visa_payment_dashboard();
    XmlCustAcctReupload _visa = new XmlCustAcctReupload();
    public enum MessageType { Success, Error, Info, Warning };

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
       //     ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        if (!IsPostBack)
        {
            
            string _get_current_date = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
            t_start_date.Text = _get_current_date;
            //_drop.bindDropDownList(d_settlement,_visa._get_settlement_type());
            
        }
     }



    //public void ReadCSVFile(string fileName)
    //{
    //    try
    //    {
    //        string connection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}\\;Extended Properties='Text;HDR=Yes;FMT=CSVDelimited'";

    //        connection = String.Format(connection, Path.GetDirectoryName(fileName));


    //        OleDbDataAdapter csvAdapter;
    //        csvAdapter = new OleDbDataAdapter("SELECT * FROM [" + Path.GetFileName(fileName) + "]", connection);

    //        if (File.Exists(fileName) && new FileInfo(fileName).Length > 0)
    //        {
    //            try
    //            {
    //                csvAdapter.Fill(CSVTable);
    //                if ((CSVTable != null) && (CSVTable.Rows.Count > 0))
    //                {
    //                    ViewState["CSVTable"] = CSVTable;
    //                    GridView _getGrid = new GridView();
    //                    _getGrid.DataSource = CSVTable;
    //                    _getGrid.DataBind();

    //                    _true._WING_Disputed_Insert(_getGrid);
    //                    // _CSS._CSS_LoopGrid(_getGrid);  //getgrid1
    //                    loading_Close();
    //                    ShowMessage("Insert records into Table Successful.", MessageType.Success);
                        
    //                }
    //                else
    //                {
    //                    String msg = "No records found";
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                throw new Exception(String.Format("Error reading Table {0}.\n{1}", Path.GetFileName(fileName), ex.Message));
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}

    private void loading()
    {
        //string script = isHide ? "$('#loading').hide(); " : "$('#loading').show(); ";
        //ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);
        ScriptManager.RegisterStartupScript(this,this.GetType(), "load", "$('#loading').show();", true);
    }
    private void loading_Close()
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "load", "$('#loading').hide();", true);
    }
    
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    protected void Update_ServerClick(object sender, EventArgs e)
    {
        
        loading_Close();
        ShowMessage("Uploaded Successful !!!", MessageType.Success);

    }
    
    protected void xml_export_ServerClick(object sender, EventArgs e)
    {
        try
        {
            _visa.P_DATE = t_start_date.Text;
            DataTable dt = _visa._get_CUST_ACCT_PENDING_RE_UPLOAD();

            // Generate the XML file
            string fileName = "acc_settle_" + t_start_date.Text + ".xml";
            string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
            string filePath = Path.Combine(downloadsPath, fileName);

            ExportDataToXml(dt, t_start_date.Text , filePath);

            // Prepare to download the file
            Response.Clear();
            Response.ContentType = "application/xml";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.AppendHeader("Content-Length", new FileInfo(filePath).Length.ToString());
            Response.TransmitFile(filePath);
            // Flush the response to send all content to the client
            Response.Flush();
        }
        catch (Exception ex)
        {
            Response.Write("Error: " + ex.Message);
        }

        finally
        {
            // End the response
            Response.End();
        }

    }

    public string ExportDataToXml(DataTable dt , string p_date , string p_path )
    {

        // Export dataset to XML
        //string fileName = "acc_settle_"+ p_date + ".xml";

        // Determine the downloads folder path
        //string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";

        // Combine downloads folder path with file name
        //string filePath = Path.Combine(downloadsPath, fileName);

        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Encoding = Encoding.UTF8;  // Specify the encoding
        settings.Indent = true;             // Indent the XML for readability
        settings.OmitXmlDeclaration = false; // Include XML declaration

        using (XmlWriter writer = XmlWriter.Create(p_path, settings))
        {
            // Write start of document
            //writer.WriteStartDocument();
            string xmlns = "http://sv.bpc.in/SVXP/Settlement";
            // Write root element start
            writer.WriteStartElement("settlement", xmlns);  // Replace "Root" with your root element name

            // Write additional elements 
            writer.WriteElementString("file_id", "2407100000016557");
            writer.WriteElementString("file_type", "FLTPMSTT");
            writer.WriteElementString("inst_id", "9999");


            foreach (DataRow row in dt.Rows)
            {
                writer.WriteStartElement("operation"); // Replace with your custom element name
                writer.WriteElementString("oper_type", row["OPER_TYPE"].ToString()); // Replace with actual column names
                writer.WriteElementString("msg_type", row["MSG_TYPE"].ToString());
                writer.WriteElementString("oper_date", row["OPER_DATE"].ToString());
                writer.WriteElementString("host_date", row["HOST_DATE"].ToString());

                writer.WriteStartElement("oper_amount");
                writer.WriteElementString("amount_value", row["OPER_AMOUNT_VALUE"].ToString());
                writer.WriteElementString("currency", row["CURRENCY"].ToString());
                writer.WriteEndElement(); // Close the custom row element

                writer.WriteElementString("network_refnum", row["NETWORK_REFNUM"].ToString());
                writer.WriteElementString("is_reversal", row["IS_REVERSAL"].ToString());
                writer.WriteElementString("merchant_number", row["MERCHANT_NUMBER"].ToString());
                writer.WriteElementString("mcc", row["MCC"].ToString());
                writer.WriteElementString("merchant_name", row["MERCHANT_NAME"].ToString());
                writer.WriteElementString("merchant_city", row["MERCHANT_CITY"].ToString());
                writer.WriteElementString("merchant_country", row["MERCHANT_COUNTRY"].ToString());
                writer.WriteElementString("merchant_postcode", row["MERCHANT_POSTCODE"].ToString());
                writer.WriteElementString("terminal_type", row["TERMINAL_TYPE"].ToString());
                writer.WriteElementString("terminal_number", row["TERMINAL_NUMBER"].ToString());
                writer.WriteElementString("card_number", row["CARD_NUMBER"].ToString());
                writer.WriteElementString("card_seq_number", row["CARD_SEQ_NUMBER"].ToString());
                writer.WriteElementString("auth_code", row["AUTH_CODE"].ToString());
                writer.WriteElementString("acq_inst_id", row["ACQ_INST_ID"].ToString());
                writer.WriteElementString("acq_inst_bin", row["ACQ_INST_BIN"].ToString());
                writer.WriteElementString("iss_inst_id", row["ISS_INST_ID"].ToString());

                writer.WriteStartElement("transaction");
                writer.WriteElementString("transaction_id", row["TRANSACTION_ID"].ToString());
                writer.WriteElementString("transaction_type", row["TRANSACTION_TYPE"].ToString());
                writer.WriteElementString("posting_date", row["POSTING_DATE"].ToString());

                writer.WriteStartElement("debit_entry");
                writer.WriteElementString("entry_id", row["ENTRY_ID"].ToString());

                writer.WriteStartElement("account");
                writer.WriteElementString("account_number", row["ACCOUNT_NUMBER"].ToString());
                writer.WriteElementString("account_currency", row["ACCOUNT_CURRENCY"].ToString());
                writer.WriteEndElement(); // Close the custom row element

                writer.WriteStartElement("amount");
                writer.WriteElementString("amount_value", row["TRN_AMOUNT_VALUE"].ToString());
                writer.WriteElementString("amount_currency", row["TRN_CURRENCY"].ToString());
                writer.WriteEndElement(); // Close the custom row element

                // Add more elements as needed for each column
                writer.WriteEndElement(); // Close the custom row element
                writer.WriteElementString("amount_purpose", row["AMOUNT_PURPOSE"].ToString());
                writer.WriteEndElement(); // Close the custom row element

                writer.WriteEndElement(); // Close the custom row element
            }


            // Write data from DataSet to XML
            //dataSet.Tables["NodeDownReason"].WriteXml(writer);

            // Write root element end
            writer.WriteEndElement();

            // Write end of document
            writer.WriteEndDocument();
        }

        // Export dataset to XML
        //dataSet.WriteXml(filePath);

        // Return the file path
        return p_path;
    }
}