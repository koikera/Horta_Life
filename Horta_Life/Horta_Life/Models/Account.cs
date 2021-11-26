using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Horta_Life.Models
{
    public class Account
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
    }

    public class Regsiter
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string CEP { get; set; }
        public string DtNascimento { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}