using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL
{
    public class RuleBll
    {
        DAL.RuleDao dao = new DAL.RuleDao();

        //增加
        public OperationResult ruleAdd(Rule rule)
        {
            Rule temp = dao.QueryRuleItme(rule.ruleItem);
            if (temp == null)
            {
                return OperationResult.exist;
            }
            else
            {
                int rowCount = dao.Add(rule);
                if (rowCount == 1)
                {
                    return OperationResult.success;
                }
                return OperationResult.failure;
            }
        }

        //更新
        public bool Update(Rule rule)
        {
            int rowCount = dao.Update(rule);
            return rowCount == 1 ? true : false;
        }

        //删除
        public bool deletRule(string ruleItem)
        {
            Rule temp = dao.QueryRuleItme(ruleItem);
            if (temp == null)
            {
                return false;
            }
            else
            {
                int rowCount = dao.Delete(ruleItem);
                if (rowCount == 1)
                {
                    return true;
                }
                return false;
            }
        }

        //检索单个所有信息
        public Model.Rule likeCheckAllRule(string ruleItem)
        {
            Model.Rule checkAllRule = dao.QueryRuleItme(ruleItem);

            //不需要访问数据源，直接执行业务逻辑
            if (checkAllRule != null)
            {
                return checkAllRule;
            }
            else
            {
                return checkAllRule;
            }
        }

        //模糊查询
        public List<Rule> CheckRule(string ruleItem, bool isAccurate)
        {
            return dao.likeQueryRuleItem(ruleItem, isAccurate);
        }

        //根据规则相查询某项符合某记录的数量
        public int checkCountRuleItem(string ruleItem)
        {
            int checkCountRuleItem = dao.checkCountRuleItem(ruleItem);
            return checkCountRuleItem;
        }
    }
}
