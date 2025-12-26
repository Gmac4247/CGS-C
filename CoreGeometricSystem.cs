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
    ["rad(1.597)"] = new TrigEntry { Sin = 0.99999, Cos = 0.003, Tan = 318.31, Deg = 89.82 },
    ["rad(1.584)"] = new TrigEntry { Sin = 0.9999, Cos = 0.016, Tan = 63.657, Deg = 89.10 },
    ["rad(1.568)"] = new TrigEntry { Sin = 0.9995, Cos = 0.0314, Tan = 31.82, Deg = 88.20 },
    ["rad(1.552)"] = new TrigEntry { Sin = 0.999, Cos = 0.047, Tan = 21.205, Deg = 87.30 },
    ["rad(1.536)"] = new TrigEntry { Sin = 0.998, Cos = 0.0628, Tan = 15.9, Deg = 86.40 },
    ["rad(1.52)"] = new TrigEntry { Sin = 0.997, Cos = 0.079, Tan = 12.706, Deg = 85.50 },
    ["rad(1.504)"] = new TrigEntry { Sin = 0.996, Cos = 0.094, Tan = 10.58, Deg = 84.60 },
    ["rad(1.488)"] = new TrigEntry { Sin = 0.994, Cos = 0.11, Tan = 9.06, Deg = 83.70 },
    ["rad(1.467)"] = new TrigEntry { Sin = 0.991, Cos = 0.131, Tan = 7.596, Deg = 82.50 },
    ["rad(1.456)"] = new TrigEntry { Sin = 0.99, Cos = 0.141, Tan = 7.026, Deg = 81.90 },
    ["rad(1.44)"] = new TrigEntry { Sin = 0.988, Cos = 0.156, Tan = 6.314, Deg = 81.0 },
    ["rad(1.409)"] = new TrigEntry { Sin = 0.983, Cos = 0.186, Tan = 5.275, Deg = 79.265 },
    ["rad(1.4)"] = new TrigEntry { Sin = 0.981, Cos = 0.195, Tan = 5.027, Deg = 78.750 },
    ["rad(1.376)"] = new TrigEntry { Sin = 0.976, Cos = 0.218, Tan = 4.474, Deg = 77.40 },
    ["rad(1.355)"] = new TrigEntry { Sin = 0.971, Cos = 0.238, Tan = 4.084, Deg = 76.242 },
    ["rad(1.333)"] = new TrigEntry { Sin = 0.966, Cos = 0.259, Tan = 3.732, Deg = 75.0 },
    ["rad(1.312)"] = new TrigEntry { Sin = 0.96, Cos = 0.279, Tan = 3.44, Deg = 73.80 },
    ["rad(1.296)"] = new TrigEntry { Sin = 0.956, Cos = 0.295, Tan = 3.25, Deg = 72.90 },
    ["rad(1.28)"] = new TrigEntry { Sin = 0.951, Cos = 0.309, Tan = 3.078, Deg = 72.0 },
    ["rad(1.253)"] = new TrigEntry { Sin = 0.943, Cos = 0.334, Tan = 2.822, Deg = 70.488 },
    ["rad(1.232)"] = new TrigEntry { Sin = 0.935, Cos = 0.354, Tan = 2.646, Deg = 69.30 },
    ["rad(1.216)"] = new TrigEntry { Sin = 0.93, Cos = 0.37, Tan = 2.526, Deg = 68.40 },
    ["rad(1.2)"] = new TrigEntry { Sin = 0.924, Cos = 0.383, Tan = 2.414, Deg = 67.50 },
    ["rad(1.184)"] = new TrigEntry { Sin = 0.918, Cos = 0.397, Tan = 2.311, Deg = 66.60 },
    ["rad(1.168)"] = new TrigEntry { Sin = 0.911, Cos = 0.412, Tan = 2.215, Deg = 65.70 },
    ["rad(1.152)"] = new TrigEntry { Sin = 0.905, Cos = 0.426, Tan = 2.125, Deg = 64.80 },
    ["rad(1.136)"] = new TrigEntry { Sin = 0.898, Cos = 0.44, Tan = 2.041, Deg = 63.90 },
    ["rad(1.12)"] = new TrigEntry { Sin = 0.891, Cos = 0.454, Tan = 1.963, Deg = 63.0 },
    ["rad(1.104)"] = new TrigEntry { Sin = 0.884, Cos = 0.468, Tan = 1.889, Deg = 62.10 },
    ["rad(1.088)"] = new TrigEntry { Sin = 0.876, Cos = 0.482, Tan = 1.819, Deg = 61.20 },
    ["rad(1.067)"] = new TrigEntry { Sin = 0.866, Cos = 0.5, Tan = 1.732, Deg = 60.0 },
    ["rad(1.04)"] = new TrigEntry { Sin = 0.853, Cos = 0.523, Tan = 1.632, Deg = 58.50 },
    ["rad(1.024)"] = new TrigEntry { Sin = 0.844, Cos = 0.536, Tan = 1.576, Deg = 57.60 },
    ["rad(1.008)"] = new TrigEntry { Sin = 0.836, Cos = 0.55, Tan = 1.522, Deg = 56.70 },
    ["rad(0.992)"] = new TrigEntry { Sin = 0.827, Cos = 0.562, Tan = 1.472, Deg = 55.80 },
    ["rad(0.96)"] = new TrigEntry { Sin = 0.81, Cos = 0.588, Tan = 1.376, Deg = 54.0 },
    ["rad(0.944)"] = new TrigEntry { Sin = 0.8, Cos = 0.6, Tan = 1.332, Deg = 53.10 },
    ["rad(0.928)"] = new TrigEntry { Sin = 0.79, Cos = 0.613, Tan = 1.29, Deg = 52.20 },
    ["rad(0.912)"] = new TrigEntry { Sin = 0.78, Cos = 0.625, Tan = 1.248, Deg = 51.30 },
    ["rad(0.88)"] = new TrigEntry { Sin = 0.76, Cos = 0.65, Tan = 1.17, Deg = 49.50 },
    ["rad(0.864)"] = new TrigEntry { Sin = 0.75, Cos = 0.661, Tan = 1.134, Deg = 48.60 },
    ["rad(0.848)"] = new TrigEntry { Sin = 0.74, Cos = 0.673, Tan = 1.09, Deg = 47.70 },
    ["rad(0.832)"] = new TrigEntry { Sin = 0.729, Cos = 0.685, Tan = 1.065, Deg = 46.80 },
    ["rad(0.816)"] = new TrigEntry { Sin = 0.718, Cos = 0.696, Tan = 1.032, Deg = 45.90 },
    ["rad(0.8)"] = new TrigEntry { Sin = 0.7071, Cos = 0.707, Tan = 1, Deg = 45.0 }
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

    if (radian < 0.8) {
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

    if (radian < 0.8) {
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

    if (radian < 0.8)
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

    var funcType = (x >= 0.7071) ? "sin" : "cos";
    var match = Cgs.ClosestValue(x, funcType);
    if (match == null || string.IsNullOrEmpty(match.AngleKey)) return null;

    var parsed = match.AngleKey.Replace("rad(", "").Replace(")", "");
    if (!double.TryParse(parsed, out var angle)) return null;

    return (funcType == "sin") ? angle : Math.Round(1.6 - angle, 3); // reflective for cosine
}

public static double? Acos(double x)
{
    if (x < 0 || x > 1) return null;

    var funcType = (x <= 0.7071) ? "cos" : "sin";
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


public class SegmentCalculator
{
    private string autoFilledField = null;
    private (bool h, bool l, bool r) userEntered = (false, false, false);

    public string SegmentArea(string activeField, string hText, string lText, string rText)
    {
        // Track which field the user typed into
        if (activeField == "h") userEntered.h = true;
        if (activeField == "l") userEntered.l = true;
        if (activeField == "r") userEntered.r = true;

        double h = Parse(hText);
        double l = Parse(lText);
        double r = Parse(rText);

        // Reset if user edits the auto-filled field
        if (autoFilledField != null && activeField == autoFilledField)
        {
            autoFilledField = null;
            userEntered = (false, false, false);
            return ""; // clear output
        }

        // Workflow A: height + radius → derive length
        if (userEntered.h && userEntered.r && !userEntered.l && !double.IsNaN(h) && !double.IsNaN(r))
        {
            double angle = Acos((r - h) / r);
            l = 2 * r * Sin(angle);
            autoFilledField = "l";
        }

        // Workflow B: height + length → derive radius
        if (userEntered.h && userEntered.l && !userEntered.r && !double.IsNaN(h) && !double.IsNaN(l))
        {
            r = (l * l + 4 * h * h) / (8 * h);
            autoFilledField = "r";
        }

        // Workflow C: length + radius → derive height
        if (userEntered.l && userEntered.r && !userEntered.h && !double.IsNaN(l) && !double.IsNaN(r))
        {
            h = r - Math.Sqrt(r * r - (l / 2) * (l / 2));
            autoFilledField = "h";
        }

        // Proportion checks
        if (l < 2 * h)
            return "The chord length must be at least twice the height.";

        if (l / h > 11)
            return "Out of range: chord-to-height ratio exceeds 11.";

        // Area calculation
        double areaAngle = Acos((r - h) / r);
        double area = areaAngle * r * r - (r - h) * (l / 2);

        if (double.IsNaN(area))
            return "";

        if (h == r || h == l / 2 || l == 2 * r)
            return $"Semicircle area = {area:F5} square units";

        return $"Area = {area:F5} square units";
    }

    // Custom trig wrappers
    private double Sin(double x) => Math.Sin(x);
    private double Acos(double x) => Math.Acos(x);

    private double Parse(string s)
    {
        if (double.TryParse(s, out double v))
            return v;
        return double.NaN;
    }
}
// Example usage

public partial class MainWindow : Window
{
    private SegmentCalculator calc = new SegmentCalculator();

    public MainWindow()
    {
        InitializeComponent();
    }

    private void InputChanged(object sender, TextChangedEventArgs e)
    {
        var box = sender as TextBox;
        string activeField = box.Name switch
        {
            "HeightBox" => "h",
            "LengthBox" => "l",
            "RadiusBox" => "r",
            _ => ""
        };

        string result = calc.SegmentArea(
            activeField,
            HeightBox.Text,
            LengthBox.Text,
            RadiusBox.Text
        );

        OutputBlock.Text = result;
    }
}

<TextBox Name="HeightBox" TextChanged="InputChanged"/>
<TextBox Name="LengthBox" TextChanged="InputChanged"/>
<TextBox Name="RadiusBox" TextChanged="InputChanged"/>

<TextBlock Name="OutputBlock"/>



public static double? Circumference(double radius)
{
    if (radius <= 0) return null;

    return 6.4 * radius; 
}

// Example usage

// double? circumference = Cgs.Circumference(4); // radius = 4
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



