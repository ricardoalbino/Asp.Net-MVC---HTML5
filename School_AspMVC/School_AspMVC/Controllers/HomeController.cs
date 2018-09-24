using School_AspMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School_AspMVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            PessoaModel pessoaModel = new PessoaModel();
            ViewBag.GetAll = pessoaModel.GetAll();
            return View();
        }

        // Chama o formulario de Cadastrar
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // Pega os dados do formulario e passa p/ Controller enviar p/ BD
        [HttpPost]
        public ActionResult Create(PessoaModel pessoaModel)
        {
            if (ModelState.IsValid)
            {
                pessoaModel.Create(pessoaModel);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create");
            }
            
        }

        // Carrega o Formulario de Editar
        [HttpGet]
        public ActionResult Editar(int? id)
        {
            if (id != 0)
            {

                PessoaModel pessoaModel = new PessoaModel();
                ViewBag.GetByID = pessoaModel.GetByID(Convert.ToInt16(id));
               
                return View();
            }
            else
            {
                return RedirectToAction("index");
            }
           
        }

        // Obtem dados do formulario via POST, e passa para o Controller salvar no BD
        [HttpPost]
          public ActionResult Update(PessoaModel pessoaModel)
        {
            
            if (ModelState.IsValid)
            {
             
                pessoaModel.Update(pessoaModel);

                return RedirectToAction("index");
            }
            else
            {
                return View("Editar");
            }
           
        }

        [HttpGet]
        public ActionResult Deletar(int id)
        {
            PessoaModel pessoaModel = new PessoaModel();
            pessoaModel.Deletar(id);

            return RedirectToAction("Index");
        }


    }
}