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
    }
}
