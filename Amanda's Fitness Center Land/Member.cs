using System;
using System.Collections.Generic;
using System.Text;

namespace Amanda_s_Fitness_Center_Land
{
    class Member
    {
        public int MemberID { get; set; }
        public bool Status { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ClubName { get; set; }

        public Member(int id, bool status, string firstName, string lastName, string clubName)
        {
            MemberID = id;
            Status = status;
            FirstName = firstName;
            LastName = lastName;
            ClubName = clubName;
        }

        public Member()
        {

        }

    }
}
