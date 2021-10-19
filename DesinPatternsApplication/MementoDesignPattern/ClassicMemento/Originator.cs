using System;
using System.Collections.Generic;
using System.Text;

namespace MementoDesignPattern.ClassicMemento
{
    public class Originator
    {
        private string _state;

        public void SetSate(string state)
        {
            _state = state;
        }
        public string GetState()
        {
            return _state;

        }

        public Memento SaveStateToMemento()
        {
            return new Memento(_state);
        }

        public void GetStateFromMemento(Memento memento)
        {
            _state = memento.GetState();
        }
    }
}
