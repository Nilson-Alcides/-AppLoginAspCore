using AppLoginAspCore.Libraries.Filtro;
using AppLoginAspCore.Models;
using AppLoginAspCore.Repositories.Contract;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Cadastrar(Cliente cliente)
        {
            _clienteRepository.Cadastrar(cliente);
            return View();
        }
        public IActionResult Ativar( int id)
        {
            return View(_clienteRepository.ObterCliente(id));
        }
        [HttpPost]
        public IActionResult Ativar(Cliente cliente)
        {
            _clienteRepository.Ativar(cliente);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Desativar(int id)
        {
            return View(_clienteRepository.ObterCliente(id));
        }
        [HttpPost]
        public IActionResult Desativar(Cliente cliente)
        {
            _clienteRepository.Desativar(cliente);
            return RedirectToAction(nameof(Index));
        }
    }
}
}
