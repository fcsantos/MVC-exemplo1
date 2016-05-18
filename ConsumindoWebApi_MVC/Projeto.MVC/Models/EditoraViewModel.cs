using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projeto.MVC.Models
{
    public class EditoraViewModelCadastro
    {
        [Required(ErrorMessage = "Por favor, informe o nome do Editora.")]
        [MaxLength(150, ErrorMessage = "Erro. Nome deve ter no máximo {1} caracteres.")]
        [Display(Name = "Nome da Editora:")]
        public string Nome { get; set; }

        public string MensagemErro { get; set; }
    }

    public class EditoraViewModelConsulta
    {
        [Display(Name = "Id Editora")]
        public int IdEditora { get; set; }

        [Display(Name = "Nome do Editora")]
        public string Nome { get; set; }

        [Display(Name = "Qtd de livros publicados")]
        public int QtdLivrosPublicados { get; set; }

        public ICollection<EditoraViewModelConsulta> Editoras { get; set; }

        public string MensagemErro { get; set; }
    }

    public class EditoraViewModelEdicao
    {
        public int IdEditora { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome do Editora.")]
        [MaxLength(150, ErrorMessage = "Erro. Nome deve ter no máximo {1} caracteres.")]
        [Display(Name = "Nome da Editora:")]
        public string Nome { get; set; }

        public string MensagemErro { get; set; }
    }

    public class EditoraViewModelExcluir
    {
        public int IdEditora { get; set; }

        public string Nome { get; set; }

        public int QtdLivrosPublicados { get; set; }

        public string MensagemErro { get; set; }
    }
}
