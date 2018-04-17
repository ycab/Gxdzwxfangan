using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gxdzwxfangan.Model
{
    public class ValidateResultMsg
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public string StatusCode { get; set; }

        /// <summary>
        /// 状态码描述
        /// </summary>
        public string Info { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string ValidataCode { get; set; }

        /// <summary>
        /// 发送回执ID
        /// </summary>
        public object BizId { get; set; }
    }
}
