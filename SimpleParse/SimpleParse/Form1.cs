using System;
using System.Collections.Generic;   
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            DisplayCaptionTable();
            DisplayPositionNumbers();
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

        private void DisplayCaptionTable()
        { 
            tableEPL.Controls.Add(new Label() { Text = "№" }, 0, 0);
            tableEPL.Controls.Add(new Label() { Text = "Команда" }, 1, 0);
            tableEPL.Controls.Add(new Label() { Text = "И" }, 2, 0);
            tableEPL.Controls.Add(new Label() { Text = "З" }, 3, 0);
            tableEPL.Controls.Add(new Label() { Text = "П" }, 4, 0);
            tableEPL.Controls.Add(new Label() { Text = "О" }, 5, 0);
        }

        private void DisplayPositionNumbers()
        {
            for (int i = 1; i <= 20; i++)
            {
                string number = i.ToString();
                tableEPL.Controls.Add(new Label() { Text = number }, 0, i);
            }
        }

        private void DisplayTableWithReuslt(string sourcePage)
        {
            
            string[] teams = sourcePage.Substrings("<td class=\"tt2 tt_title\"><a href=\"/stats/team/", "</a>", 0);

            for (int i = 0; i < teams.Length; i++)
            {
                string regteam = teams[i];
                var match = Regex.Match(regteam, "[^a-zA-Z0-9>]+$");
                string team = match.Value;
                tableEPL.Controls.Add(new Label { Text = team, MaximumSize = new Size(1500, 0), AutoSize = true }, 1, 1 + i);
            }

            string[] quantityMatches = sourcePage.Substrings("<td class=\"tt3\">", "</td>", 1);

            for (int i = 1; i < quantityMatches.Length; i++)
            {
                tableEPL.Controls.Add(new Label() { Text = quantityMatches[i] }, 2, i);
            }

            string[] goalsScored = sourcePage.Substrings("<td class=\"tt7\">", "</td>", 1);

            for (int i = 1; i < goalsScored.Length; i++)
            {
                tableEPL.Controls.Add(new Label() { Text = goalsScored[i] }, 3, i);
            }

            string[] goalsMissed = sourcePage.Substrings("<td class=\"tt8\">", "</td>", 1);

            for (int i = 1; i < goalsMissed.Length; i++)
            {
                tableEPL.Controls.Add(new Label() { Text = goalsMissed[i] }, 4, i);
            }
            string[] points = sourcePage.Substrings("<td class=\"tt10\">", "</td>", 1);

            for (int i = 1; i < points.Length; i++)
            {
                tableEPL.Controls.Add(new Label() { Text = points[i] }, 5, i);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DisplayTableWithReuslt(GetSourcePage());
        }
    }
}
