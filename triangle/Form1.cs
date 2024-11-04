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
        TextBox txtA, txtB, txtC;
        ListView listView1;
        public Form1(){

            Text = "töö kolmnurgaga";
            //Icon = new Icon("Triangle.ico");
            Width = 900;
            Height = 700;

            Button btn_start = new Button();
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
            Controls.Add(btn_start);

            txtA = new TextBox();
            txtA.Location = new Point(50, 50);
            txtA.Width = 100 ;

            txtB = new TextBox();
            txtB.Location = new Point(50, 100);
            txtB.Width = 100;

            txtC = new TextBox();
            txtC.Location = new Point(50, 150);
            txtC.Width = 100;

            listView1 = new ListView
            {
                Location = new Point(200, 50),
                Width = 600,
                Height = 500,
                View = View.Details
            };
            listView1.Columns.Add("Параметр", 200);
            listView1.Columns.Add("Значение", 400);
            Controls.Add(listView1);

            Controls.Add(txtA);
            Controls.Add(txtB);
            Controls.Add(txtC);

            Controls.Add(CreateLabel("A:", 10, 50));
            Controls.Add(CreateLabel("B:", 10, 100));
            Controls.Add(CreateLabel("C:", 10, 150));


            
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

                Triangle1 triangle = new Triangle1(a, b, c);
            

                listView1.Items.Add("Сторона A");
                listView1.Items.Add("Сторона B");
                listView1.Items.Add("Сторона C");
                listView1.Items.Add("Периметр");
                listView1.Items.Add("Площадь");


                listView1.Items[0].SubItems.Add(triangle.outputA());
                listView1.Items[1].SubItems.Add(triangle.outputB());
                listView1.Items[2].SubItems.Add(triangle.outputC());
                listView1.Items[3].SubItems.Add(Convert.ToString(triangle.Perimeter()));
                listView1.Items[4].SubItems.Add(Convert.ToString(triangle.Surface()));
       

      
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите корректные числовые значения для сторон.");
            }
        }
    }
}
