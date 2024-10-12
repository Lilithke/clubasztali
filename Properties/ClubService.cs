using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                    string gender = reader.IsDBNull(reader.GetOrdinal("gender")) ? string.Empty : reader.GetString("gender");
                    DateTime birth_date = reader.GetDateTime("birth_date");
                    bool banned = reader.GetBoolean("banned");

                    Member member = new Member(id, name, gender, birth_date, banned);
                    list.Add(member);
                }
            }
            return list;
        }

        public List<MemberCLI> GetMembersCLI()
        {
            List<MemberCLI> cli = new List<MemberCLI>();
            string sql = "SELECT * FROM members";
            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = sql;
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    string name = reader.GetString("name");
                    string gender = reader.IsDBNull(reader.GetOrdinal("gender")) ? string.Empty : reader.GetString("gender");
                    DateTime birth_date = reader.GetDateTime("birth_date");
                    bool banned = reader.GetBoolean("banned");

                    MemberCLI memberscli = new MemberCLI(id, name, gender, birth_date, banned);
                    cli.Add(memberscli);
                }
            }
            return cli;
        }

        internal bool  KitiltasKezeles(int id, bool value)
        {
            string sql  = $"UPDATE `members` SET `banned` = {(value ? 1 : 0)} WHERE `id` = {id}";
            MySqlCommand command = this.connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@id", id);
            return command.ExecuteNonQuery() == 1;
          
            
            
            
            
            /* try
            {
                connection.Open();
                sql.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("A módosítások mentése sikeres!");
                Beolvasas();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Hiba a módosítás folyamán" + Environment.NewLine + ex.Message);
                Environment.Exit(0);
            }*/
        }

      
    }
}
