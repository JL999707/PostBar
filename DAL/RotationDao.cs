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
    public class RotationDao
    {
        IDbHelper db = DBFactory.GetDbHelper();
        public int Add(Rotation rotate)
        {
            string cmdText = "insert into T_Rotation values(@rotID, @rotName, @rotImg)";
            string[] paramList = { "@T_RotationID", "@rotTitle", "@rotImg" };
            object[] valueList = { rotate.rotID, rotate.rotName, rotate.rotImg };
            return db.ExecuteNoneQuery(cmdText, paramList, valueList);
        }

        public int Delete(string rotName)
        {
            string cmdText = "delete from T_Rotation where rotName=@rotName";
            string[] paramList = { "@rotName" };
            object[] valueList = { rotName };
            return db.ExecuteNoneQuery(cmdText, paramList, valueList);
        }

        public int Update(Rotation rotate)
        {
            string cmdText = "update T_Rotation set rotID=@rotID, rotName=@rotNamee,rotImg= @rotImg where rotName=@rotName";
            string[] paramList = { "@rotID", "@rotName", "@rotImg" };
            object[] valuesList = { rotate.rotID, rotate.rotName, rotate.rotImg };
            return db.ExecuteNoneQuery(cmdText, paramList, valuesList);
        }

        public Rotation QueryRotName(string rotName)
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
                rotate.rotImg = reader["rotImg"].ToString();
            }
            reader.Close();
            return rotate;
        }

        public List<Rotation> Query(string rotName, bool isAccurate = false)
        {
            List<Rotation> rotateList = new List<Rotation>();
            DataSet ds = new DataSet();
            if (isAccurate)
            {
                string cmdText = "select * from T_Rotation where rotName=@rotName";
                string[] paramList = { "@rotName" };
                object[] valueList = { rotName };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            else
            {
                string cmdText = "select * from T_Rotation where rotName like @rotName";
                string[] paramList = { "@rotName" };
                object[] valueList = { "%" + rotName + "%" };
                ds = db.FillDataSet(cmdText, paramList, valueList);
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                Rotation rotate = new Rotation(Convert.ToInt32(dr["rotID"]), dr["rotName"].ToString(), dr["rotImg"].ToString());
                rotateList.Add(rotate);
            }
            return rotateList;
        }

        //根据规则相查询某项符合某记录的数量
        //select count(*) from table where 字段 = "";
        public int checkCountRotName(string rotName)
        {
            string cmdText = "select count(*) from  T_Rotation where rotName=@rotName";
            string[] paramList = { "@rotName" };
            object[] valueList = { rotName };
            return Convert.ToInt32(db.ExecuteScalar(cmdText, paramList, valueList));
        }
        //根据rotID查询某项符合某记录的数量
        //select count(*) from table where 字段 = "";
        public int checkCountRotID(int rotID)
        {
            string cmdText = "select count(*) from  T_Rotation where rotID=@rotID";
            string[] paramList = { "@rotID" };
            object[] valueList = { rotID };
            return Convert.ToInt32(db.ExecuteScalar(cmdText, paramList, valueList));
        }
    }
}
