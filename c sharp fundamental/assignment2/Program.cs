namespace Assignment2
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

            Console.WriteLine("Choose a number from 1 to 5 to show the list you want: \n 1. Member that are male in the list: \n 2. Oldest Member in the list: \n 3. List of Member with fullname:  " +
            "\n 4. List of Member with date of birth comparison: \n 5. The first person who was born in Ha Noi: \n 6. End the program (Press other numbers to end)."
            );

            int choice = 0;
            do
            {
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Function.ListMale(liststudent);
                            break;
                        }
                    case 2:
                        {
                            Function.OldestMember(liststudent);
                            break;
                        }
                    case 3:
                        {
                            Function.ListFullName(liststudent);
                            break;
                        }
                    case 4:
                        {
                            Function.ListDateOfBirth(liststudent);
                            break;
                        }
                    case 5:
                        {
                            Function.FirstBornHaNoi(liststudent);
                            break;
                        }
                }
            } while (choice >= 1 && choice <= 5);

            Console.ReadKey();
        }
    }
}