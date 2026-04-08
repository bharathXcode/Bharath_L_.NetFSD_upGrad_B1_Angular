using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter Question Number (1-8): ");
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1: Q1_Division.Run(); break;
            case 2: Q2_KMToMeters.Run(); break;
            case 3: Q3_SumAverage.Run(); break;
            case 4: Q4_OddEven.Run(); break;
            case 5: Q5_HighestNumber.Run(); break;
            case 6: Q6_AreaCalculation.Run(); break;
            case 7: Q7_JourneyTime.Run(); break;
            case 8: Q8_VowelOrConsonant.Run(); break;
            default: Console.WriteLine("Invalid choice"); break;
        }
    }
}
