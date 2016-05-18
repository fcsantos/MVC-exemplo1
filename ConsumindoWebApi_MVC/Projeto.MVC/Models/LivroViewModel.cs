using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Projeto.MVC.Models
{
    public class LivroViewModelCadastro
    {
        [Required(ErrorMessage = "Por favor, informe o ISBN.")]
        [MaxLength(13, ErrorMessage = "Erro. ISBN deve ter no máximo {1} caracteres.")]
        [Display(Name = "ISBN:")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Por favor, informe o Título.")]
        [MaxLength(100, ErrorMessage = "Erro. Título deve ter no máximo {1} caracteres.")]
        [Display(Name = "Título:")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Por favor, informe o Gênero.")]
        [MaxLength(30, ErrorMessage = "Erro. Gênero deve ter no máximo {1} caracteres.")]
        [Display(Name = "Gênero:")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "Por favor, informe o Sinopse.")]
        [MaxLength(200, ErrorMessage = "Erro. Sinopse deve ter no máximo {1} caracteres.")]
        [Display(Name = "Sinopse:")]
        public string Sinopse { get; set; }

        [Required(ErrorMessage = "Por favor, informe o Categoria.")]
        [MaxLength(30, ErrorMessage = "Erro. Categoria deve ter no máximo {1} caracteres.")]
        [Display(Name = "Gategoria:")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "Por favor, Selecione o Autor.")]
        [Display(Name = "Autores:")]        
        public int AutorId { get; set; }
        public ICollection<AutorViewModelConsulta> lstAutores { get; set; }

        [Required(ErrorMessage = "Por favor, Selecione a Editora.")]
        [Display(Name = "Editoras:")]
        public int EditoraId { get; set; }
        public ICollection<EditoraViewModelConsulta> lstEditoras { get; set; }

        public string MensagemErro { get; set; }
    }

    public class LivroViewModelConsulta
    {
        [Display(Name = "Id Livro")]
        public int IdLivro { get; set; }

        [Display(Name = "ISBN")]
        public string ISBN { get; set; }

        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Display(Name = "Gênero")]
        public string Genero { get; set; }

        [Display(Name = "Sinopse")]
        public string Sinopse { get; set; }

        [Display(Name = "Gategoria")]
        public string Categoria { get; set; }

        [Display(Name = "Nome do Autor")]
        public string NomeAutor { get; set; }

        [Display(Name = "Nome da Editora")]
        public string NomeEditora { get; set; }

        public string MensagemErro { get; set; }

        public ICollection<LivroViewModelConsulta> Livros { get; set; }
    }

    public class LivroViewModelEdicao
    {
        public int IdLivro { get; set; }

        [Required(ErrorMessage = "Por favor, informe o ISBN.")]
        [MaxLength(13, ErrorMessage = "Erro. ISBN deve ter no máximo {1} caracteres.")]
        [Display(Name = "ISBN:")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Por favor, informe o Título.")]
        [MaxLength(100, ErrorMessage = "Erro. Título deve ter no máximo {1} caracteres.")]
        [Display(Name = "Título:")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Por favor, informe o Gênero.")]
        [MaxLength(30, ErrorMessage = "Erro. Gênero deve ter no máximo {1} caracteres.")]
        [Display(Name = "Gênero:")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "Por favor, informe o Sinopse.")]
        [MaxLength(200, ErrorMessage = "Erro. Sinopse deve ter no máximo {1} caracteres.")]
        [Display(Name = "Sinopse:")]
        public string Sinopse { get; set; }

        [Required(ErrorMessage = "Por favor, informe o Categoria.")]
        [MaxLength(30, ErrorMessage = "Erro. Categoria deve ter no máximo {1} caracteres.")]
        [Display(Name = "Gategoria:")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "Por favor, Selecione o Autor.")]
        [Display(Name = "Autores:")]
        public int AutorId { get; set; }
        public ICollection<AutorViewModelConsulta> lstAutores { get; set; }

        [Required(ErrorMessage = "Por favor, Selecione a Editora.")]
        [Display(Name = "Editoras:")]
        public int EditoraId { get; set; }
        public ICollection<EditoraViewModelConsulta> lstEditoras { get; set; }

        public string MensagemErro { get; set; }
    }

    public class LivroViewModelExcluir
    {
        public int IdLivro { get; set; }
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public string Sinopse { get; set; }
        public int AutorId { get; set; }
        public string NomeAutor { get; set; }
        public int EditoraId { get; set; }
        public string NomeEditora { get; set; }
        public string MensagemErro { get; set; }
    }
}
