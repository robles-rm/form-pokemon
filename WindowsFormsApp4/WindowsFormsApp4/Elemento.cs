﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    internal class Elemento //Creo objeto del tipo elemento
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public override string ToString() //creo metodo para devolver descripcion del objeto
        {
            return Descripcion;
        }
    }
}
