using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gxdzwxfangan.Model
{
    public class Task_Receive
    {
        public virtual string User_ID { get; set; }

        public virtual string User_Name { get; set; }

        public virtual string Task_ID { get; set; }

        public virtual string Is_Accepted { get; set; }

        public virtual string Receive_Time { get; set; }  

        public virtual string Receive_Success_Time { get; set; }



    }
}
