using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gxdzwxfangan.Dal;
using Gxdzwxfangan.Model;


namespace Gxdzwxfangan.Bll
{

    public class LoginBll
    {
        LoginDal LoginInfoDal = new LoginDal();
        /// <summary>
        /// 填写个人会员信息
        /// </summary>
        /// <returns></returns>
        public string SetPersonalInfo(PersonalInfoModel personal, List<string> filename, string user_id)
        {
            string responText = "";
            responText = LoginInfoDal.SetPersonalInfo(personal, filename, user_id);
            return responText;
        }
        /// <summary>
        /// 填写企业会员信息
        /// </summary>
        /// <returns></returns>
        public string SetFactoryInfo(FactoryInfoModel factory, List<string> filename, string user_id, string chat_head_name, string business_license_name, string credential_name, string honor_name, string related_picture_name, string quality_guaratee_name)
        {
            string responText = "";
            responText = LoginInfoDal.SetFactoryInfo(factory, filename, user_id, chat_head_name, business_license_name, credential_name, honor_name, related_picture_name, quality_guaratee_name);
            return responText;
        }
    }
}
