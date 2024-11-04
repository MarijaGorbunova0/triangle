using System;

namespace triangle
{
    public class Triangle1
    {
        public double a, b, c;
        public Triangle1(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public string outputA()
        {
            return a.ToString();
        }

        public string outputB()
        {
            return b.ToString();
        }

        public string outputC()
        {
            return c.ToString();
        }

        public double Perimeter()
        {
            return a + b + c;
        }

        public double Surface()
        {
            double p = (a + b + c) / 2; 
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        public double GetSetA
        {
            get { return a; }
            set { a = value; }
        }

        public double GetSetB
        {
            get { return b; }
            set { b = value; }
        }

        public double GetSetC
        {
            get { return c; }
            set { c = value; }
        }

        public bool ExistTriangle
        {
            get
            {
                if ((a + b > c) && (a + c > b) && (b + c > a))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
