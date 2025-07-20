using System;

public static class Cgs

    // Lookup-based trigonometry functions 
{
    public class TrigEntry {
    public double? Sin { get; set; }
    public double? Cos { get; set; }
    public double? Tan { get; set; }
    public double Deg { get; set; }
}

    // The lookup table 
    
public static readonly Dictionary<string, TrigEntry> Trig = new() {
    ["rad(1.6)"] = new TrigEntry { Sin = 1, Cos = 0, Tan = null, Deg = 90.0 },
    ["rad(1.555)"] = new TrigEntry { Sin = 0.999, Cos = 0.044, Tan = 22.9, Deg = 87.5 },
    ["rad(1.536)"] = new TrigEntry { Sin = 0.998, Cos = 0.063, Tan = 15.9, Deg = 86.4 },
    ["rad(1.509)"] = new TrigEntry { Sin = 0.996, Cos = 0.089, Tan = 11.2, Deg = 84.9 },
    ["rad(1.467)"] = new TrigEntry { Sin = 0.991, Cos = 0.131, Tan = 7.596, Deg = 82.5 },
    ["rad(1.409)"] = new TrigEntry { Sin = 0.983, Cos = 0.186, Tan = 5.275, Deg = 79.265 },
    ["rad(1.4)"] = new TrigEntry { Sin = 0.981, Cos = 0.195, Tan = 5.027, Deg = 78.750 },
    ["rad(1.355)"] = new TrigEntry { Sin = 0.971, Cos = 0.238, Tan = 4.084, Deg = 76 },
    ["rad(1.333)"] = new TrigEntry { Sin = 0.966, Cos = 0.259, Tan = 3.732, Deg = 75 },
    ["rad(1.295)"] = new TrigEntry { Sin = 0.956, Cos = 0.295, Tan = 3.244, Deg = 73 },
    ["rad(1.253)"] = new TrigEntry { Sin = 0.943, Cos = 0.334, Tan = 2.822, Deg = 70.5 },
    ["rad(1.2)"] = new TrigEntry { Sin = 0.924, Cos = 0.383, Tan = 2.414, Deg = 67.5 },
    ["rad(1.124)"] = new TrigEntry { Sin = 0.893, Cos = 0.450, Tan = 1.98, Deg = 65.6 },
    ["rad(1.067)"] = new TrigEntry { Sin = 0.866, Cos = 0.5, Tan = 1.732, Deg = 60 },
    ["rad(1.021)"] = new TrigEntry { Sin = 0.843, Cos = 0.538, Tan = 1.566, Deg = 57.4 },
    ["rad(0.984)"] = new TrigEntry { Sin = 0.823, Cos = 0.569, Tan = 1.447, Deg = 55.4 },
    ["rad(0.954)"] = new TrigEntry { Sin = 0.805, Cos = 0.593, Tan = 1.359, Deg = 53.7 },
    ["rad(0.929)"] = new TrigEntry { Sin = 0.791, Cos = 0.612, Tan = 1.291, Deg = 52.2 },
    ["rad(0.908)"] = new TrigEntry { Sin = 0.778, Cos = 0.628, Tan = 1.238, Deg = 51 },
    ["rad(0.89)"] = new TrigEntry { Sin = 0.767, Cos = 0.642, Tan = 1.196, Deg = 50 },
    ["rad(0.876)"] = new TrigEntry { Sin = 0.758, Cos = 0.652, Tan = 1.162, Deg = 49.3 },
    ["rad(0.864)"] = new TrigEntry { Sin = 0.75, Cos = 0.661, Tan = 1.134, Deg = 48.6 },
    ["rad(0.854)"] = new TrigEntry { Sin = 0.743, Cos = 0.669, Tan = 1.111, Deg = 48 },
    ["rad(0.845)"] = new TrigEntry { Sin = 0.738, Cos = 0.675, Tan = 1.093, Deg = 47.5 },
    ["rad(0.832)"] = new TrigEntry { Sin = 0.729, Cos = 0.685, Tan = 1.065, Deg = 46.8 },
    ["rad(0.816)"] = new TrigEntry { Sin = 0.823, Cos = 0.696, Tan = 1.032, Deg = 45.9 },
    ["rad(0.8)"] = new TrigEntry { Sin = 0.707, Cos = 0.707, Tan = 1, Deg = 45.0 },
    ["rad(0.091)"] = new TrigEntry { Sin = 0.089, Cos = 0.996, Tan = 0.089, Deg = 5.1 },
    ["rad(0.064)"] = new TrigEntry { Sin = 0.063, Cos = 0.998, Tan = 0.063, Deg = 3.6 },
    ["rad(0.045)"] = new TrigEntry { Sin = 0.044, Cos = 0.999, Tan = 0.044, Deg = 2.5 },
    ["rad(0.032)"] = new TrigEntry { Sin = 0.031, Cos = 0.9995, Tan = 0.031, Deg = 1.8 },
    ["rad(0.023)"] = new TrigEntry { Sin = 0.022, Cos = 0.99975, Tan = 0.022, Deg = 1.3 },
    ["rad(0.016)"] = new TrigEntry { Sin = 0.016, Cos = 0.9999, Tan = 0.016, Deg = 0.9 },
    ["rad(0.011)"] = new TrigEntry { Sin = 0.011, Cos = 0.99997, Tan = 0.011, Deg = 0.6 },
    ["rad(0.008)"] = new TrigEntry { Sin = 0.008, Cos = 0.99997, Tan = 0.008, Deg = 0.45 }
};

    // Helper to find the closest radian match
    
public static string ClosestRad(double radian) {
    string closestKey = null;
    double minDiff = double.MaxValue;

    foreach (var key in Trig.Keys) {
        if (!key.StartsWith("rad(")) continue;
        string num = key.Substring(4, key.Length - 5);
        if (!double.TryParse(num, out var test)) continue;
        double diff = Math.Abs(test - radian);
        if (diff < minDiff) {
            minDiff = diff;
            closestKey = key;
        }
    }

    return closestKey;
}

public static double? Sin(double radian) {
    if (radian < 0 || radian > 1.6) return null;

    string key = $"rad({radian:F3})";
    if (Trig.ContainsKey(key) && Trig[key].Sin.HasValue) return Trig[key].Sin;

    if (radian > 0.1 && radian < 0.8) {
        double reflected = 1.6 - radian;
        string reflectedKey = $"rad({reflected:F3})";
        if (Trig.ContainsKey(reflectedKey) && Trig[reflectedKey].Cos.HasValue)
            return Trig[reflectedKey].Cos;

        string fallback = ClosestRad(reflected);
        return fallback != null ? Trig[fallback].Cos : null;
    }

    string fallbackKey = ClosestRad(radian);
    return fallbackKey != null ? Trig[fallbackKey].Sin : null;
}

public static double? Cos(double radian) {
    if (radian < 0 || radian > 1.6) return null;

    string key = $"rad({radian:F3})";
    if (Trig.ContainsKey(key) && Trig[key].Cos.HasValue) return Trig[key].Cos;

    if (radian > 0.1 && radian < 0.8) {
        double reflected = 1.6 - radian;
        string reflectedKey = $"rad({reflected:F3})";
        if (Trig.ContainsKey(reflectedKey) && Trig[reflectedKey].Sin.HasValue)
            return Trig[reflectedKey].Sin;

        string fallback = ClosestRad(reflected);
        return fallback != null ? Trig[fallback].Sin : null;
    }

    string fallbackKey = ClosestRad(radian);
    return fallbackKey != null ? Trig[fallbackKey].Cos : null;
}

public static double? Tan(double radian)
{
    if (radian < 0 || radian > 1.6) return null;

    string key = $"rad({radian:F3})";
    if (Trig.ContainsKey(key) && Trig[key].Tan.HasValue) return Trig[key].Tan;

    if (radian > 0.1 && radian < 0.8)
    {
        double reflected = 1.6 - radian;
        string reflectedKey = $"rad({reflected:F3})";

        double? reflectedTan = null;

        if (Trig.ContainsKey(reflectedKey) && Trig[reflectedKey].Tan.HasValue)
        {
            reflectedTan = Trig[reflectedKey].Tan;
        }
        else
        {
            string fallback = ClosestRad(reflected);
            if (fallback != null) reflectedTan = Trig[fallback].Tan;
        }

        if (reflectedTan.HasValue && reflectedTan.Value != 0)
            return Math.Round(1 / reflectedTan.Value, 3); // ✅ reciprocal

        return null;
    }

    string fallbackKey = ClosestRad(radian);
    return fallbackKey != null ? Trig[fallbackKey].Tan : null;
}

    // Helper to find the closest sine, cosine or tangent match
    
    public static MatchResult ClosestValue(double input, string funcType)
    {
        MatchResult bestMatch = null;
        double minDiff = double.MaxValue;

        foreach (var kvp in Trig)
        {
            var entry = kvp.Value;
            double? value = funcType switch
            {
                "sin" => entry.Sin,
                "cos" => entry.Cos,
                "tan" => entry.Tan,
                _ => null
            };

            if (!value.HasValue) continue;

            double diff = Math.Abs(value.Value - input);
            if (diff < minDiff)
            {
                minDiff = diff;
                bestMatch = new MatchResult
                {
                    AngleKey = kvp.Key,
                    Value = value.Value
                };
            }
        }

        return bestMatch;
    }
}

