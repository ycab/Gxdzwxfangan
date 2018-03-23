using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gxdzwxfangan.Model
{
    public class Task
    {
        public virtual string User_ID { get; set; }

        public virtual string User_Name { get; set; }

        public virtual string Task_ID { get; set; }

        public virtual string Application_area { get; set; }

        public virtual string Technical_Classificationclass { get; set; }  //技术分类

        public virtual string Task_Name { get; set; }

        public virtual string Send_Time { get; set; }               //发布时间

        public virtual string deadline { get; set; }            //截止时间

        public virtual string Demand_Description { get; set; }      //任务描述
         
        public virtual string Demand_Detail { get; set; }          //任务详情

        public virtual string Phone { get; set; }

        public virtual string Price { get; set; }

        public virtual string Apply_Number { get; set; }        //申请数量

        public virtual string Is_Received { get; set; }         //是否接受

        public virtual string Del_Flag { get; set; }            //删除标志


    }
}
