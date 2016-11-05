using Onsoft.Data;
using System;

namespace Futebol.DAL.Repositories
{
    public class TimeRepository : OnDbAction<Time>
    {
        public TimeRepository()
        {
            Context = new DataContext();
        }
    }
}