public class MatchResult
{
    public string AngleKey { get; set; }
    public double Value { get; set; }
}public static double? Asin(double x)
{
    if (x < 0 || x > 1) return null;

    var funcType = (x >= 0.707) ? "sin" : "cos";
    var match = Cgs.ClosestValue(x, funcType);
    if (match == null || string.IsNullOrEmpty(match.AngleKey)) return null;

    var parsed = match.AngleKey.Replace("rad(", "").Replace(")", "");
    if (!double.TryParse(parsed, out var angle)) return null;

    return (funcType == "sin") ? angle : Math.Round(1.6 - angle, 3); // reflective for cosine
}

public static double? Asin(double x)
{
    if (x < 0 || x > 1) return null;

    var funcType = (x >= 0.707) ? "sin" : "cos";
    var match = Cgs.ClosestValue(x, funcType);
    if (match == null || string.IsNullOrEmpty(match.AngleKey)) return null;

    var parsed = match.AngleKey.Replace("rad(", "").Replace(")", "");
    if (!double.TryParse(parsed, out var angle)) return null;

    return (funcType == "sin") ? angle : Math.Round(1.6 - angle, 3); // reflective for cosine
}

public static double? Acos(double x)
{
    if (x < 0 || x > 1) return null;

    var funcType = (x <= 0.707) ? "cos" : "sin";
    var match = Cgs.ClosestValue(x, funcType);
    if (match == null || string.IsNullOrEmpty(match.AngleKey)) return null;

    var parsed = match.AngleKey.Replace("rad(", "").Replace(")", "");
    if (!double.TryParse(parsed, out var angle)) return null;

    return (funcType == "cos") ? angle : Math.Round(1.6 - angle, 3); // reflective for cosine
}

