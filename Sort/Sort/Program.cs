using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the path to input text file:");
            string path;
            path = Console.ReadLine();

            //Declaring a list of objects of class person to represent different persons
            List<person> all_persons = new List<person>();

            //Method read_textfile will read the text file and extract all names and score
            //and will return a populated object list of person
            all_persons = read_textfile(path, all_persons);

            //Method sort_persons will sort list of objects of person in descending order
            all_persons = sort_persons(all_persons);

            //Method create_path will generate the path of output file with appropriate name
            string newpath = create_path(path);

            //Method write_textfile will write the output to a text file
            write_textfile(all_persons, newpath);

            Console.Read();
        }

        /* Method read_textfile accepts a filepath and empty list of objects of class person as arguments
         * Reads the text file and populates the list of objects
         * Returns a populated list of objects of class person                                          */
        static List<person> read_textfile(string path, List<person> all_persons)
        {

            System.IO.TextReader reader = new System.IO.StreamReader(path);

            Console.WriteLine("All names");
            string line = "";
            while ((line = reader.ReadLine()) != null)
            {
                char[] delims = { ' ', ',', '\n' };
                string[] words = line.Split(delims, StringSplitOptions.RemoveEmptyEntries);

                int i;
                if (int.TryParse(words[2], out i) == false)
                {
                    Console.WriteLine("Invalid value");
                    Environment.Exit(0);
                }

                Console.WriteLine(words[0] + " " + words[1] + " " + i);
                all_persons.Add(new person(words[0], words[1], i));
            }
            reader.Close();

            return all_persons;
        }

        /* Method write_textfile accepts a sorted list of objects of person and a path for output file
         * This method creates an output text file and writes output in that file                       */
        static void write_textfile(List<person> all, string new_path)
        {
            System.IO.TextWriter writer = new System.IO.StreamWriter(new_path);
            Console.WriteLine("\nSorted:");

            foreach (person p in all)
            {
                Console.WriteLine(p.LastName + " " + p.FirstName + " " + p.Score);
                writer.WriteLine(p.LastName + ", " + p.FirstName + ", " + p.Score);
            }
            writer.Close();
        }

        /*Method sort_persons accepts a list of objects of person and sorts it based on score
         * For objects with equal score, sorting is done based on last name
         * For same last names, sorting done based on first name                            */
        static List<person> sort_persons(List<person> all)
        {
            all.Sort((x, y) =>
            {
                int result = y.Score.CompareTo(x.Score);
                if (result != 0)
                    return result;
                else
                {
                    result = x.LastName.CompareTo(y.LastName);
                    return result != 0 ? result : x.FirstName.CompareTo(y.FirstName);
                }

            });

            return all;
        }


        /*Method create_path accepts a filepath entered by user and returns the file path for output file     */
        static string create_path(string filePath)
        {
            string directoryName, extension, filename;

            directoryName = System.IO.Path.GetDirectoryName(filePath);
            filename = System.IO.Path.GetFileNameWithoutExtension(filePath);
            extension = System.IO.Path.GetExtension(filePath);

            return directoryName + "\\" + filename + "-graded" + extension;
        }
    }
}
