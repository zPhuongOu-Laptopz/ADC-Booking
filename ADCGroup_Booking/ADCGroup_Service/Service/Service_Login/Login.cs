using ADCGroup_Service.InterfaceEx.Service_Login;
using ADCGroup_Service.Model.JiraModel.LoginSession;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace ADCGroup_Service.Service.Service_Login
{
    public class Login : IService_Login
    {
        /// <summary>
        /// The function to check the log and return the error is the http error code
        /// </summary>
        /// <returns>Http Error Code</returns>
        public int LoginServicewithIssue(string _us, string _pass) // Login with in Project 
        {
            if (_us == "")
            {
                return -1;
            }
            else if (_pass == "")
            {
                return -2;
            }
            else
            {
                int _code = 0;
                string strResponseValue = string.Empty;

                var mergedCredentials = string.Format("{0}:{1}", _us, _pass);
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

        /// <summary>
        /// The function to check the log and return the error is the http error code
        /// </summary>
        /// <returns>Http Error Code</returns>
        public ResultLogin LoginServicewithAccount(string _us, string _pass) // Login with in Jira
        {
            if (_us == null || _us == "")
            {
                return new ResultLogin(-1, string.Empty);
            }
            else if (_pass == null || _pass == "")
            {
                return new ResultLogin(-2, string.Empty);
            }
            else
            {
                ResultLogin result = new ResultLogin();
                int _code = 0;
                string strResponseValue = string.Empty;

                var mergedCredentials = string.Format("{0}:{1}", _us, _pass);
                var byteCredentials = Encoding.UTF8.GetBytes(mergedCredentials);
                var encodedCredentials = Convert.ToBase64String(byteCredentials);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://intern.adcvn.com:8100/rest/auth/1/session");

                request.Method = "GET";
                request.Headers.Add("Authorization", "Basic " + encodedCredentials);

                HttpWebResponse response = null;
                ModelLogin item = null;
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

                    item = JsonConvert.DeserializeObject<ModelLogin>(strResponseValue);
                }
                catch (Exception ex)
                {
                    strResponseValue = "{\"errorMessages\":[\"" + ex.Message.ToString() + "\"],\"errors\":{}}";
                    if (strResponseValue.Contains("401"))
                    {
                        result.code = 401;
                        result.name = string.Empty;
                        return result;
                    }
                    else if (strResponseValue.Contains("403"))
                    {
                        result.code = 403;
                        result.name = string.Empty;
                        return result;
                    }
                    else if (strResponseValue.Contains("409"))
                    {
                        result.code = 409;
                        result.name = string.Empty;
                        return result;
                    }
                }
                finally
                {
                    if (response != null)
                    {
                        ((IDisposable)response).Dispose();
                    }
                }

                result.code = _code;
                result.name = item.name;
                return result;
            }            
        }
    }
}
