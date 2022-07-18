using GTBEncryptLibrary;
using HUBAdvance;
using HUBAdvance.extranet.cbn.crms;
using HUBAdvance.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Xml;


internal class ProcessReversal
{
    private string response = string.Empty;
    private string resCode = string.Empty;
    private string resMsg = string.Empty;
    private string transId = string.Empty;
    private string accountNum = string.Empty;
    private string msg = string.Empty;
    private string mobNum = string.Empty;
    private string Nuban = "";
    private string[] acctKey = new string[5];
    private double Amount = 0.0;
    private double feeAmt = 0.0;
    private AppDevService appServe = new AppDevService();
    private int delayATM = (int)Convert.ToInt16(ConfigurationManager.AppSettings["DelayATM"]);


    public void RetrieveCBNReferenceForHubAdvance()
    {
        ErrHandler.LogError("About to load Hub Advance Unprocessed Request for CBN");
        string appSetting1 = ConfigurationManager.AppSettings["staffperiod"];
        string appSetting2 = ConfigurationManager.AppSettings["customerperiod"];
        string appSetting3 = ConfigurationManager.AppSettings["HubinterestRate"];
        this.appServe.Url = ConfigurationManager.AppSettings["GTBTechURLSMS"];
        string transId = "";
        DataTable dataTable = new DataTable();
        string appSetting4 = ConfigurationManager.AppSettings["UserName"];
        string appSetting5 = ConfigurationManager.AppSettings["Password"];
        string appSetting6 = ConfigurationManager.AppSettings["ReturnName"];
        string[] strArray = new string[10];
        try
        {
            DataTable requestForCbnReference = this.GetRequestForCBNReference();
            if (requestForCbnReference.Rows.Count > 0)
            {
                ErrHandler.LogError("About to loop through Hub Advance Unprocessed Request for CBN Rendition");
                foreach (DataRow row in requestForCbnReference.Rows)
                {
                    try
                    {
                        transId = "";
                        transId = row["TRANSACTIONID"].ToString();
                        this.Nuban = row["BALANCE_LIMIT_ACCOUNT"].ToString();
                        this.Amount = Convert.ToDouble(row["BALANCE_LIMIT_AMOUNT"].ToString());
                        this.feeAmt = Convert.ToDouble((0.01 * this.Amount).ToString() + ".00");
                        int cbnRefTryCount = (int)Convert.ToInt16(row["CBN_REF_TRYCOUNT"].ToString());
                        string isStaff = !(row["ISSTAFF"].ToString().ToUpper() == "TRUE") ? "12" : "3";
                        this.acctKey = row["BALANCE_LIMIT_ACCOUNT_OLDACCOUNT"].ToString().Split('/');
                        string bvn = row["BVN"].ToString();
                        string stateCode = this.GetStateCode(ProcessReversal.getCountryStateDetails(this.acctKey[0], this.acctKey[1], this.acctKey[2], this.acctKey[3], this.acctKey[4]));
                        if (stateCode.Length == 2)
                            stateCode = "0" + stateCode;

                        object[] objArray = new object[33]
                        {
                (object)"<CALLREPORT><HEADER><CALLREPORT_ID>CRMS300</CALLREPORT_ID><CALLREPORT_DESC>Rendition of Borrower Credit Details (Individual and Non-Individual)</CALLREPORT_DESC><INST_CODE>00058</INST_CODE><INST_NAME>Guaranty Trust Bank Plc</INST_NAME><AS_AT>",
             DateTime.Now.ToString("dd-MM-yyyy"),
              (object) "</AS_AT></HEADER><BODY><CALLREPORT_DATA><SL_NO>1</SL_NO><UNIQUE_IDENTIFICATION_TYPE>BVN</UNIQUE_IDENTIFICATION_TYPE><UNIQUE_IDENTIFICATION_NO>",
              (object) bvn,
              (object) "</UNIQUE_IDENTIFICATION_NO><CREDIT_TYPE>40030</CREDIT_TYPE><CREDIT_PURPOSE_BY_BUSINESSLINES>41000</CREDIT_PURPOSE_BY_BUSINESSLINES><CREDIT_PURPOSE_BY_BUSINESSLINES_SUB_SECTOR>41020</CREDIT_PURPOSE_BY_BUSINESSLINES_SUB_SECTOR><CREDIT_LIMIT>",
              (object) this.Amount,
              (object) "</CREDIT_LIMIT><OUTSTANDING_AMOUNT>0.00</OUTSTANDING_AMOUNT><FEES><FEE><FEE_TYPE>F0003</FEE_TYPE><FEE_AMOUNT>",
              (object) this.feeAmt,
              (object) "</FEE_AMOUNT></FEE> </FEES><EFFECTIVE_DATE>",
              (object) DateTime.Today.ToString("dd-MM-yyyy"),
              (object) "</EFFECTIVE_DATE><TENOR>",
              (object) isStaff,
              (object) "</TENOR><EXPIRY_DATE>",
              (object) DateTime.Today.AddDays((double) Convert.ToInt16(isStaff)).ToString("dd-MM-yyyy"),
              (object) "</EXPIRY_DATE><REPAYMENT_AGREEMENT_MODE>300</REPAYMENT_AGREEMENT_MODE><INTEREST_RATE>",
              (object) appSetting3,
              (object) "</INTEREST_RATE><BENEFICIARY_ACCOUNT_NUMBER>",
              (object) this.Nuban,
              (object) "</BENEFICIARY_ACCOUNT_NUMBER><LOCATION_OF_BENEFICIARY>",
              (object) stateCode,
              (object) "</LOCATION_OF_BENEFICIARY><RELATIONSHIP_TYPES><RELATIONSHIP_TYPE>RT001</RELATIONSHIP_TYPE></RELATIONSHIP_TYPES><COMPANY_SIZE>NIL</COMPANY_SIZE><FUNDING_SOURCE_CATEGORY>LCY</FUNDING_SOURCE_CATEGORY><FUNDING_SOURCES><FUNDING_SOURCE>FS1000</FUNDING_SOURCE></FUNDING_SOURCES><ECCI_NUMBER>0</ECCI_NUMBER><LEGAL_STATUS>40001</LEGAL_STATUS><CLASSIFICATION_BY_BUSINESS_LINES>41000</CLASSIFICATION_BY_BUSINESS_LINES><CLASSIFICATION_BY_BUSINESS_LINES_SUB_SECTOR>41020</CLASSIFICATION_BY_BUSINESS_LINES_SUB_SECTOR><SPECIALISED_LOAN>NO</SPECIALISED_LOAN><SPECIALISED_LOAN_MORATORIUM_PERIOD>0</SPECIALISED_LOAN_MORATORIUM_PERIOD><DIRECTOR_UNIQUE_IDENTIFIERS><DIRECTOR_UNIQUE_IDENTIFIER><UNIQUE_IDENTIFICATION_TYPE>BVN</UNIQUE_IDENTIFICATION_TYPE><UNIQUE_IDENTIFICATION_NO>",
              (object) bvn,
              (object) "</UNIQUE_IDENTIFICATION_NO><DIRECTOR_EMAIL_ADDRESS>vondorixng@yahoo.com</DIRECTOR_EMAIL_ADDRESS></DIRECTOR_UNIQUE_IDENTIFIER></DIRECTOR_UNIQUE_IDENTIFIERS><SYNDICATION>NO</SYNDICATION><SYNDICATION_STATUS>NIL</SYNDICATION_STATUS><SYNDICATION_REF_NUMBER>0</SYNDICATION_REF_NUMBER><COLLATERAL_DETAILS><COLLATERAL_PRESENT>NO</COLLATERAL_PRESENT><COLLATERAL_INFORMATION><COLLATERAL_SECURE>NO</COLLATERAL_SECURE><SECURITY_TYPE>UNSEC011</SECURITY_TYPE><ADDRESS_OF_SECURITY>NIL</ADDRESS_OF_SECURITY><OWNER_OF_SECURITY>NIL</OWNER_OF_SECURITY><UNIQUE_IDENTIFICATION_TYPE_OF_SECURITY_OWNER>BVN</UNIQUE_IDENTIFICATION_TYPE_OF_SECURITY_OWNER><UNIQUE_IDENTIFIER_OF_SECURITY_OWNER>00000000000</UNIQUE_IDENTIFIER_OF_SECURITY_OWNER></COLLATERAL_INFORMATION></COLLATERAL_DETAILS><GUARANTOR_DETAILS><GUARANTEE>NO</GUARANTEE><GUARANTOR_INFORMATION><GUARANTEE_TYPE>INDIVIDUAL</GUARANTEE_TYPE><GUARANTOR_UNIQUE_IDENTIFICATION_TYPE>BVN</GUARANTOR_UNIQUE_IDENTIFICATION_TYPE><GUARANTOR_UNIQUE_IDENTIFICATION>00000000000</GUARANTOR_UNIQUE_IDENTIFICATION><AMOUNT_GUARANTEED>0.00</AMOUNT_GUARANTEED></GUARANTOR_INFORMATION></GUARANTOR_DETAILS></CALLREPORT_DATA> </BODY><FOOTER><AUTH_SIGNATORY><NAME>a</NAME><DESIGNATION>a</DESIGNATION><POSITION>a</POSITION><DATE>",
              (object) DateTime.Today.ToString("dd-MM-yyyy"),
              (object) "</DATE><TEL_NO>a</TEL_NO><EXTN>a</EXTN></AUTH_SIGNATORY><CONTACT_DETAILS><NAME>String</NAME><DESIGNATION>String</DESIGNATION><DATE>",
              null,
              null,
              null,
              null,
              null,
              null,
              null,
              null
                        };
                        DateTime today = DateTime.Today;
                        objArray[25] = (object)today.ToString("dd-MM-yyyy");
                        objArray[26] = (object)"</DATE><TEL_NO>String</TEL_NO><EXTN>String</EXTN></CONTACT_DETAILS><DESC>String</DESC><PREPARED_BY>a</PREPARED_BY><AUTH_BY>String</AUTH_BY><MLR_OFFICER_CODE>String</MLR_OFFICER_CODE><HEAD_OFFICE_ADDRESS>a</HEAD_OFFICE_ADDRESS><TEL_NO>a</TEL_NO><DATE>";
                        today = DateTime.Today;
                        objArray[27] = (object)today.ToString("dd-MM-yyyy");
                        objArray[28] = (object)"</DATE><CREDIT_OFFICER>String</CREDIT_OFFICER><BRANCH_MANAGER>String</BRANCH_MANAGER><PREPARED_DATE>";
                        today = DateTime.Today;
                        objArray[29] = (object)today.ToString("dd-MM-yyyy");
                        objArray[30] = (object)"</PREPARED_DATE><CHECKED_BY>a</CHECKED_BY><CHECKED_DATE>";
                        today = DateTime.Today;
                        objArray[31] = (object)today.ToString("dd-MM-yyyy");
                        objArray[32] = (object)"</CHECKED_DATE></FOOTER></CALLREPORT>";
                        string Reference1 = string.Concat(objArray);
                        this.UpdateSMEHubCBNRef(transId, Reference1, 0);
                        ReturnSubmissionWSEJBBeanService wsejbBeanService = new ReturnSubmissionWSEJBBeanService();

                        string Reference2 = wsejbBeanService.submitReturn(appSetting4, appSetting5, appSetting6, Reference1.Trim());
                        if (Reference2.ToUpper().Contains("Credit Profile successfully created for Borrower with Unique Identification Number".ToUpper()))
                        {
                            Reference2 = Reference2.Split(':')[3].Trim().Replace(".</INFO>", "");
                            this.UpdateSMEHubCBNRef(transId, Reference2, 1);
                        }
                        else
                            this.UpdateSMEHubCBNRef(transId, Reference1, cbnRefTryCount + 2);
                        ErrHandler.LogError("Response from CBN: Trans ID-" + transId + " and Reference-" + Reference2);
                    }
                    catch (Exception ex)
                    {
                        ErrHandler.LogError("Generate CBN Reference Error: for Trans ID-" + transId + ". Error - " + ex.Message);
                    }
                }
            }
            else
                ErrHandler.LogError("No CBN Unproccessed record found");
            requestForCbnReference.Clear();
        }
        catch (Exception ex)
        {
            ErrHandler.LogError("Error Generating CBN Reference for HubAdvance: " + transId + ". Error - " + ex.Message);
        }
    }


