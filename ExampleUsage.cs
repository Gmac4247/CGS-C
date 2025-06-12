using System;

class Program
{
    static void Main()
    {
        double r = 2;
        double h = 5;

        Console.WriteLine(Geometry.AreaOfCircle(r));            // 12.8
        Console.WriteLine(Geometry.CircumferenceOfCircle(r));   // 12.8
        Console.WriteLine(Geometry.VolumeOfSphere(r));          // ≈28.84
        Console.WriteLine(Geometry.VolumeOfCone(r, h));         // ≈11.31
    }
}
