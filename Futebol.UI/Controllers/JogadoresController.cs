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
    public class JogadoresController : Controller
    {
        JogadorLogic logic;

        public JogadoresController()
        {
            logic = new JogadorLogic();
        }

        public ActionResult Index()
        {
            var jogadores = logic.List();
            var jogadoresVM = Mapper.Map<List<Jogador>, List<JogadorVM>>(jogadores);

            return View(jogadoresVM);
        }

        public ActionResult Criar()
        {
            var jogadorVm = new JogadorVM
            {
                ListaTimes = ListaDeTimes(),
                ListaPosicoes = ListaDePosicoes()
            };

            return View(jogadorVm);
        }

        [HttpPost]
        public ActionResult Criar(JogadorVM jogadorVM)
        {
            return Salvar(jogadorVM);
        }

        public ActionResult Editar(int? id)
        {
            return Encontrar(id);
        }

        [HttpPost]
        public ActionResult Editar(JogadorVM jogadorVM)
        {
            return Salvar(jogadorVM);
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

            var jogador = logic.Find((int)id);
            var jogadorVM = Mapper.Map<Jogador, JogadorVM>(jogador);

            jogadorVM.ListaTimes = ListaDeTimes();
            jogadorVM.ListaPosicoes = ListaDePosicoes();

            return View(jogadorVM);
        }

        [HttpPost]
        private ActionResult Salvar(JogadorVM jogadorVM)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("O modelo não é válido.");

                var jogador = Mapper.Map<JogadorVM, Jogador>(jogadorVM);

                logic.Save(jogador);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                jogadorVM.ListaTimes = ListaDeTimes();
                jogadorVM.ListaPosicoes = ListaDePosicoes();

                return View(jogadorVM);
            }
        }

        public static SelectList ListaDeTimes()
        {
            var timeLogic = new TimeLogic();

            var times = timeLogic.List();

            return new SelectList(times, "TimeId", "Nome");
        }

        public static SelectList ListaDePosicoes()
        {
            var posicaoLogic = new PosicaoLogic();

            var posicoess = posicaoLogic.List();

            return new SelectList(posicoess, "PosicaoId", "Sigla");
        }
    }
}