using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gxdzwxfangan.Dal;
using Gxdzwxfangan.Model;

namespace Gxdzwxfangan.Bll
{
    public class ReceiveTaskBll
    {
        ReceiveTaskDal taskdal = new ReceiveTaskDal();
        public string ReceiveTask(Task_Receive task)
        {
            string responseText = "";
            responseText = taskdal.ReceiveTask(task);
            return responseText;
        }
        public string IsMyTask(string user_id,string task_id)//判断是否是我自己发的任务
        {
            string resonseText = "";
            resonseText = taskdal.IsMyTask(user_id, task_id);
            return resonseText;
        }
        public string IsReceived(string user_id, string task_id)//判断我是否已经申请过该任务
        {
            string resonseText = "";
            resonseText = taskdal.IsReceived(user_id, task_id);
            return resonseText;
        }
    }
}
