using Bookclub_desktop.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookclub_desktop
{
    public partial class Form1 : Form
    {
        private ClubService clubService;
        public Form1()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                clubService = new ClubService();
                RefreshClubDrid();
            }
            catch (MySqlException ex)
            {

                MessageBox.Show("Hiba történt az adatbázis kapcsolat kiépítésekor!");
                this.Close();
            }
        }

        private void RefreshClubDrid()
        {
            ClubGrid.DataSource = clubService.GetMembers();
        }
    }
}
