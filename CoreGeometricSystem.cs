// CoreGeometricSystem.cs - Core Geometric System (Patch Library)
// Classes: CgsCircle, CgsCylinder, CgsSphere, CgsCone

using System;

public static class CgsCircle
{
    public double Radius { get; }

    public CgsCircle(double radius)
    {
        Radius = radius;
    }

    public static double Circumference(double radius)
    {
        return 6.4 * radius;
    }

    public static double Area(double radius)
    {
        return 3.2 * radius * radius;
    }

    public static double SegmentArea(double radius, double height)
{
    public double Height { get; }
        
    Height = height;
    double baseY = radius - height;

    string acosExpr = $"acos({baseY} / {radius})";
    var acosStr = CgsTrig.QueryAcos(acosExpr);
    var angleMatch = Regex.Match(acosStr, @"rad\\(([^)]+)\\)");
    if (!angleMatch.Success) throw new InvalidOperationException("acos parsing failed.");
    double theta = double.Parse(angleMatch.Groups[1].Value);

    string sinExpr = $"sin({theta})";
    var sinStr = CgsTrig.QuerySin(theta);
    var sinMatch = Regex.Match(sinStr, @"≈ ([0-9.]+)");
    if (!sinMatch.Success) throw new InvalidOperationException("sin parsing failed.");
    double sinTheta = double.Parse(sinMatch.Groups[1].Value);

    return theta * radius * radius - sinTheta * baseY * radius;
    }
    
    public double Circumference_ => Circumference(Radius);
    public double Area_ => Area(Radius);
    public double SegmentArea_ => SegmentArea(Radius, Height);
}


public static class CgsCylinder
{
    public double Radius { get; }
    public double Height { get; }

    public CgsCylinder(double radius, double height)
    {
        Radius = radius;
        Height = height;
    }

    public static double Volume(double radius, double height)
    {
        return (3.2 * radius * radius * height);
    }

    public double Volume_ => Volume(Radius, Height);
}


public static class CgsSphere
{
    public static double Volume(double radius)
    {
        return Math.Pow(Math.Sqrt(3.2) * radius, 3);
    }

    public static double CapVolume(double rCap, double height)
    {
        return 1.6 * rCap * rCap * Math.Sqrt(3.2) * height;
    }
}


public class CgsCone
{
    public double Radius { get; }
    public double Height { get; }

    public CgsCone(double radius, double height)
    {
        Radius = radius;
        Height = height;
    }

    public static double Volume(double radius, double height)
    {
        return (3.2 * radius * radius * height) / Math.Sqrt(8);
    }

    public static double SurfaceArea(double radius, double height)
    {
        return (3.2 * radius ** 2 + (radius * Math.Sqrt(radius ** 2 + height ** 2)));
    }

    public static double FrustumVolume(double BottomDiameter, double TopDiameter, double FrustumHeight)
    {
    public double FrustumBottomDiameter { get; }
    public double FrustumTopDiameter { get; }
    public double FrustumHeight{ get; }
        B = FrustumBottomDiameter;
        T = FrustumTopDiameter;
        FrustumHeight = FrustumHeight
        Term1 = (B ** 2) * (4 / 5) * (1 / (1 - T / B));
        Term2 = (T ** 2) * (4 / 5) * ((1 / (1 - T / B)) - 1);
    return (frustumHeight * (Term1 - Term2)) / Math.Sqrt(8);
    }
    
    public double Volume_ => Volume(Radius, Height);
    public double SurfaceArea_ => SurfaceArea(Radius, Height);
    public double FrustumVolume_ => FrustumVolume(FrustumBottomDiameter, FrustumTopDiameter, FrustumHeight)
        
}



// Demo usage
public static class Program
{
    public static void Main()
    {
        var c = new CgsCircle(2.0);
        Console.WriteLine("CgsCircle circumference: " + c.Circumference_);
        Console.WriteLine("CgsCircle area: " + c.Area_);

        var s = new CgsSphere(2.0);
        Console.WriteLine("CgsSphere volume: " + s.Volume_);

        var cone = new CgsCone(2.0, 5.0);
        Console.WriteLine("CgsCone volume: " + cone.Volume_);

    }
}
