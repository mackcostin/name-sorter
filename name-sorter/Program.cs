using name_sorter.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace name_sorter
{
    public class Program
    {
        public static string FilePath { get; set; }

        static void Main(string[] args)
        {
            Console.WriteLine(args[0]);
            List<Person> sortedPeople = new List<Person>();
            List<string> fileLines = ReadFile(args[0]);

            if (fileLines != null)
            {
                sortedPeople = CreateSortedList(fileLines);
            }

            if (sortedPeople != null)
            {
                CreateTextFile(sortedPeople, args[0]);
            }
        }

        /// <summary>
        /// Attempts to read a file from the provided path.
        /// </summary>
        /// <returns></returns>
        public static List<string> ReadFile(string path)
        {
            List<string> lines = null;

            try
            {
                lines = File.ReadLines(path).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if (lines != null)
            {
                Console.WriteLine("Successfully found file!");
                Console.WriteLine("-----------------------------");
            }
            return lines;
        } 

        /// <summary>
        /// Reads from a provided list of strings and sorts them into a list.
        /// </summary>
        /// <param name="lines"></param>
        /// <returns>A list of People sorted by name.</returns>
        public static List<Person> CreateSortedList(List<string> lines)
        {
            List<Person> unsortedPeople = new List<Person>();

            Console.WriteLine("Sorting names....");
            Console.WriteLine("-----------------------------");

            foreach (var line in lines)
            {
                string[] splitName = new string[4];
                splitName = SplitNameToArray(line);

                unsortedPeople.Add(new Person(splitName[0], splitName[1], splitName[2], splitName[3]));
            }

            List<Person> sortedPeople = unsortedPeople.OrderBy(o => o.LastName).ThenBy(o => o.GivenName3).ThenBy(o => o.GivenName2).ThenBy(o => o.GivenName1).ToList();

            sortedPeople.ForEach(Console.WriteLine);

            return sortedPeople;
        }


        /// <summary>
        /// Writes a list of people to a text file in the specified path.
        /// </summary>
        /// <param name="people"></param>
        /// <param name="path"></param>
        /// <returns>Returns True when file has been created.</returns>
        public static bool CreateTextFile(List<Person> people, string path)
        {
            bool fileCreated = false;

            string newFilePath = Path.GetDirectoryName(path) + "/sorted-names-list.txt";

            using (TextWriter tw = new StreamWriter(newFilePath))
            {
                foreach (Person p in people)
                {
                    tw.WriteLine(p);
                }
                tw.Close();
            }

            Console.WriteLine("-----------------------------");
            Console.WriteLine("Sorted names to the following text file: " + newFilePath);

            if(File.Exists(newFilePath)) 
            {
                fileCreated = true;
            }
            return fileCreated;
        }

        /// <summary>
        /// Returns the provided name as an Array of words. Name can have up to 
        /// four words and will be placed into a relevant position in the array.
        /// </summary>
        /// <param name="name">Hunter Uriah Mathew Clarke</param>
        /// <returns>Array[4] of possible names:
        /// 
        /// The indexes of the returned array can be used for the Person object e.g.
        /// GivenName1[0]
        /// GivenName2[1]
        /// GivenName3[2]
        /// LastName[3]
        /// </returns>
        public static string[] SplitNameToArray(string name)
        {
            string[] postitionedNames = new string[4];
            string[] nameSplit = name.Split(' ');
            
            if (nameSplit.Length == 4)
            {
                postitionedNames[0] = nameSplit[nameSplit.Length - 4];
                postitionedNames[1] = nameSplit[nameSplit.Length - 3];
                postitionedNames[2] = nameSplit[nameSplit.Length - 2];
                postitionedNames[3] = nameSplit[nameSplit.Length - 1];
            }
            else if (nameSplit.Length == 3)
            {
                postitionedNames[0] = nameSplit[nameSplit.Length - 3];
                postitionedNames[1] = nameSplit[nameSplit.Length - 2];
                postitionedNames[3] = nameSplit[nameSplit.Length - 1];
            }
            else if (nameSplit.Length == 2)
            {
                postitionedNames[0] = nameSplit[nameSplit.Length - 2];
                postitionedNames[3] = nameSplit[nameSplit.Length - 1];

            }
            return postitionedNames;
        }
    }
}
