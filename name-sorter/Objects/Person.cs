using System.Linq;

namespace name_sorter.Objects
{
    public class Person
    {
        public string GivenName1 { get; set; }
        public string GivenName2 { get; set; }
        public string GivenName3 { get; set; }
        public string LastName { get; set; }

        public Person(string givenName1, string givenName2, string givenName3, string lastName)
        {
            GivenName1 = givenName1;
            GivenName2 = givenName2;
            GivenName3 = givenName3;
            LastName = lastName;
        }

        /// <summary>
        /// Outputs the persons full name in a readable format.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string[] names = new string[4] { GivenName1, GivenName2, GivenName3, LastName };
            string fullName = string.Join(" ", names.Where(s => !string.IsNullOrEmpty(s)));

            return fullName;
        }
    }
}
