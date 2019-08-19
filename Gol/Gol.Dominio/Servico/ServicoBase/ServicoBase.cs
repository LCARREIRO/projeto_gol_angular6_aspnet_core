using Gol.Dominio.Interfaces.Repositorio;
using Gol.Dominio.Interfaces.Servico.ServicoBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gol.Dominio.Servico.ServicoBase
{
    public class ServicoBase<TEntity> : IServicoBase<TEntity> where TEntity : class
    {
        private readonly IRepositorioBase<TEntity> _repositorio;

        public ServicoBase(IRepositorioBase<TEntity> repositorio)
        {
            _repositorio = repositorio;
        }

        public void Atualizar(TEntity entidade)
        {
            _repositorio.Atualizar(entidade);
        }

        public TEntity BuscarPorId(int id)
        {
            return _repositorio.BuscarPorId(id);
        }

        public IEnumerable<TEntity> BuscarTodos()
        {
            return _repositorio.BuscarTodos();
        }

        public int Count(Expression<Func<TEntity, bool>> expression)
        {
            return _repositorio.Count(expression);
        }

        public IQueryable<TEntity> Delete(Expression<Func<TEntity, bool>> expression)
        {
            return _repositorio.Delete(expression);
        }

        public void Excluir(TEntity entidade)
        {
            _repositorio.Excluir(entidade);
        }

        public void ExcluirPorId(int id)
        {
            _repositorio.ExcluirPorId(id);
        }

        public bool Exists(Expression<Func<TEntity, bool>> expression)
        {
            return _repositorio.Exists(expression);
        }

        public TEntity Find(params object[] key)
        {
            return _repositorio.Find(key);
        }

        public TEntity First(Expression<Func<TEntity, bool>> expression)
        {
            return _repositorio.First(expression);
        }

        public IQueryable<TEntity> Get()
        {
            return _repositorio.Get();
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression)
        {
            return _repositorio.Get(expression);
        }

        public async Task<IQueryable<TEntity>> GetAsync()
        {
            return await _repositorio.GetAsync();
        }

        public Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            return _repositorio.GetAsync(expression);
        }

        public TEntity Insert(TEntity entity)
        {
            return _repositorio.Insert(entity);
        }

        public Task<TEntity> InsertAsync(TEntity entity)
        {
            return _repositorio.InsertAsync(entity);
        }

        public long LongCount()
        {
            return _repositorio.LongCount();
        }

        public long LongCount(Expression<Func<TEntity, bool>> expression)
        {
            return _repositorio.LongCount(expression);
        }

        public void Salvar(TEntity entidade)
        {
            _repositorio.Salvar(entidade);
        }

        public TEntity Update(TEntity entity)
        {
            return _repositorio.Update(entity);
        }
    }
}