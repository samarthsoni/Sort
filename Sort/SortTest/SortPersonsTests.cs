using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sort;
using System.Collections.Generic;
using System.Linq;

namespace SortTest
{
    [TestClass]
    public class SortPersonsTests
    {
        //Unit test for read_textfile method
        [TestMethod]
        public void TestMethod_read_textfile()
        {
            //arrange
            List<Sort.person> test_persons = new List<Sort.person>();
            /*Change the path of the text file which can be used for testing of read_textfile method*/
            string path = "F:\\workspace\\C# workspace\transmax_question\names2.txt";

            string[] Last= new string[] { "DALEY", "CALAM", "ROWE" };
            string[] First = new string[] { "ROSS", "JILL", "CHRIS" };
            int[] Score1 = new int[] { 84, 62, 77 };
            List<Sort.person> expected_persons = new List<Sort.person>();
            int i = 0;
            foreach(person p in expected_persons)
            {
                p.LastName = Last[i];
                p.FirstName = First[i];
                p.Score = Score1[i];
                i++;
            }

            //act
            test_persons = Program.read_textfile(path, test_persons);


            //Assert
            Assert.AreEqual(expected_persons.Count, test_persons.Count, "Text file incorrectly read");
            if(expected_persons.Count==test_persons.Count)
            {
                expected_persons.ToArray();
                test_persons.ToArray();
                for (int k = 0; k < expected_persons.Count;k++)
                {
                    Assert.AreEqual(expected_persons[k], test_persons[k], "Text file incorrectly read");
                }
            }
            
        }

        //unit test for sort_persons method
        [TestMethod]
        public void TestMethod_sort_persons()
        {
            //arrange
            List<person> test_list = new List<person>();
            test_list.Add(new person("DALEY", "ROSS", 84));
            test_list.Add(new person("DALEY", "BRUNDA", 84));
            test_list.Add(new person("CALAM", "JILL", 62));
            test_list.Add(new person("ROWE", "CHRIS", 77));
            test_list.Add(new person("JAMES", "AMI", 55));
            test_list.Add(new person("STEWART", "GLENN", 82));
            test_list.Add(new person("PERRIN", "DIMITRI", 82));
            
            List<person> expected_list = new List<person>();
            expected_list.Add(new person("DALEY", "BRUNDA", 84));
            expected_list.Add(new person("DALEY", "ROSS", 84));
            expected_list.Add(new person("PERRIN", "DIMITRI", 82));
            expected_list.Add(new person("STEWART", "GLENN", 82));
            expected_list.Add(new person("ROWE", "CHRIS", 77));
            expected_list.Add(new person("CALAM", "JILL", 62));
            expected_list.Add(new person("JAMES", "AMI", 55));

            //act
            List<person> actual_list = new List<person>();
            actual_list = Program.sort_persons(test_list);

            //assertion
            Assert.AreEqual(expected_list.Count, actual_list.Count, "Names incorrectly sized");
            if (expected_list.Count == actual_list.Count && actual_list.Count!=0 && expected_list.Count!=0)
            {

                expected_list.ToArray();
                actual_list.ToArray();
                for (int k = 0; k < expected_list.Count; k++)
                {
                    Assert.AreEqual(expected_list[k], actual_list[k],"Incorrect Sorting");
                }
            }

        }

        //unit test for create_path method
        [TestMethod]
        public void TestMethod_create_path()
        {
            //arrange
            string filepath= @"F:\workspace\C# workspace\transmax_question\names.txt";

            string[] expected = new string[3];
            expected[0] = @"F:\workspace\C# workspace\transmax_question";
            expected[1] = @"names";
            expected[2] = @".txt";

            //act
            string[] actual = new string[3];
            actual = Program.create_path(filepath);

            //assert
            Assert.AreEqual(expected[0]+expected[1]+expected[2], actual[0]+actual[1]+actual[2], "Incorrect filepath created");
        }

    }
}