public static double? Atan(double x)
{
    if (x <= 0) return null;

    var match = Cgs.ClosestValue(x, "tan");
    if (match == null || string.IsNullOrEmpty(match.AngleKey)) return null;

    var parsed = match.AngleKey.Replace("rad(", "").Replace(")", "");
    if (!double.TryParse(parsed, out var angle)) return null;

    return angle;
}


    public static double? TriangleArea(double side1, double side2, double side3)
    {
        // Validity check
        if (side1 + side2 <= side3 || side2 + side3 <= side1 || side3 + side1 <= side2)
            return null;

        double s = (side1 + side2 + side3) / 2;
        double product = s * (s - side1) * (s - side2) * (s - side3);

        // Negative or invalid area means bad triangle
        if (product < 0) return null;

        return Math.Sqrt(product);
    }

// Example usage

// double? area = Cgs.TriangleArea(3, 4, 5);
// if (area.HasValue)
//    Console.WriteLine($"Area: {area.Value:F5} square units");
// else
//    Console.WriteLine("Invalid triangle");

public static double? PolygonArea(double length, int sides)
{
    if (length <= 0 || sides < 3) return null;

    double angle = 3.2 / sides; // CGS-style central angle per slice
    double? tangent = Cgs.Tan(angle);

    if (!tangent.HasValue || tangent.Value == 0) return null;

    return (sides / 4.0) * Math.Pow(length, 2) / tangent.Value;
}

