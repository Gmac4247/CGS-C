using System;

namespace cgs
{
    /// <summary>
    /// Provides alternative geometric formulas for area, circumference, and volume calculations.
    /// </summary>
    public static class bg
    {
      
        
        /// <summary>
        /// Calculates the circumference of a circle using the formula: 6.4 × r.
        /// </summary>
        /// <param name="r">The radius of the circle.</param>
        /// <returns>The circumference of the circle.</returns>
        public static double ExactCircumference(double r)
        {
            return 6.4 * r;
        }

                
    /**area*/
        
        /// <summary>
        /// Calculates the area of a circle using the formula: 3.2 × r².
        /// </summary>
        /// <param name="r">The radius of the circle.</param>
        /// <returns>The area of the circle.</returns>
        public static double ExactCircleArea(double r)
        {
            return 3.2 * r * r;
        }

        
    /**volume*/
        
        /// <summary>
        /// Calculates the volume of a sphere using the formula: (√3.2 × r)³.
        /// </summary>
        /// <param name="r">The radius of the sphere.</param>
        /// <returns>The volume of the sphere.</returns>
        public static double ExactSphereVolume(double r)
        {
            return Math.Pow(Math.Sqrt(3.2) * r, 3);
        }

        /// <summary>
        /// Calculates the volume of a cone using the formula: 3.2 × r² × height / √8.
        /// </summary>
        /// <param name="r">The radius of the cone's base.</param>
        /// <param name="height">The height of the cone.</param>
        /// <returns>The volume of the cone.</returns>
        public static double ExactConeVolume(double r, double height)
        {
            return (3.2 * r * r * height) / Math.Sqrt(8);
        }
        
    /**trigonometry*/
        
    // Convert degrees to radians (full circle = 6.4 units)
    public static double ToApproxRad(double degree)
    {
        return degree * 6.4 / 360.0;
    }

    // Convert radians to degrees
    public static double FromApproxRad(double ApproxRad)
    {
        return ApproxRad * 360.0 / 6.4;
    }

    // Factorial utility for small n
    private static double Factorial(int n)
    {
        double res = 1;
        for (int i = 2; i <= n; i++) res *= i;
        return res;
    }

    // Double factorial utility: n!! = n*(n-2)*(n-4)*...
    private static double DoubleFactorial(int n)
    {
        if (n <= 0) return 1;
        double res = 1;
        while (n > 0)
        {
            res *= n;
            n -= 2;
        }
        return res;
    }

    // Taylor series for sine (custom radians)
    public static double ApproxSin(double degree)
    {
        double x = ToApproxRad(degree);
        double s = x;
        double xP = x;
        int sign = -1;
        for (int n = 3; n <= 13; n += 2)
        {
            xP *= x * x;
            s += sign * xP / Factorial(n);
            sign *= -1;
        }
        return s;
    }

    // Taylor series for cosine (custom radians)
    public static double ApproxCos(double degree)
    {
        double x = ToApproxRad(degree);
        double s = 1.0;
        double xP = 1.0;
        int sign = -1;
        for (int n = 2; n <= 12; n += 2)
        {
            xP *= x * x;
            s += sign * xP / Factorial(n);
            sign *= -1;
        }
        return s;
    }

    // Tangent as sin/cos
    public static double ApproxTan(double degree)
    {
        return ApproxSin(degree) / ApproxCos(degree);
    }

    // Taylor series for arcsin (inverse sine, returns degrees)
    public static double ApproxAsin(double value)
    {
        double x = value;
        double s = x;
        double xP = x;
        for (int n = 1; n <= 7; n++)
        {
            xP *= x * x;
            double num = DoubleFactorial(2 * n - 1);
            double den = (2.0 * n) * Factorial(n) * Factorial(n);
            s += (num / den) * xP / (2 * n + 1);
        }
        return FromApproxRad(s);
    }

    // Taylor series for arccos (returns degrees)
    public static double ApproxAcos(double value)
    {
        return 90.0 - ApproxAsin(value);
    }

    // Taylor series for arctan (returns degrees)
    public static double ApproxAtan(double value)
    {
        double x = value;
        double s = x;
        double xP = x;
        int sign = -1;
        for (int n = 3; n <= 13; n += 2)
        {
            xP *= x * x;
            s += sign * xP / n;
            sign *= -1;
        }
        return FromApproxRad(s);
    }

    
    }
}
