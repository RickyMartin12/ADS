using Algarve_Destino_Seguro.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Algarve_Destino_Seguro.Controllers
{
    public class ThemeController : Controller
    {
        private Random rng = new Random();
        private IEnumerable<string> acceptedImageTypes = new string[] { ".bmp", ".gif", ".jpg", ".jpeg", ".png" };

        // Themes

        public ActionResult Index()
        {
            return View(DBAccessor.GetThemes());
        }

        public ActionResult IndexGetThemes()
        {
            IEnumerable<Theme> themes = DBAccessor.GetThemes();
            ViewBag.webGrid = new WebGrid(source: themes,
                                          canPage: false,
                                          canSort: false,
                                          ajaxUpdateContainerId: "webgrid",
                                          sortFieldName: "Title");

            return PartialView("_IndexThemes");
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            id = Uri.UnescapeDataString(id);
            Theme theme = DBAccessor.GetTheme(id);
            if (theme == null)
            {
                return HttpNotFound();
            }

            return View(theme);
        }

        public ActionResult DetailsGetTopicsPage(string id, int? page)
        {
            if (id == null || page == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            id = Uri.UnescapeDataString(id);
            Theme theme = DBAccessor.GetTheme(id);
            if (theme == null)
            {
                return HttpNotFound();
            }

            IEnumerable<Topic> topics = DBAccessor.GetTopics(theme);
            ViewBag.webGrid = new WebGrid(source: topics,
                                          canPage: true,
                                          rowsPerPage: 5,
                                          canSort: false,
                                          ajaxUpdateContainerId: "webgrid-topics",
                                          sortFieldName: "Title");

            page = (page >= ViewBag.webGrid.PageCount) ? ViewBag.webGrid.PageCount - 1 : page;
            page = (page < 0) ? 0 : page;

            if (topics.Count() > 0) {
                ViewBag.webGrid.PageIndex = (int) page;
            }
            return PartialView("_DetailsTopics", theme);
        }

        public ActionResult DetailsGetThemeContentsPage(string id, int? page)
        {
            if (id == null || page == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            id = Uri.UnescapeDataString(id);
            Theme theme = DBAccessor.GetTheme(id);
            if (theme == null)
            {
                return HttpNotFound();
            }

            IEnumerable<ThemeContent> themeContents = DBAccessor.GetThemeContents(theme);
            ViewBag.webGrid = new WebGrid(source: themeContents,
                                          canPage: true,
                                          rowsPerPage: 5,
                                          canSort: false,
                                          ajaxUpdateContainerId: "webgrid-themecontents",
                                          sortFieldName: "LanguageCode");

            page = (page >= ViewBag.webGrid.PageCount) ? ViewBag.webGrid.PageCount - 1 : page;
            page = (page < 0) ? 0 : page;

            if (themeContents.Count() > 0)
            {
                ViewBag.webGrid.PageIndex = (int) page;
            }
            return PartialView("_DetailsThemeContents", theme);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Title,Description,Visibility,Icon")] ThemeViewModel theme)
        {
            if (ModelState.IsValid)
            {
                string filePath = null;
                Theme dbTheme = DBAccessor.GetTheme(theme.Title);

                HttpPostedFileBase icon = theme.Icon;
                if (icon != null)
                {
                    var extension = Path.GetExtension(icon.FileName).ToLower();
                    if (icon.ContentLength > 0 && acceptedImageTypes.Contains(extension))
                    {
                        if (dbTheme.Icon != null && System.IO.File.Exists(dbTheme.Icon))
                        {
                            System.IO.File.Delete(dbTheme.Icon);
                        }

                        var fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + rng.Next(1, 2000000000) + extension;
                        filePath = Path.Combine(Server.MapPath("~/Icons"), fileName);
                        icon.SaveAs(filePath);
                    }
                }

                Theme newTheme = new Theme
                {
                    Title = theme.Title,
                    Description = theme.Description,
                    Visibility = theme.Visibility
                };

                if (filePath == null)
                    newTheme.Icon = dbTheme.Icon;
                else
                    newTheme.Icon = filePath;
                theme.IconPath = newTheme.Icon;

                string err = DBAccessor.EditTheme(newTheme);
                if (err != null)
                {
                    ModelState.AddModelError("", err);
                }
            }

            if (Request.IsAjaxRequest())
            {
                theme.Icon = null;
                return Json(theme);
            }

            return RedirectToAction("Index", "Theme");
        }

        // Theme Contents

        public ActionResult DetailsContent(string id, string themeTitle)
        {
            if (id == null || themeTitle == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            id = Uri.UnescapeDataString(id);
            themeTitle = Uri.UnescapeDataString(themeTitle);
            ThemeContent themeContent = DBAccessor.GetThemeContent(id, themeTitle);
            if (themeContent == null)
            {
                return HttpNotFound();
            }

            return View(themeContent);
        }

        [HttpPost]
        public ActionResult CreateContent([Bind(Include = "ThemeTitle,LanguageCode,TranslatedTitle,Visibility,Document")] ThemeContentViewModel themeContent)
        {
            if (ModelState.IsValid)
            {
                string filePath = null;

                HttpPostedFileBase document = themeContent.Document;
                if (document != null)
                {
                    var extension = Path.GetExtension(document.FileName).ToLower();
                    if (document.ContentLength > 0 && (extension.Equals(".html") || extension.Equals(".htm")))
                    {
                        var fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + rng.Next(1, 2000000000) + ".html";
                        filePath = Path.Combine(Server.MapPath("~/Documents/Uploads"), fileName);
                        document.SaveAs(filePath);
                    }
                }

                ThemeContent content = new ThemeContent {
                        ThemeTitle = themeContent.ThemeTitle,
                        LanguageCode = themeContent.LanguageCode,
                        TranslatedTitle = themeContent.TranslatedTitle,
                        Visibility = themeContent.Visibility,
                        Document = filePath
                    };

                string err = DBAccessor.CreateThemeContent(content);
                if (err != null)
                {
                    ModelState.AddModelError("", err);
                }
            }

            if (Request.IsAjaxRequest())
            {
                themeContent.Document = null;
                return Json(themeContent);
            }

            return RedirectToAction("Details", "Theme", new { id = themeContent.ThemeTitle });
        }

        [HttpPost]
        public ActionResult EditContent([Bind(Include = "ThemeTitle,LanguageCode,TranslatedTitle,Visibility,Document")] ThemeContentViewModel themeContent)
        {
            if (ModelState.IsValid)
            {
                string filePath = null;
                ThemeContent dbContent = DBAccessor.GetThemeContent(themeContent.LanguageCode, themeContent.ThemeTitle);
                        
                HttpPostedFileBase document = themeContent.Document;
                if (document != null)
                {
                    var extension = Path.GetExtension(document.FileName).ToLower();
                    if (document.ContentLength > 0 && (extension.Equals(".html") || extension.Equals(".htm")))
                    {
                        if (dbContent.Document != null && System.IO.File.Exists(dbContent.Document))
                        {
                            System.IO.File.Delete(dbContent.Document);
                        }

                        var fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + rng.Next(1, 2000000000) + ".html";
                        filePath = Path.Combine(Server.MapPath("~/Documents/Uploads"), fileName);
                        document.SaveAs(filePath);
                    }
                }

                ThemeContent content = new ThemeContent
                {
                    ThemeTitle = themeContent.ThemeTitle,
                    LanguageCode = themeContent.LanguageCode,
                    TranslatedTitle = themeContent.TranslatedTitle,
                    Visibility = themeContent.Visibility,
                };

                if (filePath == null)
                    content.Document = dbContent.Document;
                else
                    content.Document = filePath;
                themeContent.DocumentPath = content.Document;

                string err = DBAccessor.EditThemeContent(content);
                if (err != null)
                {
                    ModelState.AddModelError("", err);
                }
            }

            if (Request.IsAjaxRequest())
            {
                themeContent.Document = null;
                return Json(themeContent);
            }

            return RedirectToAction("Details", "Theme", new { id = themeContent.ThemeTitle });
        }

        [HttpPost]
        public ActionResult DeleteContent([Bind(Include = "ThemeTitle,LanguageCode")] ThemeContent themeContent)
        {
            if (ModelState.IsValid)
            {
                ThemeContent dbContent = DBAccessor.GetThemeContent(themeContent.LanguageCode, themeContent.ThemeTitle);
                if (dbContent.Document != null && System.IO.File.Exists(dbContent.Document))
                {
                    System.IO.File.Delete(dbContent.Document);
                }

                string err = DBAccessor.DeleteThemeContent(themeContent);
                if (err != null)
                {
                    ModelState.AddModelError("", err);
                }
            }

            if (Request.IsAjaxRequest())
            {
                themeContent.Document = null;
                return Json(themeContent);
            }

            return RedirectToAction("Details", "Theme", new { id = themeContent.ThemeTitle });
        }
    }
}