using System.Net;
using System.Text;
using System;
using ADCGroup_Service.Model.JiraModel.InfoUser;
using ADCGroup_Service.Model.BasicModel.Account;
using ADCGroup_Service.Model.JiraModel.LoginSession;
using System.IO;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using ADCGroup_Service.Service_BookingRoom.Service_Basic;

namespace ADCGroup_Service.Service_BookingRoom.Service_Login
{
    public class JiraLogin
    {       
        /// <summary>
        /// Method for Get Session User after Login // Method.Get
        /// </summary>
        /// <param name="account">Account of user</param>
        /// <returns>byte[]</returns>      
        public LoginInfo GetSessionJiraLogin(Accounts account)
        {
            string strResponseValue = string.Empty;
            string resultJson = string.Empty;
            string url = "http://intern.adcvn.com:8100/rest/auth/1/session";

            string encodedCredentials = new ChangeType() { }.EncodedAccount(account);
            var json = new JavaScriptSerializer().Serialize(account);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("Authorization", "Basic " + encodedCredentials);
            request.Method = WebRequestMethods.Http.Post;
            request.ContentType = "application/json";
            request.ContentLength = json.Length;

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(new ChangeType() { }.ByteCredentials(account), 0, new ChangeType() { }.ByteCredentials(account).Length);

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
