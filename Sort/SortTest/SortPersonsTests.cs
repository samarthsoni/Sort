using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sort;
using System.Collections.Generic;
using System.IO;
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
            /*Change the path of the text file which can be used for testing of read_textfile method*/
            string path = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "names2.txt");

            List<Sort.person> expected_persons = GetFileList();

            //act
            List<Sort.person> test_persons = Program.read_textfile(path);
            
            //Assert
            Assert.AreEqual(expected_persons.Count, test_persons.Count, "Text file incorrectly read");
            if(expected_persons.Count==test_persons.Count)
            {
                for (int k = 0; k < expected_persons.Count;k++)
                {
                    Assert.AreEqual(expected_persons[k], test_persons[k], "Text file incorrectly read");
                }
            }
            
        }

        public List<person> GetFileList()
        {
            return new List<Sort.person>()
            {
                new person("DALEY", "ROSS", 84),
                new person("DALEY", "BRUNDA", 84),
                new person("CALAM", "JILL", 62),
                new person("ROWE", "CHRIS", 77),
                new person("JAMES", "AMI", 55),
                new person("STEWART", "GLENN", 82),
                new person("PERRIN", "DIMITRI", 82),
            };
        }

        public List<person> GetTestList()
        {
            return new List<Sort.person>()
            {
                new person("DALEY", "ROSS", 84),
                new person("CALAM", "JILL", 62),
                new person("ROWE", "CHRIS", 77),
                new person("DALEY", "BRUNDA", 84),
                new person("JAMES", "AMI", 55),
                new person("STEWART", "GLENN", 82),
                new person("PERRIN", "DIMITRI", 82),
            };
        }

        public List<person> GetExpectedList()
        {
            return new List<Sort.person>()
            {
                new person("DALEY", "BRUNDA", 84),
                new person("DALEY", "ROSS", 84),
                new person("PERRIN", "DIMITRI", 82),
                new person("STEWART", "GLENN", 82),
                new person("ROWE", "CHRIS", 77),
                new person("CALAM", "JILL", 62),
                new person("JAMES", "AMI", 55),
            };
        }

        //unit test for sort_persons method
        [TestMethod]
        public void TestMethod_sort_persons()
        {
            //arrange
            List<person> test_list = GetTestList();
            
            List<person> expected_list = GetExpectedList();

            //act
            List<person> actual_list = new List<person>();
            actual_list = Program.sort_persons(test_list);

            //assertion
            Assert.AreEqual(expected_list.Count, actual_list.Count, "Names incorrectly sized");
            if (expected_list.Count == actual_list.Count && actual_list.Count!=0 && expected_list.Count!=0)
            {
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
