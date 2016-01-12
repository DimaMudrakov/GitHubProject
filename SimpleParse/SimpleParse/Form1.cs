using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xNet;

namespace SimpleParse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetCaptionTable();
            MessageBox.Show(GetSourcePage());
        }

        private string GetSourcePage()
        {
            string sourcePage = "";

            using (HttpRequest request = new HttpRequest())
            {
                request.CharacterSet = Encoding.UTF8;
                sourcePage = request.Get("http://www.ua-football.com/foreign/england").ToString();
            }
            return sourcePage;
        }

        private void GetCaptionTable()
        {
            TableLayoutPanel table = tableLayoutPanel1;

            table.Controls.Add(new Label() { Text = "№" }, 0, 0);
            table.Controls.Add(new Label() { Text = "Команда" }, 1, 0);
            table.Controls.Add(new Label() { Text = "И" }, 2, 0);
            table.Controls.Add(new Label() { Text = "З" }, 3, 0);
            table.Controls.Add(new Label() { Text = "П" }, 4, 0);
            table.Controls.Add(new Label() { Text = "О" }, 5, 0);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
