using Newtonsoft.Json;
using Projeto.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Projeto.MVC.Controllers
{
    public class LivroController : Controller
    {
        private string URL_BASE = "http://localhost:51558/api/livro";

        [HttpGet]
        public ActionResult Consulta()
        {
            var livro = new LivroViewModelConsulta();
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(URL_BASE + "/listar").Result;
            if (response.IsSuccessStatusCode)
            {
                livro.Livros = response.Content.ReadAsAsync<ICollection<LivroViewModelConsulta>>().Result;
            }
            else
            {
                livro.MensagemErro = "Error";
            }
            return View(livro);
        }

        [HttpGet]
        public ActionResult Cadastro()
        {
            var livro = new LivroViewModelCadastro();
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage responseEdt = client.GetAsync("http://localhost:51558/api/editora/listar").Result;
            HttpResponseMessage responseAut = client.GetAsync("http://localhost:51558/api/autor/listar").Result;
            if (responseEdt.IsSuccessStatusCode && responseAut.IsSuccessStatusCode)
            {
                var resultEdt = responseEdt.Content.ReadAsAsync<ICollection<EditoraViewModelConsulta>>().Result;
                var resultAut = responseAut.Content.ReadAsAsync<ICollection<AutorViewModelConsulta>>().Result;
                if (resultEdt != null && resultAut != null)
                {
                    livro.lstEditoras = resultEdt;
                    livro.lstAutores = resultAut;
                }
            }
            return View(livro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro(LivroViewModelCadastro model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var client = new HttpClient();
                    var serializedAutor = JsonConvert.SerializeObject(model);
                    var content = new StringContent(serializedAutor, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PostAsync(URL_BASE + "/cadastrar", content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Consulta");
                    }
                    else
                    {
                        model.MensagemErro = "Falha ao cadastrar o livro: " + response.StatusCode;
                    }
                }
                catch (Exception e)
                {
                    model.MensagemErro = e.Message;
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Atualiza(int id)
        {
            var livro = new LivroViewModelEdicao();
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(string.Format("{0}?id={1}", URL_BASE + "/obter", id)).Result;

            HttpResponseMessage responseEdt = client.GetAsync("http://localhost:51558/api/editora/listar").Result;
            HttpResponseMessage responseAut = client.GetAsync("http://localhost:51558/api/autor/listar").Result;
            if (response.IsSuccessStatusCode && responseEdt.IsSuccessStatusCode && responseAut.IsSuccessStatusCode)
            {
                livro = response.Content.ReadAsAsync<LivroViewModelEdicao>().Result;
                var resultEdt = responseEdt.Content.ReadAsAsync<ICollection<EditoraViewModelConsulta>>().Result;
                var resultAut = responseAut.Content.ReadAsAsync<ICollection<AutorViewModelConsulta>>().Result;
                if (resultEdt != null && resultAut != null)
                {
                    livro.lstEditoras = resultEdt;
                    livro.lstAutores = resultAut;
                }
            }
            return View(livro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Atualiza(LivroViewModelEdicao model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var client = new HttpClient();
                    var serializedAutor = JsonConvert.SerializeObject(model);
                    var content = new StringContent(serializedAutor, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PutAsync(URL_BASE + "/atualizar", content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Consulta");
                    }
                    else
                    {
                        model.MensagemErro = "Falha ao atualizar o livro: " + response.StatusCode;
                    }
                }
                catch (Exception e)
                {
                    model.MensagemErro = e.Message;
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Deleta(int id)
        {
            var livro = new LivroViewModelExcluir();
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(string.Format("{0}?id={1}", URL_BASE + "/obter", id)).Result;
            if (response.IsSuccessStatusCode)
            {
                livro = response.Content.ReadAsAsync<LivroViewModelExcluir>().Result;
            }
            return View(livro);
        }

        [HttpPost, ActionName("Deleta")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmaDeletacao(int id)
        {
            var livro = new LivroViewModelExcluir();
            var client = new HttpClient();
            HttpResponseMessage response = client.DeleteAsync(string.Format("{0}?id={1}", URL_BASE + "/excluir", id)).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Consulta");
            }
            else
            {
                livro.MensagemErro = "Falha ao excluir o livro: " + response.StatusCode;
            }
            return View(livro);
        }
    }
}