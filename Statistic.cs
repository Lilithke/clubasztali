using Bookclub_desktop.Properties;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace Bookclub_desktop
{
    internal  static class Statistic
    {
        static List<Member> members;
        public static void Run()
        {
            try
            {
                ReadAllMembers();
                Console.WriteLine("Kitiltott tagok száma: {0}",BannedSum());
                //Console.WriteLine("{0} a tagok között 18 évnél fiatalabb személy.", Youngerthan18() ? "Van" : "Nincs");
                Console.WriteLine("{0} a tagok között 18 évnél fiatalabb személy.", DateDifferenc());
                // Console.WriteLine("A legidősebb clubtag:{0}",OldestMember());
                Console.ReadKey();
            }
            catch (MySqlException ex)
            {

                Console.WriteLine("Hiba történt az adatbázis kapcsolat kiépítésekor:");
                Console.WriteLine(ex.Message);
            }
            
        }

        /*private static object OldestMember()
        {
            
        }*/

        public static DateTime oneGoodResult()
        {
            DateTime localDate = new DateTime(2006, 10, 4);
            return localDate;
        }
        public static string DateDifferenc()
        {

            
            DateTime date1 = new DateTime(2006, 1, 1);
            DateTime date2 = DateTime.Now;
            int result = DateTime.Compare(date2, date1);
            string relationship;

            if (result < 18)
            {
                relationship = "Van";
            }
            else if (result == 18)
            {
                relationship = "nincs,pont betöltötte";
            }
            else
            {
                relationship = "nincs";
            }

            return relationship;
        } 

        



        private static bool Youngerthan18()
        {
            int index = 0;
            while (index < members.Count && (members[index].Birth_date) > oneGoodResult())
            {
                index++;
            }
            return index < members.Count;
        }

        private static int BannedSum()
        {
            int count = 0;
            foreach (Member member in members)
            {
                if (member.Banned == true)
                {
                    count++; 
                }
            }
            return count;

        }
     

        private static void ReadAllMembers()
        {
            ClubService clubservice = new ClubService();
            members = clubservice.GetMembers();
        }
    }
}
