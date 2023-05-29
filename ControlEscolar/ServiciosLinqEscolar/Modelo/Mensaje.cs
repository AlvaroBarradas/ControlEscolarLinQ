using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosLinqEscolar.Modelo
{
    public class Mensaje
    {
        public usuario usuarioRegistrado { get; set; }

        public string respuesta { get; set; }

        public bool Error { get; set; }

        public Mensaje() { }
    }
}