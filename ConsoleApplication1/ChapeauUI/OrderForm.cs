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

namespace ChapeauUI
{
    public partial class orderForm : Form
    {
        public orderForm()
        {
            InitializeComponent();

        }

        public ListView tablesListView;

        private void TablesViewBtn_Click(object sender, EventArgs e)
        {
            orderViewPanel.Controls.Clear();
            orderViewPanel.Controls.Add(CreateChnageTableStatusBtn());
            orderViewPanel.Controls.Add(ShowTables());
        }

        private Control ShowTables()
        {
            tablesListView = new ListView();
            tablesListView.Width = orderViewPanel.Width;
            tablesListView.Height = 220;
            tablesListView.View = View.Details;
            tablesListView.FullRowSelect = true;
            //tablesListView.BackColor=Color.DarkCyan;

            tablesListView.Columns.Add("Table Number", -2, HorizontalAlignment.Left);
            tablesListView.Columns.Add("Table Status", -2, HorizontalAlignment.Left);
            List<Table> tables = TableService.GetTables();

            //for (int i = 0; i < tables.Count; i++)
            //{
            //    string[] items = { tables[i].tableID.ToString(), tables[i].occupied.ToString() };
            //}
            //tablesListView.Items.Clear();
            foreach (Table table in tables)
            {
                ListViewItem entryItem = tablesListView.Items.Add(table.tableID.ToString());

                if (table.occupied == true)
                {
                    entryItem.SubItems.Add("Reserved");
                }
                else
                {
                    entryItem.SubItems.Add("Un-Reserved");
                }
            }
            return tablesListView;
        }

        private Control CreateChnageTableStatusBtn()
        {
            Button changeTableStatusBtn = new Button();
            changeTableStatusBtn.Text = "Change Status";
            changeTableStatusBtn.Width = tablesViewBtn.Width;
            changeTableStatusBtn.Height = tablesViewBtn.Height;
            changeTableStatusBtn.Top = orderViewPanel.Bottom - 200;
            changeTableStatusBtn.Left = orderViewPanel.Right - 460;

            changeTableStatusBtn.Click += new EventHandler(changeTableStatusBtn_Click);

            return changeTableStatusBtn;
        }

        private void changeTableStatusBtn_Click(object sender, EventArgs e)
        {
            bool occuoied;
            int tableID = Convert.ToInt32(tablesListView.SelectedItems[0].Text);

            if (tablesListView.SelectedItems[0].SubItems[1].Text == "Reserved")
            {
                occuoied = false;
            }
            else
            {
                occuoied = true;
            }

            TableService.ChangeTableStatus(new Table(tableID, occuoied));
            orderViewPanel.Controls.Clear();
            orderViewPanel.Controls.Add(ShowTables());

        }

        private void logoffLink_Click(object sender, EventArgs e)
        {
           
           
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }
    }
}
