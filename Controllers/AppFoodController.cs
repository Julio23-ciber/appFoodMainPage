using appFoodMainPage.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace appFoodMainPage.Controllers
{
    public class AppFoodController : Controller
    {
        DbApi db = new DbApi();
        private string URL = "https://localhost:44388/api/";
        // DashBoard index page
        public ActionResult Index()
        {
            int CantRecetas = int.Parse(db.Get(URL + "Index/GetCantResetas").ToString());
            int CantUsuarios= int.Parse(db.Get(URL + "Index/GetCantUsuario").ToString());
            int CantCategorias = int.Parse(db.Get(URL + "Index/GetCantCategorias").ToString());
            int CantCocinas = int.Parse(db.Get(URL + "Index/GetCantCocinas").ToString());
            ViewBag.CantRecetas = CantRecetas;
            ViewBag.CantUsuarios = CantUsuarios;
            ViewBag.CantCategorias = CantCategorias;
            ViewBag.CantCocinas = CantCocinas;

            /**
             * Lista de recetas con mas likes
             */
            dynamic respuesta = db.Get(URL + "Index/GetMostLikedRecetas");
            List<dynamic> lst = new List<dynamic>();
            foreach (var i in respuesta)
            {
                lst.Add(i);
            }

            List<Receta> item = lst.ConvertAll(d =>
            {
                return new Receta()
                {
                    nombre = d.nombre,
                    nro_likes = d.likes
                };
            });
            /***/
            dynamic userMostActive = db.Get(URL + "Index/GetMostActiveUsers");
            List<dynamic> lista = new List<dynamic>();
            foreach (var i in userMostActive)
            {
                lista.Add(i);
            }
            List<Usuario> item2 = lista.ConvertAll(d =>
            {
                return new Usuario()
                {
                    nombre = d.nombre,
                    id = d.id
                };
            });

            ViewBag.userMostActive = item2;
            ViewBag.MostLikedRecetas = item;

            return View();
            
        }

        //Usuarios index page

        public ActionResult Usuario()
        {
            dynamic userMostActive = db.Get(URL + "Usuario/ListarUsuario");
            List<dynamic> lista = new List<dynamic>();
            foreach (var i in userMostActive)
            {
                lista.Add(i);
            }
            List<Usuario> usuarios = lista.ConvertAll(d =>
            {
                return new Usuario()
                {
                    id = d.id,
                    img = d.img,
                    nombre = d.nombre,
                    email = d.email,
                    tipo_usuario = d.tipo_usuario,
                    cantRecetas = d.cantRecetas,
                    estado = d.estado
                };
            });
           
            
            return View(usuarios);
        }
 

    }
}
