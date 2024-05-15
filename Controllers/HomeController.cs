using PizzaMVC.Entity;
using PizzaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaMVC.Controllers
{
    public class HomeController : Controller
    {
        DataContext _context = new DataContext();

        public ActionResult Index()
        {
            var urunler = _context.Products
                .Where(i => i.IsHome && i.IsApproved)
                .Select(i => new ProductModel
                {
                    Id=i.Id, Name=i.Name, Description=i.Description.Length>50?i.Description.Substring(0,47)+ "....": i.Description,
                    Price=i.Price,
                    Stock=i.Stock,
                    Image=i.Image,
                     CategoryId=i.CategoryId
                }
                ).ToList();



            return View(urunler);
        }

        public ActionResult About(int id)
        {
            

            return View(_context.Products.Where(i => i.Id==id).FirstOrDefault());
        }

        public ActionResult Contact(int? id)
        {


            var urunler = _context.Products
                .Where(i => i.IsApproved)
                .Select(i => new ProductModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "...." : i.Description,
                    Price = i.Price,
                    Stock = i.Stock,
                    Image = i.Image,
                    CategoryId = i.CategoryId
                }
                ).AsQueryable();

            if (id !=null)
            {
                urunler = urunler.Where(i => i.CategoryId == id);
            }


            return View(urunler.ToList());
        }

        public PartialViewResult GetCategories() => PartialView(_context.Categories.ToList());
    }
}