﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankaccounts
{

    // Student name Ramandeep kaur kainth  C0723796
    //Student name Ashpreet singh   C0730263
    // CSD3354 section 2
    // Assigment 3
    // March 13, 2019

    public class BankAccount

    {

        public const string DebitamountExceedsBalanceMessage = "Debit amount exceeds balance";
        public const string DebitamountLessThanZeroMessage = "Debit amount is less than zero";
        private string m_customerName;
        private double m_balance;
        private bool m_frozen = false;
        private BankAccount()
        {

        }

        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;

        }
        public string CustomerName
        {
            get { return m_customerName; }
        }
        public double Balance
        {
            get { return m_balance; }
        }


        public void Debit(double amount)
        {
            if (m_frozen)
            {
                throw new Exception("Account frozen");
            }
            if (amount > m_balance)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitamountExceedsBalanceMessage);
            }
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, DebitamountLessThanZeroMessage);
            }
            m_balance -= amount;


        }

        public void Credit(double amount)
        {
            if (m_frozen)
            {
                throw new Exception("frozen");
            }
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }
            m_balance += amount;
        }
        private void FreezeAccount()
        {
            m_frozen = true;

        }
        private void UnfreezeAccount()
        {
            m_frozen = false;
        }

        static void Main(string[] args)
        {

            BankAccount ba = new BankAccount("Mr. Bryan Walton", 11.99);
            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine("Current balance is ${0}", ba.Balance);


        }

    }
}