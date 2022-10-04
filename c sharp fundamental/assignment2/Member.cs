namespace Assignment2
{
    public class Member
    {
        public string? FName { get; set; }

        public string? LName { get; set; }

        public string? Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string? PhoneNumber { get; set; }

        public string? BirthPlace { get; set; }

        public uint Age
        {
            get
            {
                return (uint)(DateTime.Now.Year - DateOfBirth.Year);
            }
        }

        public bool IsGraduated { get; set; }

        public string? GraduatedString
        {
            get
            {
                if (IsGraduated == true)
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
            return FName +
            ", " +
            LName +
            ", " +
            Gender +
            ", " +
            DateOfBirth +
            ", " +
            PhoneNumber +
            ", " +
            BirthPlace +
            ", " +
            Age +
            ", " +
            GraduatedString +
            ".";
        }
    }
}
