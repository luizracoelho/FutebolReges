using Futebol.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Futebol.BLL
{
    public class JogadorLogic
    {
        public List<Jogador> List()
        {
            using (var dao = new JogadorRepository())
            {
                dao.Load<Time>();
                dao.Load<Posicao>();

                return dao.List().OrderBy(x => x.Nome).ToList();
            }
        }

        public Jogador Find(int id)
        {
            using (var dao = new JogadorRepository())
            {
                dao.Load<Time>();
                dao.Load<Posicao>();

                return dao.Find(id);
            }
        }

        private void Validate(Jogador jogador)
        {
            if (string.IsNullOrEmpty(jogador.Nome))
                throw new ArgumentNullException("Nome");

            using (var dao = new JogadorRepository())
            {
                var jogadorDB = dao.Find(x =>
                                    x.Nome.Trim().ToLower() == jogador.Nome.Trim().ToLower() &&
                                    x.JogadorId != jogador.JogadorId
                                );

                if (jogadorDB != null)
                    throw new ArgumentException("Já existe um Jogador com este Nome.");
            }
        }

        public void Save(Jogador jogador)
        {
            Validate(jogador);

            if (jogador.JogadorId == 0)
                Add(jogador);
            else
                Edit(jogador);
        }

        private void Add(Jogador jogador)
        {
            using (var dao = new JogadorRepository())
            {
                dao.Add(jogador);
            }
        }

        private void Edit(Jogador jogador)
        {
            using (var dao = new JogadorRepository())
            {
                dao.Edit(x => x.JogadorId == jogador.JogadorId, jogador);
            }
        }

        public void Remove(int id)
        {
            using (var dao = new JogadorRepository())
            {
                dao.Remove(id);
            }
        }
    }
}
