namespace Assignment1
{
    public class Function
    {
        public static void ListMale(List<Member> liststudent)
        {
            Console.WriteLine("1. Member that are male in the list: ");
            foreach (Member student in liststudent)
            {
                if (student.gender == "Male")
                {
                    Console.WriteLine(student.ToString());
                }
            }
            Console.WriteLine("------------------------------------------");
        }
        public static void OldestMember(List<Member> liststudent)
        {
            Console.WriteLine("2. Oldest Member in the list: ");

            uint maxValue = uint.MinValue;

            foreach (Member student in liststudent)
            {
                if (student.age > maxValue)
                {
                    maxValue = student.age;
                }
            }
            foreach (Member student in liststudent)
            {
                if (student.age == maxValue)
                {
                    Console.WriteLine(student.ToString());
                    break;
                }
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

            foreach (Member student in liststudent)
            {
                switch (student.dateOfBirth.Year)
                {
                    case 2000:
                        Console.WriteLine(student.ToString() + " -> this person was born in the year 2000.");
                        break;
                    case < 2000:
                        Console.WriteLine(student.ToString() + " -> this person was born before 2000.");
                        break;
                    case > 2000:
                        Console.WriteLine(student.ToString() + " -> this person was born after 2000.");
                        break;
                }
            }

            Console.WriteLine("------------------------------------------");
        }
        public static void FirstBornHaNoi(List<Member> liststudent)
        {
            Console.WriteLine("5. The first person who was born in Ha Noi: ");

            int bornHaNoi = 0;

            while (liststudent[bornHaNoi].birthPlace.ToLower() != "ha noi")
            {
                bornHaNoi++;
            }
            Console.WriteLine(liststudent[bornHaNoi].ToString());

            Console.WriteLine("------------------------------------------");
        }
    }
}
