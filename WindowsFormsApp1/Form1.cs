using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Dictionary<string, string> task_book;

        private void button2_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.AddDays(1);
            data_load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = dateTimePicker1.Value.AddDays(-1);
            data_load();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            data_load();
        }

        private void data_load()
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < 13; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dateTimePicker1.Value.ToString("dd.MM.yy");
                dataGridView1.Rows[i].Cells[1].Value = (i + 8) + ":00";
                dataGridView1.Rows[i].Cells[2].Value = 1;
            }
        }

        private void save()
        {
            StreamWriter sw = new StreamWriter(Application.StartupPath + "\\log\\" + dateTimePicker1.Value.ToString("dd.MM.yy") + ".txt");
            for (int i = 0; i < 13; i++)
            {
                string s = dataGridView1.Rows[i].Cells[0].Value.ToString() + "\\" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "\\" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "\\" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "\\" + dataGridView1.Rows[i].Cells[4].Value.ToString();
                sw.WriteLine(s);
            }
            sw.Close();
        }

        private void load()
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            save();
        }
    }
}