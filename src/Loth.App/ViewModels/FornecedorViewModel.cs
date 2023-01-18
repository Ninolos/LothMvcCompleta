using AppLothMVC.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Loth.App.ViewModels
{
    public class FornecedorViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Campo é obrigatório")]
        [StringLength(100, ErrorMessage = "O Campo precisa ter entre 2 e 100 caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Campo é obrigatório")]
        [StringLength(14, ErrorMessage = "O Campo precisa ter entre 11 e 14 caracteres", MinimumLength = 11)]
        public string Documento { get; set; }

        [DisplayName("Tipo")]
        public int TipoFornecedor { get; set; }
        public EnderecoViewModel Endereco { get; set; }

        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }        
        public IEnumerable<ProdutoViewModel> Produtos { get; set; }
    }
}
