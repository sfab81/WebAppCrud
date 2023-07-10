using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using WebAppCrud.DB;
using WebAppCrud.Models;

namespace WebAppCrud.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DBContext1 _dbContext1;
        public HomeController(ILogger<HomeController> logger, DBContext1 dBContext1)
        {
            _logger = logger;
            _dbContext1 = dBContext1;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Prods()
        {
            List<ProdModel> models = new List<ProdModel>();
            foreach (Prod p in _dbContext1.Prods)
            {
                ProdModel model = new ProdModel();
                model.Id = p.Id;
                model.Nome = p.Nome;
                model.Prezzo = p.Prezzo;
                models.Add(model);
            }
            return View(models);
        }
        public IActionResult Crea() 
        { 
            return View(); 
        }
        [HttpPost]
        public async Task<IActionResult> Crea(ProdModel model) 
        {
            Prod prod=new Prod();
            prod.Id = Guid.NewGuid();
            prod.Nome = model.Nome;
            prod.Prezzo = model.Prezzo;
            var result =await _dbContext1.Prods.AddAsync(prod);
            _dbContext1.SaveChanges();
            return Redirect("Prods");
        }
        public async Task<IActionResult> Modifica(Guid Id)
        {
            if (Id == null) 
            {
                return View();
            }
            var result = await _dbContext1.Prods.FindAsync(Id);
                if (result == null) 
                {
                    return View();
                }
                ProdModel model = new ProdModel();
                model.Id = result.Id;
                model.Nome = result.Nome;
                model.Prezzo = result.Prezzo;
                return View(model);
                
        }

        [HttpPost]
        public IActionResult Salva(ProdModel prodModel)
        {
            Prod prod = new Prod();
            prod.Id=prodModel.Id;
            prod.Nome = prodModel.Nome; 
            prod.Prezzo = prodModel.Prezzo;
            _dbContext1.Prods.Update(prod);
            _dbContext1.SaveChanges();
            return Redirect("Prods");
        }
        public async Task<IActionResult> Cancella(Guid Id)
        {
            if (Id != null) 
            { 
                var result = await _dbContext1.Prods.FindAsync(Id);
                if (result != null) 
                {
                    _dbContext1.Prods.Remove(result);
                    _dbContext1.SaveChanges();
                }
            }
            return RedirectToAction("Prods");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
