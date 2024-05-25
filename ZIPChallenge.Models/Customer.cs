namespace ZIPChallenge.Models;

public class Customer(int bureauScore, int missedPaymentCount, int completedPaymentCount, int ageInYears)
{
    public int BureauScore { get; } = bureauScore;
    public int MissedPaymentCount { get; } = missedPaymentCount;
    public int CompletedPaymentCount { get; } = completedPaymentCount;
    public int AgeInYears { get; } = ageInYears;
}