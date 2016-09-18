using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public class person
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public int Score { get; set; }

        public person(string lastname, string firstname, int score)
        {
            LastName = lastname;
            FirstName = firstname;
            Score = score;
        }

        public override bool Equals(Object obj)
        {
            if (obj is person)
            {
                var that = obj as person;
                return this.Score == that.Score && this.LastName == that.LastName && this.FirstName == that.FirstName;
            }

            return false;
        }
    }
}