    public void ProcessSMEHubAdvance()
{
    string transId = "";
        try
        {
            PM_TechAppDev.AppDevService appDevService1 = new PM_TechAppDev.AppDevService();
            AppDevService appDevService2 = new AppDevService();
            appDevService1.Url = ConfigurationManager.AppSettings["GTBTechURL_PM"];
            appDevService2.Url = ConfigurationManager.AppSettings["GTBTechURL"];
            string appSetting1 = ConfigurationManager.AppSettings["HubinterestRate"];
            string appSetting25 = ConfigurationManager.AppSettings["MonthlyHubinterestRate"];
            string appSetting2 = ConfigurationManager.AppSettings["smehubemail"];
            string appSetting3 = ConfigurationManager.AppSettings["staffperiod"];
            string appSetting4 = ConfigurationManager.AppSettings["customerperiod"];
            XmlDocument xmlDocument = new XmlDocument();
            DataTable dataTable = new DataTable();
            DataTable unprocessedHubAdvance = this.GetUnprocessedHubAdvance();

            if (unprocessedHubAdvance.Rows.Count > 0)
            {
                ErrHandler.LogError("Retrieved Salary Advance Unprocessed requests: " + unprocessedHubAdvance.Rows.Count);
                ErrHandler.LogError("About to loop through Salary Advance Unprocessed Request");
                foreach (DataRow row in (InternalDataCollectionBase)unprocessedHubAdvance.Rows)
                {
                    try
                    {
                        transId = "";
                        transId = row["TRANSACTIONID"].ToString();
                        string oldAccountNumber = row["BALANCE_LIMIT_ACCOUNT_OLDACCOUNT"].ToString();
                        string nuban = row["NUBAN"].ToString();
                        string isStaff = row["ISSTAFF"].ToString();
                        row["IS_ELIGIBLE"].ToString();
                        string emailFromBasis = row["EMAIL"].ToString();
                        double balLimitAmt = Convert.ToDouble(row["BALANCE_LIMIT_AMOUNT"].ToString());
                        string cusName = row["CUSTOMERNAME"].ToString();
                        string balLimitAcct = row["BALANCE_LIMIT_ACCOUNT"].ToString();
                        DateTime now;
                        string mat_date;
                        string appSet;
                        int tenor;
                        if (isStaff.ToUpper() == "TRUE")
                        {
                            tenor = 3;
                            now = DateTime.Now;
                            mat_date = Convert.ToString(now.AddMonths(3));
                            appSet = appSetting3;
                        }
                        else
                        {
                            tenor = 12;
                            now = DateTime.Now;
                            mat_date = Convert.ToString(now.AddMonths(12));
                            appSet = appSetting4;
                        }
                        if (oldAccountNumber.Split('/')[4] != "0")
                        {
                            this.UpdateSMEHubAdvanceRequest(transId, "Sub Account not allowed " + oldAccountNumber, 1);
                        }
                        else
                        {
                            double checkLimit = this.CheckCrditLimtExist(oldAccountNumber);
                            ErrHandler.LogError("Check balance limit on acct: " + oldAccountNumber + " with status: " + (object)checkLimit);
                            if (checkLimit < 0.0)
                            {
                                this.resCode = "1000";
                                ErrHandler.LogError("Balance limit of " + checkLimit.ToString() + " exists on account " + oldAccountNumber);
                            }                                
                            else if (checkLimit == 0.0)
                            {
                                ErrHandler.LogError("About to insert balance limit of " + Convert.ToString(balLimitAmt) + " on account " + oldAccountNumber);
                                string xml = this.InsertBallim((int)Convert.ToInt16(oldAccountNumber.Split('/')[0]), oldAccountNumber.Split('/')[1], oldAccountNumber.Split('/')[2], oldAccountNumber.Split('/')[3], oldAccountNumber.Split('/')[4], 9938, Convert.ToString(balLimitAmt), mat_date);
                                xmlDocument.LoadXml(xml);
                                this.resCode = xmlDocument.SelectSingleNode("/Response/CODE").InnerXml;
                                ErrHandler.LogError("status of balance limit placed on  acct: " + oldAccountNumber + " with status: " + xml);
                            }
                            else
                                continue;
                            if (this.resCode == "1000")
                            {
                                
                                StandingInstructionModel standinginstructiondetails = new StandingInstructionModel();
                                var startstandinginstruction = new Basis();
                                ErrHandler.LogError("About to convert nuban to old account number");
                                string oldaccount = startstandinginstruction.ConvertToOldAccount(nuban);
                                double rate = Convert.ToDouble(ConfigurationManager.AppSettings["LoanCreditRate"].ToString());
                                double amount = CalculateMonthlyRepaymentAmount(balLimitAmt, tenor, rate);
                                bool standinginstructionresult = false;
                                if (oldaccount.Contains("/"))
                                {                                    
                                    standinginstructiondetails.bracode = Convert.ToDouble(oldaccount.Split('/')[0]);
                                    standinginstructiondetails.cusnum = Convert.ToDouble(oldaccount.Split('/')[1]);
                                    standinginstructiondetails.curcode = Convert.ToDouble(oldaccount.Split('/')[2]);
                                    standinginstructiondetails.ledcode = Convert.ToDouble(oldaccount.Split('/')[3]);
                                    standinginstructiondetails.subacct = Convert.ToDouble(oldaccount.Split('/')[4]);
                                    standinginstructiondetails.payfreq = Convert.ToDouble(ConfigurationManager.AppSettings["StandingInstructionpayfrequency"].ToString());
                                    standinginstructiondetails.paytype = Convert.ToDouble(ConfigurationManager.AppSettings["StandingInstructionpaytype"].ToString());
                                    standinginstructiondetails.novdn_flag = Convert.ToDouble(ConfigurationManager.AppSettings["StandingInstructionnovdn_flag"].ToString());
                                    standinginstructiondetails.firstpayamount = Convert.ToDouble(amount);
                                    standinginstructiondetails.firstpaydate = (Convert.ToDateTime(row["DATEINSERTED"].ToString()).AddDays(30)).Date;                                    
                                    standinginstructiondetails.lastpaydate = Convert.ToDateTime(row["DATEINSERTED"].ToString()).AddMonths(12).Date;
                                    standinginstructiondetails.cre_acct = Convert.ToInt32(oldAccountNumber.Split('/')[0]).ToString("0000") + Convert.ToInt32(oldAccountNumber.Split('/')[1]).ToString("0000000") + Convert.ToInt32(oldAccountNumber.Split('/')[2]).ToString("000") + Convert.ToInt32(oldAccountNumber.Split('/')[3]).ToString("0000") + Convert.ToInt32(oldAccountNumber.Split('/')[4]).ToString("000");
                                    standinginstructiondetails.remarks = ConfigurationManager.AppSettings["LoanCreditRemark"].ToString();
                                    ErrHandler.LogError("About to call the standing Instruction Procedure");
                                    standinginstructionresult = startstandinginstruction.GiveStandingInstruction(standinginstructiondetails);
                                    if (standinginstructionresult)
                                    {
                                        ErrHandler.LogError("Call to Standing Instruction Procedure was successful");
                                        this.UpdateSMEHubAdvanceRequest(transId, "Limit Successfully Placed", 1);
                                        if (string.IsNullOrEmpty(emailFromBasis))
                                        {
                                            emailFromBasis = this.getEmailFromBasis(oldAccountNumber);
                                            if (string.IsNullOrEmpty(emailFromBasis))
                                                this.UpdateSMEHubAdvanceRequest(transId, "Limit Successfully Placed, Email does not exist", 1);
                                        }
                                        string mailmessage = "Dear <strong>" + cusName + "</strong>,<br><br>You have successfully enrolled for Hub Credit. " +
                                        "You are now on your way to a superior shopping experience on " +
                                        "Habari! <br><br>" +
                                        "<strong>Please see below the details of your Hub Credit Account: </strong><br><br>" +
                                        "<strong>Hub Credit Account: </strong> " + balLimitAcct + " <br><strong>Credit Limit: " +
                                        "</strong> " + string.Format("{0:n}", (object)balLimitAmt) + "<br><strong>Tenor: </strong> "
                                        + appSet + " Months<br><strong>Interest Rate: </strong> " + appSetting25 + "% monthly<br>" +
                                        "<p>To shop using Hub Credit, kindly follow the steps below: </p> <br>" +
                                        "<li>Visit <a href = 'https://habarigt.com' >habarigt.com </a> </li> " +
                                        "<li>Log in or create your Habari User profile</li>" +
                                        "<li>Add your HubCredit Account</li>" +
                                        "<li>Select the items you want to buy and proceed to checkout</li>" +
                                        "<li>Select your HubCredit account at checkout</li>" +
                                        "<li>Confirm payment with the OTP from your hardware token or sent to your mobile phone</li><br>" +
                                        "<p>Your shopping expenses will be withdrawn from your Hub Credit account and not your regular account<br>" +
                                        "<p>You can keep track of your Hub Credit on your Internet Banking page or GTWorld mobile App. </p> " +
                                        "<p>For further information or enquiries, please contact us by calling GTConnect, " +
                                        "our fully interactive self-service Contact Center, on +234 01 4480000, +234 80 2900 2900 or +234 80 3900 3900.</p> " +
                                        "<p> Thank you for banking with us.</p> <br>";
                                        string successMsg = "";
                                        successMsg = appDevService2.SendEmail_HTML("Your Application for HubCredit is Successful", mailmessage, appSetting2, emailFromBasis, "", "");
                                        ErrHandler.LogError("status of email sent for  acct: " + oldAccountNumber + " with status: " + successMsg);
                                        if (successMsg.ToUpper() == "SUCCEED")
                                            this.UpdateSMEHubAdvanceRequest(transId, "SENT EMAIL SUCCESSFUL", 0);
                                        else
                                            this.UpdateSMEHubAdvanceRequest(transId, "SENT EMAIL UNSUCCESSFUL", 1);
                                    }
                                    else
                                    {
                                        ErrHandler.LogError("Call to standing Instruction Procedure failed");
                                    }
                                }
                                
                            }
                            else
                                this.UpdateSMEHubAdvanceRequest(transId, "Limit was not Successfully Placed", 2);
                        }

                    }

                    catch (Exception ex)
                    {
                        this.UpdateSMEHubAdvanceRequest(transId, ex.Message, 2);
                        ErrHandler.LogError(nameof(ProcessSMEHubAdvance) + ex.Message);
                    }

                }
                ErrHandler.LogError(" loop through Salary Advance Unprocessed Request Succesfully");
            }
            else
                ErrHandler.LogError("No Pending Salary Advance Request");
            unprocessedHubAdvance.Clear();
        }
        catch (Exception ex)
        {
            this.UpdateSMEHubAdvanceRequest(transId, ex.Message, 2);
            ErrHandler.LogError(nameof(ProcessSMEHubAdvance) + ex.Message);
        }
}

