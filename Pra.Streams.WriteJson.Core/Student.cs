using System;

namespace Pra.Streams.WriteJson.Core
{
    public class Student
    {
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string City { get; set; }

        public Student(string lastname, string firstname, string city)
        {
            Lastname = lastname;
            Firstname = firstname;
            City = city;
        }
        public override string ToString()
        {
            return $"{Lastname} {Firstname}";
        }
    }
}
