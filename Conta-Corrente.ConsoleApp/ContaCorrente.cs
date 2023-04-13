using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conta_Corrente.ConsoleApp
{
    internal class ContaCorrente
    {
        public decimal saldo = 0, numero = 12, limite = 0;
        public bool ehEspecial = true;
        public ArrayList movimentacaoSaque = new ArrayList();
        public ArrayList movimentacaoDeposito = new ArrayList();
        public ArrayList movimentacaoTransferencia = new ArrayList();

        public void MostrarExtrato()
        {
            
            Console.WriteLine(" --      Banco      -- ");
            Console.WriteLine($" -- NÚMERO DA CONTA: {numero} ");
            Console.WriteLine($" -- LIMITE DO CARTÃO: {limite} ");
            Console.WriteLine($" -- SALDO ATUAL: {saldo} ");
            if (ehEspecial == true)
            {
                Console.WriteLine($" Sua conta é tanto de crédito quanto débito. ");
            }
            else
            {
                Console.WriteLine($" Sua conta tem somente a funcionalidade débito. ");
            }
         

            for (int i = 0; i < movimentacaoSaque.Count; i++)
            {
                Console.WriteLine($"{movimentacaoSaque[i]}");
            }
            for (int i = 0; i < movimentacaoDeposito.Count; i++)
            {
                Console.WriteLine($"{movimentacaoDeposito[i]}");
            }
            for (int i = 0; i < movimentacaoTransferencia.Count; i++)
            {
                Console.WriteLine($"{movimentacaoTransferencia[i]}");
            }

        }
        public decimal Sacar(decimal valorSaque)
        {
            if (valorSaque <= saldo)
            {
                saldo -= valorSaque;
                movimentacaoSaque.Add($"Saque de {valorSaque} ");
            }
            else
            {
                Console.WriteLine("O valor de saque ultrapassa o valor disponível na conta!");
            }

            return saldo;
        }

        public decimal Depositar(decimal valorDeposito)
        {
            saldo += valorDeposito;
            movimentacaoDeposito.Add($"Depósito de {valorDeposito}");
            return saldo;
        }

        public decimal Transferir(ContaCorrente conta, decimal valorTransferido)
        {
            if (valorTransferido <= saldo)
            {
                saldo -= valorTransferido;
                conta.Depositar(valorTransferido);
                movimentacaoTransferencia.Add($"Transferência de {valorTransferido}");
            }
            else
            {
                Console.WriteLine("O valor de saque ultrapassa o valor disponível na conta!");
            }
            return conta.saldo;
    }   }
}
