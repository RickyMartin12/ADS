using Algarve_Destino_Seguro.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Algarve_Destino_Seguro.Controllers
{
    public class TopicController : Controller
    {
        private Random rng = new Random();
        private IEnumerable<string> acceptedImageTypes = new string[] { ".bmp", ".gif", ".jpg", ".jpeg", ".png" };

        // Topics

        public ActionResult Details(string id, string themeTitle)
        {
            if (id == null || themeTitle == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            id = Uri.UnescapeDataString(id);
            themeTitle = Uri.UnescapeDataString(themeTitle);
            Topic topic = DBAccessor.GetTopic(id, themeTitle);
            if (topic == null)
            {
                return HttpNotFound();
            }

            return View(topic);
        }

        public ActionResult DetailsGetSubTopicsPage(string id, string themeTitle, int? page)
        {
            if (id == null || themeTitle == null || page == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            id = Uri.UnescapeDataString(id);
            themeTitle = Uri.UnescapeDataString(themeTitle);
            Topic topic = DBAccessor.GetTopic(id, themeTitle);
            if (topic == null)
            {
                return HttpNotFound();
            }

            IEnumerable<SubTopic> subTopics = DBAccessor.GetSubTopics(topic);
            ViewBag.webGrid = new WebGrid(source: subTopics,
                                          canPage: true,
                                          rowsPerPage: 5,
                                          canSort: false,
                                          ajaxUpdateContainerId: "webgrid-subtopics",
                                          sortFieldName: "Title");

            page = (page >= ViewBag.webGrid.PageCount) ? ViewBag.webGrid.PageCount - 1 : page;
            page = (page < 0) ? 0 : page;
            
            if (subTopics.Count() > 0)
            {
                ViewBag.webGrid.PageIndex = (int) page;
            }
            return PartialView("_DetailsSubTopics", topic);
        }

        public ActionResult DetailsGetTopicContentsPage(string id, string themeTitle, int? page)
        {
            if (id == null || themeTitle == null || page == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            id = Uri.UnescapeDataString(id);
            themeTitle = Uri.UnescapeDataString(themeTitle);
            Topic topic = DBAccessor.GetTopic(id, themeTitle);
            if (topic == null)
            {
                return HttpNotFound();
            }

            IEnumerable<TopicContent> topicContents = DBAccessor.GetTopicContents(topic);
            ViewBag.webGrid = new WebGrid(source: topicContents,
                                          canPage: true,
                                          rowsPerPage: 5,
                                          canSort: false,
                                          ajaxUpdateContainerId: "webgrid-topiccontents",
                                          sortFieldName: "LanguageCode");

            page = (page >= ViewBag.webGrid.PageCount) ? ViewBag.webGrid.PageCount - 1 : page;
            page = (page < 0) ? 0 : page;

            if (topicContents.Count() > 0)
            {
                ViewBag.webGrid.PageIndex = (int) page;
            }
            return PartialView("_DetailsTopicContents", topic);
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "ThemeTitle,Title,Description,Visibility,Icon")] TopicViewModel topic)
        {
            if (ModelState.IsValid)
            {
                string filePath = null;

                HttpPostedFileBase icon = topic.Icon;
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

                Topic newTopic = new Topic
                {
                    ThemeTitle = topic.ThemeTitle,
                    Title = topic.Title,
                    Description = topic.Description,
                    Visibility = topic.Visibility,
                    Icon = filePath
                };

                string err = DBAccessor.CreateTopic(newTopic);
                if (err != null)
                {
                    ModelState.AddModelError("", err);
                }
            }

            if (Request.IsAjaxRequest())
            {
                topic.Icon = null;
                return Json(topic);
            }

            return RedirectToAction("Details", "Theme", new { id = topic.ThemeTitle });
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "ThemeTitle,Title,Description,Visibility,Icon")] TopicViewModel topic)
        {
            if (ModelState.IsValid)
            {
                string filePath = null;
                Topic dbTopic = DBAccessor.GetTopic(topic.Title, topic.ThemeTitle);

                HttpPostedFileBase icon = topic.Icon;
                if (icon != null)
                {
                    var extension = Path.GetExtension(icon.FileName).ToLower();
                    if (icon.ContentLength > 0 && acceptedImageTypes.Contains(extension))
                    {
                        if (dbTopic.Icon != null && System.IO.File.Exists(dbTopic.Icon))
                        {
                            System.IO.File.Delete(dbTopic.Icon);
                        }

                        var fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + rng.Next(1, 2000000000) + extension;
                        filePath = Path.Combine(Server.MapPath("~/Icons"), fileName);
                        icon.SaveAs(filePath);
                    }
                }

                Topic newTopic = new Topic
                {
                    ThemeTitle = topic.ThemeTitle,
                    Title = topic.Title,
                    Description = topic.Description,
                    Visibility = topic.Visibility
                };

                if (filePath == null)
                    newTopic.Icon = dbTopic.Icon;
                else
                    newTopic.Icon = filePath;
                topic.IconPath = newTopic.Icon;

                string err = DBAccessor.EditTopic(newTopic);
                if (err != null)
                {
                    ModelState.AddModelError("", err);
                }
            }

            if (Request.IsAjaxRequest())
            {
                topic.Icon = null;
                return Json(topic);
            }

            return RedirectToAction("Details", "Theme", new { id = topic.ThemeTitle });
        }

        [HttpPost]
        public ActionResult Delete([Bind(Include = "ThemeTitle,Title")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                string err = DBAccessor.DeleteTopic(topic);
                if (err != null)
                {
                    ModelState.AddModelError("", err);
                }
            }

            if (Request.IsAjaxRequest())
            {
                return Json(topic);
            }

            return RedirectToAction("Details", "Theme", new { id = topic.ThemeTitle });
        }

        // Topic Contents

        public ActionResult DetailsContent(string id, string topicTitle, string topicThemeTitle)
        {
            if (id == null || topicTitle == null || topicThemeTitle == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            id = Uri.UnescapeDataString(id);
            topicTitle = Uri.UnescapeDataString(topicTitle);
            topicThemeTitle = Uri.UnescapeDataString(topicThemeTitle);
            TopicContent topicContent = DBAccessor.GetTopicContent(id, topicTitle, topicThemeTitle);
            if (topicContent == null)
            {
                return HttpNotFound();
            }

            return View(topicContent);
        }

        [HttpPost]
        public ActionResult CreateContent([Bind(Include = "TopicThemeTitle,TopicTitle,LanguageCode,TranslatedTitle,Visibility,Document")] TopicContentViewModel topicContent)
        {
            if (ModelState.IsValid)
            {
                string filePath = null;

                HttpPostedFileBase document = topicContent.Document;
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

                TopicContent content = new TopicContent
                {
                    TopicThemeTitle = topicContent.TopicThemeTitle,
                    TopicTitle = topicContent.TopicTitle,
                    LanguageCode = topicContent.LanguageCode,
                    TranslatedTitle = topicContent.TranslatedTitle,
                    Visibility = topicContent.Visibility,
                    Document = filePath
                };

                string err = DBAccessor.CreateTopicContent(content);
                if (err != null)
                {
                    ModelState.AddModelError("", err);
                }
            }

            if (Request.IsAjaxRequest())
            {
                topicContent.Document = null;
                return Json(topicContent);
            }

            return RedirectToAction("Details", "Topic", new { id = topicContent.TopicTitle, themeTitle = topicContent.TopicThemeTitle });
        }

        [HttpPost]
        public ActionResult EditContent([Bind(Include = "TopicThemeTitle,TopicTitle,LanguageCode,TranslatedTitle,Visibility,Document")] TopicContentViewModel topicContent)
        {
            if (ModelState.IsValid)
            {
                string filePath = null;
                TopicContent dbContent = DBAccessor.GetTopicContent(topicContent.LanguageCode, topicContent.TopicTitle, topicContent.TopicThemeTitle);

                HttpPostedFileBase document = topicContent.Document;
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

                TopicContent content = new TopicContent
                {
                    TopicThemeTitle = topicContent.TopicThemeTitle,
                    TopicTitle = topicContent.TopicTitle,
                    LanguageCode = topicContent.LanguageCode,
                    TranslatedTitle = topicContent.TranslatedTitle,
                    Visibility = topicContent.Visibility,
                };

                if (filePath == null)
                    content.Document = dbContent.Document;
                else
                    content.Document = filePath;
                topicContent.DocumentPath = content.Document;

                string err = DBAccessor.EditTopicContent(content);
                if (err != null)
                {
                    ModelState.AddModelError("", err);
                }
            }

            if (Request.IsAjaxRequest())
            {
                topicContent.Document = null;
                return Json(topicContent);
            }

            return RedirectToAction("Details", "Topic", new { id = topicContent.TopicTitle, themeTitle = topicContent.TopicThemeTitle });
        }

        [HttpPost]
        public ActionResult DeleteContent([Bind(Include = "TopicThemeTitle,TopicTitle,LanguageCode")] TopicContent topicContent)
        {
            if (ModelState.IsValid)
            {
                TopicContent dbContent = DBAccessor.GetTopicContent(topicContent.LanguageCode, topicContent.TopicTitle, topicContent.TopicThemeTitle);
                if (dbContent.Document != null && System.IO.File.Exists(dbContent.Document))
                {
                    System.IO.File.Delete(dbContent.Document);
                }

                string err = DBAccessor.DeleteTopicContent(topicContent);
                if (err != null)
                {
                    ModelState.AddModelError("", err);
                }
            }

            if (Request.IsAjaxRequest())
            {
                topicContent.Document = null;
                return Json(topicContent);
            }

            return RedirectToAction("Details", "Topic", new { id = topicContent.TopicTitle, themeTitle = topicContent.TopicThemeTitle });
        }
    }
}