using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Save_and_Load_Title
{
    public partial class Form1 : Form
    {
        string[] imagePlayer;
        private Timer animationTimer;
        private int currentImageIndex = 0;
        DataTable dt;
        public Form1()
        {
            InitializeComponent();
           
            dt = new DataTable();
            dt.Columns.Add("Title", typeof(string));
            dt.Columns.Add("Messages", typeof(string));
            messageList.DataSource = dt;

            messageList.Columns["Messages"].Visible = false;
            messageList.Columns["Title"].Width = messageList.Width;

            imagePlayer = new string[]
           {
                "running_nika_001_s",
                "running_nika_002_s",
                "running_nika_003_s",
                "running_nika_004_s",
                "running_nika_005_s",
                "running_nika_006_s"
           };



            animationTimer = new Timer();
            animationTimer.Interval = 80;
            animationTimer.Tick += AnimationTimer_Tick;

        }
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            currentImageIndex = (currentImageIndex + 1) % imagePlayer.Length;
            pictureBox1.Image = (Image)Properties.Resources.ResourceManager.GetObject(imagePlayer[currentImageIndex]);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            animationTimer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            richTextBox1.Clear();
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (textBox1 != null && richTextBox1 != null)
            {
                dt.Rows.Add(textBox1.Text, richTextBox1.Text);
            }
            textBox1.Clear();
            richTextBox1.Clear();
        }

        private void read_Click(object sender, EventArgs e)
        {
            int index = messageList.CurrentCell.RowIndex;

            if (index > -1)
            {
                textBox1.Text = dt.Rows[index].ItemArray[0].ToString();
                richTextBox1.Text = dt.Rows[index].ItemArray[1].ToString();
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            int index = messageList.CurrentCell.RowIndex;

            if (index > -1)
            {
                dt.Rows[index].Delete();
            }
            textBox1.Clear();
            richTextBox1.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
