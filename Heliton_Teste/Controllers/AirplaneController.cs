using System.Collections.Generic;
using System.Web.Http;
//
using GOL.AcessoDados.Models;
using GOL.AcessoDados.Repositorio;

namespace Heliton_Teste.Controllers
{
    public class AirplaneController : ApiController
    {

        // Api/Airplane 
        [HttpGet]
        public List<AIRPLANE> ListaAIRPLANE()
        {
            string sql = "select * from[dbo].[AIRPLANE]";

            List<AIRPLANE> lista = new RepositorioGenerico<AIRPLANE>().ExecutaConsulta(sql);

            return lista;
        }

    }
}