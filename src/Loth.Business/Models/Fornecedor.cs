using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppLothMVC.Models
{
    public class Fornecedor : Entity
    {
        public string Nome { get; set; }        
        public string Documento { get; set; }
        public TipoFornecedor TipoFornecedor { get; set; }
        public Endereco Endereco { get; set; }       
        public bool Ativo { get; set; }

        /* Relação EF para Fornecedor ter uma lista de Produtos */
        public IEnumerable<Produto> Produtos { get; set; }
    }
   
}
