using System.Net;
using System;
using ADCGroup_Service.Model.BasicModel.Account;
using System.IO;
using Newtonsoft.Json;
using ADCGroup_Service.Service.Service_Basic;
using ADCGroup_Service.Model.JiraModel.Issue;
using System.Collections.Generic;
using ADCGroup_Service.Model.BasicModel.MeetingRoom;
using System.Web.Script.Serialization;
using System.Text;
using ADCGroup_Service.InterfaceEx.Service_Booking;
using System.Linq;
using ADCGroup_Service.Model.BasicModel.TimeMeeting;

namespace ADCGroup_Service.Service.Service_Booking
{
    public class Metting : IMeeting
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
            string url = string.Format("http://intern.adcvn.com:8100/rest/api/2/search?jql=project={0}&startAt={1}&maxResults={2}", "DKPH", 0, 1000);

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

        /// <summary>
        /// Get List Issue MeetingRoom
        /// </summary>
        /// <param name="account">Account of User</param>
        /// <returns>List<Issue></returns>
        public List<Issue> GetAllIssue(Accounts account)
        {
            Issues alldata = GetAllMeetingRoom(account);
            var list = alldata.issues;
            return list;
        }

        public List<Issue> GetAllIssueToday(Accounts account)
        {
            int daytoday = DateTime.Now.Day;
            int monthtoday = DateTime.Now.Month;
            int yeartoday = DateTime.Now.Year;
            Issues alldata = GetAllMeetingRoom(account);
            List<Issue> list = alldata.issues;
            List<Issue> listresult = new List<Issue>();
            foreach (var item in list)
            {
                try
                {
                    if (item.fields.customfield_10400.Value.Day == daytoday && item.fields.customfield_10400.Value.Month == monthtoday && item.fields.customfield_10400.Value.Year == yeartoday)
                    {
                        listresult.Add(item);
                    }
                }
                catch
                {
                    continue;
                }
            }
            return listresult;
        }

