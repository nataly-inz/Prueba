using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using prueba21.web.Data;
using prueba21.web.Models;

namespace prueba21.web.Controllers
{
    public class TareasController : Controller
    {

        private readonly DataContext _dataContext;
       

        public TareasController(DataContext dataContext)
        {
         _dataContext = dataContext;

           
        }

        public IActionResult Index()
        {
            var Tareas = _dataContext.Tareas.Where(x => x.Estatus == false).ToList();
            return View(Tareas);
        }

        public IActionResult Nuevo()
        {
            var tarea = new TareaEntity();

            return View(new TareaEntity());
        }

        [HttpPost]

        public IActionResult Nuevo (TareaEntity newObj)
        {
            _dataContext.Tareas.Add(newObj);
            _dataContext.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Modificar(int id)
        {
            var tarea= _dataContext.Tareas.Where(x=>x.Id==id).FirstOrDefault();


            return View(tarea);
        }
        [HttpPost]
        public IActionResult Modificar(TareaEntity newObj)
                {
         var tarea = _dataContext.Tareas.Where(x => x.Id == newObj.Id).FirstOrDefault();
         tarea.Tarea = newObj.Tarea;
         tarea.Descripcion = newObj.Descripcion;
         tarea.Fecha = newObj.Fecha;

            _dataContext.Tareas.Update(tarea);
            _dataContext.SaveChanges();
            return RedirectToAction("Index");

        }


        
        [HttpGet]
        public IActionResult Borrar(int id)
       {
            var tarea = _dataContext.Tareas.Find(id);

            _dataContext.Tareas.Remove(tarea);
            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Completar(int id)
        {
            var tarea = _dataContext.Tareas.Find(id);

            tarea.Estatus = true;

            _dataContext.Tareas.Update(tarea);
            _dataContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}