    private string getEmailFromBasis(string oldAccountNumber)
    {
        string email = string.Empty;
        string[] strArray = oldAccountNumber.ToString().Split('/');
        string bracode = strArray[0].Trim();
        string cusnum = strArray[1].Trim();
        using (OracleConnection oracleConnection = new OracleConnection(
            GTBEncryptLib.DecryptText(ConfigurationManager.AppSettings["BASISConString_eone"].ToString())))
        {
            using (OracleCommand oracleCommand = new OracleCommand())
            {
                try
                {
                    if (oracleConnection.State == ConnectionState.Closed)
                        oracleConnection.Open();
                    oracleCommand.Connection = oracleConnection;
                    string sqlGet = "select get_emailadd(:bracode,:cusnum) email from dual";
                    oracleCommand.CommandText = sqlGet;
                    oracleCommand.CommandType = CommandType.Text;
                    oracleCommand.Parameters.AddWithValue("bracode", (object)bracode);
                    oracleCommand.Parameters.AddWithValue("cusnum", (object)cusnum);
                    OracleDataReader oracleDataReader;
                    using (oracleDataReader = oracleCommand.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (oracleDataReader.HasRows)
                        {
                            oracleDataReader.Read();
                            email = Convert.ToString(oracleDataReader["email"].ToString());
                        }
                        else
                            email = "";
                    }
                }
                catch (Exception ex)
                {
                    ErrHandler.LogError("Error getting customer Email from BASIS : " + ex.Message);
                    email = ex.Message;
                }
                finally
                {
                    if (oracleConnection.State == ConnectionState.Open)
                        oracleConnection.Close();
                    oracleConnection.Dispose();
                }
            }
            return email;
        }
    }


