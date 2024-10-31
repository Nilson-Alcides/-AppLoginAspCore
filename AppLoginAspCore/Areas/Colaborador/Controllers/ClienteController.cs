using AppLoginAspCore.Libraries.Filtro;
using AppLoginAspCore.Models;
using AppLoginAspCore.Repositories.Contract;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;

namespace AppLoginAspCore.Areas.Colaborador.Controllers
{
    [Area("Colaborador")]
    [ColaboradorAutorizacao]
    public class ClienteController : Controller
    {
        private IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public IActionResult Index()
        {
            return View(_clienteRepository.ObterTodosClientes());
        }
        public IActionResult Cadastrar()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar([FromForm] Cliente cliente)
        {
            var CPFExit = _clienteRepository.BuscaCpfCliente(cliente.CPF).CPF;
            var EmailExit = _clienteRepository.BuscaEmailCliente(cliente.Email).Email;

            if (!string.IsNullOrWhiteSpace(CPFExit))
            {
                //CPF Cadastrado
                ViewData["MSG_CPF"] = "CPF já cadastrado, por favor verifique os dados digitado";
                return View();

            }
            else if (!string.IsNullOrWhiteSpace(EmailExit))
            {
                //Email Cadastrado
                ViewData["MSG_Email"] = "E-mail já cadastrado, por favor verifique os dados digitado";
                return View();
            }
            else if (ModelState.IsValid)
            {

                _clienteRepository.Cadastrar(cliente);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [ValidateHttpReferer]
        public IActionResult Ativar(int id)
        {
            _clienteRepository.Ativar(id);
            return RedirectToAction(nameof(Index));
        }       
        [ValidateHttpReferer]
        public IActionResult Desativar(int id)
        {
            _clienteRepository.Desativar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

