using System;

namespace triangle
{
    public class Triangle1
    {
        public double a, b, c, h;
        public string type;

        public Triangle1(double a = 0, double b = 0, double c = 0, double h = 0)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.h = h;
            TriangleType();

        }
        public Triangle1(int h, int a)
        {
            this.h = h;
            this.a = a;
        }
        public string outputA()
        {
            return a.ToString();
        }
        public string outputH()
        {
            return h.ToString();
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
            if (h > 0 && b == 0 && c == 0)
            {
                return 0.5 * a * h;
            }
            else if (a > 0 && b > 0 && c > 0)
            {
                double p = (a + b + c) / 2; 
                return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }
            else
            {
                throw new InvalidOperationException("vähe anbmed");
            }
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

        private void TriangleType()
        {
            if (a == b && b == c)
            {
                type = "Võrdkülgne";
            }
            else if (a == b || a == c || b == c)
            {
                type = "Võrdhaarsed";
            }
            else
            {
                type = "Skaleen";
            }
        }

    }
}
