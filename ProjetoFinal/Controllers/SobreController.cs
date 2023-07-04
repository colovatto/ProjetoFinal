using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.Models;

namespace ProjetoFinal.Controllers
{
    public class SobreController : Controller
    {
        public IActionResult Sobre()
        {
            return View();
        }
    }
}
