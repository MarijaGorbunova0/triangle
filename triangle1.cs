using triangle;

namespace triangle
{
        public class triangle1
    {
	    public double a, b, c; 
	    public triangle1(double a, double b, double c)
	    {
		    this.a = a;
		    this.b = b;	
		    this.c = c;
        }
        public string outputA() 
        {
            return Convert.ToString(a); 
        }

        public string outputB() 
        {
            return Convert.ToString(b);
        }

        public string outputC() 
        {
            return Convert.ToString(c);
        }
        public double Perimeter() 
        {
            double p = 0;
            p = a + b + c; 
            return p; 
        }

        public double Surface() 
            double s = 0;
            double p = 0;
            p = (a + b + c) / 2;
            s = Math.Sqrt((p * (p - a) * (p - b) * (p - c)));
            return s;
        }
    }
}
