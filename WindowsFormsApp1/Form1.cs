using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

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
            string file = Application.StartupPath + "\\log\\" + dateTimePicker1.Value.ToString("dd.MM.yy") + ".txt";
            DateTime t = DateTime.Parse("08:00");
            if (File.Exists(file))
            {
                StreamReader sr = new StreamReader(file);
                string s;
                dataGridView1.Rows.Clear();
                for (int i = 0; i < 13; i++)
                {
                    s = sr.ReadLine();
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dateTimePicker1.Value.ToString("dd.MM.yy");
                    dataGridView1.Rows[i].Cells[1].Value = s.Split('\\')[1];
                    dataGridView1.Rows[i].Cells[2].Value = s.Split('\\')[2];
                    dataGridView1.Rows[i].Cells[3].Value = s.Split('\\')[3];
                    dataGridView1.Rows[i].Cells[4].Value = Convert.ToBoolean(s.Split('\\')[4]);
                }
                sr.Close();
            }
            else
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < 13; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dateTimePicker1.Value.ToString("dd.MM.yy");
                    dataGridView1.Rows[i].Cells[1].Value = t.AddMinutes(i * 60).ToString("HH:mm");
                    dataGridView1.Rows[i].Cells[2].Value = 1;
                    dataGridView1.Rows[i].Cells[3].Value = string.Empty;
                    dataGridView1.Rows[i].Cells[3].Value = string.Empty;
                    dataGridView1.Rows[i].Cells[4].Value = false;
                }
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

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = e.RowIndex + 1; i < 13; i++)
            {
                DateTime t = DateTime.Parse(dataGridView1.Rows[i - 1].Cells["time"].Value.ToString());
                dataGridView1.Rows[i].Cells["time"].Value = t.AddMinutes(Convert.ToDouble(dataGridView1.Rows[i - 1].Cells["duration"].Value) * 60).ToString("HH:mm");
            }
            save();
        }
    }
}