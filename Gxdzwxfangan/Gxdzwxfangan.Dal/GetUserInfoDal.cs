using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Gxdzwxfangan.Model;
using Gxdzwxfangan.Utilities;
using Gxdzwxfangan.Dal;
using System.Data.OracleClient;


namespace Gxdzwxfangan.Dal
{
    public class GetUserInfoDal
    {
        public string GetUserID(string openid)
        {
            string sql = string.Format("select * from GX_USER  where open_id='{0}' ", openid);
            DataTable dt = OracleHelper.GetTable(sql, null);
            string userid;
            if (dt.Rows.Count != 0)
            {
                userid = dt.Rows[0]["USER_ID"].ToString();
            }
            else
            {
                userid = "none";
            }
            return userid;
        }
        public string GetUserName(string userid)
        {
            string sql = string.Format("select * from GX_USER_MEMBER_PERSONAL  where USER_ID='{0}' ", userid);
            DataTable dt = OracleHelper.GetTable(sql, null);
            string username="";
            if (dt.Rows.Count != 0)
            {
                username = dt.Rows[0]["USER_NAME"].ToString();
            }
            else
            {
                username = "none";
            }
            return username;

        }
    }
}
