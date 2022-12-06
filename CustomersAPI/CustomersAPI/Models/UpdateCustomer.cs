namespace CustomersAPI.Models
{
    public class UpdateCustomer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string DateOfBirth { get; set; }
        public int Age { get; set; }
        public DateTime DateEdited { get; set; }

    }
}
