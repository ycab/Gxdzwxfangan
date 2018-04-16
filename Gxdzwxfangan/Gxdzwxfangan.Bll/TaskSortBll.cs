using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Gxdzwxfangan.Utilities;
using Gxdzwxfangan.Model;
using Gxdzwxfangan.Dal;
namespace Gxdzwxfangan.Bll
{
    public class TaskSortBll
    {
        TaskSortDal SortInfoDal = new TaskSortDal();
        public string MiddleSortNameInfo()
        {
            string guid = Guid.NewGuid().ToString();
            string responseText = "";
            // int sortnamelast = Convert.ToInt32(sortname_last);//对于null不会报异常,使用int.Parse报异常
            // int sortnameamount = Convert.ToInt32(sortname_amount);
            responseText = SortInfoDal.MiddleSortNameInfo();
            return responseText;
        }
        public Task GetOneTaskInfo(string task_id)
        {
            Task task = new Task();
            string guid = Guid.NewGuid().ToString();
            string responseText = "";
            // int sortnamelast = Convert.ToInt32(sortname_last);//对于null不会报异常,使用int.Parse报异常
            // int sortnameamount = Convert.ToInt32(sortname_amount);
            task = SortInfoDal.GetOneTaskInfo(task_id);
            return task;
        }
        public string GetTaskInfoByField(string application_area)
        {
            string responseText = "";
            responseText = SortInfoDal.GetTaskInfoByField(application_area);
            return responseText;
        }

    }
}
