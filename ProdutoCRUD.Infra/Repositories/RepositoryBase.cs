
using ProdutoCRUD.Dominio.Interfaces;
using ProdutoCRUD.Infra.Contexto;
using System;
using System.Data.Entity;
using System.Linq;
namespace ProdutoCRUD.Infra
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected ProdutoContext Db = new ProdutoContext();

        public void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public System.Collections.Generic.IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
