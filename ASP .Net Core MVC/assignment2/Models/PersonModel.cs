using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment2.Models
{
    public class PersonModel
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

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

        private string? _fullName;

        public string FullName
        {
            get
            {
                _fullName = FirstName + " " + LastName;
                return _fullName;
            }
        }
    }
}