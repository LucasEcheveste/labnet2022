using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab.EF.Logic;
using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic.Tests
{
    [TestClass()]
    public class TerritoriesLogicTests
    {
        [TestMethod()]
        public void AgregarTest()
        {

            //arrege
            TerritoriesLogic territoriesLogic = new TerritoriesLogic();
            string id = "120";
            string desc = "Montevideo";
            int reg = 1;
            bool resultado = true;

            //act
            resultado = territoriesLogic.Agregar(new Territories
            {
                TerritoryID = id,
                TerritoryDescription = desc,
                RegionID = reg,
            });

            //assert
            Assert.AreEqual(true, resultado);

        }
    }
}