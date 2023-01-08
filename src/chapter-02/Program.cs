namespace FunctionalProgramming.Exercises.Chapter02;

public sealed class Program
{
    private static void Main(string[] _)
    {
        Run(InputDouble, InputDouble, OutputBmiRange);
    }

    public static void Run(Func<string, double> readHeight, Func<string, double> readWeight, Action<BmiRange> writeOutput)
    {
        ArgumentNullException.ThrowIfNull(readHeight);
        ArgumentNullException.ThrowIfNull(readWeight);
        ArgumentNullException.ThrowIfNull(writeOutput);

        double height = readHeight("Enter height in meters: ");
        double weight = readWeight("Enter weight in kilograms: ");

        double bmi = CalculateBMI(height, weight);
        BmiRange bmiRange = ToBmiRange(bmi);

        writeOutput(bmiRange);
    }

    public static double InputDouble(string message)
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

    public static void OutputBmiRange(BmiRange bmiRange)
    {
        Console.WriteLine(bmiRange);
    }

    public enum BmiRange
    {
        Underweight,
        Healthy,
        Overweight
    }
}