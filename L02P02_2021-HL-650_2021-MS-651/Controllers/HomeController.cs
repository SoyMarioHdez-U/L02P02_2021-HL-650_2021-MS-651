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
            var listaDeDepartamentos = _usuariosContext.departamentos.ToList();
            ViewData["listaDeDepartamentos"] = new SelectList(listaDeDepartamentos, "id", "departamento");

            var listaDePuestos = _usuariosContext.puestos.ToList();
            ViewData["listaDePuestos"] = new SelectList(listaDePuestos, "id", "puesto");


            var listaDeClientes = (from c in _usuariosContext.clientes
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
            ViewData["listadoDeClientes"] = listaDeClientes;

            return View();
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
