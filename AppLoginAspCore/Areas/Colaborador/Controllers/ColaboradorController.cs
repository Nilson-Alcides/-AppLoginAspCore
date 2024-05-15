using AppLoginAspCore.Libraries.Filtro;
using AppLoginAspCore.Models.Constants;
using AppLoginAspCore.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AppLoginAspCore.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    [ColaboradorAutorizacao(ColaboradorTipoConstant.Gerente)]
    public class ColaboradorController : Controller
    {
        private IColaboradorRepository _colaboradorRepository;

        public ColaboradorController(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }
        public IActionResult Index()
        {
            return View(_colaboradorRepository.ObterTodosColaboradores());
        }
        [HttpGet]       
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Models.Colaborador colaborador)
        {
            if (ModelState.IsValid)
            {
                colaborador.Tipo = ColaboradorTipoConstant.Comum;
                _colaboradorRepository.Cadastrar(colaborador);

                TempData["MSG_S"] = "Registro salvo com sucesso!";

                return RedirectToAction(nameof(Index));

            }
            return View();
        }
    }
}
