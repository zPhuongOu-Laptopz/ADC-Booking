﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADCGroup_WebUI.Controllers
{
    public class BuildingController : Controller
    {
        // GET: Building
        public ActionResult Index(string _username)
        {
            ViewBag.Name = _username;
            return View();
        }
    }
}