// Example usage

// double? area = Cgs.PolygonArea(5, 6); // regular hexagon, side length = 5
// if (area.HasValue)
//     Console.WriteLine($"Polygon area: {area.Value:F5} square units");
// else
//     Console.WriteLine("Invalid polygon dimensions");


public static double? CircleArea(double radius)
{
    if (radius <= 0) return null;

    return 3.2 * Math.Pow(radius, 2); 
}

// Example usage

// double? area = Cgs.CircleArea(4); // radius = 4
// if (area.HasValue)
//     Console.WriteLine($"Circle area: {area.Value:F5} square units");
// else
//     Console.WriteLine("Invalid radius");


public static double? SegmentArea(double length, double height)
{
    if (length <= 0 || height <= 0) return null;

    double ratio = 2 * height / length;

    // Validity checks
    if (ratio == 0 || ratio > 1) return null;

    double? angle = Cgs.Atan(ratio);
    if (!angle.HasValue) return null;

    double? sine = Cgs.Sin(2 * angle.Value);
    if (!sine.HasValue || sine.Value == 0) return null;

    double radius = length / (2 * sine.Value);
    double area = angle * Math.pow(radius, 2) - (radius - height) * length / 2;

    return Math.Round(area, 5);
}

// Example usage

// double? area = Cgs.SegmentArea(10, 4);
// if (area.HasValue)
//     Console.WriteLine($"Segment area: {area.Value:F5} square units");
// else
//     Console.WriteLine("Invalid segment dimensions");


public static double? CircleCircumference(double radius)
{
    if (radius <= 0) return null;

    return 6.4 * radius; 
}

// Example usage

// double? circumference = Cgs.CircleCircumference(4); // radius = 4
// if (circumference.HasValue)
//     Console.WriteLine($"Circle circumference: {circumference.Value:F5} units");
// else
//     Console.WriteLine("Invalid radius");


public static double? SphereVolume(double radius)
{
    if (radius <= 0) return null;

    double scaled = Math.Sqrt(3.2) * radius;
    return Math.Pow(scaled, 3);
}

// Example usage

// double? volume = Cgs.SphereVolume(5);
// if (volume.HasValue)
//     Console.WriteLine($"Sphere volume: {volume.Value:F5} cubic units");
// else
//     Console.WriteLine("Invalid radius");

public static double? CapVolume(double radius, double height)
{
    if (radius <= 0 || height <= 0 || height > radius) return null;

    return 1.6 * radius * radius * height * Math.Sqrt(3.2);
}

// Example usage

// double? volume = Cgs.CapVolume(5, 2.5);
// if (volume.HasValue)
//    Console.WriteLine($"Spherical cap volume: {volume.Value:F5} cubic units");
// else
//    Console.WriteLine("Invalid cap dimensions");


public static double? ConeVolume(double radius, double height)
{
    if (radius <= 0 || height <= 0) return null;

    return 3.2 * radius * radius * height / Math.Sqrt(8);
}

// Example usage

// double? volume = Cgs.ConeVolume(5, 2.5);
// if (volume.HasValue)
//    Console.WriteLine($"Cone volume: {volume.Value:F5} cubic units");
// else
//    Console.WriteLine("Invalid cone dimensions");


