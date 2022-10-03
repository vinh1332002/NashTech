namespace Assignment1
{
    public class Member
    {
        public string? fName { get; set; } //First Name
        public string? lName { get; set; } //Last Name
        public string? gender { get; set; } //Gender
        public DateTime dateOfBirth { get; set; } //= new DateTime(2022, 9, 30); //date of birth
        public string? phoneNumber { get; set; } //phone number
        public string? birthPlace { get; set; }// birth place
        public uint age
        {
            get
            {
                return (uint)(DateTime.Now.Year - dateOfBirth.Year);
            }
        } //age
        public bool isGraduated { get; set; }// is graduated or not, true/false
        public string? graduatedString //print out is graduated or is not graduated
        {
            get
            {
                if (isGraduated == true)
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
            return fName + ", " + lName + ", " + gender + ", " + dateOfBirth + ", " + phoneNumber + ", " + birthPlace + ", " + age + ", " + graduatedString + ".";
        }
        public string GetFullName()
        {
            return fName + " " + lName + ", " + gender + ", " + dateOfBirth + ", " + phoneNumber + ", " + birthPlace + ", " + age + ", " + graduatedString + ".";
        }
    }
}
