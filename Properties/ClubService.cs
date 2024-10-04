using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub_desktop.Properties
{
    internal class ClubService
    {

        private static string DB_Host = "localhost";
        private static string DB_USER = "root";
        private static string DB_PASWORD ="";
        private static string DB_DBNAME = "members";



        private MySqlConnection connection;

        public ClubService()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = DB_Host;
            builder.UserID = DB_USER;
            builder.Password = DB_PASWORD;
            builder.Database = DB_DBNAME;

            this.connection = new MySqlConnection(builder.ConnectionString);
            this.connection.Open();

        }

        public List<Member> GetMembers()
        {
            List<Member> list = new List<Member>();
            string sql = "SELECT * FROM members";
            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = sql;
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    string name = reader.GetString("name");
                   
                    DateTime birth_date = reader.GetDateTime("birth_date");
                    bool banned = reader.GetBoolean("banned");

                    Member member = new Member(id, name, birth_date, banned);
                    list.Add(member);
                }
            }
            return list;
        }
    }
}
