using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gxdzwxfangan.Model
{
    public class ValidataCodeParameter
    {
        private string _mobile;//目标手机号

        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }
        private string _accessKeyId;//阿里key

        public string AccessKeyId
        {
            get { return _accessKeyId; }
            set { _accessKeyId = value; }
        }
        private string _accessKeySecret;//阿里key密码

        public string AccessKeySecret
        {
            get { return _accessKeySecret; }
            set { _accessKeySecret = value; }
        }
        private string _signName; //短信签名

        public string SignName
        {
            get { return _signName; }
            set { _signName = value; }
        }
        private string _templateCode;//短信模板编号

        public string TemplateCode
        {
            get { return _templateCode; }
            set { _templateCode = value; }
        }
        private string _templateParam;//该模板json字符串变量

        public string TemplateParam
        {
            get { return _templateParam; }
            set { _templateParam = value; }
        }

    }
}
