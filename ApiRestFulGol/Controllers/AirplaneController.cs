using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

// Objeto Acesso SQL //
using GOL.AcessoDados.Models;
using GOL.AcessoDados.Repositorio;

namespace ApiRestFulGol.Controllers
{
    public class AirplaneController : ApiController
    {
        // api/Airplane
        [HttpGet]
        public List<AIRPLANE> GetAllAirplane()
        {
            string sql = "select * from[dbo].[AIRPLANE]";

            return new RepositorioGenerico<AIRPLANE>().ExecutaConsulta(sql);
        }

        // api/Airplane/5006
        [HttpGet]
        public AIRPLANE FindAirplane(int id)
        {
            string sql = "select * from [dbo].[AIRPLANE] where ID=" + id;

            return new RepositorioGenerico<AIRPLANE>().ExecutaConsulta(sql).ToList().FirstOrDefault();

        }

        // api/Airplane/{AIRPLANE}
        [HttpPost]
        public void InsertAirplane(AIRPLANE request)
        {
            string sql = "insert into [dbo].[AIRPLANE] "
                        + " values("
                        + "'" + request.MODELO.ToString() + "',"
                        + request.QTDEPASSAGEIRO + ","
                        + "getdate()"
                        + ")";

            new RepositorioGenerico<AIRPLANE>().ExecutaAtualizacao(sql);
        }
    }
}