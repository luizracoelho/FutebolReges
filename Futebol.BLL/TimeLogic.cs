using Futebol.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Futebol.BLL
{
    public class TimeLogic
    {
        public List<Time> List()
        {
            using (var dao = new TimeRepository())
            {
                return dao.List().OrderBy(x => x.Nome).ToList();
            }
        }

        public Time Find(int id)
        {
            using (var dao = new TimeRepository())
            {
                return dao.Find(id);
            }
        }

        private void Validate(Time time)
        {
            if (string.IsNullOrEmpty(time.Nome))
                throw new ArgumentNullException("Nome");

            if (string.IsNullOrEmpty(time.Sigla))
                throw new ArgumentNullException("Sigla");

            using (var dao = new TimeRepository())
            {
                var timeDB = dao.Find(x =>
                                    x.Nome.Trim().ToLower() == time.Nome.Trim().ToLower() &&
                                    x.TimeId != time.TimeId
                                );

                if (timeDB != null)
                    throw new ArgumentException("Já existe um Time com este Nome.");
            }

            using (var dao = new TimeRepository())
            {
                var timeDB = dao.Find(x =>
                                    x.Sigla.Trim().ToLower() == time.Sigla.Trim().ToLower() &&
                                    x.TimeId != time.TimeId
                                );

                if (timeDB != null)
                    throw new ArgumentException("Já existe um Time com esta Sigla.");
            }
        }

        public void Save(Time time)
        {
            Validate(time);

            if (time.TimeId == 0)
                Add(time);
            else
                Edit(time);
        }

        private void Add(Time time)
        {
            using (var dao = new TimeRepository())
            {
                dao.Add(time);
            }
        }

        private void Edit(Time time)
        {
            using (var dao = new TimeRepository())
            {
                dao.Edit(x => x.TimeId == time.TimeId, time);
            }
        }

        public void Remove(int id)
        {
            using (var dao = new TimeRepository())
            {
                dao.Remove(id);
            }
        }
    }
}
