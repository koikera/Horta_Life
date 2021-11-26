using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Horta_Life.Models;
using System.Data.SqlClient;

namespace Horta_Life.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        //GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult cadastro()
        {
            return View("cadastro");
        }
        public ActionResult reserva()
        {
            return View("reserva");
        }

        void connectionString()
        {
            con.ConnectionString = "data source=WKPCG001; database=UnipDB; integrated security = SSPI";
        }
        
        [HttpPost]
        public ActionResult Verify(Account acc)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * FROM UnipDB.dbo.tb_usuario where [nm_usuario]='" + acc.Usuario + "'and [ds_senha]='" + acc.Senha+"'";
            dr = com.ExecuteReader();
            if(dr.Read())
            {
                con.Close();
                return View("reserva");
            }
            else
            {
                con.Close();
                return View("Login");
            }

        }
        public ActionResult Registration(Regsiter acc)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "INSERT INTO UnipDB.dbo.tb_usuario(nm_nomedoatendente, nm_usuario, ds_email, ds_senha, ds_cpf, ds_cep, ds_telefone, dt_nascimento) VALUES('" + acc.Nome + "','" + acc.Usuario + "','" + acc.Email + "','" + acc.Senha + "','" + acc.CPF + "','" + acc.CEP + "','" + acc.Telefone + "','" + acc.DtNascimento + "')";
            dr = com.ExecuteReader();
            return View("Login");
        }
        public ActionResult Reservar(Reserva res)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "INSERT INTO UnipDB.dbo.tb_reserva(ds_entrada, ds_saida, qtd_hospedes,  nr_quarto, nm_nome) VALUES('" + res.Checkin + "','" + res.Checkout + "','" + res.Hospedes + "',1, 'Teste')";
            dr = com.ExecuteReader();

            con.Close();
            return View("reserva");
        }
        public ActionResult TelaRegistrar => View("cadastro");
    } 
}