using appFoodMainPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace appFoodMainPage.Controllers
{
    public class HomeController : Controller
    {
        DbApi db = new DbApi();
        //URL  =  https://localhost:44388/api/
        public ActionResult Index()
        {
 
            return View();
        }

        public ActionResult About()
        {
            
            dynamic respuesta = db.Get("https://localhost:44388/api/dificultad_receta");
            List<dynamic> lst = new List<dynamic>();
            foreach (var i in respuesta)
            {
                lst.Add(i);
            }

            List<SelectListItem> item = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.dificultad,
                    Value = d.id,
                    Selected = false
                };
            });
            ViewBag.Message = "hola";
            ViewBag.item = item;
            return View(item);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}