using AppLothMVC.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loth.App.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [DisplayName("Fornecedor")]
        public Guid FornecedorId { get; set; }

        [Required(ErrorMessage = "O Campo é obrigatório")]
        [StringLength(200, ErrorMessage = "O Campo precisa ter entre 2 e 200 caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O Campo é obrigatório")]
        [StringLength(1000, ErrorMessage = "O Campo precisa ter entre 2 e 1000 caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }

        [DisplayName("Adicionar Imagem")]
        [NotMapped]
        public IFormFile ImagemUpload { get; set; }
        public string Imagem { get; set; }

        [Required(ErrorMessage = "O Campo é obrigatório")]
        public decimal Valor { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }

        [NotMapped]
        public FornecedorViewModel Fornecedor { get; set; }

        [NotMapped]
        public IEnumerable<FornecedorViewModel> Fornecedores { get; set; }
    }
}
