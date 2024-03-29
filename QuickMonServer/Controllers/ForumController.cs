﻿#region Using
 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace QuickMonServer.Controllers
{
    [Authorize]
    public class ForumController : Controller
    {
        // GET: /forum/general-view
        public ActionResult GeneralView()
        {
            return View();
        }

        // GET: /forum/topic-view
        public ActionResult TopicView()
        {
            return View();
        }

        // GET: /forum/post-view
        public ActionResult PostView()
        {
            return View();
        }
    }
}