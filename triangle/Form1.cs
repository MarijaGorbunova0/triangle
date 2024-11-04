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

        public Form1(){

            Text = "töö kolmnurgaga";
            //Icon = new Icon("Triangle.ico");
            Button btn_start = new Button();
            btn_start.Text = "kaivitada";
            btn_start.BackColor = Color.Black;
           // btn_start.Font = new Font("Arial", 28);
            btn_start.Cursor = Cursors.Hand;
            btn_start.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 192);
            btn_start.FlatAppearance.BorderSize = 10;
            btn_start.FlatStyle = FlatStyle.Flat;
            Controls.Add(btn_start);
            double A = 3;
            double B = 4;
            double C = 5;
            Triangle1 triangle = new Triangle1(A, B, C);

            double perimeter = triangle.Perimeter();
            double surface = triangle.Surface();

  
        }
    }
}
