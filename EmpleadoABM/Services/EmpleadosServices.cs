using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmpleadoABM.Entidades;

namespace EmpleadoABM.Services
{
    public class EmpleadosServices
    {
        private static List<Empleado> empleados = new List<Empleado>(); //lista para empleados

        public Empleado ObtenerId(int id)
        {
            return empleados.FirstOrDefault(c => c.Id == id);
        }

        public void Agregar(Empleado empleado)  //METODO PARA AGREGAR UN EMPLEADO NUEVO
        {
            empleados.Add(empleado);
        }

        public void Eliminar(int id)            //METODO PARA ELIMINAR EMPLEADOS
        {
            empleados.RemoveAll(e => e.Id == id);
        }
    }
}