﻿#region Using
 
using Microsoft.AspNetCore.Mvc;

#endregion

namespace QuickMonServer.Controllers
{
    public class IntelController : Controller
    {
        // GET: /intel/settings
        public ActionResult Settings()
        {
            return View();
        }

        // GET: /intel/skins
        public ActionResult Skins()
        {
            return View();
        }

        // GET: /intel/applayout
        public ActionResult AppLayout()
        {
            return View();
        }
    }
}