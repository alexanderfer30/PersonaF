using F.BL;
using F.EN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace F.UI.AppWebMVC.Controllers
{
    public class PersonaController : Controller
    {
        PersonaBL personaBL = new PersonaBL();


        public ActionResult Prueba()
        {
            return View();
        }
        // GET: PersonaController

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var personas = await personaBL.ObtenerTodos();
            return View(personas);
        }

        // GET: PersonaController/Details/5


        // GET: PersonaController/Create





        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var persona = await personaBL.ObtenerPorId(id);
            if (persona == null)
            {
                return NotFound();
            }
            return View(persona);
        }


        // POST: PersonaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PersonaF persona)
        {

            try
            {
                var result = await personaBL.Crear(persona);

                return Redirect("/Persona/Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Crear()
        {
            return View();
        }

        // GET: PersonaController/Edit/5

        public async Task<IActionResult> Modificar(int id)
        {
            var result = await personaBL.ObtenerPorId(id);
            return View(result);
        }

        // POST: PersonaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PersonaF persona)
        {
            try
            {
                var result = await personaBL.Modificar(persona);
                return Redirect("/Persona/Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonaController/Delete/5
        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await personaBL.ObtenerPorId(id);
            return View(result);
        }

        // POST: PersonaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int Id)
        {
            try
            {
                var result = await personaBL.Eliminar(Id);
                return Redirect("/Persona/Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
