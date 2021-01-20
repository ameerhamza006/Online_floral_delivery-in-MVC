using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using Online_floral_delivery.Models;


namespace Online_floral_delivery.Controllers
{
    public class backendController : Controller
    {
        floral_deliveryEntities8 db = new floral_deliveryEntities8();
        
        // GET: backend

        public ActionResult dashboard()
        {
            return View();
        }

        /*------------------------------OCCASIONS--------------------*/

        public ActionResult ocassion()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult ocassion(category r)
        {
            db.categories.Add(r);
            int a = db.SaveChanges();
            if (a == 1)
            {
                ModelState.Clear();
                ViewBag.message = "Category added";

            }
            else
            {
                ViewBag.message = "Category not added";

            }
            return View();
        }
        public ActionResult occ_view()
        {
            return View(db.categories.ToList());
        }
        public ActionResult occ_delete(int id)
        {
            db.categories.Remove(db.categories.Find(id));
            db.SaveChanges();
            return View();
        }
        public ActionResult updateCategory(int id)
        {
            return View(db.categories.Find(id));
        }
        [HttpPost]
        public ActionResult updateCategory(category ct, int id)
        {
            var data = db.categories.Where(a => a.category_id == id).FirstOrDefault();
            data.category_name = ct.category_name;
          int d =  db.SaveChanges();
            if (d == 1)
            {
                ModelState.Clear();
                ViewBag.message = "Category updated";

            }
            else
            {
                ViewBag.message = "Category not update";

            }
            return View();
        }

        /*-------------------------ADD-PRODUCT--------------------*/

        public ActionResult AddProduct()
        {
            ViewBag.product_category_id = new SelectList(db.categories.ToList(), "category_id", "category_name");
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(product t, HttpPostedFileBase p)
        {
            if (ModelState.IsValid)
            {
                ViewBag.product_category_id = new SelectList(db.categories.ToList(), "category_id", "category_name");
                string pic = Path.Combine(Server.MapPath("~/img/"), Path.GetFileName(p.FileName));
                p.SaveAs(pic);

                t.product_image = p.FileName;
                db.products.Add(t);
                int pt = db.SaveChanges();
                if (pt == 1)
                {

                    ViewBag.message = "product added";

                }
                else
                {
                    ViewBag.message = "product not added";

                }
            }
            return View();
        }
        /*------------------------------about--------------------*/

        //public ActionResult about_des()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult about_des(B des,HttpPostedFileBase hp)
        //{
        //    string data = Path.Combine(Server.MapPath("~/img"), Path.GetFileName(hp.FileName));
        //    hp.SaveAs(data);
        //    des.images = hp.FileName;
        //    db.B.Add(des);
        //    db.SaveChanges();
            

        //    return View();
        //}
        public ActionResult team_member()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult team_member(team t, HttpPostedFileBase snaps)
        //{
        //    string pic = Path.Combine(Server.MapPath("~/img"), Path.GetFileName(snaps));
        //    snaps.SaveAs(pic);
        //    t.images = snaps.FileName;
        //    db.teams.Add(t);
        //    db.SaveChanges();
        //    return View();
        //}

        public ActionResult addadmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult addadmin( registeration r)
        {
            db.registerations.Add(r);
            db.SaveChanges();
            return View();
        }

        public ActionResult adminlist()
        {
            return View(db.registerations.ToList());
        }

        public ActionResult admindelete(int? id)
        {
            var l = db.registerations.Find(id);
            db.registerations.Remove(l);
            db.SaveChanges();
            TempData["userdelet"] = "Succesfully Delete";
            return RedirectToAction("adminlist", "backend");
        }


        public ActionResult cartlist()
        {
            return View(db.carts.ToList());
        }

    }
}