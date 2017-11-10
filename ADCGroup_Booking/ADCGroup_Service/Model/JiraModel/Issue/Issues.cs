using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADCGroup_Service.Model.JiraModel.Issue
{
    public class Issues
    {
        public string expand { get; set; }
        public int startAt { get; set; }
        public int maxResults { get; set; }
        public int total { get; set; }
        public List<Issue> issues { get; set; }
    }

    public class Issuetype
    {
        public string self { get; set; }
        public string id { get; set; }
        public string description { get; set; }
        public string iconUrl { get; set; }
        public string name { get; set; }
        public bool subtask { get; set; }
        public int avatarId { get; set; }
    }

    public class AvatarUrls
    {
        public string __invalid_name__48x48 { get; set; }
        public string __invalid_name__24x24 { get; set; }
        public string __invalid_name__16x16 { get; set; }
        public string __invalid_name__32x32 { get; set; }
    }

    public class Project
    {
        public string self { get; set; }
        public string id { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public AvatarUrls avatarUrls { get; set; }
    }

    public class Watches
    {
        public string self { get; set; }
        public int watchCount { get; set; }
        public bool isWatching { get; set; }
    }

    public class Priority
    {
        public string self { get; set; }
        public string iconUrl { get; set; }
        public string name { get; set; }
        public string id { get; set; }
    }

    public class AvatarUrls2
    {
        public string __invalid_name__48x48 { get; set; }
        public string __invalid_name__24x24 { get; set; }
        public string __invalid_name__16x16 { get; set; }
        public string __invalid_name__32x32 { get; set; }
    }

    public class Assignee
    {
        public string self { get; set; }
        public string name { get; set; }
        public string key { get; set; }
        public string emailAddress { get; set; }
        public AvatarUrls2 avatarUrls { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
        public string timeZone { get; set; }
    }

    public class StatusCategory
    {
        public string self { get; set; }
        public int id { get; set; }
        public string key { get; set; }
        public string colorName { get; set; }
        public string name { get; set; }
    }

    public class Status
    {
        public string self { get; set; }
        public string description { get; set; }
        public string iconUrl { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public StatusCategory statusCategory { get; set; }
    }

    public class Customfield10402
    {
        public string self { get; set; }
        public string value { get; set; }
        public string id { get; set; }
    }

    public class AvatarUrls3
    {
        public string __invalid_name__48x48 { get; set; }
        public string __invalid_name__24x24 { get; set; }
        public string __invalid_name__16x16 { get; set; }
        public string __invalid_name__32x32 { get; set; }
    }

    public class Creator
    {
        public string self { get; set; }
        public string name { get; set; }
        public string key { get; set; }
        public string emailAddress { get; set; }
        public AvatarUrls3 avatarUrls { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
        public string timeZone { get; set; }
    }

    public class AvatarUrls4
    {
        public string __invalid_name__48x48 { get; set; }
        public string __invalid_name__24x24 { get; set; }
        public string __invalid_name__16x16 { get; set; }
        public string __invalid_name__32x32 { get; set; }
    }

    public class Reporter
    {
        public string self { get; set; }
        public string name { get; set; }
        public string key { get; set; }
        public string emailAddress { get; set; }
        public AvatarUrls4 avatarUrls { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
        public string timeZone { get; set; }
    }

    public class Aggregateprogress
    {
        public int progress { get; set; }
        public int total { get; set; }
    }

    public class Progress
    {
        public int progress { get; set; }
        public int total { get; set; }
    }

    public class Votes
    {
        public string self { get; set; }
        public int votes { get; set; }
        public bool hasVoted { get; set; }
    }

    public class Fields
    {
        public Issuetype issuetype { get; set; }
        public object timespent { get; set; }
        public Project project { get; set; }
        public List<object> fixVersions { get; set; }
        public object aggregatetimespent { get; set; }
        public object resolution { get; set; }
        public double? customfield_10307 { get; set; }
        public object resolutiondate { get; set; }
        public int workratio { get; set; }
        public DateTime? lastViewed { get; set; }
        public Watches watches { get; set; }
        public DateTime created { get; set; }
        public Priority priority { get; set; }
        public List<object> labels { get; set; }
        public object timeestimate { get; set; }
        public object aggregatetimeoriginalestimate { get; set; }
        public List<object> versions { get; set; }
        public List<object> issuelinks { get; set; }
        public Assignee assignee { get; set; }
        public DateTime updated { get; set; }
        public Status status { get; set; }
        public List<object> components { get; set; }
        public object timeoriginalestimate { get; set; }
        public string description { get; set; }
        public object customfield_10130 { get; set; }
        public object customfield_10410 { get; set; }
        public object customfield_10411 { get; set; }
        public string customfield_10005 { get; set; }
        public object customfield_10126 { get; set; }
        public object customfield_10324 { get; set; }
        public DateTime? customfield_10401 { get; set; }
        public object customfield_10127 { get; set; }
        public Customfield10402 customfield_10402 { get; set; }
        public object customfield_10325 { get; set; }
        public object customfield_10128 { get; set; }
        public object customfield_10326 { get; set; }
        public object customfield_10403 { get; set; }
        public object customfield_10404 { get; set; }
        public object customfield_10405 { get; set; }
        public object aggregatetimeestimate { get; set; }
        public object customfield_10406 { get; set; }
        public object customfield_10407 { get; set; }
        public object customfield_10408 { get; set; }
        public object customfield_10409 { get; set; }
        public string summary { get; set; }
        public Creator creator { get; set; }
        public List<object> subtasks { get; set; }
        public Reporter reporter { get; set; }
        public object customfield_10000 { get; set; }
        public Aggregateprogress aggregateprogress { get; set; }
        public object customfield_10001 { get; set; }
        public object customfield_10200 { get; set; }
        public object customfield_10201 { get; set; }
        public object customfield_10202 { get; set; }
        public string customfield_10323 { get; set; }
        public DateTime? customfield_10400 { get; set; }
        public object environment { get; set; }
        public object duedate { get; set; }
        public Progress progress { get; set; }
        public Votes votes { get; set; }
    }

    public class Issue
    {
        public string expand { get; set; }
        public string id { get; set; }
        public string self { get; set; }
        public string key { get; set; }
        public Fields fields { get; set; }


        /// <summary>
        /// Test - np
        /// </summary>
        /// <param name="sumamary"></param>
        /// <param name="idroom"></param>
        /// <param name="quantity"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="description"></param>
        public Issue(string sumamary, string idroom, double? quantity, DateTime start, DateTime end, string description) // CTor Issue - np
        {
            Fields fi = new Fields();
            Customfield10402 custom = new Customfield10402();
            fi.summary = sumamary;
            fi.customfield_10307 = quantity;
            fi.customfield_10400 = start;
            fi.customfield_10401 = end;
            custom.id = idroom;
            fi.description = description;
            this.fields = fi;
            this.fields.customfield_10402 = custom;
        }
    }
}
