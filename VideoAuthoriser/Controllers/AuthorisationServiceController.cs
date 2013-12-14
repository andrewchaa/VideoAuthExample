using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VideoAuthoriser.Controllers
{
    public class AuthorisationServiceController : Controller
    {
        //
        // GET: /AuthorisationService/

        public ActionResult Index()
        {
            string response = "<auth id=\"xxxxx\">" +
                               "<start date=\"2011-03-17\" time=\"12:30\"/>" +
                               "<expireafter>3600000</expireafter>" +
                               "<history href=\"http://domain.com/video/history/xxxxx\" />" +
                              "</auth>";

            return Content(response, "text/xml");
        }

        //
        // GET: /AuthorisationService/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }


        //
        // POST: /AuthorisationService/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /AuthorisationService/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /AuthorisationService/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /AuthorisationService/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /AuthorisationService/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
