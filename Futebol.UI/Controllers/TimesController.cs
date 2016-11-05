using AutoMapper;
using Futebol.BLL;
using Futebol.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Futebol.UI.Controllers
{
    public class TimesController : Controller
    {
        TimeLogic logic;

        public TimesController()
        {
            logic = new TimeLogic();
        }

        public ActionResult Index()
        {
            var times = logic.List();
            var timesVM = Mapper.Map<List<Time>, List<TimeVM>>(times);

            return View(timesVM);
        }

        public ActionResult Criar() => View();

        [HttpPost]
        public ActionResult Criar(TimeVM timeVM)
        {
            return Salvar(timeVM);
        }

        public ActionResult Editar(int? id)
        {
            return Encontrar(id);
        }

        [HttpPost]
        public ActionResult Editar(TimeVM timeVM)
        {
            return Salvar(timeVM);
        }

        public ActionResult Remover(int? id)
        {
            return Encontrar(id);
        }

        [HttpPost]
        public ActionResult Remover(int id)
        {
            try
            {
                logic.Remove(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return Encontrar(id);
            }
        }

        public ActionResult Detalhar(int? id)
        {
            return Encontrar(id);
        }

        private ActionResult Encontrar(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var time = logic.Find((int)id);
            var timeVM = Mapper.Map<Time, TimeVM>(time);

            return View(timeVM);
        }

        [HttpPost]
        private ActionResult Salvar(TimeVM timeVM)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("O modelo não é válido.");

                var time = Mapper.Map<TimeVM, Time>(timeVM);

                logic.Save(time);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(timeVM);
            }
        }
    }
}