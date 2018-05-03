using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gxdzwxfangan.Model;
using Gxdzwxfangan.Bll;
using Gxdzwxfangan.Dal;
using Gxdzwxfangan.Utilities;
using System.IO;
namespace Gxdzwxfangan.Controllers
{
    public class HomeController : Controller
    {
        GetUserInfoDal getuserinfodal = new GetUserInfoDal();


        public string index1()
        {
            string mobile = Request["mobile"];
            ValidataCodeParameter valicodepara = new ValidataCodeParameter();
            ValidateResultMsg result = new ValidateResultMsg();
            //业务办理进度
            //    模版CODE:SMS_89665068
            //模版内容:您好，您申请的${type}业务办理进度状态有更新，请及时查看！
            //验证码
            //    模版CODE:SMS_129757561
            //模版内容:您的验证码为:${code},该验证码5分钟内有效,请勿泄露于他人。
            string validatecode = new Random().Next(111111, 999999).ToString();
            string temppar = "{'code':'" + validatecode + "'}";
            //    string temppar = "{'type':'视频'}";
            //  string code = "SMS_89665068";//我的业务进度
             string code = "SMS_130915976";//电子联盟
     //       string code = "SMS_129757561";//我的短信验证码
             string accesskeyid = "LTAIcI6HnskaEPcd";//电子联盟账号
             string accesskeysecret = "8msoPHZT60r2RFkywOwU96wteISnFu";//电子联盟密码
             string signame = "蓝联盟众创空间";
         //   string accesskeyid = "LTAI2pVIR8OKNxPv";//我的
        //    string accesskeysecret = "v3aEoHynOoxkG2uVyArUfaJzCItrSj";//我的
          //  string signame = "乐意为";
             valicodepara.AccessKeyId = accesskeyid;
             valicodepara.AccessKeySecret = accesskeysecret;
             valicodepara.SignName = signame;
             valicodepara.TemplateCode = code;
             valicodepara.Mobile = mobile;
             valicodepara.TemplateParam = temppar;
             result = SmsHelper.FlexVerificationCode(valicodepara);

             ViewBag.statuscode = result.StatusCode;
             ViewBag.info = result.Info;
            ViewBag.validatecode = validatecode;
            return validatecode;     
          }
        public ActionResult GxfaWxIndex(string openid)
        {
            /////获取openid
            if (openid == null)
            {

                ////openid = "oXx_Mw7JSzz218WpGTprNfSaHC7k";//鹏伟峰
                openid = "oXx_Mw-hx0yNF3wIELsf_RP6cJoA";//我的
                string user_id = getuserinfodal.GetUserID(openid);
                string username = getuserinfodal.GetUserName(user_id);
                CookieHelper.ClearCookie("openid");
                CookieHelper.SetCookie("openid", openid);
                Session["user_id"] = user_id;
                Session["user_name"] = username;
                string url1 = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;//获取当前url端木雲 2018/3/26 21:22:46
                string url2 = "http://egov.jinyuc.com/gxdzwx/gxdzwxlogin/?openid= " + openid + "&url1=" + url1;
                Session["RegisterUrl"] = url2;
                Session["url"] = url2;
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
            string navid = Request["navid"];
            ViewBag.navid = navid;
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
            string openid = CookieHelper.GetCookieValue("openid");
            string user_id = getuserinfodal.GetUserID(openid);
            string user_name = getuserinfodal.GetUserName(user_id);
            string membership = getuserinfodal.GetMemberType(user_id);
            if (user_id == "none")
            {
                string url1 = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;//获取当前url端木雲 2018/3/26 21:22:46
                string url2 = "http://egov.jinyuc.com/gxdzwx/gxdzwxlogin/?openid= " + openid + "&url1=" + url1;
               // string url = Session["url"].ToString();
                Response.Redirect(url2, false);
                //  Session["rediret_url"] = url2;
                //非会员，跳转登陆页面
                // System.Web.HttpContext.Current.Response.Redirect(url3);
                return View();
                //return Content("fail");
            }
            else if (membership != "个人会员")
            {
                System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert(\"企业会员无法接包\")" + "</script>");
                return View("GxFaWxFl");
            }
            else if (user_name == "")
            {
                System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert(\"请先完善会员信息\")" + "</script>");
                return View("GxFaWxPersonal");
            }
            else
            {
                return View();
            }
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
            Task task = new Task();
            Task_Receive receivetask = new Task_Receive();
            TaskSortBll SortTaskInfo = new TaskSortBll();
            ReceiveTaskBll receivetaskbll = new ReceiveTaskBll();
            SendTaskBll sendtaskbll = new SendTaskBll();
            string openid = CookieHelper.GetCookieValue("openid");
            string user_id = getuserinfodal.GetUserID(openid);
            string user_name = getuserinfodal.GetUserName(user_id);
            string membership = getuserinfodal.GetMemberType(user_id);
            string task_id = Session["task_id"].ToString();
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
            else if(membership!="个人会员")
            {
                System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert(\"企业会员无法接包\")" + "</script>");
                return View("GxFaWxFl");
            }

             else if(user_name=="")
            {
                System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert(\"请先完善会员信息\")" + "</script>");
                return View("GxFaWxPersonal");
            }
            else if(receivetaskbll.IsMyTask(user_id,task_id)=="yes")
            {
                System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert(\"申请失败，无法申请您自己的项目\")" + "</script>");
                return View("GxFaWxFl");
            }
            else if(receivetaskbll.IsReceived(user_id,task_id)=="yes")
            {
                System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert(\"申请失败，您已申请过该项目\")" + "</script>");
                return View("GxFaWxFl");
            }

            else
            {
                task = SortTaskInfo.GetOneTaskInfo(task_id);
                receivetask.User_ID = user_id;
                receivetask.User_Name = user_name;
                receivetask.Task_ID = task_id;
                receivetask.Is_Accepted = "0";
                receivetask.Receive_Time = DateTime.Now.ToLocalTime().ToString();
                receivetaskbll.ReceiveTask(receivetask);
                sendtaskbll.UpdateReceiveTaskNumber(task_id);
                System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert(\"申请成功，等待审核\")" + "</script>");
                return View("GxfaWxFl");
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
            string user_name = getuserinfodal.GetUserName(user_id);

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
        public ActionResult RediretToFinish()
        {
            return View("GxFaWxPersonal");
        }
        public ActionResult GetTaskListByField()
        {
            string application_area = Session["application_area"].ToString();
            TaskSortBll sorttaskinfo = new TaskSortBll();
            string responseText = "";
            responseText = sorttaskinfo.GetTaskInfoByField(application_area);
            return Content(responseText);
        }
        public ActionResult GetSomeTask()//得到首页的一些需求任务
        {
            TaskSortBll sorttaskinfo = new TaskSortBll();
            string responseText = "";
            responseText = sorttaskinfo.GetSomeTask();
            return Content(responseText);
        }
        public ActionResult SetPersonalInfo(PersonalInfoModel Personal)
        {
            LoginBll LoginInfoBll = new LoginBll();
            string responseText = "";
            GetUserInfoDal getuserinfodal = new GetUserInfoDal();
            string openid = CookieHelper.GetCookieValue("openid");
            string user_id = getuserinfodal.GetUserID(openid);
            string fileExt = "";
            List<string> filename = new List<string>();
            //string chat_head_name = Request["chat_head_name"];
            //string id_card_name = Request["id_card_name"];
            int cnt = System.Web.HttpContext.Current.Request.Files.Count;
            for (int i = 0; i < cnt; i++)
            {
                HttpPostedFile hpf = System.Web.HttpContext.Current.Request.Files[i];
                string filenames = Path.GetFileName(hpf.FileName);
                fileExt = Path.GetExtension(hpf.FileName).ToLower();//带.的后缀
                filename.Add(filenames);
                string fileFilt = ".jpg|.jpeg|.png|.JPG|.PNG|......";
                if ((fileFilt.IndexOf(fileExt) <= -1) || (fileExt == "") || (hpf.ContentLength > 4 * 1024 * 1024))
                    continue;
                //  string filepath = HttpContext.Server.MapPath("../xwhz_uploadimages/template/" + filenames);
                ///string filepath = context.Server.MapPath("E:\\inetpub\\wwwroot\\sj_uploadimage\\ZJZ_PIC\\" + hpf.FileName);
                if (i == 0)
                {
                    hpf.SaveAs("D:\\MVCRoot\\gxdzwx\\gxdzimages\\gxdzwxlogin\\personal\\chat_head\\" + filenames);
                    //                    hpf.SaveAs("G:\\Visual Studio\\image\\" + filenames);
                }
                if (i == 1)
                {
                    hpf.SaveAs("D:\\MVCRoot\\gxdzwx\\gxdzimages\\gxdzwxlogin\\personal\\id_card\\" + filenames);
                    //                    hpf.SaveAs("G:\\Visual Studio\\image\\" + filenames);
                }
                //               hpf.SaveAs("G://Visual Studio//IMP");
                //  var mappedPath = System.Web.Hosting.HostingEnvironment.MapPath("~/");
                //  hpf.SaveAs(filepath);
            }
            responseText = LoginInfoBll.SetPersonalInfo(Personal, filename, user_id);
            return Content(responseText);
        }
        public ActionResult test()
        {
            return View();
        }
    }
}
