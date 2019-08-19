using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gol.Aplicacao.Interfaces.Base
{
    public interface IAppServicoBase<TEntity> where TEntity : class
    {
        void Salvar(TEntity entidade);
        void Excluir(TEntity entidade);
        void ExcluirPorId(int id);
        TEntity BuscarPorId(int id);
        IEnumerable<TEntity> BuscarTodos();
        void Atualizar(TEntity entidade);

        IQueryable<TEntity> Get();

        Task<IQueryable<TEntity>> GetAsync();

        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression);

        Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression);

        TEntity Find(params object[] key);

        TEntity First(Expression<Func<TEntity, bool>> expression);

        TEntity Insert(TEntity entity);

        Task<TEntity> InsertAsync(TEntity entity);

        TEntity Update(TEntity entity);

        bool Exists(Expression<Func<TEntity, bool>> expression);

        int Count(Expression<Func<TEntity, bool>> expression);

        IQueryable<TEntity> Delete(Expression<Func<TEntity, bool>> expression);

        long LongCount();

        long LongCount(Expression<Func<TEntity, bool>> expression);
    }
}
