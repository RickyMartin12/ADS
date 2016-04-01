using Algarve_Destino_Seguro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Algarve_Destino_Seguro.Controllers
{
    public class LanguageController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexGetLanguages(int? page)
        {
            if (page == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IEnumerable<Language> languages = DBAccessor.GetLanguages();
            ViewBag.webGrid = new WebGrid(source: languages,
                                          canPage: true,
                                          rowsPerPage: 5,
                                          canSort: false,
                                          ajaxUpdateContainerId: "webgrid",
                                          sortFieldName: "Code");

            page = (page >= ViewBag.webGrid.PageCount) ? ViewBag.webGrid.PageCount - 1 : page;
            page = (page < 0) ? 0 : page;

            if (languages.Count() > 0)
            {
                ViewBag.webGrid.PageIndex = (int) page;
            }
            return PartialView("_IndexLanguages");
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Code,Name")] Language language)
        {
            if (ModelState.IsValid)
            {
                string err = DBAccessor.CreateLanguage(language);
                if (err != null)
                {
                    ModelState.AddModelError("", err);
                }
            }

            if (Request.IsAjaxRequest())
            {
                return Json(language);
            }

            return RedirectToAction("Index", "Language");
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Code,Name")] Language language)
        {
            if (ModelState.IsValid)
            {
                string err = DBAccessor.EditLanguage(language);
                if (err != null)
                {
                    ModelState.AddModelError("", err);
                }
            }

            if (Request.IsAjaxRequest())
            {
                return Json(language);
            }

            return RedirectToAction("Index", "Language");
        }

        [HttpPost]
        public ActionResult Delete([Bind(Include = "Code")] Language language)
        {
            if (ModelState.IsValid)
            {
                string err = DBAccessor.DeleteLanguage(language);
                if (err != null)
                {
                    ModelState.AddModelError("", err);
                }
            }

            if (Request.IsAjaxRequest())
            {
                return Json(language);
            }

            return RedirectToAction("Index", "Language");
        }
    }
}