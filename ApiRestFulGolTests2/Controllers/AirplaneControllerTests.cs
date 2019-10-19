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
    public class AirplaneControllerTests
    {
        //
        [TestMethod()]
        public void GetAllAirplaneTest()
        {
            List<AIRPLANE> data = new AirplaneController().GetAllAirplane();
        }

        //
        [TestMethod()]
        public void FindAirplaneTest()
        {
            AIRPLANE data = new AirplaneController().FindAirplane(5006);
        }

        //
        [TestMethod()]
        public void InsertAirplaneTest()
        {
            AIRPLANE data = new AIRPLANE
            {
                MODELO = "MODELO 10",
                QTDEPASSAGEIRO = 100
            };

            new AirplaneController().InsertAirplane(data);

        }
    }
}