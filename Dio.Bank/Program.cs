using System;
using System.Collections.Generic;
using Dio.Bank.Classes;
using Dio.Bank.Enum;

namespace Dio.Bank
{
    class Program
    {
        static List<Conta> listarContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarConta();
                        break;

                    case "2":
                        InserirConta();
                        break;

                    case "3":
                        Trasferir();
                        break;
                    case "4":
                        SacarConta();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços");
            Console.WriteLine();
        }

        private static void ListarConta()
        {
            Console.WriteLine("Listar contas");

            if (listarContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }

            for (int i = 0; i < listarContas.Count; i++)
            {
                Conta conta = listarContas[i];
                Console.WriteLine("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }
        private static void InserirConta()
        {
            Console.WriteLine("Inserir uma nova conta");

            Console.WriteLine("Digite 1 para Pessoa Física | Digite 2 para Pessoa Juridica");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o saldo");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o credito");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, saldo: entradaSaldo, credito: entradaCredito, nome: entradaNome);

            listarContas.Add(novaConta);

        }

        private static void SacarConta()
        {
            Console.WriteLine("Digite o numero da conta");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a ser saquado");
            double valorSaquado = double.Parse(Console.ReadLine());

            listarContas[indiceConta].Sacar(valorSaquado);

        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o numero da conta");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a ser depositado");
            double valorDepositado = double.Parse(Console.ReadLine());

            listarContas[indiceConta].Depositar(valorDepositado);

        }

        private static void Trasferir()
        {
            Console.WriteLine("Digite o número da conta de origem");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da conta de destino");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a ser transferido");
            double valorTranferido = double.Parse(Console.ReadLine());

            listarContas[indiceContaOrigem].Transferir(valorTranferido, listarContas[indiceContaDestino]);

        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bem Vindo ao DIO Bank");
            Console.WriteLine("Informe a opção desejada");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inseri nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}