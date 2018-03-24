using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gxdzwxfangan.Model
{
    public class MyTaskInfo
    {
        public virtual string SendTaskSelected{ get; set; }

        public virtual string SendTaskHosting { get; set; }

        public virtual string SendTaskFinished { get; set; }

        public virtual string ReceiveTaskSelected { get; set; }

        public virtual string ReceiveTaskHosting { get; set; }  

        public virtual string ReceiveTaskFinished { get; set; }
    }
}
