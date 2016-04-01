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
    public class IdentifiedZoneController : Controller
    {
        // Identified Zones

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexGetIdentifiedZoneTypesPage(int? page)
        {
            if (page == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IEnumerable<IdentifiedZoneType> identifiedZoneTypes = DBAccessor.GetIdentifiedZoneTypes();
            ViewBag.webGrid = new WebGrid(source: identifiedZoneTypes,
                                          canPage: true,
                                          rowsPerPage: 5,
                                          canSort: false,
                                          ajaxUpdateContainerId: "webgrid-identifiedzonetype",
                                          sortFieldName: "Name");

            page = (page >= ViewBag.webGrid.PageCount) ? ViewBag.webGrid.PageCount - 1 : page;
            page = (page < 0) ? 0 : page;

            if (identifiedZoneTypes.Count() > 0)
            {
                ViewBag.webGrid.PageIndex = (int) page;
            }
            return PartialView("_IndexIdentifiedZoneTypes");
        }

        public ActionResult IndexGetIdentifiedZonesPage(int? page)
        {
            if (page == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IEnumerable<IdentifiedZone> identifiedZones = DBAccessor.GetIdentifiedZones();
            ViewBag.webGrid = new WebGrid(source: identifiedZones,
                                          canPage: true,
                                          rowsPerPage: 5,
                                          canSort: false,
                                          ajaxUpdateContainerId: "webgrid-identifiedzonetype",
                                          sortFieldName: "Name");

            page = (page >= ViewBag.webGrid.PageCount) ? ViewBag.webGrid.PageCount - 1 : page;
            page = (page < 0) ? 0 : page;

            if (identifiedZones.Count() > 0)
            {
                ViewBag.webGrid.PageIndex = (int) page;
            }
            return PartialView("_IndexIdentifiedZones");
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            id = Uri.UnescapeDataString(id);
            IdentifiedZone identifieZone = DBAccessor.GetIdentifiedZone(id);
            if (identifieZone == null)
            {
                return HttpNotFound();
            }

            return View(identifieZone);
        }

        [HttpPost]
        public ActionResult Test(string id, int? page)
        {
            return DetailsGetIdentifiedZoneSchedulesPage(id, page);
        }

        public ActionResult DetailsGetIdentifiedZoneSchedulesPage(string id, int? page)
        {
            if (id == null || page == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            id = Uri.UnescapeDataString(id);
            IdentifiedZone identifiedZone = DBAccessor.GetIdentifiedZone(id);

            IEnumerable<IdentifiedZoneSchedule> identifiedZoneSchedules = DBAccessor.GetIdentifiedZoneSchedules(identifiedZone);
            ViewBag.webGrid = new WebGrid(source: identifiedZoneSchedules,
                                          canPage: true,
                                          rowsPerPage: 5,
                                          canSort: false,
                                          ajaxUpdateContainerId: "webgrid",
                                          sortFieldName: "IdentifiedZoneTypeName");

            page = (page >= ViewBag.webGrid.PageCount) ? ViewBag.webGrid.PageCount - 1 : page;
            page = (page < 0) ? 0 : page;

            if (identifiedZoneSchedules.Count() > 0)
            {
                ViewBag.webGrid.PageIndex = (int)page;
            }
            return PartialView("_DetailsIdentifiedZoneSchedules", identifiedZone);
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Name,Radius,VertexLatitude,VertexLongitude")] IdentifiedZone identifiedZone)
        {
            if (ModelState.IsValid)
            {
                string err = DBAccessor.CreateIdentifiedZone(identifiedZone);
                if (err != null)
                {
                    ModelState.AddModelError("", err);
                }
            }

            if (Request.IsAjaxRequest())
            {
                return Json(identifiedZone);
            }

            return RedirectToAction("Index", "IdentifiedZone");
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Name,Radius,VertexLatitude,VertexLongitude")] IdentifiedZone identifiedZone)
        {
            if (ModelState.IsValid)
            {
                string err = DBAccessor.EditIdentifiedZone(identifiedZone);
                if (err != null)
                {
                    ModelState.AddModelError("", err);
                }
            }

            if (Request.IsAjaxRequest())
            {
                return Json(identifiedZone);
            }

            return RedirectToAction("Index", "IdentifiedZone");
        }

        [HttpPost]
        public ActionResult Delete([Bind(Include = "Name")] IdentifiedZone identifiedZone)
        {
            if (ModelState.IsValid)
            {
                string err = DBAccessor.DeleteIdentifiedZone(identifiedZone);
                if (err != null)
                {
                    ModelState.AddModelError("", err);
                }
            }

            if (Request.IsAjaxRequest())
            {
                return Json(identifiedZone);
            }

            return RedirectToAction("Index", "IdentifiedZone");
        }

        // Identified Zone Types

        [HttpPost]
        public ActionResult CreateType([Bind(Include = "Name,Notification")] IdentifiedZoneType identifiedZoneType)
        {
            if (ModelState.IsValid)
            {
                string err = DBAccessor.CreateIdentifiedZoneType(identifiedZoneType);
                if (err != null)
                {
                    ModelState.AddModelError("", err);
                }
            }

            if (Request.IsAjaxRequest())
            {
                return Json(identifiedZoneType);
            }

            return RedirectToAction("Index", "IdentifiedZone");
        }

        [HttpPost]
        public ActionResult EditType([Bind(Include = "Name,Notification")] IdentifiedZoneType identifiedZoneType)
        {
            if (ModelState.IsValid)
            {
                string err = DBAccessor.EditIdentifiedZoneType(identifiedZoneType);
                if (err != null)
                {
                    ModelState.AddModelError("", err);
                }
            }

            if (Request.IsAjaxRequest())
            {
                return Json(identifiedZoneType);
            }

            return RedirectToAction("Index", "IdentifiedZone");
        }

        [HttpPost]
        public ActionResult DeleteType([Bind(Include = "Name")] IdentifiedZoneType identifiedZoneType)
        {
            if (ModelState.IsValid)
            {
                string err = DBAccessor.DeleteIdentifiedZoneType(identifiedZoneType);
                if (err != null)
                {
                    ModelState.AddModelError("", err);
                }
            }

            if (Request.IsAjaxRequest())
            {
                return Json(identifiedZoneType);
            }

            return RedirectToAction("Index", "IdentifiedZone");
        }

        // Identified Zone Schedules

        [HttpPost]
        public ActionResult CreateSchedule([Bind(Include = "IdentifiedZoneTypeName,IdentifiedZoneName,Start,End")] IdentifiedZoneSchedule identifiedZoneSchedule)
        {
            if (ModelState.IsValid)
            {
                string err = DBAccessor.CreateIdentifiedZoneSchedule(identifiedZoneSchedule);
                if (err != null)
                {
                    ModelState.AddModelError("", err);
                }
            }

            if (Request.IsAjaxRequest())
            {
                return Json(identifiedZoneSchedule);
            }

            return RedirectToAction("Details", "IdentifiedZone", new { id = identifiedZoneSchedule.IdentifiedZoneName });
        }

        [HttpPost]
        public ActionResult EditSchedule([Bind(Include = "IdentifiedZoneTypeName,IdentifiedZoneName,Start,End")] IdentifiedZoneSchedule identifiedZoneSchedule)
        {
            if (ModelState.IsValid)
            {
                string err = DBAccessor.EditIdentifiedZoneSchedule(identifiedZoneSchedule);
                if (err != null)
                {
                    ModelState.AddModelError("", err);
                }
            }

            if (Request.IsAjaxRequest())
            {
                return Json(identifiedZoneSchedule);
            }

            return RedirectToAction("Details", "IdentifiedZone", new { id = identifiedZoneSchedule.IdentifiedZoneName });
        }

        [HttpPost]
        public ActionResult DeleteSchedule([Bind(Include = "IdentifiedZoneTypeName,IdentifiedZoneName")] IdentifiedZoneSchedule identifiedZoneSchedule)
        {
            if (ModelState.IsValid)
            {
                string err = DBAccessor.DeleteIdentifiedZoneSchedule(identifiedZoneSchedule);
                if (err != null)
                {
                    ModelState.AddModelError("", err);
                }
            }

            if (Request.IsAjaxRequest())
            {
                return Json(identifiedZoneSchedule);
            }

            return RedirectToAction("Details", "IdentifiedZone", new { id = identifiedZoneSchedule.IdentifiedZoneName });
        }
    }
}