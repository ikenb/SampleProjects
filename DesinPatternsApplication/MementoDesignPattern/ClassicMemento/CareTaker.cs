using System;
using System.Collections.Generic;
using System.Text;

namespace MementoDesignPattern.ClassicMemento
{
    public class CareTaker
    {
        private List<Memento> mementos = new List<Memento>();

        public void Add(Memento state)
        {
            mementos.Add(state);
        }

        public Memento GetState(int index)
        {
            return mementos.Find(i => i.Equals(index));
        }
    }
}
