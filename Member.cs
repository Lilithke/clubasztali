using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub_desktop
{
    internal class Member
    {

        int id;
        string name;
        enum gender { male, female, other };
        DateTime birth_date;
        bool banned;

        public Member(int id, string name, DateTime birth_date, bool banned)
        {
            this.id = id;
            this.name = name;
            this.birth_date = birth_date;
            this.banned = banned;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public DateTime Birth_date { get => birth_date; set => birth_date = value; }
        public bool Banned { get => banned; set => banned = value; }
    }
}
