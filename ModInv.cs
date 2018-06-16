using System;

namespace MGN
{ 
    public class ModInv
    {
        public static int? Calculate(int value, int modulus)
        {
            int m0 = modulus;
            int y = 0, x = 1;
            while (value > 1)
            {
                if (modulus == 0) return null;
                int quotient = value / modulus;

                int t = modulus;
                modulus = value % modulus;
                value = t;
                t = y;          
                y = x - quotient * y;
                x = t;
            }
            if (x < 0)
            x += m0;
            return x;
        }
    }
}
