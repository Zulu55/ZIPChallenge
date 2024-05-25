using Microsoft.Extensions.DependencyInjection;
using ZIPChallenge.Common;
using ZIPChallenge.Models;
using ZIPChallenge.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<ICreditCalculator, CreditCalculator>()
            .BuildServiceProvider();
        var creditCalculatorService = serviceProvider.GetService<ICreditCalculator>();
        var answer = string.Empty;
        var options = new List<string> { "y", "n" };

        do
        {
            // Data input
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WriteLine("*** CREDIT EVALUATOR ***");
            var bureauScore = ConsoleExtension.GetInt("Please enter Bureau Score...........? ");
            var missedPayments = ConsoleExtension.GetInt("Please enter Missed Payments........? ");
            var completedPayments = ConsoleExtension.GetInt("Please enter Completed Payments.....? ");
            var ageInYears = ConsoleExtension.GetInt("Please enter the age in years.......? ");

            // Do process
            var customer = new Customer(bureauScore, missedPayments, completedPayments, ageInYears);
            var availableCredit = creditCalculatorService!.CalculateCredit(customer);

            // Show results
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"Available Credit....................: {availableCredit:C2}");

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;

            do
            {
                answer = ConsoleExtension.GetValidOptions("Do you want to continue [Y]es, [N]o?: ", options);
            } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
        } while (answer!.Equals("y", StringComparison.CurrentCultureIgnoreCase));
    }
}