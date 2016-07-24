using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    public class ComputerController : Controller
    {
        private ProductContext db = new ProductContext();

        // GET: /Computer/
        public ActionResult Index()
        {
            return View(db.Products_ComputerServer.ToList());
        }

        // GET: /Computer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products_ComputerServer products_computerserver = db.Products_ComputerServer.Find(id);
            if (products_computerserver == null)
            {
                return HttpNotFound();
            }
            return View(products_computerserver);
        }

        // GET: /Computer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Computer/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ProductId,ModelNumber,Name,Picture,Description,Price,CompanyName,SecretLevel,Structure,Size,CPU,Frequency,StandardCPUNumber,MaxCPUNumber,MemoryType,MemorySize,MaxMemorySize,HardDriveInterface,StandardHardDriveSize,MaxHardDriveSize,Contact,DataEntryPerson,LastUpdateTime,Source")] Products_ComputerServer products_computerserver)
        {
            if (ModelState.IsValid)
            {
                db.Products_ComputerServer.Add(products_computerserver);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(products_computerserver);
        }

        // GET: /Computer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products_ComputerServer products_computerserver = db.Products_ComputerServer.Find(id);
            if (products_computerserver == null)
            {
                return HttpNotFound();
            }
            return View(products_computerserver);
        }

        // POST: /Computer/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ProductId,ModelNumber,Name,Picture,Description,Price,CompanyName,SecretLevel,Structure,Size,CPU,Frequency,StandardCPUNumber,MaxCPUNumber,MemoryType,MemorySize,MaxMemorySize,HardDriveInterface,StandardHardDriveSize,MaxHardDriveSize,Contact,DataEntryPerson,LastUpdateTime,Source")] Products_ComputerServer products_computerserver)
        {
            if (ModelState.IsValid)
            {
                db.Entry(products_computerserver).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(products_computerserver);
        }

        // GET: /Computer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products_ComputerServer products_computerserver = db.Products_ComputerServer.Find(id);
            if (products_computerserver == null)
            {
                return HttpNotFound();
            }
            return View(products_computerserver);
        }

        // POST: /Computer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Products_ComputerServer products_computerserver = db.Products_ComputerServer.Find(id);
            db.Products_ComputerServer.Remove(products_computerserver);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
