using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gxdzwxfangan.Utilities;
using System.Data;
using Gxdzwxfangan.Model;
using System.Data.OracleClient;
namespace Gxdzwxfangan.Dal
{
    public class TaskSortDal
    {
        public string MiddleSortNameInfo()
        {
            string responseText = "";
            string sql = "select * from GXFW_TASK_CATEGORY";
            DataTable dt = OracleHelper.GetTable(sql, null);
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string task_category_name = dt.Rows[i]["TASK_CATEGORY_NAME"].ToString();
                    string task_category_id = dt.Rows[i]["TASK_CATEGORY_ID"].ToString();
                    string sql1 = string.Format("select * from GXFW_SEND_TASK t where TECHNICAL_CLASSIFICATIONCLASS='{0}'and IS_RECEIVED <> '{1}' ", task_category_name,"0");
                    DataTable dt1 = OracleHelper.GetTable(sql1, null);
                    string response = JsonHelper.getRecordJson(dt1);
                    if (i == dt.Rows.Count - 1)
                    {
                        responseText += "{\"task_category_name\":\"" + task_category_name + "\",\"task_category_id\":\"" + task_category_id + "\",\"info\":[" + response + "]}";
                    }
                    else
                    {
                        responseText += "{\"task_category_name\":\"" + task_category_name + "\",\"task_category_id\":\"" + task_category_id + "\",\"info\":[" + response + "]},";
                    }
                }
                responseText = "{\"msg\":\"success\",\"middlesortinfo\":[" + responseText + "]}";

            }
            else
            {
                responseText = "{\"msg\":\"fail\",\"failinfo\":\"查询出错\"}";
            }



