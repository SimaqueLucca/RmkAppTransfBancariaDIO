using System;

namespace RmkTransBancaria
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private string Nome { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }

        public Conta(TipoConta tipoConta, string nome, double saldo, double credito)
        {
            this.TipoConta = tipoConta;
            this.Nome = nome;
            this.Saldo = saldo;
            this.Credito = credito;
        }

        public bool Sacar(double valorSaque)
        {
            if (this.Saldo - valorSaque < (this.Credito * -1))
            {
                System.Console.WriteLine("Saldo insuficiente");
                System.Console.WriteLine("");
                return false;
            }

            this.Saldo -= valorSaque;
            System.Console.WriteLine($"{this.Nome}, o saldo atual da conta é de R${this.Saldo}");
            System.Console.WriteLine("");
            return true;
        }
        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            System.Console.WriteLine($"{this.Nome}, o saldo atual da conta é de: {this.Saldo}");
            System.Console.WriteLine("");
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string detalhesConta = $"Tipo da conta: {this.TipoConta} | ";
            detalhesConta += $"Nome do titular: {this.Nome} | ";
            detalhesConta += $"Saldo: {this.Saldo} | ";
            detalhesConta += $"Credito: {this.Credito}";

            return detalhesConta;
        }
    }
}