        /// <summary>
        /// Create a new Meeting in Jira
        /// </summary>
        /// <param name="isu">Infomation about Issue</param>
        /// <param name="account">Account of User</param>
        /// <returns></returns>
        public bool CreateIssue(Accounts account, string sumamary, string idroom, double? quantity, DateTime start, DateTime end, string description)
        {
            string strResponseValue = string.Empty;
            string resultJson = string.Empty;
            string url = string.Format("http://intern.adcvn.com:8100/rest/api/2/issue");
            string encodedCredentials = new ChangeType() { }.EncodedAccount(account);

            string resultsjson = JsonMeetingRoom(sumamary, idroom, 20, start, end, description);
            //var postjson = Encoding.ASCII.GetBytes(resultsjson);
            var postjson = Encoding.UTF8.GetBytes(resultsjson);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = WebRequestMethods.Http.Post;
            request.Headers.Add("Authorization", "Basic " + encodedCredentials);
            request.ContentType = "application/json";
            request.ContentLength = postjson.Length;

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(postjson, 0, postjson.Length);

            WebResponse response = null;
            try
            {
                response = request.GetResponse();
                if (response == null)
                {
                    return false;
                }
                else
                {
                    ((IDisposable)response).Dispose();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Convert value to Json for POST API
        /// </summary>
        /// <param name="sumamary"></param>
        /// <param name="idroom"></param>
        /// <param name="quantity"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public string JsonMeetingRoom(string sumamary, string idroom, double? quantity, DateTime start, DateTime end, string description)
        {
            var daystart = start.ToString("yyyy-MM-ddThh:mm:ss.fffK");
            daystart = daystart.Substring(0, 26) + daystart.Substring(27, 2);
            DateTime teststart = Convert.ToDateTime(daystart);
            var dayend = end.ToString("yyyy-MM-ddThh:mm:ss.fffK");
            dayend = dayend.Substring(0, 26) + dayend.Substring(27, 2);
            DateTime testend = Convert.ToDateTime(dayend);
            MeetingRoom meet = new MeetingRoom(sumamary, idroom, quantity, daystart, dayend, description);
            string json = new JavaScriptSerializer().Serialize(meet);
            return json;
        }

        public bool ChangeStatusIssue()
        {
            return true;
        }

        public List<Issue> GetAllIssuebyRoom2big(Accounts account)
        {
            List<Issue> list = GetAllIssueToday(account);
            List<Issue> listresult = new List<Issue>();
            foreach (var item in list)
            {
                try
                {
                    if (item.fields.customfield_10402.id == "10300")
                    {
                        listresult.Add(item);
                    }
                }
                catch
                {
                    continue;
                }
            }
            return listresult;
        }

        public List<Issue> GetAllIssuebyRoom2small(Accounts account)
        {
            List<Issue> list = GetAllIssueToday(account);
            List<Issue> listresult = new List<Issue>();
            foreach (var item in list)
            {
                try
                {
                    if (item.fields.customfield_10402.id == "10301")
                    {
                        listresult.Add(item);
                    }
                }
                catch
                {
                    continue;
                }
            }
            return listresult;
        }

        public List<Issue> GetAllIssuebyRoom4(Accounts account)
        {
            List<Issue> list = GetAllIssueToday(account);
            List<Issue> listresult = new List<Issue>();
            foreach (var item in list)
            {
                try
                {
                    if (item.fields.customfield_10402.id == "10302")
                    {
                        listresult.Add(item);
                    }
                }
                catch
                {
                    continue;
                }
            }
            return listresult;
        }

        public List<Issue> GetAllIssuebyRoom6(Accounts account)
        {
            List<Issue> list = GetAllIssueToday(account);
            List<Issue> listresult = new List<Issue>();
            foreach (var item in list)
            {
                try
                {
                    if (item.fields.customfield_10402.id == "10303")
                    {
                        listresult.Add(item);
                    }
                }
                catch
                {
                    continue;
                }
            }
            return listresult;
        }

        public List<Issue> GetAllIssuebyRoom2big(Accounts account, DateTime day)
        {
            List<Issue> list = GetAllIssueThisDay(account, day);
            List<Issue> listresult = new List<Issue>();
            foreach (var item in list)
            {
                try
                {
                    if (item.fields.customfield_10402.id == "10300")
                    {
                        listresult.Add(item);
                    }
                }
                catch
                {
                    continue;
                }
            }
            return listresult;
        }

        public List<Issue> GetAllIssuebyRoom2small(Accounts account, DateTime day)
        {
            List<Issue> list = GetAllIssueThisDay(account, day);
            List<Issue> listresult = new List<Issue>();
            foreach (var item in list)
            {
                try
                {
                    if (item.fields.customfield_10402.id == "10301")
                    {
                        listresult.Add(item);
                    }
                }
                catch
                {
                    continue;
                }
            }
            return listresult;
        }

        public List<Issue> GetAllIssuebyRoom4(Accounts account, DateTime day)
        {
            List<Issue> list = GetAllIssueThisDay(account, day);
            List<Issue> listresult = new List<Issue>();
            foreach (var item in list)
            {
                try
                {
                    if (item.fields.customfield_10402.id == "10302")
                    {
                        listresult.Add(item);
                    }
                }
                catch
                {
                    continue;
                }
            }
            return listresult;
        }

        public List<Issue> GetAllIssuebyRoom6(Accounts account, DateTime day)
        {
            List<Issue> list = GetAllIssueThisDay(account, day);
            List<Issue> listresult = new List<Issue>();
            foreach (var item in list)
            {
                try
                {
                    if (item.fields.customfield_10402.id == "10303")
                    {
                        listresult.Add(item);
                    }
                }
                catch
                {
                    continue;
                }
            }
            return listresult;
        }

        public List<Issue> GetAllIssueThisDay(Accounts account, DateTime day)
        {
            Issues alldata = GetAllMeetingRoom(account);
            List<Issue> list = alldata.issues;
            List<Issue> listresult = new List<Issue>();
            foreach (var item in list)
            {
                try
                {
                    if (item.fields.customfield_10400.Value.Day == day.Day && item.fields.customfield_10400.Value.Month == day.Month && item.fields.customfield_10400.Value.Year == day.Year)
                    {
                        listresult.Add(item);
                    }
                }
                catch
                {
                    continue;
                }
            }
            return listresult;
        }

        public List<TimeMeeting> ConvertDatimeIssuetoTimeMeeting(List<Issue> list)
        {
            List<TimeMeeting> listresult = new List<TimeMeeting>();            
            foreach (var item in list)
            {
                //TimeMeeting time = new TimeMeeting();
                //time.timestart = item.fields.customfield_10400.Value;
                //time.timeend = item.fields.customfield_10401.Value;
                listresult.Add(new TimeMeeting(item.fields.customfield_10400.Value, item.fields.customfield_10401.Value));
            }
            List<TimeMeeting> listcheck = listresult.OrderBy(item => item.timestart).OrderBy(item => item.timeend).ToList<TimeMeeting>();
            return listcheck;
        }

        public List<TimeMeeting> GetAllFreeTimeMeetingwithListIssueOneDay(List<TimeMeeting> list)
        {
            int day = list[0].timestart.Day;
            int month = list[0].timestart.Month;
            int year = list[0].timestart.Year;
            DateTime minimum = new DateTime(year, month, day, 8, 0, 0);
            DateTime maximum = new DateTime(year, month, day, 17, 0, 0);
            List<TimeMeeting> listresult = new List<TimeMeeting>();
            if (list[0].timestart.Hour > 8 && list[0].timestart.Minute > 0)
            {
                listresult.Add(new TimeMeeting(minimum, new DateTime(year, month, day, list[0].timestart.Hour, list[0].timestart.Minute, list[0].timestart.Second)));
            }
            for (int i = 0; i < list.Count - 1; i++)
            {
                int j = i + 1;
                if (list[j].timestart.Hour > list[i].timeend.Hour || list[j].timestart.Minute > list[i].timeend.Minute)
                {
                    listresult.Add(new TimeMeeting(new DateTime(year, month, day, list[i].timeend.Hour, list[i].timeend.Minute, list[i].timeend.Second), new DateTime(year, month, day, list[j].timeend.Hour, list[j].timeend.Minute, list[j].timeend.Second)));
                }
            }
            if (list[list.Count - 1].timeend.Hour < 17)
            {
                listresult.Add(new TimeMeeting(new DateTime(year, month, day, list[list.Count - 1].timeend.Hour, list[list.Count - 1].timeend.Minute, list[list.Count - 1].timeend.Second), maximum));
            }
            return listresult;
        } // Not yet!

        public bool CheckFreeTimeIssueforBooking()
        {
            throw new NotImplementedException();
        } // Not yet!

        public bool BookingMeetingRoom()
        {
            throw new NotImplementedException();
        } // Not yet!
    }
}
