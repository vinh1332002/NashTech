namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Member> listStudent =
                new List<Member>()
                {
                    new Member()
                    {
                        FName = "Vinh",
                        LName = "Nguyen",
                        Gender = "Male",
                        DateOfBirth = new DateTime(2002, 3, 13),
                        PhoneNumber = "0964083300",
                        BirthPlace = "Ha Noi",
                        IsGraduated = false
                    },
                    new Member()
                    {
                        FName = "Duc",
                        LName = "Bui",
                        Gender = "Female",
                        DateOfBirth = new DateTime(2002, 9, 30),
                        PhoneNumber = "0985483300",
                        BirthPlace = "ha noi",
                        IsGraduated = false
                    },
                    new Member()
                    {
                        FName = "Ngai",
                        LName = "Nguyen",
                        Gender = "Male",
                        DateOfBirth = new DateTime(1999, 5, 30),
                        PhoneNumber = "0875463300",
                        BirthPlace = "Thai Binh",
                        IsGraduated = true
                    },
                    new Member()
                    {
                        FName = "Chuoi",
                        LName = "Le",
                        Gender = "Female",
                        DateOfBirth = new DateTime(2001, 4, 24),
                        PhoneNumber = "0185683001",
                        BirthPlace = "Quang Ngai",
                        IsGraduated = true
                    },
                    new Member()
                    {
                        FName = "Than",
                        LName = "Dang",
                        Gender = "Female",
                        DateOfBirth = new DateTime(2000, 10, 10),
                        PhoneNumber = "0285483780",
                        BirthPlace = "Thai Nguyen",
                        IsGraduated = true
                    }
                };

            Console
                .WriteLine("Choose a number from 1 to 5 to show the list you want: \n 1. Member that are male in the list: \n 2. Oldest Member in the list: \n 3. List of Member with fulLName:  " +
                "\n 4. List of Member with date of birth comparison: \n 5. The first person who was born in Ha Noi: \n 6. End the program (Press other numbers to end).");

            int choice = 0;
            do
            {
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Function.GetListMale (listStudent);
                            break;
                        }
                    case 2:
                        {
                            Function.GetOldestMember (listStudent);
                            break;
                        }
                    case 3:
                        {
                            Function.GetListFullName (listStudent);
                            break;
                        }
                    case 4:
                        {
                            Function.GetListDateOfBirth (listStudent);
                            break;
                        }
                    case 5:
                        {
                            Function.GetFirstBornHaNoi (listStudent);
                            break;
                        }
                }
            }
            while (choice >= 1 && choice <= 5);

            Console.ReadKey();
        }
    }
}
