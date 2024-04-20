using L02P02_2021_HL_650_2021_MS_651.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace L02P02_2021_HL_650_2021_MS_651.Controllers
{
    public class HomeController : Controller


    {


		private readonly usuariosContext _usuariosContext;
		public HomeController(usuariosContext usuariosContext)
		{
			_usuariosContext = usuariosContext;
		}


		public IActionResult Index()
		{
			
			return View();
		}

		public IActionResult CrearUsuario()
		{
            var listadoDeDepartamentos = (from d in _usuariosContext.departamentos
                                          select new { d.id, d.departamento }).ToList();
            ViewData["listadoDeDepartamentos"] = new SelectList(listadoDeDepartamentos, "id", "departamento");

            var listadoDePuestos = (from p in _usuariosContext.puestos
                                     select new { p.id, p.puesto }).ToList();

            ViewData["listadoDePuestos"] = new SelectList(listadoDeDepartamentos, "id", "puesto");

			var listadoDeClientes = (from c in _usuariosContext.clientes
                                     join d in _usuariosContext.departamentos on c.id equals d.id
                                     join p in _usuariosContext.puestos on c.id equals p.id
                                     select new
                                     {
                                         nombre = c.nombre + " " + c.apellido,
                                         email = c.email,
                                         direccion = c.direccion,
                                         departamento = d.departamento,
                                         genero = c.genero,
                                         puesto = p.puesto,

                                     }
                                    ).ToList();
            ViewData["listadoDeClientes"] = listadoDeClientes;

            return View();
		}
		
		public IActionResult CrearUsuarios(clientes nuevoCliente)
        {
			_usuariosContext.Add(nuevoCliente);
			_usuariosContext.SaveChanges();

			return RedirectToAction("CrearUsuario");
		}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
