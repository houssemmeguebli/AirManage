using AM.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Data
{
    internal class Repository<T> : IRepository<T> where T : class
    {
        readonly AMContext aMContext;
        public Repository(AMContext aMContext)
        {
            this.aMContext = aMContext;
        }
        public void Add(T t)
        {
            aMContext.Add(t);
        }
        public void Delete(T t)
        {
            aMContext.Remove(t);
        }
        public T Get(object id)
        {
            return aMContext.Find<T>(id);
        }
        public IList<T> GetALL()
        { return aMContext.Set<T>().ToList(); }
    //public void Save()
    //    {
    //    aMContext.SaveChanges();
    //}
    public void Update(T t)
        {
        aMContext.Update(t);
    }
}
}
