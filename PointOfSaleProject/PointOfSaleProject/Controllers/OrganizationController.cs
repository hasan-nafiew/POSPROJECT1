using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PointOfSaleProject.DAL;
using PointOfSaleProject.Models.ViewModel;

namespace PointOfSaleProject.Controllers
{
    public class OrganizationController : Controller
    {
        OrganizationVM ModelVm = new OrganizationVM();
        OrganizationDAL organizationDa = new OrganizationDAL();
        Image imageData = new Image();

        // GET: Organization
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrganizationVM itemVm, HttpPostedFileBase file)
        {
            itemVm.Date = DateTime.Now;
            itemVm.Image = imageData.ImageConvertToByte(file);
            if (ModelState.IsValid)
            {
                if (organizationDa.IsOrganizationSaved(itemVm))
                {
                    return RedirectToAction("Index");
                }
            }

            ModelVm.Code = organizationDa.GetOrganizationCode();
            return View(ModelVm);
        }

    }
}