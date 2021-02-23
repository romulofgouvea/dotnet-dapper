namespace dapper.Domain.ValueObjects
{
    public class Email
    {
        public string Address { get; private set; }

        public Email(string address)
        {
            Address = address;
        }

        public override string ToString()
        {
            return Address;
        }
    }
}