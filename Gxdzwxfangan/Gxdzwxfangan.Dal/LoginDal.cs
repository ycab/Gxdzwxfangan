using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using Gxdzwxfangan.Model;
using Gxdzwxfangan.Utilities;
using Gxdzwxfangan.Dal;
namespace Gxdzwxfangan.Dal
{
    public class LoginDal
    {
        /// <summary>
        /// 填写个人会员信息
        /// </summary>
        /// <returns></returns>
        public string SetPersonalInfo(PersonalInfoModel personal, List<string> filename, string user_id)
        {
            string responseText = "";
            string chat_headname = "";
            string id_cardname = "";
            int count = filename.Count;
            chat_headname = filename[0];
            id_cardname = filename[1];
            //            string sql = string.Format("insert into GX_USER_MEMBER_PERSONAL(USER_ID,CHAT_HEAD,NICK_NAME,SIGNATURE,NAME,ID_NUMBER,SEX,AGE,INDUSTRY_INVOLVED,COMPANY,PROFESSION,TEL,FAX,EMAIL,ID_CARD) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}')", user_id, chat_headname, personal.nick_name, personal.signature, personal.name, personal.id_number, personal.sex, personal.age, personal.industry_involved, personal.company, personal.profession, personal.tel, personal.fax, personal.email,id_cardname);
            string sql = string.Format("update GX_USER_MEMBER_PERSONAL set CHAT_HEAD='{0}',NICK_NAME='{1}',SIGNATURE='{2}',NAME='{3}',ID_NUMBER='{4}',SEX='{5}',INDUSTRY_INVOLVED='{6}',COMPANY='{7}',PROFESSION='{8}',TEL='{9}',FAX ='{10}',EMAIL='{11}',ID_CARD='{12}' where USER_ID = '{13}'", chat_headname, personal.nick_name, personal.signature, personal.name, personal.id_number, personal.sex, personal.industry_involved, personal.company, personal.profession, personal.tel, personal.fax, personal.email, id_cardname, user_id);
            int flag = OracleHelper.ExecuteNonQuery(sql, null);
            if (flag > 0)
            {
                responseText = "success";
            }
            else
                responseText = "fail";

            return responseText;
        }
        /// <summary>
        /// 填写企业会员信息
        /// </summary>
        /// <returns></returns>
        public string SetFactoryInfo(FactoryInfoModel factory, List<string> filename, string user_id, string chat_head_name, string business_license_name, string credential_name, string honor_name, string related_picture_name, string quality_guaratee_name)
        {
            string responseText = "";
            string chat_headname = "";
            string business_licensename = "";
            string credentialname = "";
            string honorname = "";
            string related_picturename = "";
            string quality_guarateename = "";
            for (int i = 0; i < filename.Count; i++)
            {
                if (filename[i] == chat_head_name)
                {
                    chat_headname = filename[i];
                }
                if (filename[i] == business_license_name)
                {
                    business_licensename = filename[i];
                }
                if (filename[i] == credential_name)
                {
                    credentialname = filename[i];
                }
                if (filename[i] == honor_name)
                {
                    honorname = filename[i];
                }
                if (filename[i] == related_picture_name)
                {
                    related_picturename = filename[i];
                }
                if (filename[i] == quality_guaratee_name)
                {
                    quality_guarateename = filename[i];
                }
            }
            string sql = string.Format("update GX_USER_MEMBER_FACTORY set CHAT_HEAD='{0}',NICK_NAME='{1}',SIGNATURE ='{2}',NAME='{3}',COMPANY_NAME='{4}',COMPANY_INDUSTRY_INVOLVED='{5}',COMPANY_INTRODUCE='{6}',BUSINESS_LICENSE='{7}',COMPANY_CAPABILITY='{8}',CREDENTIAL='{9}',HONOR='{10}',ARCHITECTURE_RELATED='{11}',RELATED_PICTURE='{12}',QUALITY_GUARANTEE='{13}',TEL='{14}',FAX='{15}',EMAIL='{16}',ADDRESS='{17}' where USER_ID = '{18}'", chat_headname, factory.nick_name, factory.signature, factory.name, factory.company_name, factory.company_industry_involved, factory.company_introduce, business_licensename, factory.company_capability, credentialname, honorname, factory.architecture_related, related_picturename, quality_guarateename, factory.tel, factory.fax, factory.email, factory.address, user_id);
            int flag = OracleHelper.ExecuteNonQuery(sql, null);
            if (flag > 0)
            {
                responseText = "success";
            }
            else
                responseText = "fail";

            return responseText;
        }
    }
}
