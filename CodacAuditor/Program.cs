using System;

namespace CodacLogisticsAuditor
{
    class Program
    {
        static void Main(string[] args)
        {
            string driverName = "";

            decimal weeklyBudget = 0;

            double totalDistance = 0;
            Console.Write("Enter Driver's Full Name: ");
            driverName = Console.ReadLine() ?? "Unknown Driver";
            Console.Write("Enter Weekly Fuel Budget: ");
            while (!decimal.TryParse(Console.ReadLine(), out weeklyBudget) || weeklyBudget <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid positive amount.");
                Console.Write("Enter Weekly Fuel Budget: ");
            }

            Console.Write("Enter Total Distance Traveled (1 - 5000 km): ");
            while (!double.TryParse(Console.ReadLine(), out totalDistance)
                   || totalDistance < 1.0
                   || totalDistance > 5000.0)
            {
                Console.WriteLine("Invalid distance! Enter a number between 1 and 5000.");
                Console.Write("Enter Total Distance Traveled: ");
            }
            decimal[] fuelExpenses = new decimal[5];
            decimal totalFuelSpent = 0;
            for (int i = 0; i < fuelExpenses.Length; i++)
            {
                Console.Write($"Enter fuel expense for Day {i + 1}: ");

                while (!decimal.TryParse(Console.ReadLine(), out fuelExpenses[i]) || fuelExpenses[i] < 0)
                {
                    Console.WriteLine("Invalid input. Enter a valid amount.");
                    Console.Write($"Enter fuel expense for Day {i + 1}: ");
                }

                totalFuelSpent += fuelExpenses[i];
            }

            decimal averageFuel = totalFuelSpent / fuelExpenses.Length;
            double efficiency = totalDistance / (double)totalFuelSpent;
            string efficiencyRating;

            if (efficiency > 15)
            {
                efficiencyRating = "High Efficiency";
            }
            else if (efficiency >= 10)
            {
                efficiencyRating = "Standard Efficiency";
            }
            else
            {
                efficiencyRating = "Low Efficiency / Maintenance Required";
            }
            bool isUnderBudget = totalFuelSpent <= weeklyBudget;
            Console.WriteLine("\n-------------------------------------");
            Console.WriteLine("             Codac Report              ");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"Driver Name: {driverName}");
            Console.WriteLine($"Weekly Budget: ₱{weeklyBudget}");
            Console.WriteLine("\nFuel Expenses:");
            for (int i = 0; i < fuelExpenses.Length; i++)
            {
                Console.WriteLine($"Day {i + 1}: ₱{fuelExpenses[i]}");
            }

            Console.WriteLine("\nSummary:");
            Console.WriteLine($"Total Fuel Spent: ₱{totalFuelSpent}");
            Console.WriteLine($"Average Daily Cost: ₱{averageFuel}");
            Console.WriteLine($"Total Distance: {totalDistance} km");
            Console.WriteLine($"Efficiency Rating: {efficiencyRating}");
            Console.WriteLine($"Under Budget: {isUnderBudget}");

            Console.WriteLine("\n======================================");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
