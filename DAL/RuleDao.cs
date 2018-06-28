using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbHelper;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class RuleDao
    {
        IDbHelper db = DBFactory.GetDbHelper();
        public int Add(Model.Rule rule)
        {
            string cmdText = "insert into T_Rule values(@ruleID, @ruleItem)";
            string[] paramList = { "@ruleID", "@ruleItem" };
            object[] valueList = { rule.ruleID, rule.ruleItem };
            return db.ExecuteNoneQuery(cmdText, paramList, valueList);
        }

        public int Delete(string ruleItem)
        {
            string cmdText = "delete from  T_Rule where ruleItem=@ruleItem";
            string[] paramList = { "@ ruleItem" };
            object[] valueList = { ruleItem };
            return db.ExecuteNoneQuery(cmdText, paramList, valueList);
        }

        public int Update(Model.Rule rule)
        {
            string cmdText = "update T_Rule set ruleID=@ruleID, ruleItem=@ruleItem where ruleItem=@ruleItem";
            string[] paramList = { "@ruleID", "@ruleItem" };
            object[] valuesList = { rule.ruleID, rule.ruleItem };
            return db.ExecuteNoneQuery(cmdText, paramList, valuesList);
        }

        public Model.Rule QueryRuleItme(string ruleItem)
        {
            string cmdText = "select * from T_Rule where ruleItem=@ruleItem";
            string[] paramList = { "@ruleItem" };
            object[] valueList = { ruleItem };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            Model.Rule rule = new Model.Rule();
            if (reader.Read())
            {
                rule.ruleItem = ruleItem;
                rule.ruleID = Convert.ToInt32(reader["ruleID"]);
            }
            reader.Close();
            return rule;
        }

        public List<Model.Rule> likeQueryRuleItem(string ruleItem, bool isAccurate = false)
        {
            List<Model.Rule> ruleList = new List<Model.Rule>();
            DataSet ds = new DataSet();
            if (isAccurate)
            {
                string cmdText = "select * from T_Rule where ruleItem=@ruleItem";
                string[] paramList = { "@ruleItem" };
                object[] valueList = { ruleItem };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            else
            {
                string cmdText = "select * from T_Rule where ruleItem like @ruleItem";
                string[] paramList = { "@ruleItem" };
                object[] valueList = { "%" + ruleItem + "%" };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                Model.Rule rule = new Model.Rule(Convert.ToInt32(dr["ruleID"]), dr["ruleItem"].ToString());
                ruleList.Add(rule);
            }
            return ruleList;
        }

        //根据规则相查询某项符合某记录的数量
        //select count(*) from table where 字段 = "";
        public int checkCountRuleItem(string RuleItem)
        {
            string cmdText = "select count(*) from  T_Rule where RuleItem=@RuleItem";
            string[] paramList = { "@RuleItem" };
            object[] valueList = { RuleItem };
            return Convert.ToInt32(db.ExecuteScalar(cmdText, paramList, valueList));
        }
    }
}
