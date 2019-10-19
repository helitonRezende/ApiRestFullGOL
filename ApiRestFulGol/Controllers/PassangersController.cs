using System.Collections.Generic;
using System.Web.Http;

// Objeto Acesso SQL //
using GOL.AcessoDados.Models;
using GOL.AcessoDados.Repositorio;

namespace ApiRestFulGol.Controllers
{
    public class PassangersController : ApiController
    {
        // api/Passangers/5006
        [HttpGet]
        public List<PASSAGEIRO_AIRPLANE> ListAllPassangerByAirplane(int id)
        {
            string sql = "select * from[dbo].[PASSAGEIRO_AIRPLANE] "
                        + " WHERE ID_AIRPLANE=" + id;

            return new RepositorioGenerico<PASSAGEIRO_AIRPLANE>().ExecutaConsulta(sql);
        }

        // api/Passangers/{PASSAGEIRO}
        [HttpPost]
        public void InsertPassanger(PASSAGEIRO request)
        {
            string sql = "insert into [dbo].[PASSAGEIRO] "
                        + " values("
                        + "'" + request.NOME.ToString() + "',"
                        + "'" + request.CPF.ToString() + "',"
                        + "getdate()"
                        + ")";

            new RepositorioGenerico<PASSAGEIRO>().ExecutaAtualizacao(sql);
        }

        // api/Passangers/{PASSAGEIRO_AIRPLANE}
        [HttpPost]
        public void InsertPassangerToAirplane(PASSAGEIRO_AIRPLANE request)
        {
            string sql = "insert into [dbo].[PASSAGEIRO_AIRPLANE] "
                        + " values("
                        + request.ID_AIRPLANE + ","
                        + request.ID_PASSAGEIRO
                        + ")";

            new RepositorioGenerico<PASSAGEIRO_AIRPLANE>().ExecutaAtualizacao(sql);
        }

        // api/Passangers/{ID:1, idAirplane:5006}
        [HttpPost]
        public void ChangePassanger(int id, int idAirplane)
        {
            string sql = "UPDATE [dbo].[PASSAGEIRO_AIRPLANE] "
                        + " SET ID_AIRPLANE=" + idAirplane
                        + " WHERE ID_PASSAGEIRO=" + id;

            new RepositorioGenerico<PASSAGEIRO_AIRPLANE>().ExecutaAtualizacao(sql);
        }
    }
}