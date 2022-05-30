using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appFoodMainPage.Models
{
    public class Calificacion_receta
    {
        public int id { get; set; }
        public int userid { get; set; }
        public int receta_id { get; set; }
        public double calificacion { get; set; }
    }
}