using AppLoginAspCore.Libraries.Filtro;
using AppLoginAspCore.Models.Constants;
using Microsoft.AspNetCore.Mvc;

namespace AppLoginAspCore.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    [ColaboradorAutorizacao(ColaboradorTipoConstant.Gerente)]
    public class ColaboradorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
