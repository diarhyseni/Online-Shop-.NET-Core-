using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Online_Shop.Data;
using Online_Shop.Models;
using Online_Shop.Utilityy;

namespace OnlineShop.Areas.Customer.Controllers
{
   
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET Checkout actioin method

        public IActionResult Checkout()
        {
            return View();
        }
        public IActionResult ThankYou()
        {
            return View();
        }

        //POST Checkout action method

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Checkout([Bind("Id","OrderNo","Name","PhoneNo","Email","Address","OrderDate")] Order anOrder)
        {
            List<Product> products = HttpContext.Session.Get<List<Product>>("products");
            
            if (products != null)
            {
                foreach (var product in products)
                {
                    OrderDetails orderDetails = new OrderDetails();
                    orderDetails.ProductId = product.ProductId;
                    anOrder.OrderDetails.Add(orderDetails);
                }
            }
            if (anOrder.Name == null || anOrder.Name.Trim().Equals(""))
            {
                return View();
            }else if (anOrder.PhoneNo == null || anOrder.PhoneNo.Trim().Equals(""))
            {
                return View();
            }else if (anOrder.Email == null || anOrder.Email.Trim().Equals(""))
            {
                return View();
            }else if (anOrder.Address== null || anOrder.Address.Trim().Equals(""))
            {
                return View();
            }else if(anOrder.OrderDate == null || anOrder.OrderDate == default(DateTime) )
            {
                return View();
            }


            anOrder.OrderNo = GetOrderNo();
            _context.Orders.Add(anOrder);
            await _context.SaveChangesAsync();
            HttpContext.Session.Set("products", new List<Product>());
            return RedirectToAction(nameof(ThankYou));
        }


        public string GetOrderNo()
        {
            int rowCount = _context.Orders.ToList().Count() + 1;
            return rowCount.ToString("000");
        }
    }
    
}
