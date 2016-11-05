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
    public class PosicoesController : Controller
    {
        PosicaoLogic logic;

        public PosicoesController()
        {
            logic = new PosicaoLogic();
        }

        public ActionResult Index()
        {
            var posicoes = logic.List();
            var posicoesVM = Mapper.Map<List<Posicao>, List<PosicaoVM>>(posicoes);

            return View(posicoesVM);
        }

        public ActionResult Criar() => View();

        [HttpPost]
        public ActionResult Criar(PosicaoVM posicaoVM)
        {
            return Salvar(posicaoVM);
        }

        public ActionResult Editar(int? id)
        {
            return Encontrar(id);
        }

        [HttpPost]
        public ActionResult Editar(PosicaoVM posicaoVM)
        {
            return Salvar(posicaoVM);
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

            var posicao = logic.Find((int)id);
            var posicaoVM = Mapper.Map<Posicao, PosicaoVM>(posicao);

            return View(posicaoVM);
        }

        [HttpPost]
        private ActionResult Salvar(PosicaoVM posicaoVM)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("O modelo não é válido.");

                var posicao = Mapper.Map<PosicaoVM, Posicao>(posicaoVM);

                logic.Save(posicao);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(posicaoVM);
            }
        }
    }
}