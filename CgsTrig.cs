// CgsTrig.cs - Approximation - based trigonometry lookup engine 
// Classes: CgsTrig

using System;

public static class CgsTrig
{
    private static Dictionary<string, TrigEntry> _table;

    public static void Load(string filePath)CgsTrig.Load("./trig.json");
    {
        var json = File.ReadAllText(filePath);
        _table = JsonSerializer.Deserialize<Dictionary<string, TrigEntry>>(json);
    }


    private static string FindClosest(string func, double value)
    {
        string bestKey = null;
        double minDiff = double.MaxValue;

        foreach (var pair in _table)
        {
            if (!pair.Value.TryGetApprox(func, out string approx)) continue;

            double keyVal = double.Parse(pair.Key.Replace("rad(", "").Replace(")", ""));
            double diff = Math.Abs(keyVal - value);

            if (diff < minDiff)
            {
                minDiff = diff;
                bestKey = pair.Key;
            }
        }

        return bestKey != null && _table[bestKey].TryGetApprox(func, out string result)
            ? $"{func}({bestKey}) ≈ {result}"
            : "Approximately";
    }

    private static bool TryGetApprox(this TrigEntry entry, string func, out string result)
    {
        result = func switch
        {
            "sin" => entry.sin?.approx,
            "cos" => entry.cos?.approx,
            "tan" => entry.tan?.approx,
            "asin" => entry.asin?.approx,
            "acos" => entry.acos?.approx,
            "atan" => entry.atan?.approx,
            _ => null
        };
        return result != null;
    }

private static bool TryEvaluate(string input, out double result)
{
    try
    {
        var data = new DataTable();
        object eval = data.Compute(input.Replace("/", "/"), null);
        result = Convert.ToDouble(eval);
        return true;
    }
    catch
    {
        result = 0;
        return false;
    }
}

   public static string QuerySin(double x)
    {
        string radKey = $"rad({x:0.000})";

        if (_table.TryGetValue(radKey, out var entry) && entry.cos?.approx is string val)
            return $"sin({x}) ≈ {val}";

        if ((x > 0.8 && x < 1.6) || (x > 0 && x < 0.1))
            return $"sin({x}) ≈ {FindClosest("cos", x)}";

        if (x > 0.1 && x < 0.8)
        {
            double reflected = Math.Round(1.6 - x, 3);
            string reflectedKey = $"rad({reflected:0.000})";
            if (_table.TryGetValue(reflectedKey, out var refEntry) && refEntry.cos?.approx is string refVal)
                return $"sin({x}) ≈ cos({reflected}) ≈ {refVal}";

            return $"sin({x}) ≈ cos({reflected}) ≈ {FindClosest("cos", reflected)}";
        }

        return "Invalid input.";
    }

 public static string QueryCos(double x)
    {
        string radKey = $"rad({x:0.000})";

        if (_table.TryGetValue(radKey, out var entry) && entry.cos?.approx is string val)
            return $"cos({x}) ≈ {val}";

        if ((x > 0.8 && x < 1.6) || (x > 0 && x < 0.1))
            return $"cos({x}) ≈ {FindClosest("cos", x)}";

        if (x > 0.1 && x < 0.8)
        {
            double reflected = Math.Round(1.6 - x, 3);
            string reflectedKey = $"rad({reflected:0.000})";
            if (_table.TryGetValue(reflectedKey, out var refEntry) && refEntry.sin?.approx is string refVal)
                return $"cos({x}) ≈ sin({reflected}) ≈ {refVal}";

            return $"cos({x}) ≈ sin({reflected}) ≈ {FindClosest("sin", reflected)}";
        }

        return "Invalid input.";
    }

