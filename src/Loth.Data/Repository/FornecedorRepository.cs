using AppLothMVC.Models;
using Loth.Business.Interfaces;
using Loth.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loth.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(LothDbContext context) : base(context) { }
        public virtual async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            //N esquecer do AsNoTracking
            return await Db.Fornecedores.AsNoTracking().Include(e => e.Endereco)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public virtual async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            //N esquecer do AsNoTracking
            return await Db.Fornecedores.AsNoTracking().Include(p => p.Produtos)
                .Include(e => e.Endereco)
                .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
