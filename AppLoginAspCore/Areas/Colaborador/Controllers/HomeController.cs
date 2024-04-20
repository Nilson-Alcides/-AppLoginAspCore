using AppLoginAspCore.Libraries.Filtro;
using AppLoginAspCore.Libraries.Login;
using AppLoginAspCore.Models.Constants;
using AppLoginAspCore.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AppLoginAspCore.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    public class HomeController : Controller
    {
        private IColaboradorRepository _repositoryColaborador;
        private LoginColaborador _loginColaborador;

        public HomeController(IColaboradorRepository repositoryColaborador, LoginColaborador loginColaborador)
        {
            _repositoryColaborador = repositoryColaborador;
            _loginColaborador = loginColaborador;
        }
        [ColaboradorAutorizacao]
        public IActionResult Index()
        {
            return View();
        }       
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login([FromForm] Models.Colaborador colaborador)
        {
            Models.Colaborador colaboradorDB = _repositoryColaborador.Login(colaborador.Email, colaborador.Senha);


            if (colaboradorDB.Email != null && colaboradorDB.Senha != null && 
                colaboradorDB.Tipo != ColaboradorTipoConstant.Comum)
            {
                _loginColaborador.Login(colaboradorDB);

                return new RedirectResult(Url.Action(nameof(PainelGerente)));
            }
            if (colaboradorDB.Email != null && colaboradorDB.Senha != null && 
                colaboradorDB.Tipo != ColaboradorTipoConstant.Gerente)
            {
                _loginColaborador.Login(colaboradorDB);

                return new RedirectResult(Url.Action(nameof(PainelComun)));

            }
            else
            {
                ViewData["MSG_E"] = "Usuário não encontrado, verifique o e-mail e senha digitado!";
                return View();
            }
        }
        [ColaboradorAutorizacao]
        public IActionResult PainelGerente()
        {
            ViewBag.Nome = _loginColaborador.GetColaborador().Nome;
            ViewBag.Tipo = _loginColaborador.GetColaborador().Tipo;
            ViewBag.Email = _loginColaborador.GetColaborador().Email;
            //return new ContentResult() { Content = "Este é o Painel do Cliente!" };
            return View();
        }
        [ColaboradorAutorizacao]
        public IActionResult PainelComun()
        {
            ViewBag.Nome = _loginColaborador.GetColaborador().Nome;
            ViewBag.Tipo = _loginColaborador.GetColaborador().Tipo;
            ViewBag.Email = _loginColaborador.GetColaborador().Email;
            //return new ContentResult() { Content = "Este é o Painel do Cliente!" };
            return View();

        }
        [ColaboradorAutorizacao]
        public IActionResult Painel()
        {
            return View();
        }
        [ColaboradorAutorizacao]
        public IActionResult Logout()
        {
            _loginColaborador.Logout();
            return RedirectToAction("Login", "Home");
        }

    }
}
