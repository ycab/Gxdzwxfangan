using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gxdzwxfangan.Dal;
using Gxdzwxfangan.Model;
namespace Gxdzwxfangan.Bll
{
    public class SendTaskBll 
    {
        SendTaskDal  taskinfo= new SendTaskDal();
        public string SendTask(Task task)
        {
            string responseText = "";
            responseText = taskinfo.SendTask(task);
            return responseText;
        }
        public string GetSendTaskNumber(string user_id)
        {
            string responseText = "";
            responseText = taskinfo.GetSendTaskNumber(user_id);
            return responseText;
        }
        public MyTaskInfo GetMyTaskInfo(string user_id)//得到我的接发包信息
        {
            MyTaskInfo task = new MyTaskInfo();
            task.SendTaskSelected = taskinfo.GetMySendTaskInfo(user_id, "1");
            task.SendTaskHosting = taskinfo.GetMySendTaskInfo(user_id, "3");
            task.SendTaskFinished = taskinfo.GetMySendTaskInfo(user_id, "4");
            task.ReceiveTaskSelected = taskinfo.GetMyReceiveTaskInfo(user_id, "1");
            task.ReceiveTaskHosting = taskinfo.GetMyReceiveTaskInfo(user_id, "3");
            task.ReceiveTaskFinished = taskinfo.GetMyReceiveTaskInfo(user_id, "4");
            return task;
        }
    }
}
