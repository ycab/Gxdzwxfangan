using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Dysmsapi.Model.V20170525;
using Gxdzwxfangan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;

namespace Gxdzwxfangan.Utilities
{
    public class SmsHelper
    {
        #region 发送验证码
    

        /// <summary>
        /// 灵活发送短信
        /// </summary>
        /// <param name="validatacodepara"></param>
        /// <returns></returns>
        public static ValidateResultMsg FlexVerificationCode(ValidataCodeParameter validatacodepara)
        {
            ValidateResultMsg resultMsg = null;
            string validatecode = new Random().Next(111111, 999999).ToString();
   
                String product = "Dysmsapi";//短信API产品名称
                String domain ="dysmsapi.aliyuncs.com";//短信API产品域名
                String accessKeyId = validatacodepara.AccessKeyId;//你的accessKeyId
                String accessKeySecret = validatacodepara.AccessKeySecret;//你的accessKeySecret

                IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", accessKeyId, accessKeySecret);
                //IAcsClient client = new DefaultAcsClient(profile);
                // SingleSendSmsRequest request = new SingleSendSmsRequest();

                DefaultProfile.AddEndpoint("cn-hangzhou", "cn-hangzhou", product, domain);
                IAcsClient acsClient = new DefaultAcsClient(profile);
                SendSmsRequest request = new SendSmsRequest();
                try
                {

                    //必填:待发送手机号。支持以逗号分隔的形式进行批量调用，批量上限为20个手机号码,批量调用相对于单条调用及时性稍有延迟,验证码类型的短信推荐使用单条调用的方式
                    request.PhoneNumbers = validatacodepara.Mobile;
                    //必填:短信签名-可在短信控制台中找到
                    request.SignName = validatacodepara.SignName;
                    //必填:短信模板-可在短信控制台中找到
                    request.TemplateCode = validatacodepara.TemplateCode;
                    //可选:模板中的变量替换JSON串,如模板内容为"亲爱的${name},您的验证码为${code}"时,此处的值为
                    //  request.TemplateParam = "{\"name\":\"Tom\"， \"code\":\"123\"}";
                    //   request.TemplateParam = "{\"code\":\"" + validatecode + "\"}";
                    request.TemplateParam = validatacodepara.TemplateParam;
                    //    业务类型：${type} 申请人：${name} 业务进度：${schedule} 处理时间：${time} 感谢您使用xx微警务！
                    //   request.TemplateParam = "{\"type\":\"花花\",\"name\":\"水水\",\"schedule\":\"可以\",\"time\":\"2017-09-09\"}";
                    //可选:outId为提供给业务方扩展字段,最终在短信回执消息中将此值带回给调用者
                    request.OutId = "21212121211";
                    //请求失败这里会抛ClientException异常
                    SendSmsResponse sendSmsResponse = acsClient.GetAcsResponse(request);

                    resultMsg = new ValidateResultMsg();
                    resultMsg.StatusCode = sendSmsResponse.Code;
                    resultMsg.Info = sendSmsResponse.Message;
                    resultMsg.BizId = sendSmsResponse.BizId;
                    resultMsg.ValidataCode = validatecode;
                    return resultMsg;

                    //System.Console.WriteLine(sendSmsResponse.Message);


                }
                catch (ServerException e)
                {
                    resultMsg = new ValidateResultMsg();
                    resultMsg.StatusCode = "";
                    resultMsg.Info = e.ToString();
                    resultMsg.ValidataCode = "";
                    return resultMsg;
                }
         
        }
        #endregion
    }
}