    public static string QueryTan(double x)
    {
        string radKey = $"rad({x:0.000})";

        if (_table.TryGetValue(radKey, out var entry) && entry.tan?.approx is string val)
            return $"tan({x}) ≈ {val}";

        if ((x > 0.8 && x < 1.6) || (x > 0 && x < 0.1))
            return $"tan({x}) ≈ {FindClosest("tan", x)}";

        if (x > 0.1 && x < 0.8)
        {
            double reflected = Math.Round(1.6 - x, 3);
            string reflectedKey = $"rad({reflected:0.000})";
            if (_table.TryGetValue(reflectedKey, out var refEntry) && refEntry.tan?.approx is string refVal)
                return $"tan({x}) ≈ tan({reflected}) ≈ {refVal}";

            return $"tan({x}) ≈ tan({reflected}) ≈ {FindClosest("tan", reflected)}";
        }

        return "Invalid input.";
    }

  
private static string FindClosestInverseMatch(string funcType, double value)
{
    string bestKey = null;
    double minDiff = double.MaxValue;

    foreach (var kvp in _table)
    {
        var approxStr = funcType switch
        {
            "sin" => kvp.Value.sin?.approx,
            "cos" => kvp.Value.cos?.approx,
            _ => null
        };

        if (double.TryParse(approxStr, out double approx))
        {
            double diff = Math.Abs(approx - value);
            if (diff < minDiff)
            {
                minDiff = diff;
                bestKey = kvp.Key;
            }
        }
    }

    return bestKey;
}

public static string QueryAsin(double x)
{
    // Normalize input to extract numeric or symbolic expression
    var match = Regex.Match(input, @"asin\s*\(?([0-9./\s√-]+)\)?", RegexOptions.IgnoreCase);
    if (!match.Success) return "Invalid input. Format: asin(0.5) or asin(√2÷2)";

    string inputStr = match.Groups[1].Value.Trim();

    // Evaluate symbolic expressions like √2/2 or √3.2
    string transformed = Regex.Replace(inputStr, @"√(\d+(\.\d+)?)", m =>
    {
        var rootVal = double.Parse(m.Groups[1].Value);
        return Math.Sqrt(rootVal).ToString("R");
    });

    if (!TryEvaluate(transformed, out double x) || x <= 0 || x >= 1)
        return "asin is only defined for 0 < x < 1";

    // Case A: High or low input → search sin column
    if (x > 0.707 || x < 0.1)
    {
        var best = FindClosestInverseMatch("sin", x);
        return best != null ? $"asin({inputStr}) ≈ {best}" : "No match found.";
    }

    // Case B: Mid-range → mirror from cos
    var bestCos = FindClosestInverseMatch("cos", x);
    if (bestCos != null)
    {
        var angleNum = double.Parse(Regex.Match(bestCos, @"\(([^)]+)\)").Groups[1].Value);
        var reflected = Math.Round(1.6 - angleNum, 3);
        return $"asin({inputStr}) ≈ rad({reflected})";
    }

    return "No match found.";
}

public static string QueryAcos(double x)
{
    // Match formats like "acos(0.5)" or "acos(1/2)"
    var match = Regex.Match(input, @"acos\s*\(?([0-9./\s√-]+)\)?", RegexOptions.IgnoreCase);
    if (!match.Success) return "Invalid input. Format: acos(0.5) or acos(√2÷2)";

    string inputStr = match.Groups[1].Value.Trim();

    // Evaluate expressions (e.g. √2/2 → 0.707...)
    string transformed = Regex.Replace(inputStr, @"√(\d+(\.\d+)?)", m =>
    {
        var rootVal = double.Parse(m.Groups[1].Value);
        return Math.Sqrt(rootVal).ToString("R");
    });

    if (!TryEvaluate(transformed, out double x) || x <= 0 || x >= 1)
        return "acos is only defined for 0 < x < 1";

    // Case A: High or low → look up directly from cosine
    if (x > 0.707 || x < 0.1)
    {
        var best = FindClosestInverseMatch("cos", x);
        return best != null ? $"acos({inputStr}) ≈ {best}" : "No match found.";
    }

    // Case B: Middle values → reflect sine-based match
    var bestSin = FindClosestInverseMatch("sin", x);
    if (bestSin != null)
    {
        var angleNum = double.Parse(Regex.Match(bestSin, @"rad\\(([^)]+)\\)").Groups[1].Value);
        var reflected = Math.Round(1.6 - angleNum, 3);
        return $"acos({inputStr}) ≈ rad({reflected})";
    }

    return "No match found.";
}

public static string QueryAtan(double x)
{
    // Match formats like "atan(1.2)" or "atan(5/3)"
    var match = Regex.Match(input, @"atan\s*\(?([0-9./\s√-]+)\)?", RegexOptions.IgnoreCase);
    if (!match.Success)
        return "Invalid input. Format: atan(1.25) or atan(√2÷2)";

    string inputStr = match.Groups[1].Value.Trim();

    // Evaluate symbolic expressions like √2/2
    string transformed = Regex.Replace(inputStr, @"√(\d+(\.\d+)?)", m =>
    {
        var rootVal = double.Parse(m.Groups[1].Value);
        return Math.Sqrt(rootVal).ToString("R");
    });

    if (!TryEvaluate(transformed, out double x) || x <= 0)
        return "atan is only defined for positive input values";

    // Step 1: Search tangent column for closest match
    var bestTan = FindClosestInverseMatch("tan", x);
    if (bestTan != null)
        return $"atan({inputStr}) ≈ {bestTan}";

    return "No match found.";
}

}
