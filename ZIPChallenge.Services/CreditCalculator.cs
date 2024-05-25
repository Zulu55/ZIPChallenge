using ZIPChallenge.Models;

namespace ZIPChallenge.Services;

public class CreditCalculator : ICreditCalculator
{
    public decimal CalculateCredit(Customer customer)
    {
        var pointsByBureauScore = GetPointsByBureauScore(customer.BureauScore);
        var pointsByMissedPayments = GetPointsByMissedPayments(customer.MissedPaymentCount);
        var pointsByCompletedPayments = GetPointsByCompletedPayments(customer.CompletedPaymentCount);
        var totalPoints = pointsByBureauScore + pointsByMissedPayments + pointsByCompletedPayments;
        var maxPointsByAge = GetMaxPointsByAge(customer.AgeInYears);
        if (totalPoints > maxPointsByAge) totalPoints = maxPointsByAge;
        return GetAvailbleCredit(totalPoints);
    }

    private decimal GetAvailbleCredit(int totalPoints)
    {
        return totalPoints switch
        {
            <= 0 => 0,
            1 => 100,
            2 => 200,
            3 => 300,
            4 => 400,
            5 => 500,
            _ => 600
        };
    }

    private int GetPointsByCompletedPayments(int completedPaymentCount)
    {
        return completedPaymentCount switch
        {
            0 => 0,
            1 => 2,
            2 => 3,
            _ => 4
        };
    }

    private int GetPointsByMissedPayments(int missedPaymentCount)
    {
        return missedPaymentCount switch
        {
            0 => 0,
            1 => -1,
            2 => -3,
            _ => -6
        };
    }

    private int GetMaxPointsByAge(int ageInYears)
    {
        return ageInYears switch
        {
            <= 18 => 0,
            <= 25 => 3,
            <= 35 => 4,
            <= 50 => 5,
            _ => 6
        };
    }

    private int GetPointsByBureauScore(int bureauScore)
    {
        return bureauScore switch
        {
            <= 500 => 0,
            <= 700 => 1,
            <= 850 => 2,
            _ => 3
        };
    }
}