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
    public class SendTaskDal
    {
        public string SendTask(Task task)
        {

            var sql = string.Format("insert into GXFW_SEND_TASK(USER_ID,USER_NAME,TASK_ID,APPLICATION_AREA,TECHNICAL_CLASSIFICATIONCLASS,TASK_NAME,SEND_TIME,DEADLINE,DEMAND_DESCRIPTION,DEMAND_DETAIL,PHONE,PRICE,APPLY_NUMBER,IS_RECEIVED,DEL_FLAG,MEMBERSHIP) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}')", task.User_ID, task.User_Name, task.Task_ID, task.Application_area, task.Technical_Classificationclass, task.Task_Name, task.Send_Time, task.deadline, task.Demand_Description, task.Demand_Detail, task.Phone, task.Price, task.Apply_Number, task.Is_Received, task.Del_Flag,task.Membership);
            int flag = OracleHelper.ExecuteNonQuery(sql, null);
            return flag.ToString();

        }
        public string GetSendTaskNumber(string user_id)
        {
            string sql = string.Format("select * from GXFW_SEND_TASK t where USER_ID='{0}'", user_id);
            DataTable dt = OracleHelper.GetTable(sql, null);
            return dt.Rows.Count.ToString();
        }
        public string GetMySendTaskInfo(string user_id,string is_received)//得到我的发包数量信息
        {
            string sql = string.Format("select * from GXFW_SEND_TASK  where USER_ID='{0}' and IS_RECEIVED='{1}' ", user_id,is_received);
            DataTable dt = OracleHelper.GetTable(sql, null);
            return dt.Rows.Count.ToString();
        }
        public string GetMyReceiveTaskInfo(string user_id, string is_accepted)//得到我的接包数量信息
        {
            string sql = string.Format("select * from GXFW_RECEIVE_TASK  where USER_ID='{0}' and IS_ACCEPTED='{1}' ", user_id,is_accepted);
            DataTable dt = OracleHelper.GetTable(sql, null);
            return dt.Rows.Count.ToString();
        }
        public string UpdateReceiveTaskNumber(string task_id)//跟新发包表中的申请者数量
        {
            string sql = string.Format("select * from GXFW_RECEIVE_TASK  where TASK_ID='{0}' ", task_id);
            DataTable dt = OracleHelper.GetTable(sql, null);
            string sql2 = "update GXFW_SEND_TASK set APPLY_NUMBER=" + dt.Rows.Count.ToString() + " where TASK_ID='" + task_id+"'";
            int flag = OracleHelper.ExecuteNonQuery(sql2, null);
            return "ok";
        }

    }
}
