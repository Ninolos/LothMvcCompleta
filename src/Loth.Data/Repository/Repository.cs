using AppLothMVC.Models;
using Loth.Business.Interfaces;
using Loth.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Loth.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        //protected para que tanto o repository tanto quem herdar tenha acesso
        protected readonly LothDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(LothDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }
        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> expression)
        {
            return await DbSet.AsNoTracking().Where(expression).ToListAsync();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }
        public virtual async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }       

        public virtual async Task Remover(Guid id)
        {
            var entity = new TEntity { Id = id };
            DbSet.Remove(entity);
            await SaveChanges();
        }


        //Save Changes customizado para caso precisa alterar, altere só aqui e não em todos que usam o método
        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
