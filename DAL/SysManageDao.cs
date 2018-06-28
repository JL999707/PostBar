using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbHelper;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class SysManageDao
    {
        IDbHelper db = DBFactory.GetDbHelper();
        public int Add(SysManage sysMana)
        {
            string cmdText = "insert into T_SysManage values(@sysManaID, @rotID,@noticeID,@barTypeID,@manaTime)";
            string[] paramList = { "@sysManaID", "@rotID", "@noticeID", "@barTypeID", "@manaTime" };
            object[] valueList = { sysMana.sysManaID, sysMana.rotID, sysMana.noticeID, sysMana.barTypeID,sysMana.manaTime};
            return db.ExecuteNoneQuery(cmdText, paramList, valueList);
        }

        public int Delete(int sysManaID)
        {
            string cmdText = "delete from T_SysManage where sysManaID=@sysManaID";
            string[] paramList = { "@sysManaID" };
            object[] valueList = { sysManaID };
            return db.ExecuteNoneQuery(cmdText, paramList, valueList);
        }

        public int Update(SysManage sysMana)
        {
            string cmdText = "update T_SysManage set sysManaID=@sysManaID, rotID=@rotID,noticeID=@noticeID,barTypeID=@barTypeID,manaTime=@manaTime";
            string[] paramList = { "@sysManaID", "@rotID", "@noticeID", "@barTypeID", "@manaTime" };
            object[] valuesList = { sysMana.sysManaID, sysMana.rotID, sysMana.noticeID, sysMana.barTypeID,sysMana.manaTime};
            return db.ExecuteNoneQuery(cmdText, paramList, valuesList);
        }

        public SysManage Query(int sysManaID)
        {
            string cmdText = "select * from T_SysManage where sysManaID=@sysManaID";
            string[] paramList = { "@sysManaID" };
            object[] valueList = { sysManaID };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            SysManage sysMana = new SysManage();
            if (reader.Read())
            {
                sysMana.sysManaID = sysManaID;
                sysMana.rotID = Convert.ToInt32(reader["rotID"]);
                sysMana.noticeID = Convert.ToInt32(reader["noticeID"]);
                sysMana.barTypeID = Convert.ToInt32(reader["barTypeID"]);
            }
            reader.Close();
            return sysMana;
        }

        public List<SysManage> Query(int sysManaID, bool isAccurate = false)
        {
            List<SysManage> sysManaList = new List<SysManage>();
            DataSet ds = new DataSet();
            if (isAccurate)
            {
                string cmdText = "select * from T_SysManage where sysManaID=@sysManaID";
                string[] paramList = { "@sysManaID" };
                object[] valueList = { sysManaID };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            else
            {
                string cmdText = "select * from T_SysManage where sysManaID like @sysManaID";
                string[] paramList = { "@sysManaID" };
                object[] valueList = { "%" + sysManaID + "%" };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                SysManage sysMana = new SysManage(Convert.ToInt32(dr["sysManaID"]), Convert.ToInt32(dr["rotID"]), Convert.ToInt32(dr["noticeID"]), Convert.ToInt32(dr["barTypeID"]),dr["manaTime"].ToString());
                sysManaList.Add(sysMana);
            }
            return sysManaList;
        }

        public SysManage QuerySysManaID(int sysManaID)//根据sysManaID查询
        {
            string cmdText = "select * from T_SysManage where sysManaID=@sysManaID";
            string[] paramList = { "@sysManaID" };
            object[] valueList = { sysManaID };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            SysManage sysMana = new SysManage();
            if (reader.Read())
            {
                sysMana.sysManaID = sysManaID;
                sysMana.rotID = Convert.ToInt32(reader["rotID"]);
                sysMana.noticeID = Convert.ToInt32(reader["noticeID"]);
                sysMana.barTypeID = Convert.ToInt32(reader["barTypeID"]);
                sysMana.manaTime = reader["manaTime"].ToString();
            }
            reader.Close();
            return sysMana;
        }
        public SysManage QueryRotID(int rotID)//根据rotID查询
        {
            SysManage sysMana = new SysManage();
            string cmdText = "select * from T_SysManage where rotID=@rotID";
            string[] paramList = { "@rotID" };
            object[] valueList = { rotID };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            if (reader.Read())
            {
                sysMana.rotID = rotID;
                sysMana.sysManaID = Convert.ToInt32(reader["sysManaID"]);
                sysMana.noticeID = Convert.ToInt32(reader["noticeID"]);
                sysMana.barTypeID = Convert.ToInt32(reader["barTypeID"]);
                sysMana.manaTime = reader["manaTime"].ToString();
            }
            reader.Close();
            return sysMana;
        }
        public SysManage QueryNoticeID(int noticeID)//根据noticeID查询
        {
            SysManage sysMana = new SysManage();
            string cmdText = "select * from T_SysManage where noticeID=@noticeID";
            string[] paramList = { "@noticeID" };
            object[] valueList = { noticeID };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            if (reader.Read())
            {
                sysMana.noticeID = noticeID;
                sysMana.sysManaID = Convert.ToInt32(reader["sysManaID"]);
                sysMana.noticeID = Convert.ToInt32(reader["noticeID"]);
                sysMana.barTypeID = Convert.ToInt32(reader["barTypeID"]);
                sysMana.manaTime = reader["manaTime"].ToString();

            }
            reader.Close();
            return sysMana;
        }
        public SysManage QueryBarTypeID(int barTypeID)//根据barTypeID查询
        {
            SysManage sysMana = new SysManage();
            string cmdText = "select * from T_SysManage where barTypeID=@barTypeID";
            string[] paramList = { "@barTypeID" };
            object[] valueList = { barTypeID };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            if (reader.Read())
            {
                sysMana.barTypeID = barTypeID;
                sysMana.sysManaID = Convert.ToInt32(reader["sysManaID"]);
                sysMana.noticeID = Convert.ToInt32(reader["noticeID"]);
                sysMana.barTypeID = Convert.ToInt32(reader["barTypeID"]);
                sysMana.manaTime = reader["manaTime"].ToString();
            }
            reader.Close();
            return sysMana;
        }

        //根据轮播名称得到轮播ID
        public Rotation getRotID(string rotName)
        {
            string cmdText = "select * from T_Rotation where rotName=@rotName";
            string[] paramList = { "@rotName" };
            object[] valueList = { rotName };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            Rotation rotate = new Rotation();
            if (reader.Read())
            {
                rotate.rotName = rotName;
                rotate.rotID = Convert.ToInt32(reader["rotID"]);
            }
            reader.Close();
            return rotate;
        }
        //根据公告名称得到公告ID
        public Notice getNoticeID(string noticeName)
        {
            string cmdText = "select * from T_Notice where noticeName=@noticeName";
            string[] paramList = { "@noticeName" };
            object[] valueList = { noticeName };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            Notice notice = new Notice();
            if (reader.Read())
            {
                notice.noticeName = noticeName;
                notice.noticeID = Convert.ToInt32(reader["noticeID"]);
            }
            reader.Close();
            return notice;
        }
        //根据贴吧类型名称得到贴吧类型ID
        public Model.BarType getBarTypeID(string barTypeName)
        {
            string cmdText = "select * from T_BarType where barTypeName=@barTypeName";
            string[] paramList = { "@barTypeName" };
            object[] valueList = { barTypeName };
            SqlDataReader reader = db.ExecuteReader(cmdText, paramList, valueList);
            Model.BarType barType = new Model.BarType();
            if (reader.Read())
            {
                barType.barTypeName = barTypeName;
                barType.barTypeID = Convert.ToInt32(reader["barTypeID"]);
            }
            reader.Close();
            return barType;
        }

        //根据rotID查询某项符合某记录的数量
        //select count(*) from table where 字段 = "";
        public int checkCountRotID(int rotID)
        {
            string cmdText = "select count(*) from  T_SysManage where rotID=@rotID";
            string[] paramList = { "@rotID" };
            object[] valueList = { rotID };
            return Convert.ToInt32(db.ExecuteScalar(cmdText, paramList, valueList));
        }
        //根据noticeID查询某项符合某记录的数量
        //select count(*) from table where 字段 = "";
        public int checkCountNoticeID(int noticeID)
        {
            string cmdText = "select count(*) from  T_SysManage where noticeID=@noticeID";
            string[] paramList = { "@noticeID" };
            object[] valueList = { noticeID };
            return Convert.ToInt32(db.ExecuteScalar(cmdText, paramList, valueList));
        }
        //根据barTypeID查询某项符合某记录的数量
        //select count(*) from table where 字段 = "";
        public int checkCountBarTypeID(int barTypeID)
        {
            string cmdText = "select count(*) from  T_SysManage where barTypeID=@barTypeID";
            string[] paramList = { "@barTypeID" };
            object[] valueList = { barTypeID };
            return Convert.ToInt32(db.ExecuteScalar(cmdText, paramList, valueList));
        }
    }
}
