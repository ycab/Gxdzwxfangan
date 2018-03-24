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

    }
}
