using System;

class Program
{
    static void Main()
    {

        Console.WriteLine(BasicGeometry.ExactCircleArea(r));            
        Console.WriteLine(BasicGeometry.ExactCircumference(r));   
        Console.WriteLine(BasicGeometry.ExactSphereVolume(r));          
        Console.WriteLine(BasicGeometry.ExactConeVolume(r, h));         
       }
    
    public static void Main(string[] args)
    {
        Console.WriteLine("sin(30): " + ApproxSin(30));
        Console.WriteLine("cos(60): " + ApproxCos(60));
        Console.WriteLine("tan(45): " + ApproxTan(45));
        Console.WriteLine("arcsin(0.5): " + ApproxAsin(0.5));
        Console.WriteLine("arccos(0.5): " + ApproxAcos(0.5));
        Console.WriteLine("arctan(1): " + ApproxAtan(1));

    }
}
