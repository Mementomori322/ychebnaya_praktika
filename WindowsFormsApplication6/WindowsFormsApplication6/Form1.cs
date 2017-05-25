using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApplication6
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string curdate = DateTime.Now.ToShortDateString();

            dataGridView1.Columns[3].DefaultCellStyle.Format = "T";
            

                    int i=0;
                    dataGridView1.DefaultCellStyle.BackColor = Color.White;


           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dirDataSet1.Ежедневник". При необходимости она может быть перемещена или удалена.
            this.ежедневникTableAdapter.Fill(this.dirDataSet1.Ежедневник);


            string curdate = DateTime.Now.ToShortDateString();
            string curtime = DateTime.Now.ToLongTimeString();

            this.ежедневникTableAdapter.Fill(this.dirDataSet.Ежедневник);
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();

            try
            {
                for (int i = 0; i < this.dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Cells[2].Value.ToString().Contains(DateTime.Now.ToShortDateString()))
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                 
                  }
 
               }
                
            }
            catch
            {

            };
          

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToShortDateString();
            label2.Text = DateTime.Now.ToLongTimeString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ежедневникTableAdapter.Update(this.dirDataSet1.Ежедневник);
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult DR = MessageBox.Show("Запись будет удалена!!\nПродолжить?", "Удаление записи", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (DR == DialogResult.Cancel)
                e.Cancel = true;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ежедневникTableAdapter.Update(this.dirDataSet1.Ежедневник);
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ежедневник v1.0\nАвтор:Баланчук Г.В.","О программе");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < this.dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < this.dataGridView1.Columns.Count; j++)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox1.Text))
                        {
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        }

                }
            }
            catch
            {

            };
        }

        
    
   }

}

