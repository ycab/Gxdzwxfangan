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
        GetUserInfoDal getuserinfodal = new GetUserInfoDal();
        public ActionResult GxfaWxIndex(string openid)
        {
            /////获取openid
            if (openid == null)
            {

            }
            else
            {
                ViewBag.openid = openid;
                CookieHelper.ClearCookie("openid");
                CookieHelper.SetCookie("openid", openid);
                string user_id = getuserinfodal.GetUserID(openid);
                if (user_id == "none")
                {
                    Response.Redirect("http://egov.jinyuc.com/gxdzwx/gxdzwxlogin/?openid=oXx_Mw-hx0yNF3wIELsf_RP6cJoA", false);
                }
                Session["user_id"] = user_id;
                Session["user_name"] = user_id;

                //Session["user_id"] = "70";
                //Session["user_name"] = "70";
            }
            return View();
        }
        public ActionResult GxfaWxFl()
        {
           // Response.Redirect("http://egov.jinyuc.com/gxdzwx/gxdzwxlogin/?openid=oXx_Mw-hx0yNF3wIELsf_RP6cJoA", false); 
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
            string send_flag = Request["mytaskinfo"];//发包标志位，1为全部发包，2为已选中，3为已托管，4为已完成
            Session["send_flag"] = send_flag;
            return View();
        }
        public ActionResult GxfaWxReceptPackge()
        {
            string receive_flag = Request["mytaskinfo"];//发包标志位，1为全部发包，2为已选中，3为已托管，4为已完成
            Session["receive_flag"] = receive_flag;
            return View();
        }
        public ActionResult GxfaWxExample()
        {
            Session["task_id"]=Request["task_id"];
            return View();
        }
        public ActionResult GxfaWxExampleReceive()
        {
            Session["task_id"] = Request["task_id"];
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
            receivetask.User_ID = Session["user_id"].ToString();
            receivetask.User_Name = Session["user_name"].ToString();
            receivetask.Task_ID = task_id;
            receivetask.Is_Accepted = "0";
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
            task.User_ID=Session["user_id"].ToString();
            task.User_Name="";
            task.Task_ID=Guid.NewGuid().ToString();
            task.Application_area=Request["application_area"];
            task.Technical_Classificationclass = Request["techical_classificationclass"];
            task.Task_Name = Request["task_name"];
            task.Send_Time = time;
            task.deadline = Request["deadline"];
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
            string user_id = Session["user_id"].ToString();
            mytask=send_task.GetMyTaskInfo(user_id);
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
        public ActionResult MySendTaskListInfo()//我的发包信息
        {
            string send_flag = Session["send_flag"].ToString();
            string responseText = "";
            TaskSortDal SortInfoDal = new TaskSortDal();
            string user_id = Session["user_id"].ToString();
            responseText = SortInfoDal.MySendTaskSortInfo(user_id,send_flag);
            return Content(responseText);
        }
        public ActionResult MyReceiveTaskListInfo()//我的发包信息
        {
            string receive_flag = Session["receive_flag"].ToString();
            string responseText = "";
            TaskSortDal SortInfoDal = new TaskSortDal();
            string user_id = Session["user_id"].ToString();
            responseText = SortInfoDal.MyReceiveTaskSortInfo(user_id, receive_flag);
            return Content(responseText);
        }
    }
}
