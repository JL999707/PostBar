using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Rule
    {
        public int ruleID { get; set; }
        public string ruleItem { get; set; }

        public Rule() { }

        public Rule(int ruleID, string ruleItem)
        {
            this.ruleID = ruleID;
            this.ruleItem = ruleItem;
        }
    }
}
