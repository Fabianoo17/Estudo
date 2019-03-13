using ProdutoCRUD.Dominio;
using ProdutoCRUD.Infra.Repositories;
using ProdutoMVC.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProdutoMVC.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ProdutoRepository _produtoRepository = new ProdutoRepository();
        public ProdutoController()
        {
            var listaCategoria = new CategoriaRepository().GetAll();
            ViewBag.CategoriaId = new SelectList(
            listaCategoria,
            "CategoriaId",
            "CategoriaNome"
            );
        }


        // GET: Produto
        public ActionResult Index()
        {


            IEnumerable<Produto> produtos = _produtoRepository.GetAll();
            
            return View(produtos);
        }
        [HttpPost]
        public ActionResult index(int id)
        {


            IEnumerable<Produto> produtosid = _produtoRepository.GetAll().Where(c => c.CategoriaId == id);

            return View(produtosid);
        }



        public ActionResult Cadastrar() 
        {

            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Produto produto)
        {
            if (ModelState.IsValid)
            {
                produto.DataCadasto = DateTime.Now;
                _produtoRepository.Add(produto);
                return RedirectToAction("Index");
            }


            return View(produto);
        }

        [HttpPost]
        public ActionResult CadastrarCategoria(Produto produto)
        {

           
                Categoria cat = new Categoria();
                cat.CategoriaNome = produto.Nome;
                new CategoriaRepository().Add(cat);
                return RedirectToAction("Cadastrar");
            
           
        }

        public ActionResult Edit(int id)
        {



            Produto obj = new Produto();
            obj = _produtoRepository.GetById(id);
           
            return View(obj);


        }
        [HttpPost]
        public ActionResult Edit(Produto produto)
        {


            _produtoRepository.Update(produto);


            return RedirectToAction("index");


        }



        public ActionResult Delete(int id)
        {

            Produto obj = new Produto();
            obj = _produtoRepository.GetById(id);
            _produtoRepository.Remove(obj);
            return RedirectToAction("index");


        }

        public void ExportarExcel()
        {

            var grid = new GridView();

            grid.DataSource = from data in _produtoRepository.GetAll()
                              select new
                              {
                                  ProdutoId = data.ProdutoId,
                                  Nome = data.Nome,
                                  DescricaoProduto = data.DescProduto,
                                  DataCadastro = data.DataCadasto,
                                  DataVencimento = data.DataVencimento,
                                  Preço = data.Preco,
                                  CategoriaId = data.CategoriaId

                              };
            grid.DataBind();

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=ProdutosExportList.xls");
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(sw);
            grid.RenderControl(htmlTextWriter);
            Response.Write(sw.ToString());
            Response.End();

          


        }
    }
}