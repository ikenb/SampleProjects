using System;
using System.Collections.Generic;
using System.Text;

namespace MementoDesignPattern
{
    public class Memento//TaxState
    {
        public int Balance { get; }

        public Memento(int balance)
        {
            Balance = balance;
        }
    }
}
