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

            var sql = string.Format("insert into GXFW_SEND_TASK(USER_ID,USER_NAME,TASK_ID,APPLICATION_AREA,TECHNICAL_CLASSIFICATIONCLASS,TASK_NAME,SEND_TIME,DEADLINE,DEMAND_DESCRIPTION,DEMAND_DETAIL,PHONE,PRICE,APPLY_NUMBER,IS_RECEIVED,DEL_FLAG) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}')", task.User_ID, task.User_Name, task.Task_ID, task.Application_area, task.Technical_Classificationclass, task.Task_Name, task.Send_Time, task.deadline, task.Demand_Description, task.Demand_Detail, task.Phone, task.Price, task.Apply_Number, task.Is_Received, task.Del_Flag);
            int flag = OracleHelper.ExecuteNonQuery(sql, null);
            return flag.ToString();

        }
        public string GetSendTaskNumber(string user_id)
        {
            string sql = string.Format("select * from GXFW_SEND_TASK t where USER_ID='{0}' order by t.SORT_ORDER asc", user_id);
            DataTable dt = OracleHelper.GetTable(sql, null);
            return dt.Rows.Count.ToString();
        }
    }
}
