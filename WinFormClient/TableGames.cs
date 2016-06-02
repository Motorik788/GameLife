using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormClient
{
    public partial class TableGames : Form
    {
        public TableGames()
        {
            InitializeComponent();
            button1_Click(null,null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var games = Form1.Chanell.GetAllGames();
                listView1.Items.Clear();
                foreach (var game in games)
                {
                    ListViewItem item = new ListViewItem(game.Id.ToString());
                    item.SubItems.Add(string.Format("{0}x{1}", game.CurrentField.XLenght, game.CurrentField.YLenght));
                    item.SubItems.Add(game.Settings.GameMode.ToString());
                    item.SubItems.Add(game.CurrentField.GameObjects.Count.ToString());
                    item.SubItems.Add(game.CurrentField.Generation.ToString());
                    listView1.Items.Add(item);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Нет подключения!");
            }                      
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
                contextMenuStrip1.Show(Cursor.Position);
        }

        private void ContinueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form1.CurrentGame = int.Parse(listView1.SelectedItems[0].Text);
                Form1.Chanell.ContinueGame(Form1.CurrentGame);
                foreach (var item in Application.OpenForms)
                {                    
                    if(item as Form1 != null)
                    {
                        (item as Form1).Play();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()); 
            }
            Close();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form1.Chanell.DeleteGame(int.Parse(listView1.SelectedItems[0].Text));
                button1_Click(null,null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
