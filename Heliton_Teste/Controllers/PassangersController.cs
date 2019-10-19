using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
//
using GOL.AcessoDados.Models;
using GOL.AcessoDados.Repositorio;

namespace Heliton_Teste.Controllers
{
    public class PassangersController : ApiController
    {

        [HttpPost]
        public void AdicionarPassangers(PASSAGEIRO_AIRPLANE request)
        {

            string sql = "";

            // Atualiza passageiro pelo CPF //
            sql = "select * from [dbo].[PASSAGEIRO] "
                + " where CPF = '" + request.PASSAGEIRO.CPF.ToString().Replace(".", "").Replace("-", "").Trim() + "'";

            List<PASSAGEIRO> listaPassageiro = new RepositorioGenerico<PASSAGEIRO>().ExecutaConsulta(sql);

            if (listaPassageiro != null && listaPassageiro.ToList().Count > 0)
            {
                sql = "update [dbo].[PASSAGEIRO] "
                    + " set NOME='" + request.PASSAGEIRO.NOME.ToString() + "',"
                    + " DATACRIACAO=getdate()"
                    + " where CPF = '" + request.PASSAGEIRO.CPF.ToString().Replace(".", "").Replace("-", "").Trim() + "'";
            }
            else
            {
                sql = "insert into [dbo].[PASSAGEIRO] "
                    + " values("
                    + "'" + request.PASSAGEIRO.NOME.ToString() + "',"
                    + "'" + request.PASSAGEIRO.CPF.ToString().Replace(".", "").Replace("-", "").Trim() + "',"
                    + "getdate()"
                    + ")";
            }
            new RepositorioGenerico<PASSAGEIRO>().ExecutaAtualizacao(sql);
        }

        //
        [HttpPut]
        public void AlterarPassangers(PASSAGEIRO_AIRPLANE request)
        {

            string sql = "";

            // Set passageiro atualizado pelo CPF //
            sql = "select * from [dbo].[PASSAGEIRO] "
                + " where CPF = '" + request.PASSAGEIRO.CPF.ToString().Replace(".", "").Replace("-", "").Trim() + "'";

            List<PASSAGEIRO> listaPassageiro = new RepositorioGenerico<PASSAGEIRO>().ExecutaConsulta(sql);

            // Atualiza passageiro X Aeronave (deleta depois regrava) //
            sql = "delete from [dbo].[PASSAGEIRO_AIRPLANE] where ID_PASSAGEIRO = " + listaPassageiro.ToList().FirstOrDefault().ID;
            new RepositorioGenerico<PASSAGEIRO_AIRPLANE>().ExecutaAtualizacao(sql);

            if (request.AIRPLANE.ID > 0)
            {
                sql = "insert into [dbo].[PASSAGEIRO_AIRPLANE] "
                    + " values("
                    + request.AIRPLANE.ID + ","
                    + listaPassageiro.ToList().FirstOrDefault().ID
                    + ")";
                new RepositorioGenerico<PASSAGEIRO_AIRPLANE>().ExecutaAtualizacao(sql);
            }
        }

        // Api/Passangers //
        [HttpGet]
        public List<PASSAGEIRO_AIRPLANE> ListaPassangers()
        {
            string sql = "select * from[dbo].[PASSAGEIRO]";
            List<PASSAGEIRO> listaPassageiro = new RepositorioGenerico<PASSAGEIRO>().ExecutaConsulta(sql);

            List<PASSAGEIRO_AIRPLANE> lista = new List<PASSAGEIRO_AIRPLANE>();

            // passageiros //
            if (listaPassageiro != null && listaPassageiro.ToList().Count > 0)
            {
                // passageiros X Aeronaves //
                foreach (var lst in listaPassageiro)
                {
                    sql = "select distinct isnull(c.ID,0) as ID, isnull(c.MODELO,'') as MODELO"
                        + " from[dbo].[PASSAGEIRO] a  "
                        + " left join[dbo].[PASSAGEIRO_AIRPLANE] b ON a.ID = b.ID_PASSAGEIRO "
                        + " left join[dbo].[AIRPLANE] c ON c.ID=b.ID_AIRPLANE "
                        + " where a.ID=" + lst.ID;

                    List<AIRPLANE> lstAeronave = new RepositorioGenerico<AIRPLANE>().ExecutaConsulta(sql);

                    List<PASSAGEIRO_AIRPLANE> headers = lstAeronave.Select(p => new PASSAGEIRO_AIRPLANE()
                    {
                        AIRPLANE = p,
                        PASSAGEIRO = lst,
                    }).ToList();

                    lista.AddRange(headers);
                }
                return lista.OrderBy(o => o.PASSAGEIRO.NOME).ToList();
            }
            return lista;
        }
    }
}