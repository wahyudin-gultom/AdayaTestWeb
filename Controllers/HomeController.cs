using AdayaTestWeb.Helpers;
using AdayaTestWeb.Models;
using AdayaTestWeb.Repositories.Contract;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;

namespace AdayaTestWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repository;

        public HomeController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Generate()
        {
            return View("GeneratePage");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GenerateModelSample()
        {
            var list = await _repository.ListAsync();
             return Json(list);
        }

        [HttpPost]
        public IActionResult Trash()
        {
            _ = _repository.DeleteAsync();
            return Ok("sukses");
        }

        [HttpPost]
        public IActionResult ProcessGenerateData([FromBody]List<GenerateDataModel> data)
        {
            _ = _repository.GenerateAsync(data);
            return Ok("sukses");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}