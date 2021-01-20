using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_floral_delivery.Models;


namespace Online_floral_delivery.Controllers
{
    public class frontendController : Controller
    {
        floral_deliveryEntities8 db = new floral_deliveryEntities8();
        // GET: frontend
        public ActionResult Index()
        {
            ViewBag.a = tocart.c.ToList();
            
            return View();
        }
        //public ActionResult about()
        //{
        //    return View(db.B.ToList());
        //}
        public ActionResult contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult contact(contact ct)
        {
            if (ModelState.IsValid)
            {


                db.contacts.Add(ct);
                db.SaveChanges();
                ModelState.Clear();
            }
            return View();
        }

        public ActionResult register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult register(registeration r)
        {

            if (ModelState.IsValid)
            {

                db.registerations.Add(r);
                int a = db.SaveChanges();
                if (a == 1)
                {
                    ViewBag.message = " Registerd";
                    ModelState.Clear();
                }


                else
                {
                    ViewBag.msg = " not  Registerd";
                }
            }
            return View();
        }


        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(registeration r)
        {
            var match = db.registerations.Where(a => a.Email == r.Email && a.password == r.password).FirstOrDefault();
            if (match != null)
            {
                if(match.role == "User")
                {
                    Session["useremail"] = match.Email;
                    Session["id"] = match.cus_id;
                    ModelState.Clear();
                    return RedirectToAction("Index", "frontend");

                }
                if(match.role == "Admin")
                {
                    Session["Adminname"] = match.F_name;
                    return RedirectToAction("dashboard", "backend");
                }



            }
            else
            {
                ViewBag.message = "invalid Email or password";
                ModelState.Clear();

            }

            return View();
        }


        public ActionResult addtocart()
        {
            ViewBag.a = tocart.c;
            return View();
        }
        [HttpPost]
        public ActionResult addtocart(int? id, int qty, product p)
        {
            foreach (var item in tocart.c)
            {
                if (item.c_id == id)
                {
                    item.c_qty += qty;
                    ViewBag.a = tocart.c;
                    item.c_id = p.id;
                    return View();
                }
            }
            addcart li = new addcart() { c_id = id, c_qty = qty };
            tocart.c.Add(li);
            ViewBag.a = tocart.c;
            return View();
        }

        public ActionResult addtocartnew()
        {
            ViewBag.a = tocart.c;
            return View();
        }
        [HttpPost]
        public ActionResult shopdone(int cart_fk_reg)
        {
            var t = tocart.c.ToList();
            foreach (var item in t)
            {
                cart e = new cart();
                e.cart_qty = item.c_qty;
                e.cart_fk_pro = item.c_id;
                e.cart_fk_reg = cart_fk_reg;
                db.carts.Add(e);
                db.SaveChanges();

            }
            return RedirectToAction("addtocartnew", "frontend");
        }

        public ActionResult removecart(int id)
        {
            tocart.c.RemoveAll(a => a.c_id == id);
            return RedirectToAction("addtocart", "frontend");
        }

        public ActionResult removeall()
        {
            tocart.c.Clear();
            return RedirectToAction("addtocart", "frontend");
        }

        public ActionResult shopdetail(int? id)
        {


            ViewBag.p = db.products.OrderByDescending(a => a.id == id).FirstOrDefault();
            return View();
        }

        public ActionResult order(int amountt )
        {
            ViewBag.m = amountt;
            ViewBag.aa = tocart.c.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult order(billingg b)
        {
            db.billinggs.Add(b);
            db.SaveChanges();
            tocart.c.Clear();
            TempData["orderd"] = "Thank You Your order Done";
            return RedirectToAction("addtocart","frontend");
        }

        //================================================================//
        //----------------------------------------------------------------//










        public ActionResult logout()
        {
           
            Session.Abandon();
            return RedirectToAction("login","frontend");
        }
       
        public ActionResult MyAccount()
        {
            return View();
        }
     
       
      

        /*************************--PRODUCT--*********************/

        public ActionResult shop()
        {
            return View(db.products.ToList());
        }
        
        public ActionResult shops(int id)
        {
            var t = db.products.Where(a => a.category.category_id == id).ToList();
            var e = db.categories.Where(a => a.category_id == id).FirstOrDefault();
            ViewBag.h = e.category_name;
            return View(t);

        }

       

        public ActionResult fvproduct()
        {
            return View(db.categories.ToList());
        }

    }
}


