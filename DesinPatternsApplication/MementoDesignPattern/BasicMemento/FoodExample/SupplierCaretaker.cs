namespace MementoDesignPattern.BasicMemento.FoodExample
{
    public class SupplierCaretaker
    {
        private Mememto _memento;

        public Mememto Memento
        {
            get { return _memento; }
            set { _memento = value; }
        }

    }
}
