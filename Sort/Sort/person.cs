using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class person
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

    }
}
