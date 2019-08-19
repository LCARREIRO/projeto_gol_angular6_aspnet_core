using Gol.Aplicacao.Interfaces.Base;
using Gol.Dominio.Interfaces.Servico.ServicoBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gol.Aplicacao.App.Base
{
    public class AppServicoBase <TEntity> : IAppServicoBase<TEntity> where TEntity : class
    {
        private readonly IServicoBase <TEntity> _servicoBase;

        public AppServicoBase(IServicoBase<TEntity> serviceBase)
        {
            _servicoBase = serviceBase;
        }

        public void Atualizar(TEntity entidade)
        {
            _servicoBase.Atualizar(entidade);
        }

        public TEntity BuscarPorId(int id)
        {
            return _servicoBase.BuscarPorId(id);
        }

        public IEnumerable<TEntity> BuscarTodos()
        {
            return _servicoBase.BuscarTodos();
        }

        public int Count(Expression<Func<TEntity, bool>> expression)
        {
            return _servicoBase.Count(expression);
        }

        public IQueryable<TEntity> Delete(Expression<Func<TEntity, bool>> expression)
        {
            return _servicoBase.Delete(expression);
        }

        public void Excluir(TEntity entidade)
        {
            _servicoBase.Excluir(entidade);
        }

        public void ExcluirPorId(int id)
        {
            _servicoBase.ExcluirPorId(id);
        }

        public bool Exists(Expression<Func<TEntity, bool>> expression)
        {
            return _servicoBase.Exists(expression);
        }

        public TEntity Find(params object[] key)
        {
            return _servicoBase.Find(key);
        }

        public TEntity First(Expression<Func<TEntity, bool>> expression)
        {
            return _servicoBase.First(expression);
        }

        public IQueryable<TEntity> Get()
        {
            return _servicoBase.Get();
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression)
        {
            return _servicoBase.Get(expression);
        }

        public async Task<IQueryable<TEntity>> GetAsync()
        {
            return await _servicoBase.GetAsync();
        }

        public Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            return _servicoBase.GetAsync(expression);
        }

        public TEntity Insert(TEntity entity)
        {
            return _servicoBase.Insert(entity);
        }

        public Task<TEntity> InsertAsync(TEntity entity)
        {
            return _servicoBase.InsertAsync(entity);
        }

        public long LongCount()
        {
            return _servicoBase.LongCount();
        }

        public long LongCount(Expression<Func<TEntity, bool>> expression)
        {
            return _servicoBase.LongCount(expression);
        }

        public void Salvar(TEntity entidade)
        {
            _servicoBase.Salvar(entidade);
        }

        public TEntity Update(TEntity entity)
        {
            return _servicoBase.Update(entity);
        }
    }
}