    public string InsertBallim(int bra_code, string cus_num, string cur_code,string led_code,string sub_acct_code,int tell_id,string bal_lim,string mat_date)
    {
        string matDate = (string.IsNullOrEmpty(mat_date) ? DateTime.MinValue : Convert.ToDateTime(mat_date)).ToString("ddMMMyyyy");
        string empty = string.Empty;
        string resp = "<Response>";
        OracleConnection connection = new OracleConnection(GTBEncryptLib.DecryptText(ConfigurationManager.AppSettings["BASISConString_eone"]));
        if (ConfigurationManager.AppSettings["Environment"].ToString().Trim() == "Test")
        {
            connection = new OracleConnection(ConfigurationManager.AppSettings["Basis"]);
        }
        //OracleConnection connection = new OracleConnection(GTBEncryptLib.DecryptText(ConfigurationManager.AppSettings["BASISConString_eone"]));
        OracleCommand oracleCommand = new OracleCommand("eonepkg1.gtb_bal_lim", connection);
        oracleCommand.CommandType = CommandType.StoredProcedure;
        string fullResp;
        try
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            oracleCommand.Parameters.Add("inp_bra", OracleType.VarChar, 15).Value = (object)bra_code;
            oracleCommand.Parameters.Add("inp_cus", OracleType.VarChar, 15).Value = (object)cus_num;
            oracleCommand.Parameters.Add("inp_cur", OracleType.VarChar, 15).Value = (object)cur_code;
            oracleCommand.Parameters.Add("inp_led", OracleType.VarChar, 15).Value = (object)led_code;
            oracleCommand.Parameters.Add("inp_sub", OracleType.VarChar, 15).Value = (object)sub_acct_code;
            oracleCommand.Parameters.Add("inp_tell_id", OracleType.VarChar, 15).Value = (object)tell_id;
            oracleCommand.Parameters.Add("inp_bal_lim", OracleType.VarChar, 15).Value = (object)bal_lim;
            oracleCommand.Parameters.Add("inp_lim_mat_date", OracleType.DateTime, 15).Value = (object)matDate;
            oracleCommand.Parameters.Add("RETURN_STATUS", OracleType.Number, 15).Direction = ParameterDirection.Output;
            oracleCommand.ExecuteNonQuery();
            string returnStat = oracleCommand.Parameters["RETURN_STATUS"].Value.ToString();
            connection.Close();
            if (returnStat.CompareTo("0") == 0)
            {
                string loanaccount = bra_code + "/" + cus_num + "/" + cur_code + "/" + led_code + "/" + sub_acct_code;
                ErrHandler.LogError("Added a balance limit of:" + bal_lim + " to account:" + loanaccount);
                resp += "<CODE>1000</CODE>";
                resp += "<MESSAGE>SUCCESS</MESSAGE>";
                fullResp = resp + "</Response>";
            }
            else if (returnStat.Length == 0)
            {
                resp += "<CODE>1001</CODE>";
                resp = resp + "<Error>" + returnStat + "</Error>";
                fullResp = resp + "</Response>";
            }
            else
            {
                resp += "<CODE>1001</CODE>";
                resp += "<Error> BASIS Response is null</Error>";
                fullResp = resp + "</Response>";
            }
        }
        catch (Exception ex)
        {
            fullResp = resp + "<CODE>1002</CODE>" + "<Error>" + ex.Message.Replace("'", "") + "</Error>" + "</Response>";
        }
        return fullResp;
    }
    
    public double CheckCrditLimtExist(string oldAccountNumber)
    {
        double num = 1.0;
        string[] strArray = oldAccountNumber.ToString().Split('/');
        string bracode = strArray[0].Trim();
        string cusnum = strArray[1].Trim();
        string curcode = strArray[2].Trim();
        string ledcode = strArray[3].Trim();
        string subacct = strArray[4].Trim();
        DataTable dt;       

        OracleConnection oracleConnection = new OracleConnection(GTBEncryptLib.DecryptText(ConfigurationManager.AppSettings["BASISConString_eone"])); ;
        if (ConfigurationManager.AppSettings["Environment"].ToString().Trim() == "Test")
        {
            oracleConnection = new OracleConnection(ConfigurationManager.AppSettings["Basis"]);
        }       
        
        using (OracleCommand oracleCommand = new OracleCommand())
        {
            try
            {
                if (oracleConnection.State == ConnectionState.Closed)
                    oracleConnection.Open();
                oracleCommand.Connection = oracleConnection;
                string getAcctDetails = "select bal_lim from account where bra_code = :bracode and cus_num = :cusnum and cur_code = :curcode and led_code = :ledcode and sub_acct_code = :subacct";
                oracleCommand.CommandText = getAcctDetails;
                oracleCommand.CommandType = CommandType.Text;
                oracleCommand.Parameters.AddWithValue("bracode", (object)bracode);
                oracleCommand.Parameters.AddWithValue("cusnum", (object)cusnum);
                oracleCommand.Parameters.AddWithValue("curcode", (object)curcode);
                oracleCommand.Parameters.AddWithValue("ledcode", (object)ledcode);
                oracleCommand.Parameters.AddWithValue("subacct", (object)subacct);
                OracleDataReader oracleDataReader;
                using (oracleDataReader = oracleCommand.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (oracleDataReader.HasRows)
                    {
                        oracleDataReader.Read();
                        num = Convert.ToDouble(oracleDataReader["bal_lim"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ErrHandler.LogError("Error getting Credit Limit from BASIS : " + ex.Message);
                num = 1.0;
            }
            finally
            {
                if (oracleConnection.State == ConnectionState.Open)
                    oracleConnection.Close();
                oracleConnection.Dispose();
            }
        }
        return num;
        
        //using (OracleConnection oracleConnection = new OracleConnection(GTBEncryptLib.DecryptText(ConfigurationManager.AppSettings["BASISConString_eone"])))
        ////using (OracleConnection oracleConnection = new OracleConnection(ConfigurationManager.AppSettings["BASISConString_eone"]))
        //{

        //    string getAcctDetails = $"select bal_lim from account where bra_code = {bracode} and cus_num = {cusnum} and cur_code = {curcode} and led_code = {ledcode} and sub_acct_code = {subacct}";
        //    #region old implemenation
        //    using (OracleCommand oracleCommand = new OracleCommand())
        //    {
        //        try
        //        {
        //            if (oracleConnection.State == ConnectionState.Closed)
        //                oracleConnection.Open();
        //            oracleCommand.Connection = oracleConnection;
        //            string getAcctDetails = $"select bal_lim from account where bra_code = {bracode} and cus_num = {cusnum} and cur_code = {curcode} and led_code = {ledcode} and sub_acct_code = {subacct}";
        //            oracleCommand.CommandText = getAcctDetails;
        //            oracleCommand.CommandType = CommandType.Text;
        //            oracleCommand.Parameters.AddWithValue("bracode", (object)bracode);
        //            oracleCommand.Parameters.AddWithValue("cusnum", (object)cusnum);
        //            oracleCommand.Parameters.AddWithValue("curcode", (object)curcode);
        //            oracleCommand.Parameters.AddWithValue("ledcode", (object)ledcode);
        //            oracleCommand.Parameters.AddWithValue("subacct", (object)subacct);
        //            OracleDataReader oracleDataReader;
        //            using (oracleDataReader = oracleCommand.ExecuteReader(CommandBehavior.CloseConnection))
        //            {
        //                if (oracleDataReader.HasRows)
        //                {
        //                    oracleDataReader.Read();
        //                    num = Convert.ToDouble(oracleDataReader["bal_lim"].ToString());
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            ErrHandler.LogError("Error getting Credit Limit from BASIS : " + ex.Message);
        //            num = 1.0;
        //        }
        //        finally
        //        {
        //            if (oracleConnection.State == ConnectionState.Open)
        //                oracleConnection.Close();
        //            oracleConnection.Dispose();
        //        }
        //}


   //}
    }

    public DataTable GetUnprocessedHubAdvance()
    {
        DataTable dataTable = new DataTable();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConString2"]))
        {
            SqlCommand selectCommand = new SqlCommand("SelectHubAdvanceforProcessing", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                sqlDataAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                ErrHandler.LogError(ex.Message);
            }
            finally
            {
                connection.Close();
                sqlDataAdapter.Dispose();
            }
        }
        return dataTable;
    }

    public void UpdateSMEHubAdvanceRequest(string transId, string status, int tra_status)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConString2"]))
        {
            SqlCommand selectCommand = new SqlCommand("UpdateHubAdvanceforProcessing", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Parameters.AddWithValue("@transid", (object)transId);
            selectCommand.Parameters.AddWithValue("@status", (object)status);
            selectCommand.Parameters.AddWithValue("@tra_status", (object)tra_status);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                try
                {
                    selectCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ErrHandler.LogError(ex.Message);
                }
            }
            catch (Exception ex)
            {
                ErrHandler.LogError(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }


    //internal void ProcessSMEHubAdvance()
    //{
    //    throw new NotImplementedException();
    //}

   
    public void UpdateSMEHubCBNRef(string transId, string Reference, int retrycount)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConString2"]))
        {
            SqlCommand selectCommand = new SqlCommand("UpdateHubAdvanceRequestCBNRef", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.Parameters.AddWithValue("@transid", transId);
            selectCommand.Parameters.AddWithValue("@Reference", Reference);
            selectCommand.Parameters.AddWithValue("@count", retrycount);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                try
                {
                    selectCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ErrHandler.LogError(ex.Message);
                }
            }
            catch (Exception ex)
            {
                ErrHandler.LogError(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }

    public double CalculateMonthlyRepaymentAmount(double principal, int tenor, double rate)
    {
        double amount = 0.0;
        double monthlyprincipal = principal;
        for (int i=1; i<=tenor; i++)
        {
            double monthlypayment = (double)(principal / tenor);
            double interest = (double)(monthlyprincipal * (rate / 100)) / tenor;
            double monthlyamount = (double)(monthlypayment + interest);
            amount = amount + monthlyamount;
            monthlyprincipal = (double)(monthlyprincipal - (principal / tenor));
        }
        amount = (double)(amount / 12);
        amount = Math.Round(amount, 2);
        //amount = (double)((principal / tenor) + (principal *(rate/100) * (1 / tenor)));
        return amount;
    }

    public DataTable GetRequestForCBNReference()
    {
        DataTable dataTable = new DataTable();
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConString2"]))
        {
            SqlCommand selectCommand = new SqlCommand("SelectHubAdvanceRequest", connection);
            selectCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                sqlDataAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                ErrHandler.LogError(ex.Message);
            }
            finally
            {
                connection.Close();
                sqlDataAdapter.Dispose();
            }
        }
        return dataTable;
    }

    public string GetStateCode(string state)
    {
        string stateCode = "";
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConString2"]))
        {
            SqlCommand sqlCommand = new SqlCommand("proc_SelectATMStateCode", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@State", (object)state);
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    sqlDataReader.Read();
                    stateCode = sqlDataReader["StateCode"].ToString();
                    ErrHandler.LogError("CBN State " + stateCode);
                }
            }
            catch (Exception ex)
            {
                ErrHandler.LogError(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        return stateCode;
    }

    public static string getCountryStateDetails(
      string bra_code,
      string cus_num,
      string cur_code,
      string led_code,
      string sub_acct_code)
    {
        string country = "";
        using (OracleConnection oracleConnection = new OracleConnection(GTBEncryptLib.DecryptText(ConfigurationManager.AppSettings["BASISConString_eone"].ToString())))
        {
            try
            {
                using (OracleCommand oracleCommand = new OracleCommand())
                {
                    oracleCommand.Connection = oracleConnection;
                    string countryStateDetails = "select  nvl(get_state(" + bra_code + "," + cus_num + "," + cur_code + "," + led_code + "," + sub_acct_code + "),'LAGOS') as state, nvl(get_text(518, get_cou_resi(" + bra_code + "," + cus_num + ")), 'NIGERIA') as country from dual";
                    oracleCommand.CommandText = countryStateDetails;
                    if (oracleConnection.State == ConnectionState.Closed)
                        oracleConnection.Open();
                    OracleDataReader oracleDataReader = oracleCommand.ExecuteReader();
                    if (!oracleDataReader.Read())
                        return "Error Retrieving Details";
                    string readState = oracleDataReader["state"].ToString();
                    country = oracleDataReader["country"].ToString();
                    return readState;
                }
            }
            catch (Exception ex)
            {
                return "Error Retrieving Details Ex " + ex.Message;
            }
            finally
            {
                oracleConnection.Close();
            }
        }
    }

    
    //public void StopStandingInstruction()
    //{   
               
    //    var getaccountstoprocess = new SqlConnect();
    //    DataTable dt = getaccountstoprocess.GetAccountToStop();        
    //    foreach(DataRow dr in dt.Rows)
    //    {
    //        var startstandinginstruction = new Basis();
    //        string nuban = dr["NUBAN"].ToString();
    //        string oldAccountNumber = dr["BALANCE_LIMIT_ACCOUNT_OLDACCOUNT"].ToString();
    //        string bracode = dr["BALANCE_LIMIT_ACCOUNT_OLDACCOUNT"].ToString().Split('/')[0];
    //        string cusnum = dr["BALANCE_LIMIT_ACCOUNT_OLDACCOUNT"].ToString().Split('/')[1];
    //        string subacctcode = dr["BALANCE_LIMIT_ACCOUNT_OLDACCOUNT"].ToString().Split('/')[4];
    //        string query = "select cle_bal from account where bra_code = " + bracode + "and cus_num = " + cusnum + "and cur_code = 1 and led_code =  1010 and sub_acct_code = " + subacctcode;            
    //        string clearingbalance = startstandinginstruction.GetClearingBalance(query);  //Get Clearing balance for each customer 
    //        if (clearingbalance == "0") //If customer has cleared the loan
    //        {
    //            string customerid = dr["CUSTOMER_ID"].ToString();
    //            decimal amountpaid = Convert.ToDecimal(dr["BALANCE_LIMIT_AMOUNT"].ToString());                
    //            string oldaccount = startstandinginstruction.ConvertToNuban(nuban);
    //            StandingInstructionModel standinginstructiondetails = new StandingInstructionModel();
    //            standinginstructiondetails.bracode = Convert.ToDouble(oldaccount.Split('/')[0]);
    //            standinginstructiondetails.cusnum = Convert.ToDouble(oldaccount.Split('/')[1]);
    //            standinginstructiondetails.curcode = Convert.ToDouble(oldaccount.Split('/')[2]);
    //            standinginstructiondetails.ledcode = Convert.ToDouble(oldaccount.Split('/')[3]);
    //            standinginstructiondetails.subacct = Convert.ToDouble(oldaccount.Split('/')[4]);
    //            standinginstructiondetails.payfreq = 4;                
    //            standinginstructiondetails.cre_acct = Convert.ToInt32(oldAccountNumber.Split('/')[0]).ToString("0000") + Convert.ToInt32(oldAccountNumber.Split('/')[1]).ToString("0000000") + Convert.ToInt32(oldAccountNumber.Split('/')[2]).ToString("000") + Convert.ToInt32(oldAccountNumber.Split('/')[3]).ToString("0000") + Convert.ToInt32(oldAccountNumber.Split('/')[4]).ToString("000");
    //            standinginstructiondetails.remarks = ConfigurationManager.AppSettings["StopSIRemark"].ToString();
    //            var sql = new SqlConnect();
    //            var updatecustomerlimit = sql.UpdateCustomerBalanceLimit(customerid, amountpaid); //Update database for cleared loans
    //            if (updatecustomerlimit)
    //            {
    //                ErrHandler.LogError("Customer Balance limit updated successfully");
    //            }
    //            else
    //            {
    //                ErrHandler.LogError("Customer Balance limit was not successfully updated");
    //            }
    //        }
    //    }
    //}
}



