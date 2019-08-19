using Gol.Dominio.Interfaces.Repositorio;
using Gol.InfraData.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gol.InfraData.Repositorio
{
    public class RepositorioBase<TEntity> : IRepositorioBase<TEntity> where TEntity : class
    {
        private readonly EfDbContext _efbdcontext;

        public RepositorioBase(EfDbContext efdbontext)
        {
            _efbdcontext = efdbontext;
        }

        public void Atualizar(TEntity entidade)
        {
            _efbdcontext.Entry(entidade).State = EntityState.Modified;
            _efbdcontext.SaveChanges();
        }

        public TEntity BuscarPorId(int id)
        {
            return _efbdcontext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> BuscarTodos()
        {
            return _efbdcontext.Set<TEntity>().ToList();
        }

        public void Excluir(TEntity entidade)
        {
            _efbdcontext.Remove(entidade);
            _efbdcontext.SaveChanges();
        }

        public void ExcluirPorId(int id)
        {
            var entidade = _efbdcontext.Set<TEntity>().Find(id);

            _efbdcontext.Remove(entidade);
            _efbdcontext.SaveChanges();

        }

        public void Salvar(TEntity entidade)
        {
            _efbdcontext.Add(entidade);
            _efbdcontext.SaveChanges();
        }

        public virtual IQueryable<TEntity> Get()
        {

            return _efbdcontext.Set<TEntity>();

        }

        public virtual async Task<IQueryable<TEntity>> GetAsync()
        {

            var result = await _efbdcontext.Set<TEntity>().ToListAsync();
            return result.AsQueryable();

        }

        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression)
        {

            return _efbdcontext.Set<TEntity>().Where(expression);

        }

        public virtual async Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression)
        {

            var result = await _efbdcontext.Set<TEntity>().Where(expression).ToListAsync();
            return result.AsQueryable();

        }

        public virtual TEntity Find(params object[] key)
        {

            return _efbdcontext.Set<TEntity>().Find(key);

        }

        public virtual TEntity First(Expression<Func<TEntity, bool>> expression)
        {

            return _efbdcontext.Set<TEntity>().FirstOrDefault(expression);

        }

        public virtual bool Exists(Expression<Func<TEntity, bool>> expression)
        {

            return _efbdcontext.Set<TEntity>().Any(expression);

        }

        public virtual TEntity Insert(TEntity entity)
        {
            _efbdcontext.Set<TEntity>().Add(entity);
            _efbdcontext.SaveChanges();

            return entity; 
        }

        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            await _efbdcontext.Set<TEntity>().AddAsync(entity);
            _efbdcontext.SaveChanges();

            return (entity);

        }

        public virtual TEntity Update(TEntity entity)
        {

            _efbdcontext.Entry(entity).State = EntityState.Modified;
            _efbdcontext.SaveChanges();
            return entity;

        }

        public virtual IQueryable<TEntity> Delete(Expression<Func<TEntity, bool>> expression)
        {

            IQueryable<TEntity> remove = _efbdcontext.Set<TEntity>().Where(expression);
            _efbdcontext.Set<TEntity>().RemoveRange(remove);
            _efbdcontext.SaveChanges();

            return remove;

        }

        public virtual int Count(Expression<Func<TEntity, bool>> expression)
        {

            return _efbdcontext.Set<TEntity>().Count(expression);

        }

        public void Dispose()
        {

            if (_efbdcontext != null)
            {

                _efbdcontext.Dispose();

            }

            GC.SuppressFinalize(this);

        }

        public long LongCount()
        {

            return _efbdcontext.Set<TEntity>().LongCount();

        }

        public long LongCount(Expression<Func<TEntity, bool>> expression)
        {

            return _efbdcontext.Set<TEntity>().LongCount(expression);
        }       
    }
}
