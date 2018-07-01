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
    public class NoticeDao
    {
        IDbHelper db = DBFactory.GetDbHelper();
        public int Add(Notice notice)
        {
            string cmdText = "insert into T_Notice values(@noticeID, @notiTitle, @noticeContent,@noticeTime)";
            string[] paramList = { "@noticeID", "@notiTitle", "@noticeContent", "@noticeTime" };
            object[] valueList = { notice.noticeID, notice.noticeName, notice.noticeContent, notice.noticeTime };
            return db.ExecuteNoneQuery(cmdText, paramList, valueList);
        }

        public int Delete(string noticeName)
        {
            string cmdText = "delete from T_Notice where noticeName=@noticeName";
            string[] paramList = { "@noticeName" };
            object[] valueList = { noticeName };
            return db.ExecuteNoneQuery(cmdText, paramList, valueList);
        }

        public int Update(Notice notice)
        {
            string cmdText = "update T_Notice set noticeID=@noticeID, noticeName=@noticeName, noticeContent=@noticeContent,noticeTime=@noticeTime where notiTitle=@notiTitle,";
            string[] paramList = { "@noticeID", "@noticeName", "@noticeContent", "@noticeTime" };
            object[] valuesList = { notice.noticeID, notice.noticeName, notice.noticeContent, notice.noticeTime };
            return db.ExecuteNoneQuery(cmdText, paramList, valuesList);
        }

        public Notice Query(string noticeName)
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
                notice.noticeContent = reader["noticeContent"].ToString();
                notice.noticeTime = reader["noticeTime"].ToString();
            }
            reader.Close();
            return notice;
        }

        public List<Notice> Query(string noticeName, bool isAccurate = false)
        {
            List<Notice> noticeList = new List<Notice>();
            DataSet ds = new DataSet();
            if (isAccurate)
            {
                string cmdText = "select * from T_Notice where noticeName=@noticeName";
                string[] paramList = { "@noticeName" };
                object[] valueList = { noticeName };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            else
            {
                string cmdText = "select * from T_Notice where noticeName like @noticeName";
                string[] paramList = { "@noticeName" };
                object[] valueList = { "%" + noticeName + "%" };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                Notice notice = new Notice(Convert.ToInt32(dr["noticeID"]), dr["noticeName"].ToString(), dr["noticeContent"].ToString(), dr["noticeTime"].ToString());
                noticeList.Add(notice);
            }
            return noticeList;
        }

        //根据公告名称查询某项符合某记录的数量
        //select count(*) from table where 字段 = "";
        public int checkCountNoticeName(string noticeName)
        {
            string cmdText = "select count(*) from  T_Notice where noticeName=@noticeName";
            string[] paramList = { "@noticeName" };
            object[] valueList = { noticeName };
            return Convert.ToInt32(db.ExecuteScalar(cmdText, paramList, valueList));
        }
        //根据noticeID查询某项符合某记录的数量
        //select count(*) from table where 字段 = "";
        public int checkCountNoticeID(int noticeID)
        {
            string cmdText = "select count(*) from  T_Notice where noticeID=@noticeID";
            string[] paramList = { "@noticeID" };
            object[] valueList = { noticeID };
            return Convert.ToInt32(db.ExecuteScalar(cmdText, paramList, valueList));
        }
    }
}
