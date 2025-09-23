using ConsoleApp5;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestesInvestimentoFinanceiro; 

namespace TestesInvestimentoFinanceiro
{
    [TestClass]
    public class TestesInvestimento
    {
        [TestMethod]
        public void TesteTesouroSelic()
        {
            double taxaSelicAA = 0.1075;
            double taxaMensal = Math.Pow(1 + taxaSelicAA, 1.0 / 12) - 1;

            double resultado = Investimento.CalcularMontante(300, 4000, taxaMensal, 12);
            Assert.AreEqual(50653.66, resultado, 0.01);
        }

        [TestMethod]
        public void TesteTesouroIPCA()
        {
            double taxaIPCAAA = 0.045;
            double taxaMensal = Math.Pow(1 + taxaIPCAAA, 1.0 / 12) - 1;

            double resultado = Investimento.CalcularMontante(300, 4000, taxaMensal, 12);
            Assert.AreEqual( 49295.63, resultado, 0.01);
        }

        [TestMethod]
        public void TesteCDB()
        {
            double taxaCDBAA = 0.12;
            double taxaMensal = Math.Pow(1 + taxaCDBAA, 1.0 / 12) - 1;

            double resultado = Investimento.CalcularMontante(300, 4000, taxaMensal, 12);
            Assert.AreEqual(50921.99, resultado, 0.01);
        }

        [TestMethod]
        public void TestePoupanca()
        {
            double taxaPoupMes = 0.0056;

            double resultado = Investimento.CalcularMontante(300, 4000, taxaPoupMes, 12);
            Assert.AreEqual(49827.14, resultado, 0.01);
        }
    }
}

