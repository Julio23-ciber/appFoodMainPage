﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appFoodMainPage.Models
{
    public class Cocina
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string img { get; set; }
        public int estado { get; set; }
        public DateTime fecha_creacion { get; set; }
        public DateTime fecha_actualizacion { get; set; }
    }
}