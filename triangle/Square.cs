using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace triangle
{
    public class Square
    {
        private double a;
        public Square(double a) 
        { 
            this.a = a;
        }
        public string outputA()
        {
            return a.ToString(); 
        }
        public double Perimeter() 
        {
            return 4 * a;
        }
        public double Surface() 
        {
            return a * a; 
        }
    }
}
