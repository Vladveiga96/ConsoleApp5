namespace ConsoleApp5 // ou seu namespace
{
    public static class Investimento
    {
        public static double CalcularMontante(double depositoInicial, double depositoMensal, double taxaMensal, int meses)
        {
            double saldo = depositoInicial;

            for (int mes = 1; mes <= meses; mes++)
            {
                double juros = saldo * taxaMensal;
                saldo += juros + depositoMensal;
            }

            return Math.Round(saldo, 2); // Arredondar para testes
        }
    }
}


