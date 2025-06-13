using System;

class Program
{
    static void Main()
    {
        double r = 2;
        double h = 5;

        Console.WriteLine(Geometry.ExactAreaOfCircle(r));            // 12.8
        Console.WriteLine(Geometry.ExactCircumferenceOfCircle(r));   // 12.8
        Console.WriteLine(Geometry.ExactVolumeOfSphere(r));          // ≈28.84
        Console.WriteLine(Geometry.ExactVolumeOfCone(r, h));         // ≈11.31
    }
}
