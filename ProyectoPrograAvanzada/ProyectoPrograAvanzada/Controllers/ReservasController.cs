﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoPrograAvanzada.Controllers
{
    public class ReservasController : Controller
    {
        // GET: Reservas
        public ActionResult MostrarReservas()
        {
            return View();
        }
    }
}