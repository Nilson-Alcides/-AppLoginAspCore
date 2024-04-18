using AppLoginAspCore.Libraries.Login;
using AppLoginAspCore.Models.Constants;
using AppLoginAspCore.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AppLoginAspCore.Areas.Colaborador.Controllers
{
    public class HomeController : Controller
    {
        private IColaboradorRepository _repositoryColaborador;
        private LoginColaborador _loginColaborador;

        public HomeController(IColaboradorRepository repositoryColaborador, LoginColaborador loginColaborador)
        {
            _repositoryColaborador = repositoryColaborador;
            _loginColaborador = loginColaborador;
        }

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
        public IActionResult PainelGerente()
        {
            return View();
        }
        public IActionResult PainelComun()
        {
            return View();
        }
    }
}
