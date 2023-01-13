using AppLothMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Loth.Business.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Adicionar(TEntity entity);
        Task Atualizar(TEntity entity);
        Task <TEntity> ObterPorId(Guid id);
        Task <List<TEntity>> ObterTodos();
        Task Remover(Guid id);

        //Passa uma expressão Lambda que vai buscar oq vc quiser, se verdadeiro bool true
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> expression);
        Task<int> SaveChanges();
    }
}
