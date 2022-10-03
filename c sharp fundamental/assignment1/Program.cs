namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Member> liststudent = new List<Member>() //Create new list of student
            {
                new Member(){fName = "Vinh", lName = "Nguyen", gender = "Male", dateOfBirth = new DateTime(2002, 3, 13), phoneNumber = "0964083300", birthPlace = "Ha Noi", isGraduated = false},
                new Member(){fName = "Duc", lName = "Bui", gender = "Female", dateOfBirth = new DateTime(2002, 9, 30), phoneNumber = "0985483300", birthPlace = "ha noi", isGraduated = false},
                new Member(){fName = "Ngai", lName = "Nguyen", gender = "Male", dateOfBirth = new DateTime(1999, 5, 30), phoneNumber = "0875463300", birthPlace = "Thai Binh", isGraduated = true},
                new Member(){fName = "Chuoi", lName = "Le", gender = "Female", dateOfBirth = new DateTime(2001, 4, 24), phoneNumber = "0185683001", birthPlace = "Quang Ngai", isGraduated = true},
                new Member(){fName = "Than", lName = "Dang", gender = "Female", dateOfBirth = new DateTime(2000, 10, 10), phoneNumber = "0285483780", birthPlace = "Thai Nguyen", isGraduated = true}
            };
            Function.ListMale(liststudent);
            Function.OldestMember(liststudent);
            Function.ListFullName(liststudent);
            Function.ListDateOfBirth(liststudent);
            Function.FirstBornHaNoi(liststudent);
        }
    }
}
