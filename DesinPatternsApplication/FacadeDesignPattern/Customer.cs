namespace FacadeDesignPattern
{

    public class Customer
    {
        private string  _name;

        public string  Name
        {
            get { return _name; }

        }

        public Customer(string name)
        {
            _name = name;
        }
    }
}
