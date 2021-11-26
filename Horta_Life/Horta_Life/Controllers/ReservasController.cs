using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Horta_Life.Models;
using System.Data.SqlClient;

namespace Horta_Life.Controllers
{
    public class ReservasController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        // GET: Reservas
        [HttpGet]
        public ActionResult reserva()
        {
            return View("reserva");
        }

        void connectionString()
        {
            con.ConnectionString = "data source=WKPCG001; database=UnipDB; integrated security = SSPI";
        }
        [HttpPost]

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
    }
   }