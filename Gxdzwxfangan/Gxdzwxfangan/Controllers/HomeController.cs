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
        public ActionResult MyTaskInfo()
        {
            Task task = new Task();
            task.User_Name = "xingming";
            task.User_ID = "123";
            string json = JsonHelper.SerializeObject(task);
            string responseText = "{\"msg\":\"fail\",\"failinfo\":\"查询出错\"}";
            return Content(json);
        }

    }
}
