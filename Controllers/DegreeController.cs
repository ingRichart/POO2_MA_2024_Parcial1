using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_Ricardo.Models;

namespace MVC_Ricardo.Controllers
{
    public class DegreeController : Controller
    {
        private readonly ILogger<DegreeController> _logger;

        public DegreeController(ILogger<DegreeController> logger)
        {
            _logger = logger;
        }

        public IActionResult DegreeList()
        {

            List<DegreeModel> list = new List<DegreeModel>();
            list.Add( new DegreeModel() { Id = new Guid(), Nombre = "Ing. de Software"} );
            list.Add( new DegreeModel() { Id = new Guid(), Nombre = "Psicologia"} );
            list.Add( new DegreeModel() { Id = new Guid(), Nombre = "Mercadotecnía"} );

            return View(list);
        }

        public IActionResult DegreeAdd() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult DegreeAdd(DegreeModel degree)
        {
            _logger.LogInformation(degree.Nombre);

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("No es valido el modelo");
                return View(degree);
            }

            _logger.LogInformation("Modelo es valido");
            return Redirect("DegreeList");
        }

        public IActionResult DegreeEdit(Guid Id)
        {
            var model = new DegreeModel();
            // model.Id = new Guid();
            // model.Nombre = "Editar Carrera";

            return View(model);
        }
        
        [HttpPost]
        public IActionResult DegreeEdit(DegreeModel degree)
        {
            degree.Id = new Guid();
            _logger.LogInformation(degree.Nombre);

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("No es valido el modelo");
                return View(degree);
            }

            _logger.LogInformation("Modelo es valido");
            return RedirectToAction("DegreeList");
        }
        

        public IActionResult DegreeShowToDeleted(Guid Id)
        {
            var model = new DegreeModel();
            return View(model);
        }

        public IActionResult DegreeDeleted() 
        {
            return Redirect("DegreeList");
        }
    }
}