namespace assignment1
{
    public class Member
    {
        public string? fname { get; set; } //First Name
        public string? lname { get; set; } //Last Name
        public string? gender { get; set; } //Gender
        public DateTime date_of_birth { get; set; } //= new DateTime(2022, 9, 30); //date of birth
        public string? phone_number { get; set; } //phone number
        public string? birth_place { get; set; }// birth place
        public uint age
        {
            get
            {
                return (uint)(DateTime.Now.Year - date_of_birth.Year);
            }
        } //age
        public bool is_graduated { get; set; }// is graduated or not, true/false
        public string? graduated_string //print out is graduated or is not graduated
        {
            get
            {
                if (is_graduated == true)
                {
                    return "Is Graduated";
                }
                else
                {
                    return "Is Not Graduated";
                }
            }
        }

        public override string ToString()
        {
            return fname + ", " + lname + ", " + gender + ", " + date_of_birth + ", " + phone_number + ", " + birth_place + ", " + age + ", " + graduated_string + ".";
        }
        public string GetFullName()
        {
            return fname + " " + lname + ", " + gender + ", " + date_of_birth + ", " + phone_number + ", " + birth_place + ", " + age + ", " + graduated_string + ".";
        }
    }
}