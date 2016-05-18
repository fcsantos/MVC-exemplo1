using Newtonsoft.Json;
using Projeto.MVC.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Mvc;

namespace Projeto.MVC.Controllers
{
    public class AutorController : Controller
    {
        private string URL_BASE = "http://localhost:51558/api/autor";

        [HttpGet]
        public ActionResult Consulta()
        {
            var autor = new AutorViewModelConsulta();
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(URL_BASE + "/listar").Result;
            if (response.IsSuccessStatusCode)
            {
                autor.Autores = response.Content.ReadAsAsync<ICollection<AutorViewModelConsulta>>().Result;
            }
            else
            {
                autor.MensagemErro = "Error";
            }
            return View(autor);
        }

        [HttpGet]
        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro(AutorViewModelCadastro model)
        {
            if (ModelState.IsValid)
            {
                try
                {                    
                    var client = new HttpClient();
                    var serializedAutor = JsonConvert.SerializeObject(model);
                    var content = new StringContent(serializedAutor, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PostAsync(URL_BASE + "/cadastro", content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Consulta");
                    }
                    else
                    {
                        model.MensagemErro = "Falha ao cadastrar o autor: " + response.StatusCode;
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
            var autor = new AutorViewModelEdicao();
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(string.Format("{0}?id={1}", URL_BASE + "/obter", id)).Result;
            if (response.IsSuccessStatusCode)
            {
                autor  = response.Content.ReadAsAsync<AutorViewModelEdicao>().Result;
            }
            return View(autor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Atualiza(AutorViewModelEdicao model)
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
                        model.MensagemErro = "Falha ao atualizar o autor: " + response.StatusCode;
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
            var autor = new AutorViewModelExcluir();
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(string.Format("{0}?id={1}", URL_BASE + "/obter", id)).Result;
            if (response.IsSuccessStatusCode)
            {
                autor = response.Content.ReadAsAsync<AutorViewModelExcluir>().Result;
            }
            return View(autor);
        }

        [HttpPost, ActionName("Deleta")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmaDeletacao(int id)
        {
            var autor = new AutorViewModelExcluir();
            var client = new HttpClient();
            HttpResponseMessage response = client.DeleteAsync(string.Format("{0}?id={1}", URL_BASE + "/excluir", id)).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Consulta");
            }
            else
            {
                autor.MensagemErro = "Falha ao excluir o autor: " + response.StatusCode;
            }
            return View(autor);
        }
    }
}