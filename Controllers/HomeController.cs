using ChanceryStore;
using ChanceryStore.models;
using ChanceryStoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChanceryStoreMVC.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            IEnumerable<Product> productsIE = ProductSql.GetProducts("NO");
            ViewBag.Product = productsIE;
            ViewBag.Title = "Каталог";
            return View();
        }

        [HttpGet]
        public ActionResult Buy(int? code)
        {
            code = 6;
            ViewBag.ProductCode = code;
            ViewBag.Title = "Покупка";
            return View();
        }

        //обрабатывать введенные пользователем данные.
        [HttpPost]
        public string Buy(Order order)
        {
            Client client = new Client();
            client.FirstName = order.Client.FirstName;
            client.LastName = order.Client.LastName;
            if(Client.GetClient(client.FirstName, client.LastName) == null) // проверка существует ли пользователь с таким именем
            { client.AddClient(); // то добавить пользователя
            }

            client = Client.GetClient(client.FirstName, client.LastName); // получить клиента с таким именем и фамилией
            order.DateTime = DateTime.Now;
            order.ProductCode = 6;
            order.ClientId = client.Id;

            Product product = ProductSql.GetProduct(order.ProductCode);
            ViewBag.OneProduct = ProductSql.GetProduct(order.ProductCode); 
            if (product.Amount <1)
            { }

            order.AddOrder();

            return  "Спасибо, " + order.Client.FirstName + ", за покупку!";
        }

      
        public ActionResult ProductsList(ProductClient product)
        {
            //using (WebContext db = new WebContext())
            //{
            //    //ViewBag.Products = db.Products.ToList();
            //}

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}