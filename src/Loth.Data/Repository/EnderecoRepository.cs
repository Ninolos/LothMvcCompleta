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
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        
        public EnderecoRepository(LothDbContext context) : base(context) { }
        public virtual async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            //N esquecer do AsNoTracking

            return await Db.Enderecos.AsNoTracking().Include(e => e.Fornecedor)
                .FirstOrDefaultAsync(e => e.FornecedorId == fornecedorId);
        }
    }
}
