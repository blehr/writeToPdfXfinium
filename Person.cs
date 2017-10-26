namespace xfinium
{
    public class Person
    {
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Person(string firstName, string lastName, string dateOfBirth, string gender, string phoneNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
            this.PhoneNumber = phoneNumber;
        }

    }
}