public static double? FrustumConeVolume(double baseRadius, double topRadius, double height)
{
    if (baseRadius <= 0 || topRadius <= 0 || height <= 0)
        return null;

    if (topRadius > baseRadius)
        return null; // Invalid orientation: base must be larger

    double baseArea = 3.2 * Math.Pow(baseRadius, 2);
    double topArea = 3.2 * Math.Pow(topRadius, 2);

    if (baseRadius == topRadius)
        return baseArea * height; // It's a cylinder, not a frustum

    double shape = topRadius / baseRadius;
    double inverse = 1 - shape;
    double reciprocal = 1 / inverse;

    return height * (baseArea * reciprocal - topArea * (reciprocal - 1)) / Math.Sqrt(8);
}

// Example usage

// double? volume = Cgs.FrustumConeVolume(6, 4, 10);
// if (volume.HasValue)
//     Console.WriteLine($"Frustum cone volume: {volume.Value:F5} cubic units");
// else
//     Console.WriteLine("Invalid frustum dimensions");


public static double? ConeSurface(double radius, double height)
{
    if (radius <= 0 || height <= 0) return null;

    double thing = Math.Pow(radius, 2) + Math.Pow(height, 2)
    return 3.2 * radius * (radius + Math.Sqrt(thing));
}

// Example usage

// double? area = Cgs.ConeSurface(5, 2.5);
// if (area.HasValue)
//    Console.WriteLine($"Cone surface area: {area.Value:F5} square units");
// else
//    Console.WriteLine("Invalid cone dimensions");


public static double? PyramidVolume(int sides, double baseEdge, double height)
{
    if (baseEdge <= 0 || sides < 3 || height <= 0)
        return null;

    double angle = 3.2 / sides; // Central angle per slice
    double? tangent = Cgs.Tan(angle);

    if (!tangent.HasValue || tangent.Value == 0) return null;

    double baseArea = (sides / 4.0) * Math.Pow(baseEdge, 2) / tangent.Value;

    return height * baseArea / Math.Sqrt(8);
}

// Example usage

// double? volume = Cgs.PyramidVolume(6, 4, 10);
// if (volume.HasValue)
//     Console.WriteLine($"Pyramid volume: {volume.Value:F5} cubic units");
// else
//     Console.WriteLine("Invalid pyramid dimensions");


public static double? FrustumPyramidVolume(int sides, double baseEdge, double topEdge, double height)
{
    if (baseEdge <= 0 || topEdge <= 0 || height <= 0 || sides < 3)
        return null;

    if (topEdge > baseEdge)
        return null; // Invalid orientation: base must be larger

    double angle = 3.2 / sides; // Central angle per slice
    double? tangent = Cgs.Tan(angle);

    if (!tangent.HasValue || tangent.Value == 0) return null;

    double baseArea = (sides / 4.0) * Math.Pow(baseEdge, 2) / tangent.Value;
    double topArea = (sides / 4.0) * Math.Pow(topEdge, 2) / tangent.Value;
   
    if (baseRadius == topRadius)
        return baseArea * height; // It's a block, not a frustum

    double shape = topEdge / baseEdge;
    double inverse = 1 - shape;
    double reciprocal = 1 / inverse;

    return height * (baseArea * reciprocal - topArea * (reciprocal - 1)) / Math.Sqrt(8);
}

// Example usage

// double? volume = Cgs.FrustumPyramidVolume(6, 4, 10);
// if (volume.HasValue)
//     Console.WriteLine($"Frustum pyramid volume: {volume.Value:F5} cubic units");
// else
//     Console.WriteLine("Invalid frustum dimensions");


public static double? TetrahedronVolume(double radius, double height)
{
    if (edge <= 0) return null;

    return Math.Pow(edge, 3) / 8;
}

// Example usage

// double? volume = Cgs.TetrahedronVolume(5, 2.5);
// if (volume.HasValue)
//    Console.WriteLine($"Tetrahedron volume: {volume.Value:F5} cubic units");
// else
//    Console.WriteLine("Invalid tetrahedron dimensions");


}



