using PayPal.Api;
using PayPal.Api.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using WebAPI_CoffeeShop.Models;
using WebAPI_CoffeeShop.Utilities;
using WebGrease.Activities;
using WebMVC_CoffeeShopSystem.Dao;
using WebMVC_CoffeeShopSystem.Repositories;
using WebMVC_CoffeeShopSystem.Utilities;

namespace WebMVC_CoffeeShopSystem.Controllers
{
    public class CheckoutController : Controller
    {
        dynamic callCartDao = CartDao.Instance;
        dynamic callVoucherDao = VoucherDao.Instance;
        dynamic callInvoiceDao = InvoiceDao.Instance;
        private Payment payment;

        // GET: Checkout
        public ActionResult Index(string lsCartCheckout, string lsIdVoucherSupp, string idVoucherCafe, string priceTotal)
        {
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                if (lsCartCheckout != null)
                {
                    int idAccount = reqCookies["userId"].ToString().AsInt();
                    ViewBag.lsCartCheckout = callCartDao.GetCartCheckout(idAccount, lsCartCheckout);
                    ViewBag.lsVoucherOfSupp = callVoucherDao.GetVoucherByMulIdVoucher(lsIdVoucherSupp);
                    ViewBag.voucherCafe = callVoucherDao.GetVoucherByMulIdVoucher(idVoucherCafe);
                    ViewBag.strIdCart = lsCartCheckout;
                    ViewBag.priceTotal = priceTotal;
                    return View();
                }
                else
                {
                    return Redirect("/Cart");
                }
            }
            else
            {
                return RedirectToAction("Index", "Signin");
            }

        }

    }
}