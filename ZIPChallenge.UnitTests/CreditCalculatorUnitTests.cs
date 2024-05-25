using ZIPChallenge.Models;
using ZIPChallenge.Services;

namespace ZIPChallenge.UnitTests;

[TestClass]
public class CreditCalculatorUSnitTests
{
    private CreditCalculator _creditCalculator = null!;

    [TestInitialize]
    public void Setup()
    {
        _creditCalculator = new CreditCalculator();
    }

    [TestMethod]
    public void CalculateCredit_WithLowBureauScore_ReturnsExpectedCredit()
    {
        var customer = new Customer(450, 0, 0, 30);

        var result = _creditCalculator.CalculateCredit(customer);

        Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void CalculateCredit_WithHighBureauScoreAndPayments_ReturnsExpectedCredit()
    {
        var customer = new Customer(800, 0, 2, 40);

        var result = _creditCalculator.CalculateCredit(customer);

        Assert.AreEqual(500, result);
    }

    [TestMethod]
    public void CalculateCredit_WithMissedPayments_ReturnsZero()
    {
        var customer = new Customer(700, 2, 1, 50);

        var result = _creditCalculator.CalculateCredit(customer);

        Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void CalculateCredit_ExceedsMaxPointsByAge_ReturnsMaxCreditForAge()
    {
        var customer = new Customer(900, 0, 3, 20);

        var result = _creditCalculator.CalculateCredit(customer);

        Assert.AreEqual(300, result);
    }
}