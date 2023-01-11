using System.ComponentModel.DataAnnotations;

namespace AppLothMVC.Models
{
    public class Endereco : Entity
    {
        public Guid FornecedorId { get; set; }        
        public string Logradouro { get; set; }        
        public string Numero { get; set; }
        public string Complemento { get; set; }        
        public string Cep { get; set; }        
        public string Bairro { get; set; }        
        public string Cidade { get; set; }        
        public string Estado { get; set; }

        /* Relação EF para Fornecedor ter um Endereco */
        public Fornecedor Fornecedor { get; set; }
    }
}
