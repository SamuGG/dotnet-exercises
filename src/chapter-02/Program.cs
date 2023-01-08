namespace FunctionalProgramming.Exercises.Chapter02;

public sealed class Program
{
    private static void Main(string[] _)
    {
        double height = ReadDouble("Enter height in meters: ");
        double weight = ReadDouble("Enter weight in kilograms: ");
        double relation = CalculateBMI(height, weight);
        Console.WriteLine(ToBmiRange(relation));
    }

    private static double ReadDouble(string message)
    {
        Console.Write(message);
        _ = double.TryParse(Console.ReadLine(), out double value);
        return value;
    }

    public static double CalculateBMI(double height, double weight)
    {
        return Math.Round(weight / Math.Pow(height, 2), 2);
    }

    public static BmiRange ToBmiRange(double relation)
    {
        return relation switch
        {
            < 18.5 => BmiRange.Underweight,
            >= 25 => BmiRange.Overweight,
            _ => BmiRange.Healthy
        };
    }

    public enum BmiRange
    {
        Underweight,
        Healthy,
        Overweight
    }
}