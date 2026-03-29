using Microsoft.AspNetCore.Mvc;
using EstudianteMVC.Models;
using EstudianteMVC.Services;

namespace EstudianteMVC.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly EstudianteService _service;

        public EstudiantesController(EstudianteService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var lista = await _service.GetAll();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Estudiante estudiante)
        {
            await _service.Create(estudiante);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var estudiante = await _service.GetById(id);
            return View(estudiante);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Estudiante estudiante)
        {
            await _service.Update(id, estudiante);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}