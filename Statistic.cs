using Bookclub_desktop.Properties;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
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
                // Console.WriteLine("A legidősebb klubtag:{0}", OldestMember()); NEM TUDOM
                /* Console.WriteLine("Tagok száma:" +
                     "\r\n\tNő:{0}" +
                     "\r\n\tFérfi:{1}" +
                     "\r\n\tIsmeretlen:{2}",SumMemvers());NEM TUDOM */
                Console.WriteLine("Adjon meg egy nevet: ");
                string BannedName = Console.ReadLine();
                Banned(BannedName);
                Console.ReadKey();
            }
            catch (MySqlException ex)
            {

                Console.WriteLine("Hiba történt az adatbázis kapcsolat kiépítésekor:");
                Console.WriteLine(ex.Message);
            }
            
        }

        private static void Banned(string BannedName) // NEM MÜKÖDIK
        {
            int index = 0;
            while (index<members.Count && members[index].Name != BannedName)
            {
                index++;
            }
            if (members[index].Name == BannedName && members[index].Banned != true)
            {
                Console.WriteLine("A megadott személy nincs kitiltva");
            }
            else
            {
                Console.WriteLine("Nincs ilyen tagja a klubnak");
            }
        }

        /* private static object SumMemvers()
         {
             //
         }*/

        /*private static object OldestMember()
        {
            Member older = members[0];
            for (int i = 1; i < members.Count; i++)
            {
                if (members[i].Birth_date > older)
                {
                    older = members[i];
                }
            }
            return older;

            
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
