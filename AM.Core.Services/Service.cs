using AM.Core.Domain;
using AM.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Services
{
    public class Service<T> : IService<T> where T : class
    {
        IRepository<T> repo;
        readonly IUnitOfWork unit;
        public Service(IUnitOfWork unit)
        {
            this.unit = unit;
            repo = unit.GetRepository<T>();
        }
        public void Add(T t)
        {
            repo.Add(t);
            unit.Save();
        }

        public void Delete(T t)
        {
            repo.Delete(t);
            unit.Save();
        }

        public T Get(object id)
        {
            return repo.Get(id);
        }

        public IList<T> GetALL()
        {
            return repo.GetALL();
        }

        public void Update(T t)
        {
            repo.Update(t);
            unit.Save();
        }
    }
}
