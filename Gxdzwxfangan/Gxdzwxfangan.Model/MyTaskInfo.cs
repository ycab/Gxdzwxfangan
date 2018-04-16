using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gxdzwxfangan.Model
{
    public class MyTaskInfo
    {
        public virtual string SendTaskSelected{ get; set; }//发包已选中

        public virtual string SendTaskHosting { get; set; }//发包已托管

        public virtual string SendTaskFinished { get; set; }//发包已完成

        public virtual string ReceiveTaskSelected { get; set; }//接包已选中

        public virtual string ReceiveTaskHosting { get; set; }  //接包已托管

        public virtual string ReceiveTaskFinished { get; set; }//接报已完成
    }
}
