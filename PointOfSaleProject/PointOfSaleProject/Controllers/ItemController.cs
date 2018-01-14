using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PointOfSaleProject.DAL;
using PointOfSaleProject.Models.ViewModel;

namespace PointOfSaleProject.Controllers
{
    public class ItemController : Controller
    {
        ItemVM modelVm = new ItemVM();
        ItemDAL itemDa = new ItemDAL();
        Image imageData=new Image();
        // GET: Item
        public ActionResult Index()
        {
            return View();
        } 
        public ActionResult Create()
        {
            modelVm.SelectList = itemDa.GetSelectListItems();
            modelVm.Code = itemDa.GetItemCode();
            return View(modelVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItemVM itemVm, HttpPostedFileBase file)
        {
            itemVm.Date=DateTime.Now;
            itemVm.Image = imageData.ImageConvertToByte(file);
            if (ModelState.IsValid)
            {
                itemDa.IsItemSaved(itemVm);
            }
            modelVm.SelectList = itemDa.GetSelectListItems();
            return View(modelVm);
        }

        public ActionResult Edit()
        {
            return View();
        }
    }
}