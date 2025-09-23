using System;

class InvestimentoFinanceiro
{
    static void Main()
    {
       
        double taxaSelicAA = 0.1075;     // 10,75%
        double taxaIPCAAA = 0.045;       // 4,5%
        double taxaCDBAA = 0.12;         // 12% (aprox. 110% CDI)
        double taxaPoupMes = 0.0056;     // 0,56% ao mês (estimado com Selic atual)

        Console.WriteLine("=== Simulador de Investimentos ===");


        double depositoInicial;
        while (true)
        {
            Console.Write("Informe o valor inicial: R$ ");
            if (double.TryParse(Console.ReadLine(), out depositoInicial) && depositoInicial >= 0)
                break;
            Console.WriteLine(" Valor inválido! Digite um número maior ou igual a 0.");
        }

        double depositoMensal;
        while (true)
        {
            Console.Write("Informe o valor do depósito mensal: R$ ");
            if (double.TryParse(Console.ReadLine(), out depositoMensal) && depositoMensal >= 0)
                break;
            Console.WriteLine(" Valor inválido! Digite um número maior ou igual a 0.");
        }

        int unidade;
        while (true)
        {
            Console.WriteLine("Deseja informar o prazo em:\n1 - Anos\n2 - Meses");
            if (int.TryParse(Console.ReadLine(), out unidade) && (unidade == 1 || unidade == 2))
                break;
            Console.WriteLine(" Opção inválida! Digite 1 para anos ou 2 para meses.");
        }

        int prazo;
        while (true)
        {
            Console.Write("Informe o prazo: ");
            if (int.TryParse(Console.ReadLine(), out prazo) && prazo > 0)
                break;
            Console.WriteLine("⚠ Prazo inválido! Digite um número inteiro positivo.");
        }

        
        if (unidade == 1) prazo *= 12;

        
        int opcao;
        while (true)
        {
            Console.WriteLine("\nEscolha o tipo de investimento:");
            Console.WriteLine("1 - Tesouro Selic");
            Console.WriteLine("2 - Tesouro IPCA");
            Console.WriteLine("3 - CDB");
            Console.WriteLine("4 - Poupança");

            if (int.TryParse(Console.ReadLine(), out opcao) && (opcao >= 1 && opcao <= 4))
                break;
            Console.WriteLine("⚠ Opção inválida! Escolha entre 1 e 4.");
        }

        
        double taxaMensal;
        switch (opcao)
        {
            case 1:
                taxaMensal = Math.Pow(1 + taxaSelicAA, 1.0 / 12) - 1;
                break;
            case 2:
                taxaMensal = Math.Pow(1 + taxaIPCAAA, 1.0 / 12) - 1;
                break;
            case 3:
                taxaMensal = Math.Pow(1 + taxaCDBAA, 1.0 / 12) - 1;
                break;
            case 4:
                taxaMensal = taxaPoupMes;
                break;
            default:
                Console.WriteLine("Opção inválida!");
                return;
        }


        double saldo = depositoInicial;
        int pontoVirada = -1; 

        Console.WriteLine("\nMês\tDepósito\tJuros\t\tSaldo");
        Console.WriteLine("----------------------------------------------------");

        for (int mes = 1; mes <= prazo; mes++)
        {
            double juros = saldo * taxaMensal; 
            saldo += juros + depositoMensal;

            Console.WriteLine($"{mes}\t{depositoMensal:F2}\t\t{juros:F2}\t\t{saldo:F2}");


         if (pontoVirada == -1 && juros >= depositoMensal)
                pontoVirada = mes;
        }

        
        Console.WriteLine("\n====================================");
        Console.WriteLine($"Valor final acumulado: R$ {saldo:F2}");

        if (pontoVirada != -1)
        {
            int anos = pontoVirada / 12;
            int meses = pontoVirada % 12;
            Console.WriteLine($"A partir do mês {pontoVirada} (aprox. {anos} ano(s) e {meses} mês(es)), os juros superam o depósito mensal.");
        }
        else
        {
            Console.WriteLine("Os juros não superaram o depósito mensal no prazo informado.");
        }

        
        Console.WriteLine("\nDeseja simular um saque antecipado? (s/n)");
        string resposta = Console.ReadLine().ToLower();

        if (resposta == "s")
        {
            int mesSaque;
            while (true)
            {
                Console.Write("Informe o mês do saque (entre 1 e " + prazo + "): ");
                if (int.TryParse(Console.ReadLine(), out mesSaque) && mesSaque > 0 && mesSaque <= prazo)
                    break;
                Console.WriteLine(" Mês inválido! Digite um número dentro do prazo.");
            }

            double saldoSaque = depositoInicial;
            for (int mes = 1; mes <= mesSaque; mes++)
            {
                double juros = saldoSaque * taxaMensal;
                saldoSaque += juros + depositoMensal;
            }

            Console.WriteLine($"\nSe você sacar no mês {mesSaque}, terá acumulado: R$ {saldoSaque:F2}");
        }
        Console.WriteLine("====================================");
        Console.WriteLine("Pressione qualquer tecla para sair...");
        Console.ReadKey();
    }
}
