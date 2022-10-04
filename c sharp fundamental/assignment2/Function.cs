namespace Assignment2
{
    public class Function
    {
        public static void GetListMale(List<Member> listStudent)
        {
            Console.WriteLine("1. Member that are male in the list: ");
            IEnumerable<Member> maleStudent =
                listStudent.Where(s => s.Gender == "Male");
            foreach (Member member in maleStudent)
            {
                Console.WriteLine(member.ToString());
            }
            Console.WriteLine("------------------------------------------");
        }

        public static void GetOldestMember(List<Member> listStudent)
        {
            Console.WriteLine("2. Oldest Member in the list: ");

            uint ageStudent = listStudent.Max(s => s.Age);
            IEnumerable<Member> ageFullDetail =
                listStudent.Where(s => s.Age == ageStudent);

            foreach (Member member in ageFullDetail)
            {
                Console.WriteLine(member.ToString());
                break;
            }

            Console.WriteLine("------------------------------------------");
        }

        public static void GetListFullName(List<Member> listStudent)
        {
            Console.WriteLine("3. List of Member with fullname: ");
            var listFullName =
                from member in listStudent
                select member.FName + " " + member.LName;

            foreach (var member in listFullName)
            {
                Console.WriteLine (member);
            }

            Console.WriteLine("------------------------------------------");
        }

        public static void GetListDateOfBirth(List<Member> listStudent)
        {
            Console
                .WriteLine("4. List of Member with date of birth comparison: ");
            Console
                .WriteLine(" a. Student who born in 2000: (press 1) \n b. Student who born less than 2000: (press 2) \n" +
                " c. Student who born greater than 2000: (press 3) \n d. End the program (Press other numbers)");
            int choice = 0;
            do
            {
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("a. Student who born in 2000:");

                            var is2000 =
                                from member in listStudent
                                where member.DateOfBirth.Year == 2000
                                select member;

                            foreach (var member in is2000)
                            {
                                Console.WriteLine(member.ToString());
                            }
                            break;
                        }
                    case 2:
                        {
                            Console
                                .WriteLine("b. Student who born less than 2000:");
                            IEnumerable<Member> below2000 =
                                listStudent
                                    .Where(s => s.DateOfBirth.Year < 2000);
                            foreach (Member member in below2000)
                            {
                                Console.WriteLine(member.ToString());
                            }
                            break;
                        }
                    case 3:
                        {
                            Console
                                .WriteLine("c. Student who born greater than 2000:");
                            IEnumerable<Member> above2000 =
                                listStudent
                                    .Where(s => s.DateOfBirth.Year > 2000);
                            foreach (Member member in above2000)
                            {
                                Console.WriteLine(member.ToString());
                            }
                            break;
                        }
                }
            }
            while (choice >= 1 && choice <= 3);

            Console.ReadKey();

            Console.WriteLine("------------------------------------------");
        }

        public static void GetFirstBornHaNoi(List<Member> listStudent)
        {
            Console.WriteLine("5. The first person who was born in Ha Noi: ");

            var bornHaNoi =
                (
                from member in listStudent
                where member.BirthPlace.ToLower() == "ha noi" select member
                ).FirstOrDefault();

            if (bornHaNoi != null)
            {
                Console.WriteLine(bornHaNoi.ToString());
            }
            Console.WriteLine("------------------------------------------");
        }
    }
}
