﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADCGroup_Service.Model.JiraModel.InfoUser
{
    public class InfoUser
    {
        public string self { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public string emailAddress { get; set; }
        public AvatarUrls avatarUrls { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
        public string timeZone { get; set; }
        public string locale { get; set; }
        public Groups groups { get; set; }
        public ApplicationRoles applicationRoles { get; set; }
        public string expand { get; set; }
    }

    public class AvatarUrls
    {
        public string __invalid_name__48x48 { get; set; }
        public string __invalid_name__24x24 { get; set; }
        public string __invalid_name__16x16 { get; set; }
        public string __invalid_name__32x32 { get; set; }
    }

    public class Groups
    {
        public int size { get; set; }
        public List<object> items { get; set; }
    }

    public class ApplicationRoles
    {
        public int size { get; set; }
        public List<object> items { get; set; }
    }
}
