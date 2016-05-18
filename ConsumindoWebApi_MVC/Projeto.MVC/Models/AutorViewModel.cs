using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projeto.MVC.Models
{
    public class AutorViewModelCadastro
    {
        [Required(ErrorMessage = "Por favor, informe o nome do Autor.")]
        [MaxLength(150, ErrorMessage = "Erro. Nome deve ter no máximo {1} caracteres.")]
        [Display(Name = "Nome do Autor:")]
        public string Nome { get; set; }

        public string MensagemErro { get; set; }
    }

    public class AutorViewModelConsulta
    {
        [Display(Name = "Id Autor")]
        public int IdAutor { get; set; }

        [Display(Name = "Nome do Autor")]
        public string Nome { get; set; }

        [Display(Name = "Qtd de livros")]
        public int QtdLivros { get; set; }

        public ICollection<AutorViewModelConsulta> Autores { get; set; }

        public string MensagemErro { get; set; }
    }

    public class AutorViewModelEdicao
    {
        public int IdAutor { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome do Autor.")]
        [MaxLength(150, ErrorMessage = "Erro. Nome deve ter no máximo {1} caracteres.")]
        [Display(Name = "Nome do Autor:")]
        public string Nome { get; set; }

        public string MensagemErro { get; set; }
    }

    public class AutorViewModelExcluir
    {
        public int IdAutor { get; set; }

        public string Nome { get; set; }

        public int QtdLivros { get; set; }

        public string MensagemErro { get; set; }
    }
}
