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
    public class ReceiveTaskDal
    {
        public string ReceiveTask(Task_Receive task)
        {
            var sql = string.Format("insert into GXFW_RECEIVE_TASK(USER_ID,USER_NAME,TASK_ID,IS_ACCEPTED,RECEIVE_TIME,RECEIVE_SUCCESS_TIME) values('{0}','{1}','{2}','{3}','{4}','{5}')",task.User_ID,task.User_Name,task.Task_ID,task.Is_Accepted,task.Receive_Time,task.Receive_Success_Time);
            int flag = OracleHelper.ExecuteNonQuery(sql, null);
            return flag.ToString();
        }
        public string IsMyTask(string user_id,string task_id)//判断是否是我自己发的任务
        {
            string response = "";
            var sql=string.Format("select * from GXFW_SEND_TASK  where USER_ID='{0}' and TASK_ID='{1}'", user_id,task_id);
            DataTable dt = OracleHelper.GetTable(sql, null);
            if(dt.Rows.Count==0)
            {
                response = "no"; 
            }
            else
            {
                response = "yes";
            }
            return response;
        }
        public string IsReceived(string user_id,string task_id)//判断我是否已经申请过该任务
        {
            string response = "";
            var sql = string.Format("select * from GXFW_RECEIVE_TASK  where USER_ID='{0}' and TASK_ID='{1}'", user_id, task_id);
            DataTable dt = OracleHelper.GetTable(sql, null);
            if (dt.Rows.Count == 0)
            {
                response = "no";
            }
            else
            {
                response = "yes";
            }
            return response;
        }

    }
}
