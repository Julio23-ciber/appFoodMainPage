using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appFoodMainPage.Models
{
    public class Seguidor_usuario
    {
        public int id { get; set; }
        public int userid { get; set; }
        public int segidor { get; set; }
        public DateTime fecha_creacion { get; set; }
        public DateTime fecha_actualizacion { get; set; }
    }
}