﻿using System;
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
                    string sql1 = string.Format("select * from GXFW_SEND_TASK t where TECHNICAL_CLASSIFICATIONCLASS='{0}' ",task_category_name);
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
            return task;

        }
    }
}