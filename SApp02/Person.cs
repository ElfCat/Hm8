using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SApp02
{
    [Serializable]
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public int Age { get; set; }

        public Person() { }

        public Person(string lastName, string firstName, string secondName, int age)
        {
            LastName = lastName;
            FirstName = firstName;
            SecondName = secondName;
            Age = age;
        } 

    }
}
