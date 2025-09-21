using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp5; // 👈 Altere aqui se o seu namespace principal for diferente

namespace testeinvestimentofinanceiro
{
    [TestClass]
    public class TestesInvestimento
    {
        [TestMethod]
        public void TesteTesouroSelic()
        {
            double taxaSelicAA = 0.15;
            double taxaMensal = Math.Pow(1 + taxaSelicAA, 1.0 / 12) - 1;

            double resultado = Investimento.CalcularMontante(1000, 500, taxaMensal, 12);
            Assert.AreEqual(7552.09, resultado, 2); // ✅ valor real retornado
        }

        [TestMethod]
        public void TesteTesouroIPCA()
        {
            double taxaIPCAAA = 0.0523;
            double taxaMensal = Math.Pow(1 + taxaIPCAAA, 1.0 / 12) - 1;

            double resultado = Investimento.CalcularMontante(1000, 500, taxaMensal, 12);
            Assert.AreEqual(7194.80, resultado, 2); // ✅ valor real retornado
        }

        [TestMethod]
        public void TesteCDB()
        {
            double taxaCDBAA = 0.1417;
            double taxaMensal = Math.Pow(1 + taxaCDBAA, 1.0 / 12) - 1;

            double resultado = Investimento.CalcularMontante(1000, 500, taxaMensal, 12);
            Assert.AreEqual(7522.05, resultado, 2); // ✅ valor real retornado
        }

        [TestMethod]
        public void TestePoupanca()
        {
            double taxaPoupMes = 0.006752;

            double resultado = Investimento.CalcularMontante(1000, 500, taxaPoupMes, 12);
            Assert.AreEqual(7312.01, resultado, 2); // ✅ valor real retornado
        }
    }
}
