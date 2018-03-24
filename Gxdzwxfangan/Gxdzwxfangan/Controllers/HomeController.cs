using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gxdzwxfangan.Model;
using Gxdzwxfangan.Bll;
using Gxdzwxfangan.Dal;
using Gxdzwxfangan.Utilities;
namespace Gxdzwxfangan.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult GxfaWxIndex()
        {
            /////获取openid
            return View();
        }
        public ActionResult GxfaWxFl()
        {
            return View();

        }
        public ActionResult GxfaWxPlan()
        {
          
            return View();
        }
        public ActionResult GxfaWxUser()
        {
            return View();
        }
        public ActionResult GxfaWxPlanDetail()
        {
            string task_id = Request["task_id"];
            Session["task_id"] = task_id;
            return View();
        }
        public ActionResult GxfaWxSendPackge()
        {
            return View();
        }
        public ActionResult GxfaWxReceptPackge()
        {
            return View();
        }
        public ActionResult GxfaWxExample()
        {
            return View();
        }
        public ActionResult GxfaWxCheck()
        {
            Task task = new Task();
            
            TaskSortBll SortTaskInfo = new TaskSortBll();
           
            Task_Receive receivetask = new Task_Receive();
            ReceiveTaskDal receivetaskdal = new ReceiveTaskDal();
            SendTaskDal sendtaskdal = new SendTaskDal();
            string task_id = Session["task_id"].ToString();
            task = SortTaskInfo.GetOneTaskInfo(task_id);
            receivetask.User_ID = "";
            receivetask.User_Name = "";
            receivetask.Task_ID = task_id;
            receivetask.Is_Accepted = "1";
            receivetask.Receive_Time = DateTime.Now.ToLocalTime().ToString();
            receivetaskdal.ReceiveTask(receivetask);
            sendtaskdal.UpdateReceiveTaskNumber(task_id);
            return View();
        }
        public ActionResult GetCode()
        {
            return Content("ok");
        }
        public ActionResult SendTask()
        {
            Task task = new Task();
            SendTaskBll send_task = new SendTaskBll();
            string time = DateTime.Now.ToLocalTime().ToString();        // 2008-9-4 20:12:12
            task.User_ID="";
            task.User_Name="";
            task.Task_ID=Guid.NewGuid().ToString();
            task.Application_area=Request["application_area"];
            task.Technical_Classificationclass = Request["techical_classificationclass"];
            task.Task_Name = Request["task_name"];
            task.Send_Time = time;
            task.Demand_Description = Request["demand_description"];
            task.Demand_Detail=Request["detail"];
            task.Phone=Request["phone"];
            task.Price=Request["price"];
            task.Apply_Number="0";
            task.Is_Received="0";
            task.Del_Flag="0";
            send_task.SendTask(task);
            return Content("ok");
        }
        public string MyTaskInfo()
        {
            SendTaskBll send_task = new SendTaskBll();
            MyTaskInfo mytask = new MyTaskInfo();
            mytask=send_task.GetMyTaskInfo("1");
            string json = JsonHelper.SerializeObject(mytask);
            return json;
        }
        public ActionResult MiddleSortNameInfo()
        {
            string responseText = "";
            TaskSortBll SortInfoBll = new TaskSortBll();
            responseText = SortInfoBll.MiddleSortNameInfo();
            return Content(responseText);
        }
        public string GetTaskDetail()
        {
            Task task = new Task();
            string task_id = Session["task_id"].ToString();
            TaskSortBll SortTaskInfo = new TaskSortBll();
            task=SortTaskInfo.GetOneTaskInfo(task_id);
            string json = JsonHelper.SerializeObject(task);
            return json;
        }

    }
}
