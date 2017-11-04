using System.Net;
using System;
using System.Linq;
using ADCGroup_Service.Model.BasicModel.Account;
using System.IO;
using Newtonsoft.Json;
using ADCGroup_Service.Service_BookingRoom.Service_Basic;
using ADCGroup_Service.Model.JiraModel.Issue;
using System.Collections.Generic;

namespace ADCGroup_Service.Service_BookingRoom.Service_Booking
{
    public class Metting
    {
        /// <summary>
        /// Get All Issue MeetingRoom 
        /// </summary>
        /// <param name="account">Account of User</param>
        /// <returns>Issues</returns>
        public Issues GetAllMeetingRoom(Accounts account)
        {
            string strResponseValue = string.Empty;
            string resultJson = string.Empty;
            string url = string.Format("http://intern.adcvn.com:8100/rest/api/2/search?jql=project={0}&startAt={1}&maxResults={2}", "DKPH",0,1000);
            
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

            Issues item = JsonConvert.DeserializeObject<Issues>(resultJson);

            return item;
        }

        public List<Issue> GetAllIssue(Accounts account)
        {
            Issues alldata = GetAllMeetingRoom(account);
            var list = alldata.issues;
            return list;
        }
    }
}
