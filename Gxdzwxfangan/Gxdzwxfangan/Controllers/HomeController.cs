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
                openid = "oXx_Mw-hx0yNF3wIELsf_RP6cJoA";
                string user_id = getuserinfodal.GetUserID(openid);
                string username = getuserinfodal.GetUserName(user_id);
                CookieHelper.ClearCookie("openid");
                CookieHelper.SetCookie("openid", openid);
                Session["user_id"] = user_id;
                Session["user_name"] = username;
                string url1 = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;//获取当前url端木雲 2018/3/26 21:22:46
                string url2 = "http://egov.jinyuc.com/gxdzwx/gxdzwxlogin/?openid= " + openid + "&url1=" + url1;
                Session["RegisterUrl"] = url2;
                string url3 = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;//获取当前url端木雲 2018/3/26 21:22:46
                string url4 = "http://egov.jinyuc.com/gxdzwx/gxdzwxlogin/Register/GxLoginRegisterPersonal/?openid= " + openid + "&url1=" + url3;
                Session["FinishRegisterUrl"] = url4;
                ViewBag.openid = openid;
            }
            else
            {
                ViewBag.openid = openid;
                CookieHelper.ClearCookie("openid");
                CookieHelper.SetCookie("openid", openid);
                string url1 = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;//获取当前url端木雲 2018/3/26 21:22:46
                string url2 = "http://egov.jinyuc.com/gxdzwx/gxdzwxlogin/?openid= " + openid + "&url1=" + url1;
                Session["url"] = url2;
                string user_id = getuserinfodal.GetUserID(openid);
                if (user_id == "none")
                {

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
        public ActionResult GxfaWxFl2()
        {
            string application_area = Request["application_area"];
            Session["application_area"] = application_area;
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
            string receive_flag = Request["mytaskinfo"];//接包标志位，1为全部发包，2为已选中，3为已托管，4为已完成
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
            string openid = CookieHelper.GetCookieValue("openid");
            string user_id = getuserinfodal.GetUserID(openid);
            if (user_id == "none")
            {
                string url1 = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;//获取当前url端木雲 2018/3/26 21:22:46
                string url2 = "http://egov.jinyuc.com/gxdzwx/gxdzwxlogin/?openid= " + openid + "&url1=" + url1;
                string url = Session["url"].ToString();
                Response.Redirect(url, false); 
                //  Session["rediret_url"] = url2;
                //非会员，跳转登陆页面
               // System.Web.HttpContext.Current.Response.Redirect(url3);
                return View();
                //return Content("fail");
            }
            else
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

        }
        public ActionResult GetCode()
        {
            return Content("ok");
        }
        public ActionResult SendTask()
        {
            string openid=CookieHelper.GetCookieValue("openid");
            string user_id = getuserinfodal.GetUserID(openid);
            if (user_id == "none")
            {
                    string url1 = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;//获取当前url端木雲 2018/3/26 21:22:46
                    string url2 = "http://egov.jinyuc.com/gxdzwx/gxdzwxlogin/?openid= " + openid + "&url1=" + url1;
                   // string url3=" http://www.baidu.com/index.html";
                  //  Session["rediret_url"] = url2;
                    //非会员，跳转登陆页面
                    //System.Web.HttpContext.Current.Response.Redirect(url3);
                    //return View();
                    //Response.Redirect(url2, false);
                    return Content("fail");
             }
            else
            {
                Session["user_id"] = user_id;
                Session["user_name"] = user_id;
                Task task = new Task();
                SendTaskBll send_task = new SendTaskBll();
                string time = DateTime.Now.ToLocalTime().ToString();        // 2008-9-4 20:12:12
                task.User_ID = Session["user_id"].ToString();
                task.User_Name = "";
                task.Task_ID = Guid.NewGuid().ToString();
                task.Application_area = Request["application_area"];
                task.Technical_Classificationclass = Request["techical_classificationclass"];
                task.Task_Name = Request["task_name"];
                task.Send_Time = time;
                task.deadline = Request["deadline"];
                task.Demand_Description = Request["demand_description"];
                task.Demand_Detail = Request["detail"];
                task.Phone = Request["phone"];
                task.Price = Request["price"];
                task.Apply_Number = "0";
                task.Is_Received = "0";
                task.Del_Flag = "0";
                send_task.SendTask(task);
                return Content("ok");
            }

        }
        public string MyTaskInfo()//我的接发包数量
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
        public ActionResult Rediret()
        {
            string openid = CookieHelper.GetCookieValue("openid");
            string user_id = getuserinfodal.GetUserID(openid);
            string url1 = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;//获取当前url端木雲 2018/3/26 21:22:46
            string url2 = "http://egov.jinyuc.com/gxdzwx/gxdzwxlogin/?openid= " + openid + "&url1=" + url1;
            string url = Session["url"].ToString();
            System.Web.HttpContext.Current.Response.Redirect(url);
            //return View();
            return View();
        }
        public ActionResult GetTaskListByField()
        {
            string application_area = Session["application_area"].ToString();
            TaskSortBll sorttaskinfo = new TaskSortBll();
            string responseText = "";
            responseText = sorttaskinfo.GetTaskInfoByField(application_area);
            return Content(responseText);
        }
    }
}
