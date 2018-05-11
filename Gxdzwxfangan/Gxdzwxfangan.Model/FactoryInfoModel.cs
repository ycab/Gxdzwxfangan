using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gxdzwxfangan.Model
{
    public class FactoryInfoModel
    {
        private string _nick_name;//会员昵称
        public string nick_name
        {
            get { return _nick_name; }
            set { _nick_name = value; }
        }
        private string _chat_head;//会员头像
        public string chat_head
        {
            get { return _chat_head; }
            set { _chat_head = value; }
        }
        private string _signature;//会员签名
        public string signature
        {
            get { return _signature; }
            set { _signature = value; }
        }
        private string _name;//姓名
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _company_name;//企业名称
        public string company_name
        {
            get { return _company_name; }
            set { _company_name = value; }
        }
        private string _company_industry_involved;//企业所属行业
        public string company_industry_involved
        {
            get { return _company_industry_involved; }
            set { _company_industry_involved = value; }
        }
        private string _company_introduce;//企业介绍
        public string company_introduce
        {
            get { return _company_introduce; }
            set { _company_introduce = value; }
        }
        private string _business_license;//营业执照
        public string business_license
        {
            get { return _business_license; }
            set { _business_license = value; }
        }
        private string _company_capability;//企业加工能力及产品介绍
        public string company_capability
        {
            get { return _company_capability; }
            set { _company_capability = value; }
        }
        private string _credential;//证书
        public string credential
        {
            get { return _credential; }
            set { _credential = value; }
        }
        private string _honor;//荣誉
        public string honor
        {
            get { return _honor; }
            set { _honor = value; }
        }
        private string _architecture_related;//相关体系介绍
        public string architecture_related
        {
            get { return _architecture_related; }
            set { _architecture_related = value; }
        }
        private string _related_picture;//相关图片
        public string related_picture
        {
            get { return _related_picture; }
            set { _related_picture = value; }
        }
        private string _quality_guarantee;//质量保证
        public string quality_guarantee
        {
            get { return _quality_guarantee; }
            set { _quality_guarantee = value; }
        }
        private string _tel;//电话
        public string tel
        {
            get { return _tel; }
            set { _tel = value; }
        }
        private string _fax;//传真
        public string fax
        {
            get { return _fax; }
            set { _fax = value; }
        }
        private string _email;//邮箱
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }
        private string _address;//地址
        public string address
        {
            get { return _address; }
            set { _address = value; }
        }
    }
}
