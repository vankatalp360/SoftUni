using System;

class PriceChangeAlert
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        double Threshold = double.Parse(Console.ReadLine());
        double LastPrice = double.Parse(Console.ReadLine());
        for (int i = 0; i < n - 1; i++)
        {
            double CurrentPrice = double.Parse(Console.ReadLine());
            double PriceDifference = CalculateProcentageDifference(LastPrice, CurrentPrice);
            bool IsSignificantDifference = IsItSegnigicantDifference(PriceDifference/100, Threshold);
            string message = Get(CurrentPrice, LastPrice, PriceDifference, IsSignificantDifference);
            Console.WriteLine(message);
            LastPrice = CurrentPrice;
        }
    }
    private static string Get(double CurrentPrice, double LastPrice, double Difference, bool EtherTrueOrFalse)
    {
        string Result = "";
        if (Difference == 0)
        {
            Result = string.Format("NO CHANGE: {0}", CurrentPrice);
        }
        else if (!EtherTrueOrFalse)
        {
            Result = string.Format("MINOR CHANGE: {0} to {1} ({2:F2}%)", LastPrice, CurrentPrice, Difference);
        }
        else if (EtherTrueOrFalse && (Difference > 0))
        {
            Result = string.Format("PRICE UP: {0} to {1} ({2:F2}%)", LastPrice, CurrentPrice, Difference);
        }
        else if (EtherTrueOrFalse && (Difference < 0))
            Result = string.Format("PRICE DOWN: {0} to {1} ({2:F2}%)", LastPrice, CurrentPrice, Difference);
        return Result;
    }
    private static bool IsItSegnigicantDifference(double PriceDifference, double Threshold)
    {
        if (Math.Abs(PriceDifference) >= Threshold)
        {
            return true;
        }
        return false;
    }
    private static double CalculateProcentageDifference(double LastPrice, double CurrentPrice)
    {
        double Result = (CurrentPrice - LastPrice) / LastPrice*100;
        return Result;
    }
}
