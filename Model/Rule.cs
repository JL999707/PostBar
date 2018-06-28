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

        //贡献出自己的自增ID给其他引用自己逐渐的表使用//查询
        public Rule(int ruleID)
        {
            this.ruleID = ruleID;
        }

        //更新//删除 //增加//查询
        public Rule(string ruleItem)
        {
            this.ruleItem = ruleItem;
        }

        //查询//删除
        public Rule(int ruleID, string ruleItem)
        {
            this.ruleID = ruleID;
            this.ruleItem = ruleItem;
        }
    }
}
