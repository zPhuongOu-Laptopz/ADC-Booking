using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace ADCGroup_Service.Service_BookingRoom.Service_Login
{
    public class Service_Login
    {
        private string username;
        private string password;

        public Service_Login(string _us, string _pass)
        {
            this.username = _us;
            this.password = _pass;
        }

        /// <summary>
        /// The function to check the log and return the error is the http error code
        /// </summary>
        /// <returns>Http Error Code</returns>
        public int LoginService()
        {
            int _code = 0;
            string strResponseValue = string.Empty;

            var mergedCredentials = string.Format("{0}:{1}", this.username, this.password);
            var byteCredentials = Encoding.UTF8.GetBytes(mergedCredentials);
            var encodedCredentials = Convert.ToBase64String(byteCredentials);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://intern.adcvn.com:8100/rest/api/2/issue/DKPH-1");

            request.Method = "GET";
            request.Headers.Add("Authorization", "Basic " + encodedCredentials);

            HttpWebResponse response = null;

            try
            {
                response = (HttpWebResponse)request.GetResponse();

                _code = Convert.ToInt32(response.StatusCode);

                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                strResponseValue = "{\"errorMessages\":[\"" + ex.Message.ToString() + "\"],\"errors\":{}}";
                if (strResponseValue.Contains("401"))
                {
                    return _code = 401;
                }
                else if (strResponseValue.Contains("403"))
                {
                    return _code = 403;
                }
                else if (strResponseValue.Contains("409"))
                {
                    return _code = 403;
                }
            }
            finally
            {
                if (response != null)
                {
                    ((IDisposable)response).Dispose();
                }
            }

            return _code;
        }
    }
}
