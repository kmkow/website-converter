using MVCP1.Controllers;
using MVCP1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IronPdf;

namespace MVCP1.Controllers
{
    public class ConvController : Controller
    {
        // GET: Conv
        public ActionResult Index()
        {
            return View(new CurrModel());
        }
        [HttpPost]
        public ActionResult Index(CurrModel conv, string convert)
        {
            var converter1 = new Converter("bec007dd3b1548b27f7d");
            if (convert == "convert")
            {

                conv.Value = converter1.Convert(conv.Amount, conv.From, conv.To);

            }


            return View(conv);
        }
    }
}