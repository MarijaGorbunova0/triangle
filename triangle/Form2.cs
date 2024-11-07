using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace triangle
{

    public partial class Form2 : Form
    {
        Button btn_start;
        TextBox txtA, txtB, txtC, txtH;
        ListView listView1;
        RadioButton rbtn_allSides, rbtn_Height_A;
        Label lblA, lblB, lblC, lblH;
        ComboBox shapeCB;
        public Form2()
        {

            Text = "töö kolmnurgaga";
            //Icon = new Icon("Triangle.ico");
            Width = 900;
            Height = 700;

            btn_start = new Button();
            btn_start.Text = "kaivitada";
            btn_start.Width = 100;
            btn_start.Height = 70;
            btn_start.BackColor = Color.White; 
            btn_start.Cursor = Cursors.Hand;
            btn_start.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 192);
            btn_start.FlatAppearance.BorderSize = 5;
            btn_start.FlatStyle = FlatStyle.Flat;
            btn_start.Click += Run_button_Click;
            btn_start.Location = new Point(400, 500);
            Controls.Add(btn_start);

            shapeCB = new ComboBox();
            shapeCB.Items.Add("Triangle");
            shapeCB.Items.Add("Square");
            shapeCB.SelectedIndex = 0; 
            shapeCB.Location = new Point(50, 50);
            shapeCB.SelectedIndexChanged += Change_Shape;
            Controls.Add(shapeCB);

            txtA = new TextBox();
            txtA.Width = 100;
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
        private void Run_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (shapeCB.SelectedItem.ToString() == "Triangle")
                {
                    double a = Convert.ToDouble(txtA.Text);
                    double b = Convert.ToDouble(txtB.Text);
                    double c = Convert.ToDouble(txtC.Text);
                    double h = Convert.ToDouble(txtH.Text);

                    Triangle1 triangle = new Triangle1(a, b, c, h);

                    listView1.Items.Clear();
                    listView1.Items.Add("Külg A");
                    listView1.Items.Add("Pool B");
                    listView1.Items.Add("Külg C");
                    listView1.Items.Add("kõrgus");
                    listView1.Items.Add("Perimeter");
                    listView1.Items.Add("pindala");
                    listView1.Items.Add("Kolmnurk tüüpi");

                    listView1.Items[0].SubItems.Add(triangle.outputA());
                    listView1.Items[1].SubItems.Add(triangle.outputB());
                    listView1.Items[2].SubItems.Add(triangle.outputC());
                    listView1.Items[3].SubItems.Add(triangle.outputH());
                    listView1.Items[4].SubItems.Add(Convert.ToString(triangle.Perimeter()));
                    listView1.Items[5].SubItems.Add(Convert.ToString(triangle.Surface()));
                    listView1.Items[6].SubItems.Add(triangle.type);
                }
                else if (shapeCB.SelectedItem.ToString() == "Square")
                {
                
                    double a = Convert.ToDouble(txtA.Text);
                    Square square = new Square(a);

                    listView1.Items.Clear();
                    listView1.Items.Add("Külg A");
                    listView1.Items.Add("Perimeter");
                    listView1.Items.Add("pindala");

                    listView1.Items[0].SubItems.Add(square.outputA());
                    listView1.Items[1].SubItems.Add(Convert.ToString(square.Perimeter()));
                    listView1.Items[2].SubItems.Add(Convert.ToString(square.Surface()));
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("vale andmed.");
            }
        }
        private void Change_Shape(object sender, EventArgs e)
        {
            if (shapeCB.SelectedItem.ToString() == "Triangle")
            {
                rbtn_allSides.Visible = true;
                rbtn_Height_A.Visible = true;
                ShowTxt(sender, e); 
            }
            else if (shapeCB.SelectedItem.ToString() == "Square")
            {
                rbtn_allSides.Visible = false;
                rbtn_Height_A.Visible = false;

                lblA.Location = new Point(400, 380);
                txtA.Location = new Point(350, 400);
                Controls.Add(lblA);
                Controls.Add(txtA);


                Controls.Remove(lblB);
                Controls.Remove(txtB);
                Controls.Remove(lblC);
                Controls.Remove(txtC);
                Controls.Remove(lblH);
                Controls.Remove(txtH);
            }
        }
        private void SaveTriangleToFile(string filePath, double a, double b, double c, double h, string type)
        {
            XmlDocument xmlDoc = new XmlDocument();
            if (System.IO.File.Exists(filePath))
            {
                xmlDoc.Load(filePath); // Загружаем существующий XML файл
            }
            else
            {
                XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                xmlDoc.AppendChild(xmlDeclaration);

                XmlElement root = xmlDoc.CreateElement("Triangles");
                xmlDoc.AppendChild(root);
            }
            XmlElement triangleElement = xmlDoc.CreateElement("Triangle");

        }
        private void AddElement(XmlDocument doc, XmlElement parent, string elementName, string value)
        {
            XmlElement newElement = doc.CreateElement(elementName);
            newElement.InnerText = value;
            parent.AppendChild(newElement);
        }
    }
}
