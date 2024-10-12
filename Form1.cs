using Bookclub_desktop.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Policy;
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
            if (ClubGrid.SelectedRows.Count==0)
            {
                MessageBox.Show("Tiltás módosításához előbb válasszon ki klubtagot!");
                return;
            }
            else
            {
                try
                {
                    int Rowindex = ClubGrid.CurrentCell.RowIndex;


                    if (Rowindex >= 0)
                    {
                        // Az adott sor kiválasztása

                        DataGridViewRow row = ClubGrid.Rows[Rowindex];

                        // kiolvassuk a sorhoztartozó adatokat

                        int id = Convert.ToInt32(row.Cells["Id"].Value);
                        string name = row.Cells["Name"].Value.ToString();
                        bool banned = Convert.ToBoolean(row.Cells["Banned"].Value);

                        //rákérdezünk a felhasználótól, hogy tényleg kitiltja-e a kiválasztott tagot

                        if (!banned)
                        {
                            DialogResult valasztas = MessageBox.Show($"Biztos szeretné kitiltani a kiválasztott {name} klubtagot?", "Kitiltás", MessageBoxButtons.YesNo);
                            if (DialogResult.Yes == valasztas)
                            {
                                row.Cells["Banned"].Value = true;
                                // A módosítások mentése az adatbázisban
                                clubService.KitiltasKezeles(id, true);
                                MessageBox.Show("Sikeresen tiltva a klubtag!");
                            }
                            else
                            {
                                return;
                            }

                        }
                        else
                        {
                            DialogResult valasztas = MessageBox.Show($"Biztos szeretné visszavonni a kiválasztott {name} klubtag tiltását?", "Kitiltás visszavonása", MessageBoxButtons.YesNo);
                            if (DialogResult.Yes == valasztas)
                            {
                                row.Cells["Banned"].Value = false;
                                // A módosítások mentése az adatbázisban
                                clubService.KitiltasKezeles(id, false);
                                MessageBox.Show("Sikeresen visszavonta a tiltást a klubtagról!");
                            }
                            else
                            {
                                return;
                            }
                        }

                    }
                }

                catch (MySqlException ex)
                {

                    MessageBox.Show(ex.Message, "Hiba történt a módósítás során!");
                }
            }

           

            

               

            

           
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
            ClubGrid.ClearSelection();
        }
    }
}