            return responseText;
        }
        public Task GetOneTaskInfo(string task_id)
        {
            string sql = string.Format("select * from GXFW_SEND_TASK  where TASK_ID='{0}'", task_id);
            DataTable dt = OracleHelper.GetTable(sql, null);
            Task task = new Task();
            task.User_ID = dt.Rows[0]["USER_ID"].ToString();
            task.User_Name = dt.Rows[0]["USER_NAME"].ToString();
            task.Task_ID = dt.Rows[0]["TASK_ID"].ToString();
            task.Application_area = dt.Rows[0]["APPLICATION_AREA"].ToString();
            task.Technical_Classificationclass = dt.Rows[0]["TECHNICAL_CLASSIFICATIONCLASS"].ToString();
            task.Task_Name = dt.Rows[0]["TASK_NAME"].ToString();
            task.Send_Time = dt.Rows[0]["SEND_TIME"].ToString();
            task.deadline = dt.Rows[0]["DEADLINE"].ToString();
            task.Demand_Description = dt.Rows[0]["DEMAND_DESCRIPTION"].ToString();
            task.Demand_Detail = dt.Rows[0]["DEMAND_DETAIL"].ToString();
            task.Phone = dt.Rows[0]["PHONE"].ToString();
            task.Price = dt.Rows[0]["PRICE"].ToString();
            task.Apply_Number = dt.Rows[0]["APPLY_NUMBER"].ToString();
            task.Is_Received = dt.Rows[0]["IS_RECEIVED"].ToString();
            task.Del_Flag = dt.Rows[0]["DEL_FLAG"].ToString();
            string sql2 = string.Format("select * from GX_USER_MEMBER_PERSONAL t where USER_ID='{0}' ", task.User_ID);
            DataTable dt2 = OracleHelper.GetTable(sql2, null);
            if (dt2.Rows.Count != 0)
            {
                string jpg = dt2.Rows[0]["CHAT_HEAD"].ToString();
                task.Nick_Name = dt2.Rows[0]["NICK_NAME"].ToString();
                if (dt2.Rows[0]["CHAT_HEAD"].ToString() == "")
                {
                    task.Chat_Head = "avatar.jpg";
                }
                else
                {
                    task.Chat_Head = dt2.Rows[0]["CHAT_HEAD"].ToString();
                }

            }
            return task;

        }

        public string MySendTaskSortInfo(string user_id,string send_flag )//send_flag为1，所有包，2：已选中；3：已托管
        {
            string sql="";
            string responseText = "";
            if (send_flag == "1")
            {
                send_flag = "所有包";
                 sql = string.Format("select * from GXFW_SEND_TASK  where USER_ID='{0}'", user_id);
            }
            else if(send_flag=="2")
            {
                send_flag = "已选中";
                sql = string.Format("select * from GXFW_SEND_TASK  where USER_ID='{0}' and IS_RECEIVED='{1}' ", user_id, "1");
            }
            else if (send_flag == "3")
            {
                send_flag = "已托管";
                sql = string.Format("select * from GXFW_SEND_TASK  where USER_ID='{0}' and IS_RECEIVED='{1}' ", user_id, "3");
            }
            else if (send_flag == "4")
            {
                send_flag = "已完成";
                sql = string.Format("select * from GXFW_SEND_TASK  where USER_ID='{0}' and IS_RECEIVED='{1}' ", user_id, "4");
            }

            DataTable dt = OracleHelper.GetTable(sql, null);
            if (dt.Rows.Count != 0)
            {
                responseText = JsonHelper.getRecordJson(dt);
                responseText = "{\"msg\":\"success\",\"send_flag\":\""+send_flag+"\",\"sortinfo\":[" + responseText + "]}";
            }
            else
            {
                responseText = "{\"msg\":\"fail\",\"receive_flag\":\"" + send_flag + "\",\"failinfo\":\"查询出错\"}";
            }



            return responseText;
        }
        public string MyReceiveTaskSortInfo(string user_id, string receive_flag)//send_flag为1，所有包，2：已选中；3：已托管
        {
            string sql = "";
            string responseText = "";
            if (receive_flag == "1")
            {
                receive_flag = "所有包";
                sql = string.Format("select * from GXFW_RECEIVE_TASK  where USER_ID='{0}'", user_id);
            }
            else if (receive_flag == "2")
            {
                receive_flag = "已选中";
                sql = string.Format("select * from GXFW_RECEIVE_TASK  where USER_ID='{0}' and IS_ACCEPTED='{1}' ", user_id, "1");
            }
            else if (receive_flag == "3")
            {
                receive_flag = "已托管";
                sql = string.Format("select * from GXFW_RECEIVE_TASK  where USER_ID='{0}' and IS_ACCEPTED='{1}' ", user_id, "3");
            }
            else if (receive_flag == "4")
            {
                receive_flag = "已完成";
                sql = string.Format("select * from GXFW_RECEIVE_TASK  where USER_ID='{0}' and IS_ACCEPTED='{1}' ", user_id, "4");
            }

            DataTable dt = OracleHelper.GetTable(sql, null);
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count;i++ )
                {
                   string sql2 = string.Format("select * from GXFW_SEND_TASK t where TASK_ID='{0}' ", dt.Rows[i]["TASK_ID"]);
                   DataTable dt2 = OracleHelper.GetTable(sql2, null);
                   if (dt2.Rows.Count != 0)
                   {
                       dt.Rows[i]["PRICE"] = dt2.Rows[0]["PRICE"];
                       dt.Rows[i]["SEND_TIME"] = dt2.Rows[0]["SEND_TIME"];
                   }
                }
                responseText = JsonHelper.getRecordJson(dt);
                responseText = "{\"msg\":\"success\",\"receive_flag\":\"" + receive_flag + "\",\"sortinfo\":[" + responseText + "]}";
            }
            else
            {
                responseText = "{\"msg\":\"fail\",\"receive_flag\":\"" + receive_flag + "\",\"failinfo\":\"查询出错\"}";
            }



            return responseText;
        }
        public string GetTaskInfoByField(string application_area)
        {
            string responseText = "";
            string sql = string.Format("select * from GXFW_SEND_TASK  where APPLICATION_AREA='{0}'", application_area);
            DataTable dt = OracleHelper.GetTable(sql, null);
            if (dt.Rows.Count != 0)
            {
                responseText = JsonHelper.getRecordJson(dt);
                responseText = "{\"msg\":\"success\",\"middlesortinfo\":[" + responseText + "]}";

            }
            else
            {
                responseText = "{\"msg\":\"fail\",\"failinfo\":\"查询出错\"}";
            }
            return responseText;
        }

        public string GetSomeTask()
        {
            string responseText = "";
            string sql = "select * from (select * from GXFW_SEND_TASK order by dbms_random.random) where rownum<=4";//随机查询四条数据
            //string sql = string.Format("select * from GXFW_SEND_TASK");
            DataTable dt = OracleHelper.GetTable(sql, null);
            if (dt.Rows.Count != 0)
            {
                responseText = JsonHelper.getRecordJson(dt);
                responseText = "{\"msg\":\"success\",\"middlesortinfo\":[" + responseText + "]}";
            }
            else
            {
                responseText = "{\"msg\":\"fail\",\"failinfo\":\"查询出错\"}";
            }
            return responseText;
        }
    }
}
