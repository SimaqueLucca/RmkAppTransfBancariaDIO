using System;
using System.Collections.Generic;

namespace RmkTransBancaria
{
    class Program
    {
        static List<Conta> Contas = new List<Conta>();
        static void Main(string[] args)
        {
            string OpcaoUsuario = OpcaoSelecionada();

            while (OpcaoUsuario.ToUpper() != "X")
            {
                switch (OpcaoUsuario.ToUpper())
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Depositar();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Transferir();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                OpcaoUsuario = OpcaoSelecionada();
            }

        }
        private static void ListarContas()
        {
            int i = 0;

            if (Contas.Count != 0)
            {
                foreach (var item in Contas)
                {
                    System.Console.WriteLine($"[{i}] - {item}");
                    i++;
                }
            }
            else
            {
                System.Console.WriteLine("Sem contas cadastradas");
            }

        }

        private static void InserirConta()
        {
            System.Console.Write("Qual o tipo de conta? [1] - Pessoa Fisica  [2] - Pessoa Juridica: ");
            int tipoConta = int.Parse(Console.ReadLine());

            System.Console.Write("Nome do titular: ");
            string nome = Console.ReadLine();

            System.Console.Write("Saldo inicial: R$");
            double saldo = double.Parse(Console.ReadLine());

            System.Console.Write("Credito inicial: R$");
            double credito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)tipoConta, nome: nome, saldo: saldo, credito: credito);

            Contas.Add(novaConta);
        }

        private static void Depositar()
        {
            System.Console.Write("Informe a conta: ");
            int numeroConta = int.Parse(Console.ReadLine());

            System.Console.Write("O valor do deposito: R$");
            double valorDeposito = double.Parse(Console.ReadLine());

            Contas[numeroConta].Depositar(valorDeposito: valorDeposito);
        }

        private static void Sacar()
        {
            System.Console.Write("Informe o numero da conta: ");
            int numeroConta = int.Parse(Console.ReadLine());

            System.Console.Write("Valor do saque: R$");
            double valorSaque = double.Parse(Console.ReadLine());

            Contas[numeroConta].Sacar(valorSaque: valorSaque);
        }

        private static void Transferir()
        {
            System.Console.Write("Informe o numero da conta origem: ");
            int contaOrigem = int.Parse(Console.ReadLine());

            System.Console.Write("Informe o numero da conta destino: ");
            int contaDestino = int.Parse(Console.ReadLine());

            System.Console.Write("Valor da transferencia: R$");
            double valorTransferencia = double.Parse(Console.ReadLine());

            Contas[contaOrigem].Transferir(valorTransferencia: valorTransferencia, contaDestino: Contas[contaDestino]);
        }

        private static string OpcaoSelecionada()
        {
            System.Console.WriteLine("");
            System.Console.WriteLine("Menu de opções");

            System.Console.WriteLine("");
            System.Console.WriteLine("[1] - Listar contas");
            System.Console.WriteLine("[2] - Inserir nova conta");
            System.Console.WriteLine("[3] - Depositar");
            System.Console.WriteLine("[4] - Sacar");
            System.Console.WriteLine("[5] - Transferir");
            System.Console.WriteLine("[C] - Limpar a tela");
            System.Console.WriteLine("[X] - Sair");
            System.Console.WriteLine("");

            System.Console.Write("Digite o número da opção: ");
            string opcao = Console.ReadLine();

            System.Console.WriteLine("");

            return opcao;
        }
    }
}
