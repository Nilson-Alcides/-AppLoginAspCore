﻿using AppLoginCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using X.PagedList;

namespace AppLoginCore.Repositories.Contracts
{
    public interface IClienteRepository
    {
        Cliente Login(string Email, string Senha);
        
        //CRUD
        void Cadastrar(Cliente cliente);
        void Atualizar(Cliente cliente);
        void Excluir(int Id);
        Cliente ObterCliente(int Id);
        IEnumerable<Cliente> ObterTodosClientes();
        //  IPagedList<Cliente> ObterTodosClientes(int? pagina, string pesquisa);
    }
}
