using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUBAdvance
{
    class SqlConnect
    {
        public DataTable GetAccountToStop()
        {

            SqlConnection sqlcon = new SqlConnection(ConfigurationManager.AppSettings["ConString2"]);
            DataTable dt = new DataTable();
            try
            {
                if (sqlcon.State != ConnectionState.Open)
                {
                    sqlcon.Open();
                }
                SqlCommand sqlcmd = new SqlCommand("StopHubCreditStandingInstruction", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sdap = new SqlDataAdapter(sqlcmd);
                sdap.Fill(dt);
            }
            catch (Exception ex)
            {
                ErrHandler.LogError(ex.Message);
            }


            return dt;
        }       

        public bool UpdateCustomerBalanceLimit(string customerid, decimal amount)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConString2"].ToString()))

                {
                    conn.Open();
                    string query = $"UPDATE HubAdvanceRepayment set [REPAYMENT_AMOUNT] = 0 , [NUMBER_OF_REPAYMENT] = [NUMBER_OF_REPAYMENT]+13, [TOTAL_PAID]= [TOTAL_PAID]+ {amount}  where CUSTOMERID = {customerid}; UPDATE [HUBADVANCEMONTHLYRECONCILIATION] SET [PAYMENTNUMBER] = [PAYMENTNUMBER]+13, DATEPAIDONBASIS = GETDATE() WHERE [CUSTOMERID] = {customerid};";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    int res = cmd.ExecuteNonQuery();
                    result = true;
                }
            }
            catch(Exception ex)
            {
                ErrHandler.LogError(ex.Message);
            }
            return result;
        }
    }
}
