using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Owasp.Data;
using VideoShop.Models;

namespace VideoShop.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Index(PatientList pl)
        {
            if (pl !=null && !string.IsNullOrEmpty(pl.Searchname))
                pl = DbUtils.FetchData(pl.Searchname);

            return View(pl);
        }
    }
}