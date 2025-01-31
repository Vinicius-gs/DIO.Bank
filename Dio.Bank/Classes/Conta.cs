﻿using System;
using Dio.Bank.Enum;

namespace Dio.Bank.Classes
{
    public class Conta
    {

        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            if (this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo Insuficiente!");
                return false;
            }
            this.Saldo -= valorSaque;
            Console.WriteLine("Conta {0} Saldo atual {1}", this.Nome, this.Saldo);
            return true;
        }


        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine("Conta {0} Saldo atual {1}", this.Nome, this.Saldo);

        }

        public void Transferir(double valorTranferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTranferencia))
            {
                contaDestino.Depositar(valorTranferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta" + this.TipoConta + "|";
            retorno += "Nome" + this.Nome + "|";
            retorno += "Credito" + this.Credito + "|";
            retorno += "Saldo" + this.Saldo + "|";
            return retorno;
        }

    }

}
