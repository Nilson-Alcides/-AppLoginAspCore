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

        public IActionResult Index(int? pagina, string pesquisa)
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

