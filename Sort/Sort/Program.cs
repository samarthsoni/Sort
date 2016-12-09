using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter path to text file \ngrade-scores:");
            string path;
            path = Console.ReadLine();

            if (System.IO.File.Exists(path))
            {
                //Declaring a list of objects of class person to represent different persons
                //Method read_textfile will read the text file and extract all names and score
                //and will return a populated object list of person
                List<person> all_persons = read_textfile(path);

                //Method sort_persons will sort list of objects of person in descending order
                all_persons = sort_persons(all_persons);

                //Method create_path will generate the path of output file with appropriate name
                string[] newpath = create_path(path);
                string new_filepath = Path.Combine(newpath[0], newpath[1] + "-graded" + newpath[2]);
                
                //Method write_textfile will write the output to a text file
                write_textfile(all_persons, new_filepath);

                Console.WriteLine("\nFinished: created " + newpath[1] + "-graded" + newpath[2]);
            }
            else
                Console.WriteLine("\nEnter a valid file path");

            Console.Read();
        }

        /* Method read_textfile accepts a filepath and empty list of objects of class person as arguments
         * Reads the text file and populates the list of objects
         * Returns a populated list of objects of class person                                          */
        public static List<person> read_textfile(string path)
        {
            List <person> all_persons = new List<person>();

            try
            {
                using (System.IO.TextReader reader = new System.IO.StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (string.IsNullOrWhiteSpace(line))
                        {
                            continue;
                        }
                        else
                        {
                            char[] delims = {' ', ',', '\n'};
                            string[] words = line.Split(delims, StringSplitOptions.RemoveEmptyEntries);

                            int i;
                            if (int.TryParse(words[2], out i) == false)
                            {
                                Console.WriteLine("Invalid score value");
                                Environment.Exit(0);
                            }
                            all_persons.Add(new person(words[0], words[1], i));
                        }

                    }
                    reader.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Wrong path sepcified or invalid contents.Exception: {0}", e.ToString());
            }

            return all_persons;
        }

        /* Method write_textfile accepts a sorted list of objects of person and a path for output file
         * This method creates an output text file and writes output in that file                       */
        public static void write_textfile(List<person> all, string new_path)
        {
            try
            {
                if (System.IO.File.Exists(new_path))
                {
                    System.IO.File.Delete(new_path);
                }
                using (System.IO.TextWriter writer = new System.IO.StreamWriter(new_path))
                {
                    foreach (person p in all)
                    {
                        Console.WriteLine("\n" + p.LastName + ", " + p.FirstName + ", " + p.Score);
                        writer.WriteLine(p.LastName + ", " + p.FirstName + ", " + p.Score);
                    }
                    writer.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException: {0}", e.ToString());
            }
        }

        /*Method sort_persons accepts a list of objects of person and sorts it based on score
         * For objects with equal score, sorting is done based on last name
         * For same last names, sorting done based on first name                            */
        public static List<person> sort_persons(List<person> all)
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
        public static string[] create_path(string filePath)
        {
            string [] file=new string[3];

            try
            {
                //file[0] represent directoryName
                file[0] = @System.IO.Path.GetDirectoryName(filePath);

                //file[1] represents filename
                file[1] = @System.IO.Path.GetFileNameWithoutExtension(filePath);

                //file[2] represents extension
                file[2] = @System.IO.Path.GetExtension(filePath);

            }
            catch (Exception e)
            {
                Console.WriteLine("\nException: {0}", e.ToString());
            }
            return file;
        }
    }
}
