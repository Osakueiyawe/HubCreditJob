using GTBEncryptLibrary;
using HUBAdvance.Model;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUBAdvance
{
    class Basis
    {
        public bool GiveStandingInstruction(StandingInstructionModel standinginstruction)
        {
            bool result = false;
            try
            {
                var con = new OracleConnection(GTBEncryptLib.DecryptText(ConfigurationManager.AppSettings["BASISConString_eone"].ToString()));
                if (ConfigurationManager.AppSettings["Environment"].ToString().Trim() == "Test")
                {
                    con = new OracleConnection(ConfigurationManager.AppSettings["Basis"]);
                }
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                using (OracleCommand cmd = new OracleCommand("midwareusr.eonepkg7.stan_ins_add", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.BindByName = true;
                    cmd.Parameters.Add("bra", OracleDbType.Double).Value = standinginstruction.bracode;
                    cmd.Parameters.Add("cus", OracleDbType.Double).Value = standinginstruction.cusnum;
                    cmd.Parameters.Add("cur", OracleDbType.Double).Value = standinginstruction.curcode;
                    cmd.Parameters.Add("Led", OracleDbType.Double).Value = standinginstruction.ledcode;
                    cmd.Parameters.Add("sub", OracleDbType.Double).Value = standinginstruction.subacct;
                    cmd.Parameters.Add("npay_freq", OracleDbType.Double).Value = standinginstruction.payfreq;
                    cmd.Parameters.Add("npaytype", OracleDbType.Double).Value = standinginstruction.paytype;
                    cmd.Parameters.Add("novdn_flag", OracleDbType.Double).Value = standinginstruction.novdn_flag;
                    cmd.Parameters.Add("dfst_pay_date", OracleDbType.Date).Value = standinginstruction.firstpaydate;
                    cmd.Parameters.Add("nfst_pay_amt", OracleDbType.Double).Value = standinginstruction.firstpayamount;
                    cmd.Parameters.Add("dlas_pay_date", OracleDbType.Date).Value = standinginstruction.lastpaydate;
                    cmd.Parameters.Add("scre_acct", OracleDbType.Varchar2, 255).Value = standinginstruction.cre_acct;
                    cmd.Parameters.Add("sremarks", OracleDbType.Varchar2, 255).Value = standinginstruction.remarks;               
                    
                    cmd.Parameters.Add("return_status", OracleDbType.Double).Direction = ParameterDirection.Output;                    
                    cmd.ExecuteNonQuery();
                    string output = cmd.Parameters["return_status"].Value.ToString();
                    ErrHandler.LogError("Return status from standing instruction Procedure is: " + output);
                    if (output == "0")
                    {
                        result = true;
                    }

                }
            }
            catch (Exception ex)
            {
                ErrHandler.LogError(ex.Message);
            }
            return result;
        }

        public string ConvertToOldAccount(string accountno)
        {

            var result = "";       


            

            string query = $"select BRA_CODE, CUS_NUM, CUR_CODE, LED_CODE, SUB_ACCT_CODE from map_acct where MAP_ACC_NO = {accountno}";
            //log info
            //ErrHandler.LogError(string.Format("Started call to ConvertToNuban with Query: {0}, Branch Code: {1}, Customer Number: {2}, Currency Code: {3}, Ledger Code: {4}, Sub Account Code: {5}", query, branchCode, customerNumber, currencyCode, ledgerCode, subAccountCode));


            try
            {

                DataSet ds = null;

                var con = new OracleConnection(GTBEncryptLib.DecryptText(ConfigurationManager.AppSettings["BASISConString_eone"].ToString()));
                if (ConfigurationManager.AppSettings["Environment"].ToString().Trim() == "Test")
                {
                    con = new OracleConnection(ConfigurationManager.AppSettings["Basis"]);
                }

                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                using (var cmd = con.CreateCommand())
                {

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;

                    try
                    {
                        using (var da = new OracleDataAdapter(cmd))
                        {
                            ds = new DataSet();
                            da.Fill(ds);
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrHandler.LogError(ex.Message);
                    }
                }
                

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    result = Convert.ToString(ds.Tables[0].Rows[i]["BRA_CODE"]) + "/" + Convert.ToString(ds.Tables[0].Rows[i]["CUS_NUM"]) + "/" + Convert.ToString(ds.Tables[0].Rows[i]["CUR_CODE"]) + "/" + Convert.ToString(ds.Tables[0].Rows[i]["LED_CODE"]) + "/" + Convert.ToString(ds.Tables[0].Rows[i]["SUB_ACCT_CODE"]);
                }
            }

            }
            catch (Exception ex)
            {
                ErrHandler.LogError(ex.Message);
            }


            //log info
            //ErrHandler.LogError(string.Format("Ended call to ConvertToNuban with Query: {0}, Branch Code: {1}, Customer Number: {2}, Currency Code: {3}, Ledger Code: {4}, Sub Account Code: {5} | Response: {6}", query, branchCode, customerNumber, currencyCode, ledgerCode, subAccountCode, result));


            return result;
        }

        public string GetClearingBalance(string query)
        {
            string result = "";
            try
            {
                OracleConnection OraConn = new OracleConnection(GTBEncryptLib.DecryptText(ConfigurationManager.AppSettings["BASISConString_eone"].ToString()));
                OracleCommand oracomm = new OracleCommand();
                OraConn.Open();
                oracomm.Connection = OraConn;
                oracomm.CommandType = CommandType.Text;
                oracomm.CommandText = query;                
                OracleDataReader oradrread = oracomm.ExecuteReader(CommandBehavior.CloseConnection);
                DataTable dt = new DataTable();
                dt.Load(oradrread);
                result = dt.Rows[0]["cle_bal"].ToString();
            }
            catch (Exception ex)
            {
                ErrHandler.LogError(ex.Message);
            }

            return result;
        }

    }
}
