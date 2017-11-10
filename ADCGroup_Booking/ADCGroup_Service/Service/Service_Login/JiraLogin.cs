using System;
using System.Net;
using System.Text;
using ADCGroup_Service.Model.JiraModel.InfoUser;
using ADCGroup_Service.Model.BasicModel.Account;
using ADCGroup_Service.Model.JiraModel.LoginSession;
using System.IO;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using ADCGroup_Service.Service.Service_Basic;
using ADCGroup_Service.InterfaceEx.Service_Login;
using System.Threading;

namespace ADCGroup_Service.Service.Service_Login
{
    public class JiraLogin : IJiraLogin
    {       
        /// <summary>
        /// Method for Get Session User after Login // Method.POST
        /// </summary>
        /// <param name="account">Account of user</param>
        /// <returns>byte[]</returns>      
        public LoginInfo GetSessionJiraLogin(Accounts account)
        {
            string strResponseValue = string.Empty;
            string resultJson = string.Empty;
            string url = "http://intern.adcvn.com:8100/rest/auth/1/session";

            string encodedCredentials = new ChangeType() { }.EncodedAccount(account);
            var byteArray = new ChangeType() { }.ByteCredentials(account);
            var json = new JavaScriptSerializer().Serialize(account);
            var postjson = Encoding.ASCII.GetBytes(json);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("Authorization", "Basic " + encodedCredentials);
            request.Method = WebRequestMethods.Http.Post;
            request.ContentType = "application/json";
            request.ContentLength = encodedCredentials.Length;
            request.KeepAlive = true;
            request.Timeout = 200000;
            request.UserAgent = "Mozilla/5.0 (Macintosh; U; Intel Mac OS X 10_6_3; en-US) AppleWebKit/533.4 (KHTML, like Gecko) Chrome/5.0.375.70 Safari/533.4";

            //Stream dataStream = request.GetRequestStream();
            //dataStream.Write(byteArray, 0, byteArray.Length);
            //dataStream.Close();

            var data = encodedCredentials;
            if (data != null)
            {
                using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
                {
                    writer.Write(data);
                }
            }

            HttpWebResponse response = null;

            try
            {

                response = (HttpWebResponse)request.GetResponse();

                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            resultJson = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (response != null)
                {
                    ((IDisposable)response).Dispose();
                }
            }

            LoginInfo user = JsonConvert.DeserializeObject<LoginInfo>(resultJson);

            return user;
        }

        /// <summary>
        /// Method for Get Info User after Login //Method.Post
        /// </summary>
        /// <param name="account">Account of user</param>
        /// <returns>InfoUser</returns>
        public InfoUser GetInfoUser(Accounts account)
        {
            string strResponseValue = string.Empty;
            string resultJson = string.Empty;
            string url = string.Format("http://intern.adcvn.com:8100/rest/api/latest/user?username={0}", account.username);
            
            string encodedCredentials = new ChangeType() { }.EncodedAccount(account);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("Authorization", "Basic " + encodedCredentials);

            HttpWebResponse response = null;

            try
            {
                response = (HttpWebResponse)request.GetResponse();

                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            resultJson = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (response != null)
                {
                    ((IDisposable)response).Dispose();
                }
            }

            InfoUser user = JsonConvert.DeserializeObject<InfoUser>(resultJson);

            return user;
        }
    }
}
