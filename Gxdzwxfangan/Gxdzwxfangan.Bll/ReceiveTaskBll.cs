using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gxdzwxfangan.Dal;
using Gxdzwxfangan.Model;

namespace Gxdzwxfangan.Bll
{
    class ReceiveTaskBll
    {
        ReceiveTaskDal taskdal = new ReceiveTaskDal();
        public string ReceiveTask(Task_Receive task)
        {
            string responseText = "";
            responseText = taskdal.ReceiveTask(task);
            return responseText;
        }
    }
}
