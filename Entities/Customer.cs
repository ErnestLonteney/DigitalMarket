namespace DigitalMarket.Entities
{
    public class Customer : Person
    {
        public Customer(string firstName, string lastName)
        {
            LastName = lastName;
            FirstName = firstName;
        }

        protected Customer()
        {

        }

        public byte DiscountProcent { get; set; }

        public CustomerRating Rating { get; set; }

        public List<Order> Orders { get; set; } = [];
    }
}
