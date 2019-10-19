using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApiRestFulGol.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GOL.AcessoDados.Models;

namespace ApiRestFulGol.Controllers.Tests
{
    [TestClass()]
    public class PassangersControllerTests
    {
        //
        [TestMethod()]
        public void ListAllPassangerByAirplaneTest()
        {
            List<PASSAGEIRO_AIRPLANE> data = new PassangersController().ListAllPassangerByAirplane(5006);
        }

        //
        [TestMethod()]
        public void InsertPassangerTest()
        {
            PASSAGEIRO data = new PASSAGEIRO
            {
                NOME = "PASSAGEIRO 1",
                CPF = "20000000200"
            };

            new PassangersController().InsertPassanger(data);
        }

        //
        [TestMethod()]
        public void InsertPassangerToAirplaneTest()
        {

            PASSAGEIRO_AIRPLANE data = new PASSAGEIRO_AIRPLANE
            {
                ID_AIRPLANE = 5006,
                ID_PASSAGEIRO = 1
            };

            new PassangersController().InsertPassangerToAirplane(data);

        }

        //
        [TestMethod()]
        public void ChangePassangerTest()
        {
            new PassangersController().ChangePassanger(1, 5005);
            //new PassangersController().ChangePassanger(1, 5006);
        }
    }
}