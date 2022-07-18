using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HUBAdvance.Model
{
    class StandingInstructionModel
    {
        public double bracode { get; set; }
        public double cusnum { get; set; }
        public double curcode { get; set; }
        public double ledcode { get; set; }
        public double subacct { get; set; }
        public double payfreq { get; set; }
        public double novdn_flag { get; set; }
        public double paytype { get; set; }
        public DateTime firstpaydate { get; set; }
        public double firstpayamount { get; set; }
        public DateTime lastpaydate { get; set; }
        public string cre_acct { get; set; }
        public string remarks { get; set; }      
                
    }
}
