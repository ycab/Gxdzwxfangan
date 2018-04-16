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
    }
}
