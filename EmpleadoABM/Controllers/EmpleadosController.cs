using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmpleadoABM.Services;
using EmpleadoABM.Entidades;

namespace EmpleadoABM.Controllers
{
    public class EmpleadosController : Controller
    {
        EmpleadosEntities1 db = new EmpleadosEntities1();    //contexto de la base de datos

        public ActionResult Index()
        {
            List<Empleado> emp = db.Empleado.ToList();

            return View(emp);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Empleado em)
        {
            db.Empleado.Add(em);
            db.SaveChanges();         

            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            Empleado emp = db.Empleado.FirstOrDefault(o => o.Id == id);

            if(emp != null)
            {
                return View(emp);   //retorno a la vista los datos del empleado seleccionado
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult Editar(Empleado e)  //por parametro voy a pasar el empleado que modifiqué
        {
            Empleado emp = db.Empleado.FirstOrDefault(x => x.Id == e.Id); //creo un Empleado emp, cuyo id será el mismo que el modificado

            emp.Nombre = e.Nombre;         //Los nombres y apellido modificados del emp serán los que puse en la vista
            emp.Apellido = e.Apellido;

            db.SaveChanges();              //guardo los cambios para que se apliquen el bd

            return RedirectToAction("Editar");
        }


        public ActionResult Eliminar(int id)
        {
            Empleado e = db.Empleado.FirstOrDefault(x => x.Id == id);  //el empleado a eliminar será el del id seleccionado

            db.Empleado.Remove(e);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}