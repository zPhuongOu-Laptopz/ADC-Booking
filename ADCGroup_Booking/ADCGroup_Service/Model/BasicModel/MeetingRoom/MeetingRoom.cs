using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADCGroup_Service.Model.BasicModel.MeetingRoom
{
    public class MeetingRoom
    {
        public Fields fields { get; set; }

        //public MeetingRoom(string sumamary, string idroom, double? quantity, DateTime start, DateTime end, string description) // CTor Issue - np
        //{
        //    Fields fi = new Fields();
        //    Customfield10402 custom = new Customfield10402();
        //    Project project = new Project();
        //    Issuetype type = new Issuetype();
        //    fi.summary = sumamary;
        //    fi.customfield_10307 = quantity;
        //    fi.customfield_10400 = start;
        //    fi.customfield_10401 = end;
        //    custom.id = idroom;
        //    fi.description = description;
        //    this.fields = fi;
        //    this.fields.customfield_10402 = custom;
        //    this.fields.project = project;
        //    this.fields.issuetype = type;
        //}

        public MeetingRoom(string sumamary, string idroom, double? quantity, string start, string end, string description) // CTor Issue - np
        {
            Fields fi = new Fields();
            Customfield10402 custom = new Customfield10402();
            Project project = new Project();
            Issuetype type = new Issuetype();
            fi.summary = sumamary;
            fi.customfield_10307 = quantity;
            fi.customfield_10400 = start;
            fi.customfield_10401 = end;
            custom.id = idroom;
            fi.description = description;
            this.fields = fi;
            this.fields.customfield_10402 = custom;
            this.fields.project = project;
            this.fields.issuetype = type;
        }
    }

    public class Project
    {
        public string key { get; set; }

        public Project()
        {
            this.key = "DKPH";
        }
    }

    public class Issuetype
    {
        public string name { get; set; }

        public Issuetype()
        {
            this.name = "Task";
        }
    }

    public class Customfield10402
    {
        public string self { get; set; }
        public string value { get; set; }
        public string id { get; set; }
    }

    //public class Fields
    //{
    //    public Project project { get; set; }
    //    public string summary { get; set; }
    //    public string description { get; set; }
    //    public Issuetype issuetype { get; set; }
    //    public double? customfield_10307 { get; set; } //quantity
    //    public DateTime? customfield_10400 { get; set; } // Time Start
    //    public DateTime? customfield_10401 { get; set; } // Time End
    //    public Customfield10402 customfield_10402 { get; set; } // ID Room
    //}

    public class Fields
    {
        public Project project { get; set; }
        public string summary { get; set; }
        public string description { get; set; }
        public Issuetype issuetype { get; set; }
        public double? customfield_10307 { get; set; } //quantity
        public string customfield_10400 { get; set; } // Time Start
        public string customfield_10401 { get; set; } // Time End
        public Customfield10402 customfield_10402 { get; set; } // ID Room
    }
}
