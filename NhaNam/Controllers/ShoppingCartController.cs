using Microsoft.Ajax.Utilities;
using NhaNam.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NhaNam.Controllers
{
    public class ShoppingCartController : Controller
    {
        private DBNhaNamEntities db = new DBNhaNamEntities();
        // GET: ShoppingCart
        public ActionResult ShowCart()
        {
            if (Session["Cart"] == null)
                return View("EmptyCart");
            Cart _cart = Session["Cart"] as Cart;
            return View(_cart);
        }
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;

            }
            return cart;
        }

        public ActionResult AddToCart(int id)
        {
            var _pro = db.Products.SingleOrDefault(s => s.ProID == id);
            if (_pro != null)
            {
                GetCart().Add_Product_Cart(_pro);
            }
            return RedirectToAction("ShowCart", "ShoppingCart");
        }
        public ActionResult Update_Cart_Quantity(FormCollection form) 
        {
            Cart cart = Session["Cart"] as Cart;
            int id_pro = int.Parse(form["idPro"]);
            int id_quantity = int.Parse(form["cartQuantity"]);
            cart.Update_quantity(id_pro, id_quantity );
            return RedirectToAction("ShowCart", "ShoppingCart");
        }

        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart; cart.Remove_CartItem(id);
            return RedirectToAction("ShowCart", "ShoppingCart");
        }
        public ActionResult Checkout(FormCollection form)
        {
            try
            {
                Cart cart = Session["Cart"] as Cart;
                Order _order = new Order(); //Bang Hoa Don San pham 
                _order.OrderDate = DateTime.Now;
                _order.AddressDeliverry = form["AddressDelivery"];
                foreach (var item in cart.Items)
                {
                    OrderDetail _order_detail = new OrderDetail(); //Luu dong san pham vao bang Chi tiet Hoa don
                    _order_detail.OrderID = _order.OrderID;
                    _order_detail.ProSupID = item._product.ProID;
                    _order_detail.UnitPrice = (double)item._proDetail.UnitPrice;
                    _order_detail.Quantity = item._quantity;
                    db.OrderDetails.Add(_order_detail);
                }
                db.SaveChanges();
                cart.ClearCart();
                return RedirectToAction("CheckOut_Success", "ShoppingCart");
            }
            catch
            { return Content("Lỗi. Vui lòng kiểm tra thông tin khách hàng"); }

        }
        //public ActionResult CheckoutS1(FormCollection form)
        //{

        //}
        //public ActionResult CheckoutS2(FormCollection form)
        //{

        //}
        //public ActionResult CheckoutS3(FormCollection form)
        //{

        //}
    }
}
