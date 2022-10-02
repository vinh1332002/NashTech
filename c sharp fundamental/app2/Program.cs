using System;
using System.Collections.Generic;

namespace assignment1 {
    class Program {
        public class Students {
            public string? fname {get; set;} //First Name
            public string? lname {get ; set;} //Last Name
            public string? gender {get ; set;} //Gender
            public DateTime date_of_birth {get ; set;} //= new DateTime(2022, 9, 30); //date of birth
            public string? phone_number {get ; set;} //phone number
            public string? birth_place {get ; set;}// birth place
            public uint age {get ; set;} //age
            public bool is_graduated {get ; set;}// is graduated or not

            public override string ToString()
            {
                return fname + ", " + lname + ", " + gender + ", " + date_of_birth + ", " + phone_number + ", " + birth_place + ", " + age + ", " + is_graduated + ".";
            }
            public string GetFullName() {
                return fname +" " + lname + ", " + gender + ", " + date_of_birth + ", " + phone_number + ", " + birth_place + ", " + age + ", " + is_graduated + ".";

            }
            

        }
        
        static void Main(string[] args) {
            List<Students> liststudent = new List<Students>() //Create new list of student
            {
                new Students(){fname = "Vinh", lname = "Nguyen", gender = "Male", date_of_birth = new DateTime(2002, 3, 13), phone_number = "0964083300", birth_place = "Ha Noi", age = 20, is_graduated = false},
                new Students(){fname = "Duc", lname = "Bui", gender = "Female", date_of_birth = new DateTime(2002, 9, 30), phone_number = "0985483300", birth_place = "Ha Noi", age = 20, is_graduated = false},
                new Students(){fname = "Ngai", lname = "Nguyen", gender = "Male", date_of_birth = new DateTime(1999, 5, 30), phone_number = "0875463300", birth_place = "Thai Binh", age = 23, is_graduated = true},
                new Students(){fname = "Chuoi", lname = "Le", gender = "Female", date_of_birth = new DateTime(2001, 4, 24), phone_number = "0185683001", birth_place = "Quang Ngai", age = 21, is_graduated = true},
                new Students(){fname = "Than", lname = "Dang", gender = "Female", date_of_birth = new DateTime(2000, 10, 10), phone_number = "0285483780", birth_place = "Thai Nguyen", age = 21, is_graduated = true}
            };

            Console.WriteLine("1. Students that are male in the list: ");
            foreach (Students people in liststudent) {
                if (people.gender == "Male"){
                    Console.WriteLine(people.ToString());
                }
            }
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("2. Oldest students in the list: ");
            
            uint maxVal = uint.MinValue;
            foreach (Students people in liststudent) 
            {
                if (people.age > maxVal) 
                {
                    maxVal = people.age;
                }
            }
            foreach (Students people in liststudent) {
                if (people.age == maxVal){
                    Console.WriteLine(people.ToString());
                    break;
                }
            }

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("3. List of students with fullname: ");
            foreach (Students people in liststudent) {
                Console.WriteLine(people.GetFullName());
            }

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("4. List of students with date of birth comparison: ");

            foreach (Students people in liststudent) {
                switch(people.date_of_birth.Year)
                {
                    case 2000:
                        Console.WriteLine(people.ToString() + " -> this person was born in the year 2000.");
                        break;
                    case <2000:
                        Console.WriteLine(people.ToString() + " -> this person was born before 2000.");
                        break;
                    case >2000:
                        Console.WriteLine(people.ToString() + " -> this person was born after 2000.");
                        break;
                }            
            }
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("5. The first person who was born in Ha Noi: "); 
            //used if to find the first person born in Ha Noi

            //foreach (Students people in liststudent) {
            //    if (people.birth_place == "Ha Noi") {
            //        Console.WriteLine(people.ToString());
            //        break;
            //    }                
            //}
            
            int bornHaNoi = 0;
            while (liststudent[bornHaNoi].birth_place != "Ha Noi") {
                bornHaNoi++;
            }
            Console.WriteLine(liststudent[bornHaNoi].ToString());
            // thanks Nguyen Tien for helping me with this while method
            

            Console.WriteLine("------------------------------------------");

            
            

            



            

        }
    }
}

