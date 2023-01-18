using AppLothMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Loth.App.ViewModels
{
    public class EnderecoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Campo é obrigatório")]
        [StringLength(200, ErrorMessage = "O Campo precisa ter entre 2 e 200 caracteres", MinimumLength = 2)]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O Campo é obrigatório")]
        [StringLength(50, ErrorMessage = "O Campo precisa ter entre 1 e 50 caracteres", MinimumLength = 1)]
        public string Numero { get; set; }        
        public string Complemento { get; set; }

        [Required(ErrorMessage = "O Campo é obrigatório")]
        [StringLength(8, ErrorMessage = "O Campo precisa ter 8 caracteres", MinimumLength = 8)]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O Campo é obrigatório")]
        [StringLength(100, ErrorMessage = "O Campo precisa ter entre 2 e 100 caracteres", MinimumLength = 2)]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O Campo é obrigatório")]
        [StringLength(100, ErrorMessage = "O Campo precisa ter entre 2 e 100 caracteres", MinimumLength = 2)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O Campo é obrigatório")]
        [StringLength(50, ErrorMessage = "O Campo precisa ter entre 2 e 50 caracteres", MinimumLength = 2)]
        public string Estado { get; set; }

        [HiddenInput]
        public Guid FornecedorId { get; set; }
        public FornecedorViewModel Fornecedor { get; set; }
    }
}
