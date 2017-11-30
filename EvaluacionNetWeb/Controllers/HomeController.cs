using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EvaluacionNetWeb.Models;


namespace EvaluacionNetWeb.Controllers
{
    public class HomeController : Controller
    {
        List<Profesores> Listar = new List<Profesores>();
        public HomeController()
        {
            Listar.Add(new Profesores() { rut = "14.252.252-1", nombrecompleto = "Juan Soto Riquelme", titulo = "Ingeniero Civil Informatica", gradoprofesional ="Ingeniero" });
            Listar.Add(new Profesores() { rut = "11.112.252-1", nombrecompleto = "Maria Ester Rosas Sotomayor", titulo = "Tecnico Analista y Programador", gradoprofesional ="Tecnico"  });
            Listar.Add(new Profesores() { rut = "20.252.252-1", nombrecompleto = "Pedro Urdemales Perez", titulo = "PHD Ciencias de la Computacion", gradoprofesional = "Doctor" });
        }
        public IActionResult Mantenedor()
        {
            return View(new Profesores());
        }
        public IActionResult Lista()
        {
            return View(Listar);
            
        }
        private Profesores BuscarProfe(string rut)
        {
            Profesores nueva = new Profesores();
            foreach (Profesores profesor in Listar)
            {
                if (profesor.rut == rut)
                {
                    nueva = profesor;
                }
            }
            return nueva;
        }
        public IActionResult Ficha(string rut, string nombrecompleto, string titulo, string gradoprofesional)
        {
            Profesores nuevo = new Profesores()
            {
                rut = rut,
                nombrecompleto = nombrecompleto,
                titulo = titulo,
                gradoprofesional = gradoprofesional
            };
            return View(nuevo);
        }

        public IActionResult Visualizar(string rut)
        {
            Profesores nueva = BuscarProfe(rut);

            if (nueva != null)
            {
                return View("Ficha", nueva);
            }
            return View("Listado", Listar);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
