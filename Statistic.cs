using Bookclub_desktop.Properties;
using K4os.Compression.LZ4.Internal;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ZstdSharp.Unsafe;

namespace Bookclub_desktop
{
    internal  static class Statistic
    {
        static List<Member> members;
        private static List<MemberCLI> memberscli;

        public static void Run()
        {
            try
            {
                ReadAllMembers();
                /* Console.WriteLine("Kitiltott tagok száma: {0}",BannedSum());
                 //Console.WriteLine("{0} a tagok között 18 évnél fiatalabb személy.", Youngerthan18() ? "Van" : "Nincs");
                 Console.WriteLine("{0} a tagok között 18 évnél fiatalabb személy.", DateDifferenc());
                 // Console.WriteLine("A legidősebb klubtag:{0}", OldestMember()); NEM TUDOM
                 /* Console.WriteLine("Tagok száma:" +
                      "\r\n\tNő:{0}" +
                      "\r\n\tFérfi:{1}" +
                      "\r\n\tIsmeretlen:{2}",SumMemvers());NEM TUDOM 
                 Console.WriteLine("Adjon meg egy nevet: ");
                 string BannedName = Console.ReadLine();
                 Banned(BannedName);*/




                //LINQ megoldások: !!!!!!!!!

                //----Határozza meg a kitiltott klubtagok számát.

                Console.WriteLine($"Kitiltott tagok száma:{members.FindAll(a =>a.Banned).Count()}");

                //---Döntse el, hogy szerepel-e az adatok között 18 évnél fiatalabb személy.

                string younger18 = members.Exists(a => a.Birth_date.Year < DateTime.Now.Year) ? "Van" : "Nincs";
                string younger18_2 = members.Exists(a => DateTime.Now.Year - a.Birth_date.Year < 18) ? "VAN" : "NINCS";
                Console.WriteLine($"{younger18} a tagok között 18 évnél fiatalabb személy.");
                Console.WriteLine($"{younger18_2} a tagok között 18 évnél fiatalabb személy.");

                //---Határozza meg és írja ki a legidősebb klubtag nevét és születésnapját.
                Member olderMember = members.OrderBy(a => a.Birth_date).First();
                Console.WriteLine($"A legidősebb klubtag:{olderMember.Name},{olderMember.Birth_date.ToString("yyyy.MM.dd")}");

                //---Határozza meg és írja ki nemenként csoportosítva a tagok számát

                Console.WriteLine("Tagok száma:");
                Console.WriteLine($"Nő:{memberscli.Count(a => a.Gender.Equals("F"))}");
                Console.WriteLine($"Férfi:{memberscli.Count(a => a.Gender.Equals("M"))}");
                Console.WriteLine($"Ismeretlen:{memberscli.Count(a => a.Gender.Equals(string.Empty))}");

                //----Kérjen be a konzolról egy nevet. Határozza meg, hogy az adott személy ki van-e tiltva a klubból. Ha a
                //---megadott névvel nem szerepel klubtag, akkor „Nincs ilyen tagja a klubnak” üzenet jelenjen meg.

                Console.WriteLine("Adjon meg egy nevet:");
                string name = Console.ReadLine();
                Member member = members.Find(a => a.Name.Equals(name));
                if (member == null)
                {
                    Console.WriteLine("Nincs ilyen tagja a klubnak");
                }
                else
                {
                    Console.WriteLine(member.Banned ? "A megadott személy ki van tiltva" : "A megadott személy nincs kitiltva");
                }

                 Console.ReadKey();
            }
            catch (MySqlException ex)
            {

                Console.WriteLine("Hiba történt az adatbázis kapcsolat kiépítésekor:");
                Console.WriteLine(ex.Message);
            }
            
        }

       /* private static void Banned(string BannedName) // NEM MÜKÖDIK
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

        /*public static DateTime oneGoodResult()
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

        }*/
     

        private static void ReadAllMembers()
        {
            ClubService clubservice = new ClubService();
            members = clubservice.GetMembers();

            ClubService clubservicecli = new ClubService();
            memberscli = clubservicecli.GetMembersCLI();

        }
    }
}
