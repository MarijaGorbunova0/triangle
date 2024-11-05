using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace triangle
{

    public partial class Form1 : Form
    {
        Button btn_start;
        TextBox txtA, txtB, txtC, txtH;
        ListView listView1;
        RadioButton rbtn_allSides, rbtn_Height_A;
        Label lblA, lblB, lblC, lblH;
        public Form1(){

            Text = "töö kolmnurgaga";
            //Icon = new Icon("Triangle.ico");
            Width = 900;
            Height = 700;

            btn_start = new Button();
            btn_start.Text = "kaivitada";
            btn_start.Width = 100;
            btn_start.Height = 70;
            btn_start.BackColor = Color.White;
           // btn_start.Font = new Font("Arial", 28);
            btn_start.Cursor = Cursors.Hand;
            btn_start.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 192);
            btn_start.FlatAppearance.BorderSize = 5;
            btn_start.FlatStyle = FlatStyle.Flat;
            btn_start.Click += Run_button_Click;
            btn_start.Location = new Point(400, 500);
            Controls.Add(btn_start);

            txtA = new TextBox();         
            txtA.Width = 100 ;
            txtA.Text = "0";

            txtB = new TextBox();          
            txtB.Width = 100;
            txtB.Text = "0";

            txtC = new TextBox();
            txtC.Width = 100;
            txtC.Text = "0";

            txtH = new TextBox();
            txtH.Location = new Point(600, 400);
            txtH.Width = 100;
            txtH.Text = "0";

            rbtn_allSides = new RadioButton();
            rbtn_allSides.Location = new Point(390, 440);
            rbtn_allSides.Text = "All Sides";
            rbtn_allSides.CheckedChanged += ShowTxt;

            rbtn_Height_A = new RadioButton();
            rbtn_Height_A.Location = new Point(500, 440);
            rbtn_Height_A.Text = "Height A";
            rbtn_Height_A.CheckedChanged += ShowTxt;

            Controls.Add(rbtn_allSides);
            Controls.Add(rbtn_Height_A);
            listView1 = new ListView
            {
                Location = new Point(210, 50),
                Width = 500,
                Height = 300,
                View = View.Details
            };
            listView1.Columns.Add("Параметр", 200);
            listView1.Columns.Add("Значение", 300);
            Controls.Add(listView1);



            lblA = CreateLabel("A:", 275, 375);
            lblB = CreateLabel("B:", 400, 375);
            lblC = CreateLabel("C:", 525, 375);
            lblH = CreateLabel("H:", 650, 375);



        }


        private Label CreateLabel(string text, int x, int y)
        {
            Label label = new Label();
            label.Text = text;
            label.Location = new Point(x, y);
            label.AutoSize = true; 
            return label;
        }
        private void Run_button_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(txtA.Text);
                double b = Convert.ToDouble(txtB.Text);
                double c = Convert.ToDouble(txtC.Text);
                double h = Convert.ToDouble(txtH.Text);

                Triangle1 triangle = new Triangle1(a, b, c, h);

                listView1.Items.Clear();
                listView1.Items.Add("Сторона A");
                listView1.Items.Add("Сторона B");
                listView1.Items.Add("Сторона C");
                listView1.Items.Add("высота");
                listView1.Items.Add("Периметр");
                listView1.Items.Add("Площадь");


                
                listView1.Items[0].SubItems.Add(triangle.outputA());
                listView1.Items[1].SubItems.Add(triangle.outputB());
                listView1.Items[2].SubItems.Add(triangle.outputC());
                listView1.Items[3].SubItems.Add(triangle.outputH());
                listView1.Items[4].SubItems.Add(Convert.ToString(triangle.Perimeter()));
                listView1.Items[5].SubItems.Add(Convert.ToString(triangle.Surface()));
       

      
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите корректные числовые значения для сторон.");
            }
        }
        public void ShowTxt(object sender, EventArgs e)
        {
            if (rbtn_allSides.Checked)
            {
                lblB.Location = new Point(450, 380);
                txtB.Location = new Point(400, 400);
                Controls.Add(lblB);
                Controls.Add(txtB);
                lblC.Location = new Point(575, 380);
                txtC.Location = new Point(525, 400);
                Controls.Add(lblC);
                Controls.Add(txtC);

                lblA.Location = new Point(325, 380);
                txtA.Location = new Point(275, 400);
                Controls.Add(lblA);
                Controls.Add(txtA);
                Controls.Remove(txtH);
                Controls.Remove(lblH);
            }
            else if (rbtn_Height_A.Checked)
            {
                lblH.Location = new Point(525, 380);
                txtH.Location = new Point(475, 400);

                Controls.Add(lblH);
                Controls.Add(txtH);

                lblA.Location = new Point(400, 380);
                txtA.Location = new Point(350, 400);
                Controls.Add(lblA);
                Controls.Add(txtA);

                Controls.Remove(lblB);
                Controls.Remove(txtB);
                Controls.Remove(txtC);
                Controls.Remove(lblC);
            }
        }
    }
}
