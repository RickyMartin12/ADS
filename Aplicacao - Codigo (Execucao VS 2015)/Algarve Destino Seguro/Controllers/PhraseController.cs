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
    public class PhraseController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexGetPhrases(int? page)
        {
            if (page == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IEnumerable<Phrase> phrases = DBAccessor.GetPhrases();
            ViewBag.webGrid = new WebGrid(source: phrases,
                                          canPage: true,
                                          rowsPerPage: 5,
                                          canSort: false,
                                          ajaxUpdateContainerId: "webgrid",
                                          sortFieldName: "Code");

            page = (page >= ViewBag.webGrid.PageCount) ? ViewBag.webGrid.PageCount - 1 : page;
            page = (page < 0) ? 0 : page;

            if (phrases.Count() > 0)
            {
                ViewBag.webGrid.PageIndex = (int) page;
            }
            return PartialView("_IndexPhrases");
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Code,LanguageCode,PhraseCode,Content")] Phrase phrase)
        {
            if (ModelState.IsValid)
            {
                string err = DBAccessor.CreatePhrase(phrase);
                if (err != null)
                {
                    ModelState.AddModelError("", err);
                }
            }

            if (Request.IsAjaxRequest())
            {
                return Json(phrase);
            }

            return RedirectToAction("Index", "Phrase");
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Code,LanguageCode,PhraseCode,Content")] Phrase phrase)
        {
            if (ModelState.IsValid)
            {
                string err = DBAccessor.EditPhrase(phrase);
                if (err != null)
                {
                    ModelState.AddModelError("", err);
                }
            }

            if (Request.IsAjaxRequest())
            {
                return Json(phrase);
            }

            return RedirectToAction("Index", "Phrase");
        }

        [HttpPost]
        public ActionResult Delete([Bind(Include = "Code")] Phrase phrase)
        {
            if (ModelState.IsValid)
            {
                string err = DBAccessor.DeletePhrase(phrase);
                if (err != null)
                {
                    ModelState.AddModelError("", err);
                }
            }

            if (Request.IsAjaxRequest())
            {
                return Json(phrase);
            }

            return RedirectToAction("Index", "Phrase");
        }
    }
}