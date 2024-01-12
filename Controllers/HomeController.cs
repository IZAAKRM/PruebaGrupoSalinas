using Prueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prueba.Controllers
{
    public class HomeController : Controller
    {
        db_a99140_qfaEntities db = new db_a99140_qfaEntities();
        Contendor contender = new Contendor();
        public ActionResult Index()
        {
            contender.productos = db.productoes.ToList();
            return View(contender);
        }
        public ActionResult altaProducto(string nombre, decimal precio, int existencia)
        {
            producto insert = new producto();
            insert.Nombre_Producto = nombre;
            insert.precio = precio;
            insert.existencia = existencia;
            db.productoes.Add(insert);
            db.SaveChanges();
            return Json(new { sucess = true, message = "Se ha dado de alta" });
        }
        public ActionResult ventaProducto(int codigo,int cant)
        {
            var producto = db.productoes.Where(a => a.codigo.Equals(codigo)).FirstOrDefault();
            if(producto.existencia >= cant)
            {
                producto.existencia = producto.existencia - cant;
                venta venta = new venta();
                venta.fecha = DateTime.Now;
                venta.total = cant;
                venta.codigoProducto = codigo;
                db.SaveChanges();
                return Json(new { sucess = true, message = "Se ha acompletado la venta" });
            }
            else
            {
                return Json(new { sucess = false, message = "No hay inventariado suficiente" });
            }

        }
    }
}