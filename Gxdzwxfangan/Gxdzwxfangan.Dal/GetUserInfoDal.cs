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
        public string GetUserID(string openid) //根据openid得到userid
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
        public string GetUserName(string userid,string membership)//根据userid和会员类型得到用户名称
        {
            string sql="";
            if(membership=="个人会员")
            {
                 sql = string.Format("select * from GX_USER_MEMBER_PERSONAL  where USER_ID='{0}' ", userid);

            }else if(membership=="企业会员")
            {
                 sql = string.Format("select * from GX_USER_MEMBER_FACTORY  where USER_ID='{0}' ", userid);
                
            }
            DataTable dt = OracleHelper.GetTable(sql, null);
            string username = "";
            if (dt.Rows.Count != 0)
            {
               username = dt.Rows[0]["NICK_NAME"].ToString();
             }
            else
           {
              username = "none";
           }
           return username;

        }
        public string GetMemberType(string userid)
        {
            string sql = string.Format("select * from GX_USER  where USER_ID='{0}' ", userid);
            DataTable dt = OracleHelper.GetTable(sql, null);
            string membership = "";
            if (dt.Rows.Count != 0)
            {
                membership = dt.Rows[0]["MEMBER_TYPE"].ToString();

            }
            else
            {

            }
            return membership;

        }
    }
}
