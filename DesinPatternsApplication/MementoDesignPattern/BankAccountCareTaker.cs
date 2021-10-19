using System;
using System.Collections.Generic;
using System.Text;

namespace MementoDesignPattern
{
    public class BankAccountCareTaker
    {
        private int _balance;

        private List<Memento> changes = new List<Memento>();
        private int currentState;

        public BankAccountCareTaker(int balance)
        {
            _balance = balance;
            changes.Add(new Memento(balance));
        }

        public Memento Deposit(int amount)
        {
            _balance += amount;

            var memento = new Memento(_balance);
            changes.Add(memento);

            ++currentState;

            return memento;
        }

        public void Restore(Memento memento)
        {
            if(memento != null)
            {
                _balance = memento.Balance;
                changes.Add(memento);

                currentState = changes.Count - 1;
            }
        }

        public Memento Undo()
        {
           if(currentState > 0)
            {
                var memento = changes[--currentState];
                _balance = memento.Balance;

                return memento;
            }

            return null;
        }

        public Memento Redo()
        {
            if(currentState + 1 < changes.Count)
            {
                var memento = changes[++currentState];
                _balance = memento.Balance;

                return memento;
            }

            return null;
        }

        public override string ToString()
        {
            return $"{nameof(_balance)}: {_balance}";
        }

    }
}
