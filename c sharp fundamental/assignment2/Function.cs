namespace Assignment2
{
    public class Function
    {
        public static void ListMale(List<Member> liststudent)
        {
            Console.WriteLine("1. Member that are male in the list: ");
            IEnumerable<Member> maleStudent = liststudent.Where(s => s.gender == "Male");
            foreach (Member member in maleStudent)
            {
                Console.WriteLine(member.ToString());
            }
            Console.WriteLine("------------------------------------------");
        }
        public static void OldestMember(List<Member> liststudent)
        {
            Console.WriteLine("2. Oldest Member in the list: ");

            uint ageStudent = liststudent.Max(s => s.age);
            IEnumerable<Member> age_full_detail = liststudent.Where(s => s.age == ageStudent);

            foreach (Member member in age_full_detail)
            {
                Console.WriteLine(member.ToString());
                break;
            }

            Console.WriteLine("------------------------------------------");
        }
        public static void ListFullName(List<Member> liststudent)
        {
            Console.WriteLine("3. List of Member with fullname: ");

            foreach (Member student in liststudent)
            {
                Console.WriteLine(student.GetFullName());
            }

            Console.WriteLine("------------------------------------------");
        }
        public static void ListDateOfBirth(List<Member> liststudent)
        {
            Console.WriteLine("4. List of Member with date of birth comparison: ");
            Console.WriteLine(" a. Student who born in 2000: (press 1) \n b. Student who born less than 2000: (press 2) \n" + 
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
                            IEnumerable<Member> is2000 = liststudent.Where(s => s.dateOfBirth.Year == 2000);
                            foreach (Member member in is2000)
                            {
                                Console.WriteLine(member.ToString());
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("b. Student who born less than 2000:");
                            IEnumerable<Member> below2000 = liststudent.Where(s => s.dateOfBirth.Year < 2000);
                            foreach (Member member in below2000)
                            {
                                Console.WriteLine(member.ToString());
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("c. Student who born greater than 2000:");
                            IEnumerable<Member> above2000 = liststudent.Where(s => s.dateOfBirth.Year > 2000);
                            foreach (Member member in above2000)
                            {
                                Console.WriteLine(member.ToString());
                            }
                            break;
                        }
                    
                }
            } while (choice >= 1 && choice <= 3);

            Console.ReadKey();

            Console.WriteLine("------------------------------------------");
        }
        public static void FirstBornHaNoi(List<Member> liststudent)
        {
            Console.WriteLine("5. The first person who was born in Ha Noi: ");

            IEnumerable<Member> bornhanoi = liststudent.Where(s => s.birthPlace.ToLower() == "ha noi");
            foreach (Member member in bornhanoi)
            {
                Console.WriteLine(member.ToString());
                break;
            }

            Console.WriteLine("------------------------------------------");
        }
    }
}