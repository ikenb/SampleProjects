namespace MementoDesignPattern.BasicMemento.FoodExample
{
    /// <summary>
    /// This is the originator  
    /// </summary>
    public class FoodSupplier
    {
        #region Fields
        private string _name;
        private string _phone;
        private string _address;

        #endregion


        #region Properties
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }


        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }


        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        #endregion


        #region Methods
        public Mememto SaveMemento()
        {
            return new Mememto(_name, _phone, _address);
        }

        public void RestoreMemento(Mememto mememto)
        {
            Name = mememto.Name;
            Phone = mememto.PhoneNumber;
            Address = mememto.Address;
        }
        #endregion

    }
}



