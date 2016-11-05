using Futebol.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Futebol.BLL
{
    public class PosicaoLogic
    {
        public List<Posicao> List()
        {
            using (var dao = new PosicaoRepository())
            {
                return dao.List().OrderBy(x => x.Sigla).ToList();
            }
        }

        public Posicao Find(int id)
        {
            using (var dao = new PosicaoRepository())
            {
                return dao.Find(id);
            }
        }

        private void Validate(Posicao posicao)
        {
            if (string.IsNullOrEmpty(posicao.Descricao))
                throw new ArgumentNullException("Nome");

            if (string.IsNullOrEmpty(posicao.Sigla))
                throw new ArgumentNullException("Sigla");

            using (var dao = new PosicaoRepository())
            {
                var posicaoDB = dao.Find(x =>
                                    x.Descricao.Trim().ToLower() == posicao.Descricao.Trim().ToLower() &&
                                    x.PosicaoId != posicao.PosicaoId
                                );

                if (posicaoDB != null)
                    throw new ArgumentException("Já existe um Posicao com esta Descrição.");
            }

            using (var dao = new TimeRepository())
            {
                var timeDB = dao.Find(x =>
                                    x.Sigla.Trim().ToLower() == posicao.Sigla.Trim().ToLower() &&
                                    x.TimeId != posicao.PosicaoId
                                );

                if (timeDB != null)
                    throw new ArgumentException("Já existe um Time com esta Sigla.");
            }
        }

        public void Save(Posicao posicao)
        {
            Validate(posicao);

            if (posicao.PosicaoId == 0)
                Add(posicao);
            else
                Edit(posicao);
        }

        private void Add(Posicao posicao)
        {
            using (var dao = new PosicaoRepository())
            {
                dao.Add(posicao);
            }
        }

        private void Edit(Posicao posicao)
        {
            using (var dao = new PosicaoRepository())
            {
                dao.Edit(x => x.PosicaoId == posicao.PosicaoId, posicao);
            }
        }

        public void Remove(int id)
        {
            using (var dao = new PosicaoRepository())
            {
                dao.Remove(id);
            }
        }
    }
}
