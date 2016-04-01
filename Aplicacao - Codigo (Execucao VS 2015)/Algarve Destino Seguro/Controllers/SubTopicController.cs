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
    public class SubTopicController : Controller
    {
        private Random rng = new Random();
        private IEnumerable<string> acceptedImageTypes = new string[] { ".bmp", ".gif", ".jpg", ".jpeg", ".png" };

        // SubTopics

        public ActionResult Details(string id, string topicTitle, string topicThemeTitle)
        {
            if (id == null || topicTitle == null || topicThemeTitle == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            id = Uri.UnescapeDataString(id);
            topicTitle = Uri.UnescapeDataString(topicTitle);
            topicThemeTitle = Uri.UnescapeDataString(topicThemeTitle);
            SubTopic subTopic = DBAccessor.GetSubTopic(id, topicTitle, topicThemeTitle);
            if (subTopic == null)
            {
                return HttpNotFound();
            }

            return View(subTopic);
        }

        public ActionResult DetailsGetSubTopicContentsPage(string id, string topicTitle, string topicThemeTitle, int? page)
        {
            if (id == null || topicTitle == null || topicThemeTitle == null || page == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            id = Uri.UnescapeDataString(id);
            topicTitle = Uri.UnescapeDataString(topicTitle);
            topicThemeTitle = Uri.UnescapeDataString(topicThemeTitle);
            SubTopic subTopic = DBAccessor.GetSubTopic(id, topicTitle, topicThemeTitle);
            if (subTopic == null)
            {
                return HttpNotFound();
            }

            IEnumerable<SubTopicContent> subTopicContents = DBAccessor.GetSubTopicContents(subTopic);
            ViewBag.webGrid = new WebGrid(source: subTopicContents,
                                          canPage: true,
                                          rowsPerPage: 5,
                                          canSort: false,
                                          ajaxUpdateContainerId: "webgrid",
                                          sortFieldName: "LanguageCode");

            page = (page >= ViewBag.webGrid.PageCount) ? ViewBag.webGrid.PageCount - 1 : page;
            page = (page < 0) ? 0 : page;

            if (subTopicContents.Count() > 0)
            {
                ViewBag.webGrid.PageIndex = (int)page;
            }
            return PartialView("_DetailsSubTopicContents", subTopic);
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "TopicThemeTitle,TopicTitle,Title,Description,Visibility,Icon")] SubTopicViewModel subTopic)
        {
            if (ModelState.IsValid)
            {
                string filePath = null;

                HttpPostedFileBase icon = subTopic.Icon;
                if (icon != null)
                {
                    var extension = Path.GetExtension(icon.FileName).ToLower();
                    if (icon.ContentLength > 0 && acceptedImageTypes.Contains(extension))
                    {
                        var fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + rng.Next(1, 2000000000) + extension;
                        filePath = Path.Combine(Server.MapPath("~/Icons"), fileName);
                        icon.SaveAs(filePath);
                    }
                }

                SubTopic newSubTopic = new SubTopic
                {
                    TopicThemeTitle = subTopic.TopicThemeTitle,
                    TopicTitle = subTopic.TopicTitle,
                    Title = subTopic.Title,
                    Description = subTopic.Description,
                    Visibility = subTopic.Visibility,
                    Icon = filePath
                };

                string err = DBAccessor.CreateSubTopic(newSubTopic);
                if (err != null)
                {
                    ModelState.AddModelError("", err);
                }
            }

            if (Request.IsAjaxRequest())
            {
                subTopic.Icon = null;
                return Json(subTopic);
            }

            return RedirectToAction("Details", "Topic", new { id = subTopic.TopicTitle, themeTitle = subTopic.TopicThemeTitle });
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "TopicThemeTitle,TopicTitle,Title,Description,Visibility,Icon")] SubTopicViewModel subTopic)
        {
            if (ModelState.IsValid)
            {
                string filePath = null;
                SubTopic dbSubTopic = DBAccessor.GetSubTopic(subTopic.Title, subTopic.TopicTitle, subTopic.TopicThemeTitle);

                HttpPostedFileBase icon = subTopic.Icon;
                if (icon != null)
                {
                    var extension = Path.GetExtension(icon.FileName).ToLower();
                    if (icon.ContentLength > 0 && acceptedImageTypes.Contains(extension))
                    {
                        if (dbSubTopic.Icon != null && System.IO.File.Exists(dbSubTopic.Icon))
                        {
                            System.IO.File.Delete(dbSubTopic.Icon);
                        }

                        var fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + rng.Next(1, 2000000000) + extension;
                        filePath = Path.Combine(Server.MapPath("~/Icons"), fileName);
                        icon.SaveAs(filePath);
                    }
                }

                SubTopic newSubTopic = new SubTopic
                {
                    TopicThemeTitle = subTopic.TopicThemeTitle,
                    TopicTitle = subTopic.TopicTitle,
                    Title = subTopic.Title,
                    Description = subTopic.Description,
                    Visibility = subTopic.Visibility
                };

                if (filePath == null)
                    newSubTopic.Icon = dbSubTopic.Icon;
                else
                    newSubTopic.Icon = filePath;
                subTopic.IconPath = newSubTopic.Icon;

                string err = DBAccessor.EditSubTopic(newSubTopic);
                if (err != null)
                {
                    ModelState.AddModelError("", err);
                }
            }

            if (Request.IsAjaxRequest())
            {
                subTopic.Icon = null;
                return Json(subTopic);
            }

            return RedirectToAction("Details", "Topic", new { id = subTopic.TopicTitle, themeTitle = subTopic.TopicThemeTitle });
        }

        [HttpPost]
        public ActionResult Delete([Bind(Include = "TopicThemeTitle,TopicTitle,Title")] SubTopic subTopic)
        {
            if (ModelState.IsValid)
            {
                string err = DBAccessor.DeleteSubTopic(subTopic);
                if (err != null)
                {
                    ModelState.AddModelError("", err);
                }
            }

            if (Request.IsAjaxRequest())
            {
                return Json(subTopic);
            }

            return RedirectToAction("Details", "Topic", new { id = subTopic.TopicTitle, themeTitle = subTopic.TopicThemeTitle });
        }

        // SubTopic Contents

        public ActionResult DetailsContent(string id, string subTopicTitle, string subTopicTopicTitle, string subTopicTopicThemeTitle)
        {
            if (id == null || subTopicTitle == null || subTopicTopicTitle == null || subTopicTopicThemeTitle == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            id = Uri.UnescapeDataString(id);
            subTopicTitle = Uri.UnescapeDataString(subTopicTitle);
            subTopicTopicTitle = Uri.UnescapeDataString(subTopicTopicTitle);
            subTopicTopicThemeTitle = Uri.UnescapeDataString(subTopicTopicThemeTitle);
            SubTopicContent subTopicContent = DBAccessor.GetSubTopicContent(id, subTopicTitle, subTopicTopicTitle, subTopicTopicThemeTitle);
            if (subTopicContent == null)
            {
                return HttpNotFound();
            }

            return View(subTopicContent);
        }

        [HttpPost]
        public ActionResult CreateContent([Bind(Include = "SubTopicTopicThemeTitle,SubTopicTopicTitle,SubTopicTitle,LanguageCode,TranslatedTitle,Visibility,Document")] SubTopicContentViewModel subTopicContent)
        {
            if (ModelState.IsValid)
            {
                string filePath = null;

                HttpPostedFileBase document = subTopicContent.Document;
                if (document != null)
                {
                    var extension = Path.GetExtension(document.FileName);
                    if (document.ContentLength > 0 && (extension.Equals(".html") || extension.Equals(".htm")))
                    {
                        var fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + rng.Next(1, 2000000000) + ".html";
                        filePath = Path.Combine(Server.MapPath("~/Documents/Uploads"), fileName);
                        document.SaveAs(filePath);
                    }
                }

                SubTopicContent content = new SubTopicContent
                {
                    SubTopicTopicThemeTitle = subTopicContent.SubTopicTopicThemeTitle,
                    SubTopicTopicTitle = subTopicContent.SubTopicTopicTitle,
                    SubTopicTitle = subTopicContent.SubTopicTitle,
                    LanguageCode = subTopicContent.LanguageCode,
                    TranslatedTitle = subTopicContent.TranslatedTitle,
                    Visibility = subTopicContent.Visibility,
                    Document = filePath
                };

                string err = DBAccessor.CreateSubTopicContent(content);
                if (err != null)
                {
                    ModelState.AddModelError("", err);
                }
            }

            if (Request.IsAjaxRequest())
            {
                subTopicContent.Document = null;
                return Json(subTopicContent);
            }

            return RedirectToAction("Details", "SubTopic", new { id = subTopicContent.SubTopicTitle, topicTitle = subTopicContent.SubTopicTopicTitle, topicThemeTitle = subTopicContent.SubTopicTopicThemeTitle });
        }

        [HttpPost]
        public ActionResult EditContent([Bind(Include = "SubTopicTopicThemeTitle,SubTopicTopicTitle,SubTopicTitle,LanguageCode,TranslatedTitle,Visibility,Document")] SubTopicContentViewModel subTopicContent)
        {
            if (ModelState.IsValid)
            {
                string filePath = null;
                SubTopicContent dbContent = DBAccessor.GetSubTopicContent(subTopicContent.LanguageCode, subTopicContent.SubTopicTitle, subTopicContent.SubTopicTopicTitle, subTopicContent.SubTopicTopicThemeTitle);

                HttpPostedFileBase document = subTopicContent.Document;
                if (document != null)
                {
                    var extension = Path.GetExtension(document.FileName);
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

                SubTopicContent content = new SubTopicContent
                {
                    SubTopicTopicThemeTitle = subTopicContent.SubTopicTopicThemeTitle,
                    SubTopicTopicTitle = subTopicContent.SubTopicTopicTitle,
                    SubTopicTitle = subTopicContent.SubTopicTitle,
                    LanguageCode = subTopicContent.LanguageCode,
                    TranslatedTitle = subTopicContent.TranslatedTitle,
                    Visibility = subTopicContent.Visibility,
                };

                if (filePath == null)
                    content.Document = dbContent.Document;
                else
                    content.Document = filePath;
                subTopicContent.DocumentPath = content.Document;

                string err = DBAccessor.EditSubTopicContent(content);
                if (err != null)
                {
                    ModelState.AddModelError("", err);
                }
            }

            if (Request.IsAjaxRequest())
            {
                subTopicContent.Document = null;
                return Json(subTopicContent);
            }

            return RedirectToAction("Details", "SubTopic", new { id = subTopicContent.SubTopicTitle, topicTitle = subTopicContent.SubTopicTopicTitle, topicThemeTitle = subTopicContent.SubTopicTopicThemeTitle });
        }

        [HttpPost]
        public ActionResult DeleteContent([Bind(Include = "SubTopicTopicThemeTitle,SubTopicTopicTitle,SubTopicTitle,LanguageCode")] SubTopicContent subTopicContent)
        {
            if (ModelState.IsValid)
            {
                SubTopicContent dbContent = DBAccessor.GetSubTopicContent(subTopicContent.LanguageCode, subTopicContent.SubTopicTitle, subTopicContent.SubTopicTopicTitle, subTopicContent.SubTopicTopicThemeTitle);
                if (dbContent.Document != null && System.IO.File.Exists(dbContent.Document))
                {
                    System.IO.File.Delete(dbContent.Document);
                }

                string err = DBAccessor.DeleteSubTopicContent(subTopicContent);
                if (err != null)
                {
                    ModelState.AddModelError("", err);
                }
            }

            if (Request.IsAjaxRequest())
            {
                subTopicContent.Document = null;
                return Json(subTopicContent);
            }

            return RedirectToAction("Details", "SubTopic", new { id = subTopicContent.SubTopicTitle, topicTitle = subTopicContent.SubTopicTopicTitle, topicThemeTitle = subTopicContent.SubTopicTopicThemeTitle });
        }
    }
}