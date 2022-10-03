namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Member> liststudent = new List<Member>() //Create new list of student
            {
                new Member(){fname = "Vinh", lname = "Nguyen", gender = "Male", date_of_birth = new DateTime(2002, 3, 13), phone_number = "0964083300", birth_place = "Ha Noi", is_graduated = false},
                new Member(){fname = "Duc", lname = "Bui", gender = "Female", date_of_birth = new DateTime(2002, 9, 30), phone_number = "0985483300", birth_place = "ha noi", is_graduated = false},
                new Member(){fname = "Ngai", lname = "Nguyen", gender = "Male", date_of_birth = new DateTime(1999, 5, 30), phone_number = "0875463300", birth_place = "Thai Binh", is_graduated = true},
                new Member(){fname = "Chuoi", lname = "Le", gender = "Female", date_of_birth = new DateTime(2001, 4, 24), phone_number = "0185683001", birth_place = "Quang Ngai", is_graduated = true},
                new Member(){fname = "Than", lname = "Dang", gender = "Female", date_of_birth = new DateTime(2000, 10, 10), phone_number = "0285483780", birth_place = "Thai Nguyen", is_graduated = true}
            };
            Function.ListMale(liststudent);
            Function.OldestMember(liststudent);
            Function.ListFullName(liststudent);
            Function.ListDateOfBirth(liststudent);
            Function.FirstBornHaNoi(liststudent);
        }
    }
}
