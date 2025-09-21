namespace ConsoleApp5
{
    public class Investimento
    {
        public static double CalcularMontante(double depositoInicial, double depositoMensal, double taxaMensal, int prazoMeses)
        {
            double saldo = depositoInicial;

            for (int mes = 1; mes <= prazoMeses; mes++)
            {
                double juros = saldo * taxaMensal;
                saldo += juros;
                saldo += depositoMensal;
            }

            return Math.Round(saldo, 2);
        }
    }
}



