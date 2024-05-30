﻿
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppLoginAspCore.Models
{
    public class Colaborador
    {
        [Display(Name = "Código", Description = "Código.")]
        [ValidateNever]
        public int Id { get; set; }

        [Display(Name = "Nome completo", Description = "Nome e Sobrenome.")]
        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        public string Nome { get; set; }

        //[Display(Name = "Celular")]
        //[Required(ErrorMessage = "O Celular é obrigatorio")]
        //public string Telefone { get; set; }

        //[Display(Name = "CPF")]
        //[Required(ErrorMessage = "O CPF é obrigatorio")]       
        //public string CPF { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = " O Email não é valido")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "O senha é obrigatorio")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 10 caracteres")]
        public string Senha { get; set; }

        /*
         * TIPO ColaboradorTipoConstant
        */
        [Display(Name = "Tipo")]
        //[Required(ErrorMessage = "O Tipo é obrigatorio")]
        public string? Tipo { get; set; } 
    }
}
