﻿using AppLoginAspCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppLoginAspCore.Repositories.Contracts
{
    public interface IColaboradorRepository
    {
        // Login Colaboraador
        Colaborador Login(string Email, string Senha);

        // Cadastrar Colaborador
        void Cadastrar(Colaborador colaborador);

        //Atualizar colaborador
        void Atualizar(Colaborador colaborador);
        
        //Atualizar senha Colaborador
        void AtualizarSenha(Colaborador colaborador);
        
        // Excluir Colabolardor
        void Excluir(int Id);

        // Obter colaborador por Id
        Colaborador ObterColaborador(int Id);

        // Obter colaborador por E-mail
        List<Colaborador> ObterColaboradorPorEmail(string email);

        // Obter todos colaborador
        IEnumerable<Colaborador> ObterTodosColaboradores();

        // Obter todos colaborador com paginação 
        // IPagedList<Colaborador> ObterTodosColaboradores(int? pagina);
    }
}
