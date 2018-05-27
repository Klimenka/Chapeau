using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ChapeauLogic;
using ChapeauModel;
using LogicLayer;

namespace ChapeauUI
{
    public partial class orderForm : Form
    {
        public orderForm()
        {
            InitializeComponent();

        }

        private TableService tableService = new TableService();
  
        // show tables
        private void TablesViewBtn_Click(object sender, EventArgs e)
        {
            orderViewPanel.Controls.Clear();
            ShowTables();
            ShowRestaurantView();
        }

        private void ShowRestaurantView()
        {
            orderViewPanel.BackgroundImage =
                new Bitmap(Application.StartupPath + "\\RV.png");
            orderViewPanel.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void ShowTables()
        {
            List<Table> tables = tableService.GetTables();
            int lastX = 73;
            int y = 50;

            // store even table numbers
            for (int i = 0; i < tables.Count; i++)
            {
                Button btn = new Button();

                if ((i + 1) % 2 == 0)
                {
                    btn.Size = new Size(100, 50);
                    btn.Location = new Point(lastX, y);
                    orderViewPanel.Controls.Add(btn);
                    lastX += btn.Width + 36;
                    btn.Text = (i + 1).ToString();
                    btn.Click += new EventHandler(changeTableStatusBtn_Click);
                    btn.Tag = tables[i];
                }
                if (tables[i].occupied == true)
                {
                    btn.BackColor = Color.Green;
                    btn.ForeColor = Color.AliceBlue;
                }
                else
                {
                    btn.BackColor = Color.Red;
                }
            }

            // store odd table numbers
            lastX = 73;
            y = 200;
            for (int i = 0; i < tables.Count; i++)
            {
                Button btn = new Button();

                if ((i + 1) % 2 != 0)
                {
                    btn.Size = new Size(100, 50);
                    btn.Location = new Point(lastX, y);
                    orderViewPanel.Controls.Add(btn);
                    lastX += btn.Width + 36;
                    btn.Text = (i + 1).ToString();
                    btn.Click += new EventHandler(changeTableStatusBtn_Click);
                    btn.Tag = tables[i];
                }
                if (tables[i].occupied == true)
                {
                    btn.BackColor = Color.Green;
                    btn.ForeColor = Color.AliceBlue;
                }
                else
                {
                    btn.BackColor = Color.Red;
                }
            }

        }

        // change tables status
        private void changeTableStatusBtn_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Table table = (Table)button.Tag;
            int tableID = table.tableID;
            bool occupied;

            if (MessageBox.Show("Would you like to change the status of table [" + table.tableID + "]?", "Change Table Status",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (table.occupied)
                {
                    occupied = false;
                }
                else
                {
                    occupied = true;
                }
                tableService.ChangeTableStatus(new Table(tableID, occupied));
            }
            orderViewPanel.Controls.Clear();
            ShowTables();
        }

        // log off link
        private void logoffLink_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log off?", "Logging off",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Hide();
            }
        }

        private void orderForm_Load(object sender, EventArgs e)
        {

        }

        private void orderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
